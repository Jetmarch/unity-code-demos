using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class Equipment 
    {
        [SerializeField] private readonly Dictionary<EquipmentType, InventoryItem> _equipment = new();
        
        public void AddItem(EquipmentType equipmentType, InventoryItem prototypeItem, Inventory inventory)
        {
            EquipmentUseCases.AddEquipment(equipmentType, prototypeItem, inventory, this);
        }

        public void Add(EquipmentType equipmentType, InventoryItem prototypeItem)
        {
            _equipment.Add(equipmentType, prototypeItem);
        }

        public void Remove(EquipmentType equipmentType, Inventory inventory)
        {
            EquipmentUseCases.RemoveEquipment(equipmentType, inventory, this);
        }

        public void RemoveItem(EquipmentType equipmentType)
        {
            _equipment.Remove(equipmentType);
        }

        public InventoryItem Get(EquipmentType equipmentType)
        {
            return _equipment.GetValueOrDefault(equipmentType);
        }
    }

    public static class EquipmentUseCases
    {
        public static void AddEquipment(EquipmentType equipmentType, InventoryItem prototypeEquipment, Inventory inventory, Equipment equipment)
        {
            var equipmentItem = inventory.FindItem(prototypeEquipment);
            if (equipmentItem == null) return;
            if (equipmentItem.TryGetComponent<EquipmentComponent>(out var equipmentComponent) && equipmentComponent.EquipmentType == equipmentType)
            {
                var oldEquipment = equipment.Get(equipmentType);
                if (oldEquipment != null)
                {
                    equipment.Remove(equipmentType, inventory);
                }

                equipment.Add(equipmentType, equipmentItem);
                inventory.RemoveItem(equipmentItem);
            }
            else
            {
                Debug.LogError($"{prototypeEquipment.Name} is not a equipment");
            }
        }

        public static void RemoveEquipment(EquipmentType equipmentType, Inventory inventory, Equipment equipment)
        {
            var equipmentItem = equipment.Get(equipmentType);
            if (equipmentItem == null) return;
            
            inventory.AddItem(equipmentItem);
            equipment.RemoveItem(equipmentType);
        }
    }
}
