namespace Game
{
    public class SwordInventoryObserver : IInventoryObserver
    {
        //TODO: Create HeroProvider
        private readonly Hero _hero;

        public SwordInventoryObserver(Hero hero)
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