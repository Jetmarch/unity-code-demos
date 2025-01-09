using System;

namespace Game
{
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