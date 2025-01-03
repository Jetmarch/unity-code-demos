using System;
using UnityEngine;

namespace Game.Meta.Upgrades
{
    [Serializable]
    public abstract class Upgrade
    {
        public string Name => _config.Name;
        public int MaxLevel => _config.MaxLevel;
        public int CurrentLevel => _currentLevel;
        
        private int _currentLevel = 1;
        
        private UpgradeConfig _config;

        protected Upgrade(UpgradeConfig config)
        {
            _config = config;
        }
    }

    
    public abstract class UpgradeConfig : ScriptableObject
    {
        public string Name => _name;
        public int MaxLevel => _maxLevel;
        public UpgradePriceTable PriceTable => _priceTable;
        
        [SerializeField] private string _name;
        [SerializeField] private int _maxLevel;
        [SerializeField] private UpgradePriceTable _priceTable;
        
        private Upgrade _prototype;
        public abstract Upgrade CreateUpgrade();

        private void OnValidate()
        {
            _priceTable.FillLevelPrices(_maxLevel);
        }
    }

    [Serializable]
    public abstract class UpgradePriceTable
    {
        [SerializeField] private int[] _prices;
        public void FillLevelPrices(int maxLevel)
        {
            for (int i = 0; i < maxLevel; i++)
            {
                _prices[i] = CalculateCost(i);
            }
        }

        //TODO
        public abstract int CalculateCost(int level);
    }
}