using System;

namespace Game
{
    [Serializable]
    public class ArmorComponent : EquipmentComponent
    {
        public int Armor;

        public IItemComponent Clone()
        {
            return new ArmorComponent
            {
                Armor = Armor,
                EquipmentType = EquipmentType
            };
        }
    }
}