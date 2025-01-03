using System.Threading;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Gameplay.Conveyor
{
    public class ConveyorInstaller : LifetimeScope
    {
        [SerializeField] private ConveyorAttributes _attributes;
        
        [SerializeField] private ConveyorRecipeConfig _recipeConfig;
 
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureConveyorController(builder);
        }

        private void ConfigureConveyorController(IContainerBuilder builder)
        {
            var inputZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Load);
            var outputZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Unload);
            var workZone = new ConveyorWorkZone(_attributes, _recipeConfig.Clone());
            
            builder.Register<Conveyor>(Lifetime.Scoped)
                .WithParameter(inputZone)
                .WithParameter(outputZone)
                .WithParameter(workZone)
                .WithParameter(new CancellationTokenSource());
        }
    }
}