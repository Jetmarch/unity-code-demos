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
            ConfigureConveyor(builder);
        }

        private void ConfigureConveyor(IContainerBuilder builder)
        {
            var inputZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Load);
            var outputZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Unload);
            var workZone = new ConveyorWorkZone(_attributes, _recipeConfig.Clone());
            var conveyorZones = new ConveyorZones(inputZone, outputZone, workZone);
            
            builder.Register<Conveyor>(Lifetime.Scoped)
                .WithParameter(conveyorZones)
                .WithParameter(new CancellationTokenSource());
        }
    }

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