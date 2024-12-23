namespace Game
{
    public class ManaPotionConsumer : IItemConsumeObserver
    {
        private readonly Inventory _inventory;
        private readonly IAttributeRepository _attributeRepository;

        public ManaPotionConsumer(Inventory inventory, IAttributeRepository attributeRepository)
        {
            _inventory = inventory;
            _attributeRepository = attributeRepository;
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
                _attributeRepository.Mana += manaComponent.Mana;
            }
        }
    }
}