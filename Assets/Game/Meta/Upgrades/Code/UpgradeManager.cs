using System;
using System.Collections.Generic;
using Game.Gameplay.Money;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta.Upgrades
{
    [Serializable]
    public sealed class UpgradeManager
    {
        [ShowInInspector] private readonly MoneyStorage _moneyStorage;
        [ShowInInspector] private readonly Dictionary<string, Upgrade> _upgrades;

        public UpgradeManager(UpgradeConfigBundle configBundle, MoneyStorage moneyStorage)
        {
            _upgrades = new Dictionary<string, Upgrade>();
            _moneyStorage = moneyStorage;
            
            foreach (var upgrade in configBundle.GetUpgrades())
            {
                _upgrades.Add(upgrade.Id, upgrade);
            }
        }
        
        public void LevelUp(string id)
        {
            if (!_upgrades.TryGetValue(id, out var upgrade))
            {
                Debug.LogWarning($"No upgrade found for {id}");
                return;
            }

            if (!upgrade.CanLevelUp)
            {
                Debug.LogWarning($"Cannot level up {id}");
                return;
            }

            if (upgrade.CurrentPrice > _moneyStorage.Amount)
            {
                Debug.LogWarning($"Not enough money to level up {id}");
                return;
            }
            
            _moneyStorage.Get(upgrade.CurrentPrice);
            
            upgrade.LevelUp();
        }
    }
}