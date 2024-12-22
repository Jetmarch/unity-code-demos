namespace Game
{
    public class SwordInventoryObserver : IInventoryObserver
    {
        private readonly IHero _hero;

        public SwordInventoryObserver(IHero hero)
        {
            _hero = hero;
        }

        public void OnItemAdded(InventoryItem item)
        {
            if(item.TryGetComponent<SwordComponent>(out var component))
            {
                _hero.Damage += component.Damage;
            }
        }
	
        public void OnItemRemoved(InventoryItem item)
        {
            if(item.TryGetComponent<SwordComponent>(out var component))
            {
                _hero.Damage -= component.Damage;
            }
        }
    }
}