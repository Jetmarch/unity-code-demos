namespace Game
{
    public sealed class ShieldEquipmentObserver : IEquipmentObserver
    {
        private readonly IAttributeRepository _attributeRepository;

        public ShieldEquipmentObserver(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public void OnItemEquipped(InventoryItem item)
        {
            if(item.TryGetComponent<ShieldComponent>(out var component))
            {
                _attributeRepository.Armor += component.Armor;
                _attributeRepository.Health += component.Health;
            }
        }
	
        public void OnItemUnequipped(InventoryItem item)
        {
            if(item.TryGetComponent<ShieldComponent>(out var component))
            {
                _attributeRepository.Armor -= component.Armor;
                _attributeRepository.Health += component.Health;
            }
        }
    }
}