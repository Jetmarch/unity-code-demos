using NUnit.Framework;

namespace Game.Tests
{
    public class EquipmentTests
    {
        private Hero _hero;
        private Inventory _inventory;
        private InventoryItem _helmetNew;
        private InventoryItem _helmetOld;
        private InventoryItem _sword;


        [SetUp]
        public void Setup()
        {
            _hero = new Hero();
            _inventory = new Inventory();
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
        }

        [Test]
        public void WhenAddHelmet_AndHeroDoesNotHaveHelmet_ThenEquipmentContainHelmet()
        {
            _hero.Equipment.AddItem(EquipmentType.Helmet, _helmetNew, _inventory);

            Assert.IsTrue(_hero.Equipment.Get(EquipmentType.Helmet) != default);
            Assert.IsTrue(_inventory.FindItem(_helmetNew) == default);
        }

        [Test]
        public void WhenAddNewHelmet_AndHeroHasOldHelmet_ThenEquipmentContainNewHelmetAndInventoryContainsOldHelmet()
        {
            _hero.Equipment.AddItem(EquipmentType.Helmet, _helmetOld, _inventory);
            
            _hero.Equipment.AddItem(EquipmentType.Helmet, _helmetNew, _inventory);

            Assert.IsTrue(_hero.Equipment.Get(EquipmentType.Helmet).Name != _helmetOld.Name);
            Assert.IsTrue(_inventory.FindItem(_helmetNew) == default);
            Assert.IsTrue(_inventory.FindItem(_helmetOld) != default);
        }

        [Test]
        public void WhenEquipSword_AndHeroDoesNotHaveSword_ThenHeroDamageIncreased()
        {
            _hero.Equipment.AddItem(EquipmentType.RightHand, _sword, _inventory);
            
            Assert.IsTrue(_hero.Damage == _sword.GetComponent<SwordComponent>().Damage);
        }

        [Test]
        public void WhenUnequipSword_AndHeroHaveSword_ThenEquipmentDoesNotContainSwordAndInventoryContainsSword()
        {
            _hero.Equipment.AddItem(EquipmentType.RightHand, _sword, _inventory);
            
            _hero.Equipment.Remove(EquipmentType.RightHand, _inventory);
            
            Assert.IsTrue(_hero.Equipment.Get(EquipmentType.RightHand) == default);
            Assert.IsTrue(_inventory.FindItem(_sword) != default);
        }
    }
}