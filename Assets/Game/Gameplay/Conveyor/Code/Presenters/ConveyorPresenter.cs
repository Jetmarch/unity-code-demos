
namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorPresenter : IConveyorPresenter
    {
        private readonly Conveyor _conveyor;

        public ConveyorPresenter(Conveyor conveyor)
        {
            _conveyor = conveyor;
        }

        public void AddResource(ConveyorResourceConfig resourceConfig)
        {
            var resource = resourceConfig.Clone();
            _conveyor.AddResource(resource);
        }

        public void RemoveResourceFromOutput()
        {
            _conveyor.GetConvertedResource();
        }

        public async void ConvertResource()
        {
            await _conveyor.ConvertNextResource();
        }
    }
}
