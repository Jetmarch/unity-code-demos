using System;
using UnityEngine;

namespace Game.Meta.Upgrades
{
    [CreateAssetMenu(fileName = "UnloadZoneCapacityUpgrade", menuName = "Configs/Meta/UnloadZoneCapacityUpgrade")]
    public sealed class UnloadZoneCapacityUpgradeConfig : UpgradeConfig
    {
        public TableValue CapacityTableValue => _capacityTableValue; 
        [SerializeField] private TableValue _capacityTableValue;
        public override Upgrade CreateUpgrade()
        {
            return new UnloadZoneCapacityUpgrade(this);
        }

        private void OnValidate()
        {
            Validate();
            _capacityTableValue.FillLevelPrices(MaxLevel);
        }
    }
}