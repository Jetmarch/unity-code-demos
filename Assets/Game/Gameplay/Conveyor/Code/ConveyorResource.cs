namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorResource
    {
        public string Name { get; }
        public float ConvertModifier { get; }
        public ConveyorResource(string name, float convertModifier = 1f)
        {
            Name = name;
            ConvertModifier = convertModifier;
        }
    }
}