namespace Game
{
    public interface IEquipmentObserver
    {
        void OnItemEquipped(InventoryItem item);
        void OnItemUnequipped(InventoryItem item);
    }
}