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
        
        [SerializeField] private Inventory _inventory;
        
        [SerializeField] private InventoryItemConfigBundle _inventoryItemConfigBundle;
        
        [SerializeField] private TextPopupView _textPopupView;
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureInventory(builder);
            ConfigureEquipment(builder);
            ConfigureEquipmentObservers(builder);
            ConfigureUI(builder);
            ConfigureDebug(builder);

            DOTween.Init();
        }

        private void ConfigureEquipment(IContainerBuilder builder)
        {
            builder.Register<Equipment>(Lifetime.Scoped);
            builder.Register<EquipmentController>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void ConfigureDebug(IContainerBuilder builder)
        {
            builder.RegisterInstance(_attributeRepository).AsImplementedInterfaces();
        }
        
        private void ConfigureInventory(IContainerBuilder builder)
        {
            foreach (var itemConfig in _inventoryItemConfigBundle.GetItemConfigs())
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

        private void ConfigureUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_textPopupView);
        }
    }
}
