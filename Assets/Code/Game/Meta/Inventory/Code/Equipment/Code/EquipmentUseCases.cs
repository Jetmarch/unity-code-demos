using UnityEngine;

namespace Game
{
    public static class EquipmentUseCases
    {
        public static void EquipItem(EquipmentType equipmentType, InventoryItem prototypeEquipment, Inventory inventory, Equipment equipment)
        {
            if (prototypeEquipment == null)
            {
                return;
            }
            var equipmentItem = inventory.FindItem(prototypeEquipment);
            if (equipmentItem == null)
            {
                equipment.NotifyItemNotExistInInventory(prototypeEquipment);
                return;
            }
            if (equipmentItem.TryGetComponent<EquipmentComponent>(out var equipmentComponent) && equipmentComponent.EquipmentType == equipmentType)
            {
                var oldEquipment = equipment.Get(equipmentType);
                if (oldEquipment != null)
                {
                    equipment.UnequipItem(equipmentType);
                }

                equipment.Equip(equipmentType, equipmentItem);
                inventory.RemoveItem(equipmentItem);
                equipment.NotifyItemAdded(equipmentItem);
            }
            else
            {
                equipment.NotifyUnableToEquipItem(prototypeEquipment, equipmentType);
            }
        }

        public static void RemoveEquipment(EquipmentType equipmentType, Inventory inventory, Equipment equipment)
        {
            var equipmentItem = equipment.Get(equipmentType);
            if (equipmentItem == null)
            {
                equipment.NotifyUnableToUnequipEquipmentType(equipmentType);
                return;
            }
            
            inventory.AddItem(equipmentItem);
            equipment.Remove(equipmentType);
            equipment.NotifyItemRemoved(equipmentItem);
        }
    }
}