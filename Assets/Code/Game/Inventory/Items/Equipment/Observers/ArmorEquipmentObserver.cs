namespace Game
{
    public class ArmorEquipmentObserver : IEquipmentObserver
    {
        private readonly IHero _hero;

        public ArmorEquipmentObserver(IHero hero)
        {
            _hero = hero;
        }

        public void OnItemEquipped(InventoryItem item)
        {
            if(item.TryGetComponent<ArmorComponent>(out var component))
            {
                _hero.Armor += component.Armor;
            }
        }
	
        public void OnItemUnequipped(InventoryItem item)
        {
            if(item.TryGetComponent<ArmorComponent>(out var component))
            {
                _hero.Armor -= component.Armor;
            }
        }
    }
}