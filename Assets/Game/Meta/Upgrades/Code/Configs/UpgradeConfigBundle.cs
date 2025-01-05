using System;
using System.Collections.Generic;
using System.Linq;
using VContainer;

namespace Game.Meta.Upgrades
{
    [Serializable]
    public sealed class UpgradeConfigBundle
    {
        private readonly List<UpgradeConfig> _upgradeConfigs;
        private readonly IObjectResolver _objectResolver;


        public UpgradeConfigBundle(IEnumerable<UpgradeConfig> upgradeConfigs, IObjectResolver objectResolver)
        {
            _upgradeConfigs = upgradeConfigs.ToList();
            _objectResolver = objectResolver;
        }

        public Upgrade[] GetUpgrades()
        {
            var upgrades = new Upgrade[_upgradeConfigs.Count];

            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i] = _upgradeConfigs[i].CreateUpgrade();
                _objectResolver.Inject(upgrades[i]);
            }
            
            return upgrades;
        }
    }
}