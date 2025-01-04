using System;

namespace Game.Meta.Upgrades
{
    [Serializable]
    public abstract class Upgrade
    {
        public string Name => Config.Name;
        public int MaxLevel => Config.MaxLevel;
        public int CurrentLevel => _currentLevel;
        
        protected int _currentLevel = 1;
        
        protected UpgradeConfig Config;
        protected Upgrade(UpgradeConfig config)
        {
            Config = config;
        }
        
        public abstract void LevelUp();
    }
}