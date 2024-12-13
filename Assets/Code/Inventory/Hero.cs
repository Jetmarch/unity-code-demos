using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Hero
    {
        public int Damage { get; set; }
        public int Mana { get; set; }

        [SerializeField] private readonly Dictionary<EquipmentType, InventoryItem> _equipment = new();
        
        public void AddEquipment(EquipmentType equipmentType, InventoryItem equipmentItem)
        {
            _equipment.Add(equipmentType, equipmentItem);
        }

        public void RemoveEquipment(EquipmentType equipmentType)
        {
            _equipment.Remove(equipmentType);
        }

        public InventoryItem GetEquipment(EquipmentType equipmentType)
        {
            if (_equipment.TryGetValue(equipmentType, out InventoryItem equipmentItem))
            {
                return equipmentItem;
            }
            
            return default;
        }
    }
}