using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Game
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private AttributeRepository _attributeRepository;
        
        [SerializeField] private Equipment _equipment;
        
        [SerializeField] private Inventory _inventory;

        [Inject]
        public void Construct(AttributeRepository attributeRepository, Equipment equipment, Inventory inventory)
        {
            _attributeRepository = attributeRepository;
            _equipment = equipment;
            _inventory = inventory;
        }

        [Button]
        public void AddItemToInventory(InventoryItemConfig itemConfig)
        {
            _inventory.AddItem(itemConfig.Clone());
        }

        [Button]
        public void RemoveItemFromInventory(InventoryItemConfig itemConfig)
        {
            _inventory.RemoveItem(itemConfig.Clone());
        }

        [Button]
        public void EquipItem(EquipmentType equipmentType, InventoryItemConfig itemConfig)
        {
            _equipment.AddItem(equipmentType, itemConfig.Clone(), _inventory);
        }

        [Button]
        public void UnequipItem(EquipmentType equipmentType)
        {
            _equipment.RemoveItem(equipmentType, _inventory);
        }
    }
}
