using System.Threading;
using DG.Tweening;
using Game.Gameplay.Money;
using Game.Gameplay.Money.Controllers;
using Game.Gameplay.Money.UI;
using Game.Meta.Upgrades;
using Game.Meta.Upgrades.Presenters;
using Game.Meta.Upgrades.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Gameplay.Conveyor
{
    public class SceneInstaller : LifetimeScope
    {
        [Header("Conveyor")]
        [SerializeField] private ConveyorAttributes _attributes;
        [SerializeField] private ConveyorRecipeConfig _recipeConfig;
        
        [Header("Upgrades")]
        [SerializeField] private UpgradeConfig[] _upgradeConfigs;
        [SerializeField] private UpgradePanelList _upgradePanelList;
        [SerializeField] private Transform _panelContainer;
        [SerializeField] private UpgradePanel _panelPrefab;
        
        [Header("Money")]
        [SerializeField] private MoneyPanel _moneyPanel;
        [SerializeField] private MoneyDebugPanel _moneyDebugPanel;
        [SerializeField] private int _moneyAmountForTesting = 100;
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureConveyor(builder);
            ConfigureUpgrades(builder);
            ConfigureMoney(builder);
            
            DOTween.Init();
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

            builder.Register<ConveyorPresenter>(Lifetime.Scoped).AsImplementedInterfaces();
        }
        
        private void ConfigureUpgrades(IContainerBuilder builder)
        {
            builder.Register<UpgradeManager>(Lifetime.Scoped);
            builder.Register<UpgradeConfigBundle>(Lifetime.Scoped);

            foreach (var upgradeConfig in _upgradeConfigs)
            {
                builder.RegisterInstance(upgradeConfig).As<UpgradeConfig>();
            }
            
            ConfigureUpgradesUI(builder);
        }

        private void ConfigureUpgradesUI(IContainerBuilder builder)
        {
            builder.Register<UpgradeListPresenter>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.RegisterInstance(_upgradePanelList);

            builder.Register<UpgradePanelFactory>(Lifetime.Scoped)
                .WithParameter(_panelContainer)
                .WithParameter(_panelPrefab);
        }

        private void ConfigureMoney(IContainerBuilder builder)
        {
            builder.Register<MoneyStorage>(Lifetime.Scoped);
            builder.Register<MoneyController>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.RegisterInstance(_moneyPanel);
            
            builder.Register<MoneyDebugController>(Lifetime.Scoped).AsImplementedInterfaces()
                .WithParameter(_moneyAmountForTesting);
            builder.RegisterInstance(_moneyDebugPanel);
        }
    }
    
}