using System;
using Game.Gameplay.Conveyor;
using VContainer;

namespace Game.Meta.Upgrades
{
    [Serializable]
    public sealed class LoadZoneCapacityUpgrade : Upgrade
    {
        private readonly LoadZoneCapacityUpgradeConfig _config;
        private Conveyor _conveyor;
        public LoadZoneCapacityUpgrade(LoadZoneCapacityUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        [Inject]
        private void Configure(Conveyor conveyor)
        {
            _conveyor = conveyor;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            var newCapacity = _config.CapacityTableValue.GetValue(CurrentLevel);
            _conveyor.Attributes.MaxLoadZoneCapacity = newCapacity;
        }
        
        public override int GetUpgradeCurrentValue()
        {
            return _conveyor.Attributes.MaxLoadZoneCapacity;
        }

        public override int GetUpgradeValueIncrement()
        {
            if (!CanLevelUp)
            {
                return 0;
            }
            
            var valueIncrement = _config.CapacityTableValue.GetValue(_currentLevel + 1) - _config.CapacityTableValue.GetValue(_currentLevel);
            return valueIncrement;
        }
    }
}