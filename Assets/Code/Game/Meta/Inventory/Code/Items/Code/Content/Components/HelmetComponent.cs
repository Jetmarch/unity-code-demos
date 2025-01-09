using System;

namespace Game
{
    [Serializable]
    public sealed  class HelmetComponent : IItemComponent
    {
        public int Health;
	
        public IItemComponent Clone()
        {
            return new HelmetComponent()
            {
                Health = Health
            };
        }
    }
}