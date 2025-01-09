using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    [CreateAssetMenu(fileName="InventoryItemConfig", menuName="Configs/InventoryItemConfig")]
    public sealed class InventoryItemConfig : ScriptableObject
    {
        public InventoryItem Prototype => _prototype;
        [SerializeField] private InventoryItem _prototype;

        public InventoryItem Clone()
        {
            return _prototype.Clone();
        }
    }
}