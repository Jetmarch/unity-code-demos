using System.Threading;
using Game.Gameplay.Money;
using Game.Meta.Upgrades;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Gameplay.Conveyor
{
    public class SceneInstaller : LifetimeScope
    {
        [SerializeField] private ConveyorAttributes _attributes;
        
        [SerializeField] private ConveyorRecipeConfig _recipeConfig;
        [SerializeField] private UpgradeConfig[] _upgradeConfigs;
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureConveyor(builder);
            ConfigureUpgrades(builder);
            ConfigureMoney(builder);
        }
        
        private void ConfigureConveyor(IContainerBuilder builder)
        {
            builder.RegisterInstance(_attributes);
            var inputZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Load);
            var outputZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Unload);
            var workZone = new ConveyorWorkZone(_attributes, _recipeConfig.Clone());
            var conveyorZones = new ConveyorZones(inputZone, outputZone, workZone);
            
            builder.Register<Conveyor>(Lifetime.Scoped)
                .WithParameter(conveyorZones)
                .WithParameter(new CancellationTokenSource());
        }
        
        private void ConfigureUpgrades(IContainerBuilder builder)
        {
            builder.Register<UpgradeManager>(Lifetime.Scoped);
            builder.Register<UpgradeConfigBundle>(Lifetime.Scoped);

            foreach (var upgradeConfig in _upgradeConfigs)
            {
                builder.RegisterInstance(upgradeConfig).As<UpgradeConfig>();
            }
        }
        
        private void ConfigureMoney(IContainerBuilder builder)
        {
            builder.Register<MoneyStorage>(Lifetime.Scoped);
        }
    }
    
}