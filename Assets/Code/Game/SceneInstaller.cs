using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public sealed class SceneInstaller : LifetimeScope
    {
        [SerializeField] private Hero _hero;
        
        [SerializeField] private Equipment _equipment;
        
        [SerializeField] private Inventory _inventory;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_hero).AsImplementedInterfaces();
            builder.RegisterInstance(_equipment);
            builder.RegisterInstance(_inventory);
            
            ConfigureEquipmentObservers(builder);
        }

        private void ConfigureEquipmentObservers(IContainerBuilder builder)
        {
            builder.Register<EquipmentObserverManager>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<SwordEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<HelmEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<ArmorEquipmentObserver>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
