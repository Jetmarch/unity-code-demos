using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class Equipment 
    {
        [SerializeField] private readonly Dictionary<EquipmentType, InventoryItem> _equipment = new();
        
        public void Add(EquipmentType equipmentType, InventoryItem equipmentItem)
        {
            if (_equipment.ContainsKey(equipmentType))
            {
                Remove(equipmentType);
            }
            
            _equipment.Add(equipmentType, equipmentItem);
        }

        public void Remove(EquipmentType equipmentType)
        {
            _equipment.Remove(equipmentType);
        }

        public InventoryItem Get(EquipmentType equipmentType)
        {
            if (_equipment.TryGetValue(equipmentType, out InventoryItem equipmentItem))
            {
                return equipmentItem;
            }
            
            return default;
        }
    }

    public static class EquipmentUseCases
    {
        public static void AddEquipment(EquipmentType equipmentType, InventoryItem prototypeEquipment, Inventory inventory, Equipment equipment)
        {
            var item = inventory.FindItem(prototypeEquipment);
            if (item == null) return;
            if (item.TryGetComponent<EquipmentComponent>(out var equipmentComponent) && equipmentComponent.EquipmentType == equipmentType)
            {
                var oldEquipment = equipment.Get(equipmentType);
                equipment.Add(equipmentType, item);
                inventory.RemoveItem(item);
                if (oldEquipment == null) return;
                inventory.AddItem(oldEquipment);
            }
            else
            {
                Debug.LogError($"{equipmentType} is not a equipment type");
            }
        }
    }
}
