using System;
using Game.UI;
using VContainer.Unity;

namespace Game.Controllers
{
    public sealed class EquipmentController : IStartable, IDisposable
    {
        private readonly Equipment _equipment;
        private readonly TextPopupView _textPopup;

        public EquipmentController(Equipment equipment, TextPopupView textPopup)
        {
            _equipment = equipment;
            _textPopup = textPopup;
        }

        public void Start()
        {
            _equipment.OnItemEquipped += EquipmentOnItemEquipped;
            _equipment.OnItemUnequipped += EquipmentOnItemUnequipped;
            _equipment.OnUnableToEquipItem += EquipmentOnUnableToEquipItem;
            _equipment.OnItemNotExistInInventory += EquipmentOnItemNotExistInInventory;
            _equipment.OnUnableToUnequipEquipmentType += EquipmentOnUnableToUnequipEquipmentType;
            _textPopup.Hide();
        }
        
        public void Dispose()
        {
            _equipment.OnUnableToUnequipEquipmentType -= EquipmentOnUnableToUnequipEquipmentType;
            _equipment.OnItemNotExistInInventory -= EquipmentOnItemNotExistInInventory;
            _equipment.OnUnableToEquipItem -= EquipmentOnUnableToEquipItem;
            _equipment.OnItemUnequipped -= EquipmentOnItemUnequipped;
            _equipment.OnItemEquipped -= EquipmentOnItemEquipped;
        }
        
        private void EquipmentOnUnableToUnequipEquipmentType(EquipmentType equipmentType)
        {
            _textPopup.Show($"Unable to unequip {equipmentType} slot");
        }

        private void EquipmentOnItemNotExistInInventory(InventoryItem item)
        {
            _textPopup.Show($"Item {item.Name} doesn't exist in inventory");
        }

        private void EquipmentOnUnableToEquipItem(InventoryItem item, EquipmentType equipmentType)
        {
            _textPopup.Show($"Unable to equip item {item.Name} in {equipmentType} slot");
        }

        private void EquipmentOnItemUnequipped(InventoryItem item)
        {
            _textPopup.Show($"Unequipped {item.Name}");
        }

        private void EquipmentOnItemEquipped(InventoryItem item)
        {
            _textPopup.Show($"Equipped {item.Name}");
        }
        
    }
}