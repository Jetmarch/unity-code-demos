using System.Collections.Generic;

namespace Game
{
    public sealed class EquipmentObserverManager
    {
        private readonly Equipment _equipment;
        private readonly List<IEquipmentObserver> _observers;

        public EquipmentObserverManager(Equipment equipment, List<IEquipmentObserver> observers)
        {
            _equipment = equipment;
            _observers = observers;
        }

        public void OnInit()
        {
            _equipment.OnItemEquipped += ItemEquipped;
            _equipment.OnItemUnequipped += ItemUnequipped;
        }

        public void OnDestroy()
        {
            _equipment.OnItemEquipped -= ItemEquipped;
            _equipment.OnItemUnequipped -= ItemUnequipped;
        }

        private void ItemEquipped(InventoryItem item)
        {
            foreach (var observer in _observers)
            {
                observer.OnItemEquipped(item);
            }
        }

        private void ItemUnequipped(InventoryItem item)
        {
            foreach (var observer in _observers)
            {
                observer.OnItemUnequipped(item);
            }
        }
    }
}