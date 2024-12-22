namespace Game
{
    public class ManaPotionConsumer : IItemConsumeObserver
    {
        private readonly Inventory _inventory;
        private readonly IHero _hero;

        public ManaPotionConsumer(Inventory inventory, IHero hero)
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