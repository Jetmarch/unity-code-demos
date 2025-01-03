using System;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    [Serializable]
    public sealed class ConveyorRecipe
    {
        public ConveyorResourceConfig RequiredResource => _requiredResource;
        public ConveyorResourceConfig ResultingResource => _resultingResource;
        
        [SerializeField] private ConveyorResourceConfig _requiredResource;
        [SerializeField] private ConveyorResourceConfig _resultingResource;
        
        public ConveyorRecipe(ConveyorResourceConfig requiredResource, ConveyorResourceConfig resultingResource)
        {
            _requiredResource = requiredResource;
            _resultingResource = resultingResource;
        }
    }
}