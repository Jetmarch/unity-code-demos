namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorAttributes
    {
        public int MaxUnloadZoneCapacity { get; }
        public int MaxLoadZoneCapacity { get; }
        public float BaseWorkTime { get; }
        
        public ConveyorAttributes(int maxLoadZoneCapacity, int maxUnloadZoneCapacity, float baseWorkTime)
        {
            MaxLoadZoneCapacity = maxLoadZoneCapacity;
            BaseWorkTime = baseWorkTime;
            MaxUnloadZoneCapacity = maxUnloadZoneCapacity;
        }
    }
}