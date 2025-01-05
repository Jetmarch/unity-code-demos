namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorZones
    {
        public readonly ConveyorTransportZone InputZone;
        public readonly ConveyorTransportZone OutputZone;
        public readonly ConveyorWorkZone WorkZone;

        public ConveyorZones(ConveyorTransportZone inputZone, ConveyorTransportZone outputZone, ConveyorWorkZone workZone)
        {
            InputZone = inputZone;
            OutputZone = outputZone;
            WorkZone = workZone;
        }
    }
}