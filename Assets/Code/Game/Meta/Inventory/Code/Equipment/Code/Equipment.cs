using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Game
{
    [Serializable]
    public sealed class Equipment 
    {
        public event Action<InventoryItem> OnItemEquipped;
        public event Action<InventoryItem> OnItemUnequipped;
        
        public event Action<InventoryItem> OnItemNotExistInInventory;
        public event Action<InventoryItem, EquipmentType> OnUnableToEquipItem;
        public event Action<EquipmentType> OnUnableToUnequipEquipmentType;
        
        [ShowInInspector] private Dictionary<EquipmentType, InventoryItem> _equipment = new();
        
        private readonly Inventory _inventory;

        public Equipment(Inventory inventory)
        {
            _inventory = inventory;
        }
        
        public void EquipItem(EquipmentType equipmentType, InventoryItem prototypeItem)
        {
            EquipmentUseCases.EquipItem(equipmentType, prototypeItem, _inventory, this);
        }

        public void Equip(EquipmentType equipmentType, InventoryItem prototypeItem)
        {
            _equipment.Add(equipmentType, prototypeItem);
        }

        public void UnequipItem(EquipmentType equipmentType)
        {
            EquipmentUseCases.RemoveEquipment(equipmentType, _inventory, this);
        }

        public void Remove(EquipmentType equipmentType)
        {
            _equipment.Remove(equipmentType);
        }

        public InventoryItem Get(EquipmentType equipmentType)
        {
            return _equipment.GetValueOrDefault(equipmentType);
        }

        public void NotifyItemAdded(InventoryItem item)
        {
            OnItemEquipped?.Invoke(item);
        }

        public void NotifyItemRemoved(InventoryItem item)
        {
            OnItemUnequipped?.Invoke(item);
        }

        public void NotifyItemNotExistInInventory(InventoryItem item)
        {
            OnItemNotExistInInventory?.Invoke(item);
        }

        public void NotifyUnableToEquipItem(InventoryItem item, EquipmentType equipmentType)
        {
            OnUnableToEquipItem?.Invoke(item, equipmentType);
        }

        public void NotifyUnableToUnequipEquipmentType(EquipmentType equipmentType)
        {
            OnUnableToUnequipEquipmentType?.Invoke(equipmentType);
        }
    }
}
