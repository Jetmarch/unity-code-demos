using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public sealed class EquipmentObserverManager : IStartable, IDisposable
    {
        private readonly Equipment _equipment;
        private readonly IEnumerable<IEquipmentObserver> _observers;

        public EquipmentObserverManager(Equipment equipment, IEnumerable<IEquipmentObserver> observers)
        {
            _equipment = equipment;
            _observers = observers;
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

        public void Start()
        {
            _equipment.OnItemEquipped += ItemEquipped;
            _equipment.OnItemUnequipped += ItemUnequipped;
        }

        public void Dispose()
        {
            _equipment.OnItemEquipped -= ItemEquipped;
            _equipment.OnItemUnequipped -= ItemUnequipped;
        }
    }
}