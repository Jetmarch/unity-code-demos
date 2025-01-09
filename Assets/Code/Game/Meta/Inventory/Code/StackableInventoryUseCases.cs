namespace Game
{
    public static class StackableInventoryUseCases
    {
        public static void ConsumeItem(Inventory inventory, InventoryItem item)
        {
            if(!CanConsume(item))
            {
                return;
            }
		
            if(inventory.RemoveItem(item))
            {
                inventory.NotifyConsumed(item);
            }
        }

        private static bool CanConsume(InventoryItem item)
        {
            return (item.Flags & InventoryItemFlag.CONSUMABLE) == InventoryItemFlag.CONSUMABLE; 
        }
	
        public static bool RemoveItem(Inventory inventory, InventoryItem item)
        {
            var resultItem = inventory.FindItem(item);

            if(resultItem == null)
            {
                return false;
            }

            inventory.RemoveItemInstance(resultItem);
            inventory.NotifyRemove(resultItem);
            return true;
        }

        public static void AddItem(Inventory inventory, InventoryItem prototype)
        {
            if(!CanStack(prototype))
            {
                inventory.Add(prototype);
                return;
            }
            var lastItem = FindLastItem(inventory, prototype);

            if(lastItem == null)
            {
                inventory.Add(prototype);
                if (prototype.TryGetComponent<StackComponent>(out var component))
                {
                    component.Count = 1;
                }
                return;
            }

            if(lastItem.TryGetComponent<StackComponent>(out var stackComponent))
            {
                if(stackComponent.Count == stackComponent.MaxCount)
                {
                    inventory.Add(prototype);
                    prototype.GetComponent<StackComponent>().Count = 1;
                    return;
                }
			
                stackComponent.Count++;
            }
        }

        private static bool CanStack(InventoryItem item)
        {
            return (item.Flags & InventoryItemFlag.STACKABLE) == InventoryItemFlag.STACKABLE;
        }

        private static InventoryItem FindLastItem(Inventory inventory, InventoryItem prototype)
        {
            return inventory.FindLastItem(prototype);
        }
    }
}