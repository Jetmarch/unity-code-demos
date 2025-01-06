using Game.Gameplay.Money;

namespace Game.Meta.Upgrades.Presenters
{
    public sealed class UpgradePresenter : IUpgradePresenter
    {
        public string Name => $"{_upgrade.DisplayName}";
        public string Value => $"Value: {_upgrade.GetUpgradeCurrentValue()} <color=green>(+{_upgrade.GetUpgradeValueIncrement()})</color>";
        public string Level => $"Level: {_upgrade.CurrentLevel}/{_upgrade.MaxLevel}";
        
        private readonly Upgrade _upgrade;
        private readonly MoneyStorage _moneyStorage;
        private readonly UpgradeManager _upgradeManager;
        public UpgradePresenter(Upgrade upgrade, MoneyStorage moneyStorage, UpgradeManager upgradeManager)
        {
            _upgrade = upgrade;
            _moneyStorage = moneyStorage;
            _upgradeManager = upgradeManager;
        }

        public IUpgradeButtonPresenter GetUpgradeButtonPresenter()
        {
            return new UpgradeButtonPresenter(_upgrade, _moneyStorage, _upgradeManager);
        }
    }
}