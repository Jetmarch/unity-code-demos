using System.Collections.Generic;
using NUnit.Framework;

namespace Game.Tests
{
    public class EquipmentTests
    {
        private AttributeRepository _attributeRepository;
        private Inventory _inventory;
        private Equipment _equipment;
        private InventoryItem _helmetNew;
        private InventoryItem _helmetOld;
        private InventoryItem _sword;
        private InventoryItem _armor;
        
        private EquipmentObserverManager _equipmentObserverManager;

        [SetUp]
        public void Setup()
        {
            _attributeRepository = new AttributeRepository();
            _inventory = new Inventory();
            _equipment = new Equipment();
            _helmetNew = new InventoryItem("helmet_new");
            _helmetOld = new InventoryItem("helmet_old");
            _sword = new InventoryItem("sword");
            _armor = new InventoryItem("armor");

            _helmetNew.AddComponent<HelmetComponent>().Health = 10;
            _helmetNew.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.Helmet;
            
            _helmetOld.AddComponent<HelmetComponent>().Health = 5;
            _helmetOld.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.Helmet;
            
            _sword.AddComponent<SwordComponent>().Damage = 5;
            _sword.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.RightHand;
            
            _armor.AddComponent<ArmorComponent>().Armor = 5;
            _armor.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.Armor;
            
            _inventory.AddItem(_helmetNew);
            _inventory.AddItem(_helmetOld);
            _inventory.AddItem(_sword);
            _inventory.AddItem(_armor);
            
            var equipmentObservers = new List<IEquipmentObserver>
            {
                new SwordEquipmentObserver(_attributeRepository),
                new HelmEquipmentObserver(_attributeRepository),
                new ArmorEquipmentObserver(_attributeRepository)
            };

            _equipmentObserverManager = new EquipmentObserverManager(_equipment, equipmentObservers);
            _equipmentObserverManager.Start();
        }

        [Test]
        public void WhenEquipHelmet_AndHeroDoesNotHaveHelmet_ThenEquipmentContainsHelmet()
        {
            _equipment.AddItem(EquipmentType.Helmet, _helmetNew, _inventory);

            Assert.IsTrue(_equipment.Get(EquipmentType.Helmet) != default);
            Assert.IsTrue(_inventory.FindItem(_helmetNew) == default);
        }

        [Test]
        public void WhenEquipNewHelmet_AndHeroHasOldHelmet_ThenEquipmentContainsNewHelmetAndInventoryContainsOldHelmet()
        {
            _equipment.AddItem(EquipmentType.Helmet, _helmetOld, _inventory);
            
            _equipment.AddItem(EquipmentType.Helmet, _helmetNew, _inventory);

            Assert.IsTrue(_equipment.Get(EquipmentType.Helmet).Name != _helmetOld.Name);
            Assert.IsTrue(_inventory.FindItem(_helmetNew) == default);
            Assert.IsTrue(_inventory.FindItem(_helmetOld) != default);
        }

        [Test]
        public void WhenEquipSword_AndHeroDoesNotHaveSword_ThenHeroDamageIncreased()
        {
            _equipment.AddItem(EquipmentType.RightHand, _sword, _inventory);
            
            Assert.IsTrue(_attributeRepository.Damage == _sword.GetComponent<SwordComponent>().Damage);
        }
        
        [Test]
        public void WhenEquipArmor_AndHeroDoesNotHaveArmor_ThenHeroArmorIncreased()
        {
            _equipment.AddItem(EquipmentType.Armor, _armor, _inventory);
            
            Assert.IsTrue(_attributeRepository.Armor == _armor.GetComponent<ArmorComponent>().Armor);
        }
        
        [Test]
        public void WhenUnequipSword_AndHeroHaveSword_ThenHeroDamageDecreased()
        {
            _equipment.AddItem(EquipmentType.RightHand, _sword, _inventory);
            _equipment.RemoveItem(EquipmentType.RightHand, _inventory);
            
            Assert.IsTrue(_attributeRepository.Damage == 0);
        }

        [Test]
        public void WhenUnequipSword_AndHeroHaveSword_ThenEquipmentDoesNotContainsSwordAndInventoryContainsSword()
        {
            _equipment.AddItem(EquipmentType.RightHand, _sword, _inventory);
            
            _equipment.RemoveItem(EquipmentType.RightHand, _inventory);
            
            Assert.IsTrue(_equipment.Get(EquipmentType.RightHand) == default);
            Assert.IsTrue(_inventory.FindItem(_sword) != default);
        }
        
        [Test]
        public void WhenEquipArmorInLeftHandSlot_AndHeroDoesNotHaveArmor_ThenHeroArmorNotChangedAndArmorStayInInventory()
        {
            _equipment.AddItem(EquipmentType.LeftHand, _armor, _inventory);
            
            Assert.IsTrue(_attributeRepository.Armor == 0);
            Assert.IsTrue(_inventory.FindItem(_armor) != default);
        }
    }
}