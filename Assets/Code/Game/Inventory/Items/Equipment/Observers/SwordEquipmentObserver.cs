namespace Game
{
    public class SwordEquipmentObserver : IEquipmentObserver
    {
        private readonly IHero _hero;

        public SwordEquipmentObserver(IHero hero)
        {
            _hero = hero;
        }

        public void OnItemEquipped(InventoryItem item)
        {
            if(item.TryGetComponent<SwordComponent>(out var component))
            {
                _hero.Damage += component.Damage;
            }
        }
	
        public void OnItemUnequipped(InventoryItem item)
        {
            if(item.TryGetComponent<SwordComponent>(out var component))
            {
                _hero.Damage -= component.Damage;
            }
        }
    }
}