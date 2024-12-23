using UnityEngine;

namespace Game
{
    public static class EquipmentUseCases
    {
        public static void AddEquipment(EquipmentType equipmentType, InventoryItem prototypeEquipment, Inventory inventory, Equipment equipment)
        {
            var equipmentItem = inventory.FindItem(prototypeEquipment);
            if (equipmentItem == null)
            {
                Debug.LogWarning($"Item {prototypeEquipment.Name} doesn't exist in inventory");
                return;
            }
            if (equipmentItem.TryGetComponent<EquipmentComponent>(out var equipmentComponent) && equipmentComponent.EquipmentType == equipmentType)
            {
                var oldEquipment = equipment.Get(equipmentType);
                if (oldEquipment != null)
                {
                    equipment.RemoveItem(equipmentType, inventory);
                }

                equipment.Add(equipmentType, equipmentItem);
                equipment.NotifyItemAdded(equipmentItem);
                inventory.RemoveItem(equipmentItem);
                
                Debug.Log($"Added {equipmentItem.Name} to {equipmentType} slot");
            }
            else
            {
                Debug.LogWarning($"Unable to equip item {prototypeEquipment.Name} in {equipmentType} slot");
            }
        }

        public static void RemoveEquipment(EquipmentType equipmentType, Inventory inventory, Equipment equipment)
        {
            var equipmentItem = equipment.Get(equipmentType);
            if (equipmentItem == null)
            {
                Debug.Log($"{equipmentType} is empty");
                return;
            }
            
            inventory.AddItem(equipmentItem);
            equipment.Remove(equipmentType);
            equipment.NotifyItemRemoved(equipmentItem);
            
            Debug.Log($"Item {equipmentItem.Name} was removed from equipment");
        }
    }
}