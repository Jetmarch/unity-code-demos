using System;
using UnityEngine;

namespace Game.Meta.Upgrades
{
    [CreateAssetMenu(fileName = "LoadZoneCapacityUpgrade", menuName = "Configs/Meta/LoadZoneCapacityUpgrade")]
    public sealed class LoadZoneCapacityUpgradeConfig : UpgradeConfig
    {
        public TableValue CapacityTableValue => _capacityTableValue; 
        [SerializeField] private TableValue _capacityTableValue;
        public override Upgrade CreateUpgrade()
        {
            return new LoadZoneCapacityUpgrade(this);
        }

        private void OnValidate()
        {
            Validate();
            _capacityTableValue.FillLevelPrices(MaxLevel);
        }
    }
}