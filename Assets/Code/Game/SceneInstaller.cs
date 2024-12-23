using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public sealed class SceneInstaller : LifetimeScope
    {
        [SerializeField] private AttributeRepository _attributeRepository;
        
        [SerializeField] private Equipment _equipment;
        
        [SerializeField] private Inventory _inventory;
        
        [SerializeField] private List<InventoryItemConfig> _inventoryItemConfigs;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_attributeRepository).AsImplementedInterfaces();
            builder.RegisterInstance(_equipment);
            
            ConfigureInventory(builder);
            ConfigureEquipmentObservers(builder);
        }

        private void ConfigureEquipmentObservers(IContainerBuilder builder)
        {
            builder.Register<EquipmentObserverManager>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<SwordEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<HelmEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<ArmorEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void ConfigureInventory(IContainerBuilder builder)
        {
            foreach (var itemConfig in _inventoryItemConfigs)
            {
                _inventory.AddItem(itemConfig.Clone());
            }
            
            builder.RegisterInstance(_inventory);
        }
    }
}
