using UnityEngine;

namespace Game
{
    public class HelmEquipmentObserver : IEquipmentObserver
    {
        private readonly IHero _hero;

        public HelmEquipmentObserver(IHero hero)
        {
            _hero = hero;
        }

        public void OnItemEquipped(InventoryItem item)
        {
            if(item.TryGetComponent<HelmetComponent>(out var component))
            {
                _hero.Health += component.Health;
            }
        }
	
        public void OnItemUnequipped(InventoryItem item)
        {
            if(item.TryGetComponent<HelmetComponent>(out var component))
            {
                _hero.Health -= component.Health;
            }
        }
    }
}