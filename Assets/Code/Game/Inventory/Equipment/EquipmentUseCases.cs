using UnityEngine;

namespace Game
{
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
                    equipment.RemoveItem(equipmentType, inventory);
                }

                equipment.Add(equipmentType, equipmentItem);
                equipment.NotifyItemAdded(equipmentItem);
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
            equipment.Remove(equipmentType);
            equipment.NotifyItemRemoved(equipmentItem);
        }
    }
}