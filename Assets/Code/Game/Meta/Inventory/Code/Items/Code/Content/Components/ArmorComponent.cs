using System;

namespace Game
{
    [Serializable]
    public class ArmorComponent : IItemComponent
    {
        public int Armor;

        public IItemComponent Clone()
        {
            return new ArmorComponent
            {
                Armor = Armor
            };
        }
    }
}