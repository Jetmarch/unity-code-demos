using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName="InventoryItemConfig", menuName="Configs/InventoryItemConfig")]
    public class InventoryItemConfig : ScriptableObject
    {
        [SerializeField] private InventoryItem Prototype;

        public InventoryItem Clone()
        {
            return Prototype.Clone();
        }
    }
}