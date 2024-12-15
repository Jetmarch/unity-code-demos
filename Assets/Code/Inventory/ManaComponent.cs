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
    
    [Serializable]
    public class EquipmentComponent : IItemComponent
    {
        public EquipmentType EquipmentType;
        public IItemComponent Clone()
        {
            return new EquipmentComponent()
            {
                EquipmentType = EquipmentType
            };
        }
    }
}