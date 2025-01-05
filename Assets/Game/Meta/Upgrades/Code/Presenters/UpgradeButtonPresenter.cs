using System;
using Game.Gameplay.Money;

namespace Game.Meta.Upgrades.Presenters
{
    public sealed class UpgradeButtonPresenter : IUpgradeButtonPresenter
    {
        public string Price => _upgrade.CurrentPrice.ToString();
        public bool CanLevelUp => _upgrade.CanLevelUp;
        public bool CanBuy => _moneyStorage.Amount >= _upgrade.CurrentPrice;
        public event Action OnMoneyChanged;
        
        private readonly Upgrade _upgrade;
        private readonly MoneyStorage _moneyStorage;
        private readonly UpgradeManager _upgradeManager;
        
        public UpgradeButtonPresenter(Upgrade upgrade, MoneyStorage moneyStorage, UpgradeManager upgradeManager)
        {
            _upgrade = upgrade;
            _moneyStorage = moneyStorage;
            _upgradeManager = upgradeManager;
            _moneyStorage.OnAmountChanged += NotifyMoneyChanged;
        }
        
        public void LevelUp()
        {
            _upgradeManager.LevelUp(_upgrade.Id);
        }

        private void NotifyMoneyChanged()
        {
            OnMoneyChanged?.Invoke();
        }
    }
}