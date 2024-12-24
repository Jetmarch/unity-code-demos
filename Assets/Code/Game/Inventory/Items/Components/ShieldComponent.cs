using System;

namespace Game
{
    [Serializable]
    public class ShieldComponent : IItemComponent
    {
        public int Armor;
        public int Health;

        public IItemComponent Clone()
        {
            return new ShieldComponent
            {
                Armor = Armor,
                Health = Health
            };
        }
    }
}