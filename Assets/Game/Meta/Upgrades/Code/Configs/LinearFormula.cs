using System;

namespace Game.Meta.Upgrades
{
    [Serializable]
    public sealed class LinearFormula : TableFormula
    {
        public override int CalculateValue(int baseValue, int level)
        {
            return baseValue * level;
        }
    }
}