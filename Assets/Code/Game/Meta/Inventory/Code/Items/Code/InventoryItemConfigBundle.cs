using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName="InventoryItemConfigBundle", menuName="Configs/InventoryItemConfigBundle")]
    public sealed class InventoryItemConfigBundle : ScriptableObject
    {
        [SerializeField] private InventoryItemConfig[] _items;

        public InventoryItemConfig[] GetItemConfigs()
        {
            return _items;
        }

        public InventoryItemConfig GetItemConfig(string name)
        {
            foreach (var item in _items)
            {
                if (item.Prototype.Name == name)
                {
                    return item;
                }
            }
            
            throw new System.Exception("Item config with name " + name + " was not found");
        }
    }
}