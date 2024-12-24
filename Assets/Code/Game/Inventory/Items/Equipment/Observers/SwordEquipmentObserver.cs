namespace Game
{
    public sealed class SwordEquipmentObserver : IEquipmentObserver
    {
        private readonly IAttributeRepository _attributeRepository;

        public SwordEquipmentObserver(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public void OnItemEquipped(InventoryItem item)
        {
            if(item.TryGetComponent<SwordComponent>(out var component))
            {
                _attributeRepository.Damage += component.Damage;
            }
        }
	
        public void OnItemUnequipped(InventoryItem item)
        {
            if(item.TryGetComponent<SwordComponent>(out var component))
            {
                _attributeRepository.Damage -= component.Damage;
            }
        }
    }
}