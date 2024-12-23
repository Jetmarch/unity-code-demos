using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public class EquipmentDebug : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        
        [SerializeField] private Equipment _equipment;
        
        [SerializeField] private Inventory _inventory;


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
