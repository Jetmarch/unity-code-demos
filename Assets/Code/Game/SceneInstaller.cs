using System.Collections.Generic;
using System.ComponentModel;
using DG.Tweening;
using Game.Controllers;
using Game.UI;
using UnityEngine;
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
        
        [SerializeField] private TextPopupView _textPopupView;
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureHero(builder);
            ConfigureEquipmentObservers(builder);
            ConfigureControllers(builder);
            ConfigureUI(builder);

            DOTween.Init();
        }

        private void ConfigureHero(IContainerBuilder builder)
        {
            builder.RegisterInstance(_attributeRepository).AsImplementedInterfaces();
            builder.RegisterInstance(_equipment);
            
            ConfigureInventory(builder);
        }
        
        private void ConfigureInventory(IContainerBuilder builder)
        {
            foreach (var itemConfig in _inventoryItemConfigs)
            {
                _inventory.AddItem(itemConfig.Clone());
            }
            
            builder.RegisterInstance(_inventory);
        }

        private void ConfigureEquipmentObservers(IContainerBuilder builder)
        {
            builder.Register<EquipmentObserverManager>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<SwordEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<HelmEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<ArmorEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<ShieldEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void ConfigureControllers(IContainerBuilder builder)
        {
            builder.Register<EquipmentController>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void ConfigureUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_textPopupView);
        }
    }
}
