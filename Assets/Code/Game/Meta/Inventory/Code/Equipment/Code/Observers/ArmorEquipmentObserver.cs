namespace Game
{
    public sealed class ArmorEquipmentObserver : IEquipmentObserver
    {
        private readonly IAttributeRepository _attributeRepository;

        public ArmorEquipmentObserver(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public void OnItemEquipped(InventoryItem item)
        {
            if(item.TryGetComponent<ArmorComponent>(out var component))
            {
                _attributeRepository.Armor += component.Armor;
            }
        }
	
        public void OnItemUnequipped(InventoryItem item)
        {
            if(item.TryGetComponent<ArmorComponent>(out var component))
            {
                _attributeRepository.Armor -= component.Armor;
            }
        }
    }
}