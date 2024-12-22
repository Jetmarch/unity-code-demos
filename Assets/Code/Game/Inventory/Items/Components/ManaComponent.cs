using System;

namespace Game
{
    [Serializable]
    public sealed class ManaComponent : IItemComponent
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