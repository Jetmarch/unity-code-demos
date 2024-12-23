using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class Inventory
    {
        public event Action<InventoryItem> OnItemAdded;

        public event Action<InventoryItem> OnItemRemoved;

        public event Action<InventoryItem> OnItemConsumed;
	
        [SerializeField] private List<InventoryItem> _items = new();

        public void AddItem(InventoryItem prototype)
        {
            InventoryUseCases.AddItem(this, prototype);
        }

        public void Add(InventoryItem item)
        {
            _items.Add(item);
        }

        public InventoryItem FindItem(InventoryItem prototype)
        {
            var resultItem = _items.FirstOrDefault(item => item.Name == prototype.Name);
            return resultItem;
        }

        public InventoryItem FindLastItem(InventoryItem prototype)
        {
            var resultItem = _items.LastOrDefault(item => item.Name == prototype.Name);
            return resultItem;
        }

        public bool RemoveItem(InventoryItem item)
        {
            return InventoryUseCases.RemoveItem(this, item);
        }

        public void RemoveItemInstance(InventoryItem item)
        {
            _items.Remove(item);
        }

        public void NotifyRemove(InventoryItem item)
        {
            OnItemRemoved?.Invoke(item);
        }

        public void ConsumeItem(InventoryItem item)
        {
            InventoryUseCases.ConsumeItem(this, item);
        }

        public void NotifyConsumed(InventoryItem item)
        {
            OnItemConsumed?.Invoke(item);
        }

        public int GetCount(string itemName)
        {
            var count = _items.Count(item => item.Name == itemName);
            return count;
        }

        public bool HasItems(string itemName, int count)
        {
            var itemCount = GetCount(itemName);
            return itemCount >= count;
        }
    }
}