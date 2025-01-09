using System;

namespace Game
{
    [Serializable]
    public class SwordComponent : IItemComponent
    {
        public int Damage;

        public IItemComponent Clone()
        {
            return new SwordComponent
            {
                Damage = Damage
            };
        }
    }
}