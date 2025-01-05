using System.Collections.Generic;

namespace Game.Meta.Upgrades.Presenters
{
    public sealed class UpgradeListPresenter : IUpgradeListPresenter
    {
        private readonly Upgrade[] _upgrades;

        public UpgradeListPresenter(UpgradeConfigBundle upgradeConfigs)
        {
            _upgrades = upgradeConfigs.GetUpgrades();
        }
        
        public List<IUpgradePresenter> GetUpgradePresenters()
        {
            var upgradePresenters = new List<IUpgradePresenter>();
            foreach (var upgrade in _upgrades)
            {
                upgradePresenters.Add(new UpgradePresenter(upgrade));
            }
            
            return upgradePresenters;
        }
    }

    public sealed class UpgradePresenter : IUpgradePresenter
    {
        public string Name => $"{_upgrade.Id}";
        public string Value => $"Value: TODO";
        public string Level => $"Level: {_upgrade.CurrentLevel}/{_upgrade.MaxLevel}";
        public string Cost => _upgrade.CurrentPrice.ToString();
        
        private readonly Upgrade _upgrade;

        public UpgradePresenter(Upgrade upgrade)
        {
            _upgrade = upgrade;
        }
    }

    public interface IUpgradeListPresenter
    {
        List<IUpgradePresenter> GetUpgradePresenters();
    }

    public interface IUpgradePresenter
    {
        string Name { get; }
        string Value { get; }
        string Level { get; }
        string Cost { get; }
    }
}