using System.Collections.Generic;
using Game.Gameplay.Money;

namespace Game.Meta.Upgrades.Presenters
{
    public sealed class UpgradeListPresenter : IUpgradeListPresenter
    {
        private readonly Upgrade[] _upgrades;
        private readonly MoneyStorage _moneyStorage;
        private readonly UpgradeManager _upgradeManager;

        public UpgradeListPresenter(MoneyStorage moneyStorage, UpgradeManager upgradeManager)
        {
            _upgrades = upgradeManager.GetUpgrades();
            _moneyStorage = moneyStorage;
            _upgradeManager = upgradeManager;
        }
        
        public List<IUpgradePresenter> GetUpgradePresenters()
        {
            var upgradePresenters = new List<IUpgradePresenter>();
            foreach (var upgrade in _upgrades)
            {
                upgradePresenters.Add(new UpgradePresenter(upgrade, _moneyStorage, _upgradeManager));
            }
            
            return upgradePresenters;
        }
    }
}