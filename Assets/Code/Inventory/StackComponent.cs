namespace Game
{
    public class StackComponent : IItemComponent
    {
        public int Count = 0;
        public int MaxCount = 5;
	
        public IItemComponent Clone()
        {
            return new StackComponent()
            {
                Count = Count,
                MaxCount = MaxCount
            };
        }
    }
}