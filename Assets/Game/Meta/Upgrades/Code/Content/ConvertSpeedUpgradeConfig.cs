using UnityEngine;

namespace Game.Meta.Upgrades
{
    [CreateAssetMenu(fileName = "ConvertSpeedUpgrade", menuName = "Configs/Meta/ConvertSpeedUpgrade")]
    public sealed class ConvertSpeedUpgradeConfig : UpgradeConfig
    {
        public TableValue SpeedTableValue => _speedTableValue;
        [SerializeField] private TableValue _speedTableValue;
        
        public override Upgrade CreateUpgrade()
        {
            return new ConvertSpeedUpgrade(this);
        }

        private void OnValidate()
        {
            Validate();
            _speedTableValue.FillLevelPrices(MaxLevel);
        }
    }
}