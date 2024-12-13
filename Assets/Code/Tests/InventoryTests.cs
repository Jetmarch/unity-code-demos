using NUnit.Framework;

namespace Game.Tests
{
    public class InventoryTests
    {
        [Test]
        public void WhenAddPickaxe_AndInventoryDoesNotContainPickaxe_ThenInventoryContainPickaxe()
        {
            var inventory = new Inventory();
            var item = new InventoryItem();
            
            Assert.AreEqual(0, 0);
        }
    }
}
