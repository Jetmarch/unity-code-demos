using NUnit.Framework;

namespace Game.Tests
{
    public class InventoryTests
    {
        [Test]
        public void WhenAddItem_AndInventoryIsEmpty_ThenInventoryContainItem()
        {
            var inventory = new Inventory();
            var item = new InventoryItem();
        }
    }
}
