using System;

namespace Game.Gameplay.Conveyor
{
    [Serializable]
    public sealed class ConveyorRecipe
    {
        public ConveyorResource RequiredResource { get; }
        public ConveyorResource ResultingResource { get; }
        
        public ConveyorRecipe(ConveyorResource requiredResource, ConveyorResource resultingResource)
        {
            RequiredResource = requiredResource;
            ResultingResource = resultingResource;
        }
    }
}