using System.Collections.Generic;
using NUnit.Framework;

namespace Game.Tests
{
    public class EquipmentTests
    {
        private Hero _hero;
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
            _hero = new Hero();
            _inventory = new Inventory();
            _equipment = new Equipment();
            _helmetNew = new InventoryItem("helmet_new");
            _helmetOld = new InventoryItem("helmet_old");
            _sword = new InventoryItem("sword");
            _armor = new InventoryItem("armor");

            var helmetComponent = _helmetNew.AddComponent<HelmetComponent>();
            helmetComponent.EquipmentType = EquipmentType.Helmet;
            helmetComponent.Health = 10;

            var oldHelmetComponent = _helmetOld.AddComponent<HelmetComponent>();
            oldHelmetComponent.EquipmentType = EquipmentType.Helmet;
            oldHelmetComponent.Health = 5;
            
            var swordComponent = _sword.AddComponent<SwordComponent>();
            swordComponent.EquipmentType = EquipmentType.RightHand;
            swordComponent.Damage = 5;
            
            var armorComponent = _armor.AddComponent<ArmorComponent>();
            armorComponent.EquipmentType = EquipmentType.Armor;
            armorComponent.Armor = 5;
            
            _inventory.AddItem(_helmetNew);
            _inventory.AddItem(_helmetOld);
            _inventory.AddItem(_sword);
            _inventory.AddItem(_armor);
            
            var equipmentObservers = new List<IEquipmentObserver>
            {
                new SwordEquipmentObserver(_hero),
                new HelmEquipmentObserver(_hero),
                new ArmorEquipmentObserver(_hero)
            };

            _equipmentObserverManager = new EquipmentObserverManager(_equipment, equipmentObservers);
            _equipmentObserverManager.OnInit();
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
            
            Assert.IsTrue(_hero.Damage == _sword.GetComponent<SwordComponent>().Damage);
        }
        
        [Test]
        public void WhenEquipArmor_AndHeroDoesNotHaveArmor_ThenHeroArmorIncreased()
        {
            _equipment.AddItem(EquipmentType.Armor, _armor, _inventory);
            
            Assert.IsTrue(_hero.Armor == _armor.GetComponent<ArmorComponent>().Armor);
        }
        
        [Test]
        public void WhenUnequipSword_AndHeroHaveSword_ThenHeroDamageDecreased()
        {
            _equipment.AddItem(EquipmentType.RightHand, _sword, _inventory);
            _equipment.RemoveItem(EquipmentType.RightHand, _inventory);
            
            Assert.IsTrue(_hero.Damage == 0);
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
            
            Assert.IsTrue(_hero.Armor == 0);
            Assert.IsTrue(_inventory.FindItem(_armor) != default);
        }
    }
}