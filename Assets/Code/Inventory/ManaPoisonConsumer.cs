namespace Game
{
    public class ManaPoisonConsumer : IItemConsumeObserver
    {
        private readonly Inventory _inventory;
        private readonly Hero _hero;

        public ManaPoisonConsumer(Inventory inventory, Hero hero)
        {
            _inventory = inventory;
            _hero = hero;
        }

        public void OnStartGame()
        {
            _inventory.OnItemConsumed += OnItemConsumed;
        }

        public void OnFinishGame()
        {
            _inventory.OnItemConsumed -= OnItemConsumed;
        }

        public void OnItemConsumed(InventoryItem item)
        {
            if(item.TryGetComponent<ManaComponent>(out var manaComponent))
            {
                _hero.Mana += manaComponent.Mana;
            }
        }
    }
}