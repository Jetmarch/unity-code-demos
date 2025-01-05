using System;

namespace Game.Meta.Upgrades
{
    [Serializable]
    public abstract class Upgrade
    {
        public string Id => Config.Id;
        public int MaxLevel => Config.MaxLevel;
        public int CurrentLevel => _currentLevel;
        public int CurrentPrice => Config.PriceTableValue.GetValue(_currentLevel);
        
        protected int _currentLevel = 1;
        
        protected UpgradeConfig Config;
        protected Upgrade(UpgradeConfig config)
        {
            Config = config;
        }

        public virtual void LevelUp()
        {
            _currentLevel++;
        }
        public bool CanLevelUp => _currentLevel < MaxLevel;
    }
}