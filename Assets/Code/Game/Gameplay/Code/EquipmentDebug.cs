using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Game
{
    public class EquipmentDebug : MonoBehaviour
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
            if (itemConfig == null)
            {
                return;
            }
            
            _inventory.AddItem(itemConfig.Clone());
        }

        [Button]
        public void RemoveItemFromInventory(InventoryItemConfig itemConfig)
        {
            if (itemConfig == null)
            {
                return;
            }
            
            _inventory.RemoveItem(itemConfig.Clone());
        }

        [Button]
        public void EquipItem(EquipmentType equipmentType, InventoryItemConfig itemConfig)
        {
            if (itemConfig == null)
            {
                return;
            }
            
            _equipment.EquipItem(equipmentType, itemConfig.Clone());
        }

        [Button]
        public void UnequipItem(EquipmentType equipmentType)
        {
            _equipment.UnequipItem(equipmentType);
        }
    }
}
