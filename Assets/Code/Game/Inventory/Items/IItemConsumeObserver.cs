namespace Game
{
    public interface IItemConsumeObserver
    {
        void OnItemConsumed(InventoryItem item);
    }
}