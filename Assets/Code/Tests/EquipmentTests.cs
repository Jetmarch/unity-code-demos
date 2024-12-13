using NUnit.Framework;

namespace Game.Tests
{
    public class EquipmentTests
    {
        [Test]
        public void WhenAddHelmet_AndHeroDoesNotHaveHelmet_ThenEquipmentContainHelmet()
        {
            var hero = new Hero();
            var helmet = new InventoryItem("helmet");
            
            hero.AddEquipment(EquipmentType.Helmet, helmet);
            
            Assert.That(hero.GetEquipment(EquipmentType.Helmet), Is.EqualTo(helmet));
        }
    }
}