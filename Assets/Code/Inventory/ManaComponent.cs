using System;

namespace Game
{
    [Serializable]
    public class ManaComponent : IItemComponent
    {
        public int Mana;
	
        public IItemComponent Clone()
        {
            return new ManaComponent()
            {
                Mana = Mana
            };
        }
    }
}