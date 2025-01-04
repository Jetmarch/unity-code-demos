using Game.Gameplay.Conveyor;

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

        public override void LevelUp()
        {
            _currentLevel++;
            var newSpeedValue = _config.SpeedTableValue.GetValue(_currentLevel);
            //Conveyor set new speed value
            //_conveyor.Attributes.SetSpeed(newSpeedValue);
        }
    }
}