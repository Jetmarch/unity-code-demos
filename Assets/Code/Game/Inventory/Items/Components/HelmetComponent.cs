using System;

namespace Game
{
    [Serializable]
    public sealed  class HelmetComponent : EquipmentComponent
    {
        public int Health;
	
        public IItemComponent Clone()
        {
            return new HelmetComponent()
            {
                Health = Health,
                EquipmentType = EquipmentType
            };
        }
    }
}