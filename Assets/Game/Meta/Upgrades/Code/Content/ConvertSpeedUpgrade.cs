using Game.Gameplay.Conveyor;
using UnityEngine;
using VContainer;

namespace Game.Meta.Upgrades
{
    public sealed class ConvertSpeedUpgrade : Upgrade
    {
        private readonly ConvertSpeedUpgradeConfig _config;
        private Conveyor _conveyor;
        public ConvertSpeedUpgrade(ConvertSpeedUpgradeConfig config) : base(config)
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
            var newSpeedValue = _config.SpeedTableValue.GetValue(_currentLevel);
            _conveyor.Attributes.BaseWorkTime = newSpeedValue;
        }
    }
}