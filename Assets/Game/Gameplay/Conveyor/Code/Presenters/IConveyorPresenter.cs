namespace Game.Gameplay.Conveyor
{
    public interface IConveyorPresenter 
    {
        void AddResource(ConveyorResourceConfig resourceConfig);
        void RemoveResourceFromOutput();
        void ConvertResource();
    }
}