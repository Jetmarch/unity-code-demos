using UnityEngine;

namespace Game
{
    public class HelmEquipmentObserver : IEquipmentObserver
    {
        private readonly IAttributeRepository _attributeRepository;

        public HelmEquipmentObserver(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public void OnItemEquipped(InventoryItem item)
        {
            if(item.TryGetComponent<HelmetComponent>(out var component))
            {
                _attributeRepository.Health += component.Health;
            }
        }
	
        public void OnItemUnequipped(InventoryItem item)
        {
            if(item.TryGetComponent<HelmetComponent>(out var component))
            {
                _attributeRepository.Health -= component.Health;
            }
        }
    }
}