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
        private SwordInventoryObserver _swordObserver;

        [SetUp]
        public void Setup()
        {
            _hero = new Hero();
            _inventory = new Inventory();
            _equipment = new Equipment();
            _helmetNew = new InventoryItem("helmet_new");
            _helmetOld = new InventoryItem("helmet_old");
            _sword = new InventoryItem("sword");
            
            _helmetNew.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.Helmet;
            _helmetOld.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.Helmet;
            
            _sword.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.RightHand;
            _sword.AddComponent<SwordComponent>().Damage = 5;
            
            _inventory.AddItem(_helmetNew);
            _inventory.AddItem(_helmetOld);
            _inventory.AddItem(_sword);

            _swordObserver = new SwordInventoryObserver(_hero);
            _equipment.OnItemAdded += _swordObserver.OnItemAdded;
            _equipment.OnItemRemoved += _swordObserver.OnItemRemoved;
        }

        [Test]
        public void WhenAddHelmet_AndHeroDoesNotHaveHelmet_ThenEquipmentContainHelmet()
        {
            _equipment.AddItem(EquipmentType.Helmet, _helmetNew, _inventory);

            Assert.IsTrue(_equipment.Get(EquipmentType.Helmet) != default);
            Assert.IsTrue(_inventory.FindItem(_helmetNew) == default);
        }

        [Test]
        public void WhenAddNewHelmet_AndHeroHasOldHelmet_ThenEquipmentContainNewHelmetAndInventoryContainsOldHelmet()
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
        public void WhenEquipSword_AndHeroHaveSword_ThenHeroDamageDecreased()
        {
            _equipment.AddItem(EquipmentType.RightHand, _sword, _inventory);
            _equipment.RemoveItem(EquipmentType.RightHand, _inventory);
            
            Assert.IsTrue(_hero.Damage == 0);
        }

        [Test]
        public void WhenUnequipSword_AndHeroHaveSword_ThenEquipmentDoesNotContainSwordAndInventoryContainsSword()
        {
            _equipment.AddItem(EquipmentType.RightHand, _sword, _inventory);
            
            _equipment.RemoveItem(EquipmentType.RightHand, _inventory);
            
            Assert.IsTrue(_equipment.Get(EquipmentType.RightHand) == default);
            Assert.IsTrue(_inventory.FindItem(_sword) != default);
        }
    }
}