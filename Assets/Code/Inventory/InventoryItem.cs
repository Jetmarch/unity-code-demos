using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class InventoryItem
    {
        public string Name;
        public ItemMetaData MetaData;
        public InventoryItemFlag Flags;

        //Odin
        [SerializeReference] public IItemComponent[] ItemComponents;

        public InventoryItem(string name)
        {
            Name = name;
        }

        public InventoryItem() {}
        
        public InventoryItem Clone()
        {
            var item = new InventoryItem()
            {
                Name = Name,
                MetaData = CloneMetadata(),
                ItemComponents = CloneComponents(),
                Flags = Flags
            };
            return item;
        }

        public T GetComponent<T>() where T : IItemComponent
        {
            foreach(var itemComponent in ItemComponents)
            {
                if(itemComponent is T component)
                {
                    return component;
                }
            }
            return default;
        }

        public bool TryGetComponent<T>(out T resultComponent) where T : IItemComponent
        {
            foreach(var itemComponent in ItemComponents)
            {
                if(itemComponent is T component)
                {
                    resultComponent = component;
                    return true;
                }
            }
            resultComponent = default;
            return false;
        }

        private ItemMetaData CloneMetadata()
        {
            return new ItemMetaData()
            {
                Description = MetaData.Description,
                Icon = MetaData.Icon
            };
        }

        private IItemComponent[] CloneComponents()
        {
            var list = new List<IItemComponent>();
		
            foreach(var itemComponent in ItemComponents)
            {
                list.Add(itemComponent.Clone());
            }

            return list.ToArray();
        }
    }
}