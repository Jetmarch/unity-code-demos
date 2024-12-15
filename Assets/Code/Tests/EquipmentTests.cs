using NUnit.Framework;

namespace Game.Tests
{
    public class EquipmentTests
    {
        private Hero _hero;
        private Inventory _inventory;
        private InventoryItem _helmetNew;
        private InventoryItem _helmetOld;


        [SetUp]
        public void Setup()
        {
            _hero = new Hero();
            _inventory = new Inventory();
            _helmetNew = new InventoryItem("helmet_new");
            _helmetOld = new InventoryItem("helmet_old");
            
            _helmetNew.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.Helmet;
            _helmetOld.AddComponent<EquipmentComponent>().EquipmentType = EquipmentType.Helmet;
            
            _inventory.AddItem(_helmetNew);
            _inventory.AddItem(_helmetOld);
        }

        [Test]
        public void WhenAddHelmet_AndHeroDoesNotHaveHelmet_ThenEquipmentContainHelmet()
        {
            EquipmentUseCases.AddEquipment(EquipmentType.Helmet, _helmetNew, _inventory, _hero.Equipment);

            Assert.IsTrue(_hero.Equipment.Get(EquipmentType.Helmet) != default);
            Assert.IsTrue(_inventory.FindItem(_helmetNew) == default);
        }

        [Test]
        public void WhenAddNewHelmet_AndHeroHasOldHelmet_ThenEquipmentContainNewHelmetAndInventoryContainsOldHelmet()
        {
            _hero.Equipment.Add(EquipmentType.Helmet, _helmetOld);

            EquipmentUseCases.AddEquipment(EquipmentType.Helmet, _helmetNew, _inventory, _hero.Equipment);

            Assert.IsTrue(_hero.Equipment.Get(EquipmentType.Helmet).Name != _helmetOld.Name);
            Assert.IsTrue(_inventory.FindItem(_helmetNew) == default);
            Assert.IsTrue(_inventory.FindItem(_helmetOld) != default);
        }
    }
}