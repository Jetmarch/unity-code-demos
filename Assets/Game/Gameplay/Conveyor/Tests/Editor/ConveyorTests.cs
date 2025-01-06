using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

namespace Game.Gameplay.Conveyor.Tests
{
    
    public sealed class ConveyorTests
    {
        private ConveyorAttributes _attributes;
        private ConveyorResource _woodLog;
        private ConveyorResource _woodPlank;
        private ConveyorTransportZone _loadZone;
        private ConveyorTransportZone _unloadZone;
        private ConveyorWorkZone _workZone;

        // private ConveyorRecipeConfig _woodPlankRecipe;
        private ConveyorResourceConfig _woodLogConfig;
        private ConveyorResourceConfig _woodPlankConfig;
        
        private Conveyor _conveyor;
        private CancellationTokenSource _cts;
        private readonly int _ctsMillis = 1000;
        

        [SetUp]
        public void Configure()
        {
            _attributes = new ConveyorAttributes(4, 4,0.1f);
            _woodLog = new ConveyorResource("woodLog");
            _woodPlank = new ConveyorResource("woodPlank");
            _loadZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Load);
            _unloadZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Unload);

            _woodLogConfig = ScriptableObject.CreateInstance<ConveyorResourceConfig>();
            _woodLogConfig.SetPrototype(_woodLog);
            _woodPlankConfig = ScriptableObject.CreateInstance<ConveyorResourceConfig>();
            _woodPlankConfig.SetPrototype(_woodPlank);
            
            _workZone = new ConveyorWorkZone(_attributes, new ConveyorRecipe(_woodLogConfig, _woodPlankConfig));
            
            _cts = new CancellationTokenSource(_ctsMillis);

            var conveyorZones = new ConveyorZones(_loadZone, _unloadZone, _workZone);
            _conveyor = new Conveyor(conveyorZones, _attributes, _cts);
        }

        [Test]
        public void WhenAddWoodLogToLoadZone_AndLoadZoneIsEmpty_ThenLoadZoneHaveWoodLog()
        {
            _loadZone.TryAddResource(_woodLog);
            _loadZone.TryGetNextResource(out var loadedResource);
            Assert.AreEqual(loadedResource, _woodLog);
        }
        
        [Test]
        public void WhenAddWoodLogToLoadZone_AndLoadZoneIsFull_ThenLoadZoneDoesNotHaveWoodLog()
        {
            for (int i = 0; i < _attributes.MaxLoadZoneCapacity; i++)
            {
                _loadZone.TryAddResource(_woodPlank);
            }
            
            _loadZone.TryAddResource(_woodLog);
            _loadZone.TryGetNextResource(out var loadedResource);
            Assert.AreNotEqual(loadedResource, _woodLog);
        }
        
        [Test]
        public void WhenAddWoodLogToUnloadZone_AndUnloadZoneIsEmpty_ThenUnloadZoneHaveWoodLog()
        {
            _unloadZone.TryAddResource(_woodLog);
            _unloadZone.TryGetNextResource(out var unloadedResource);
            
            Assert.AreEqual(unloadedResource, _woodLog);
        }
        
        [Test]
        public void WhenAddWoodLogToUnloadZone_AndUnloadZoneIsFull_ThenUnloadZoneDoesNotHaveWoodLog()
        {
            for (int i = 0; i < _attributes.MaxUnloadZoneCapacity; i++)
            {
                _unloadZone.TryAddResource(_woodPlank);
            }
            
            _unloadZone.TryAddResource(_woodLog);
            _unloadZone.TryGetNextResource(out var unloadedResource);
            
            Assert.AreNotEqual(unloadedResource, _woodLog);
        }
        
        [Test]
        public async Task WhenWoodLogResourceInWorkZone_AndWorkZoneIsNotBusy_ThenProduceWoodPlankResource()
        {
            var convertedWoodPlank = await _workZone.ConvertResourceAsync(_woodLog, _cts);
            
            Assert.AreEqual(convertedWoodPlank.Name, _woodPlank.Name);
        }
        
        [Test]
        public void WhenWoodLogResourceAddInLoadZone_AndWorkZoneIsNotBusy_ThenProduceWoodPlankResource()
        {
            _conveyor.AddResource(_woodLog);
            _conveyor.ConvertNextResource();
            var unloadedResource = _conveyor.GetConvertedResource();
            
            
            Assert.AreEqual(unloadedResource.Name, _woodPlank.Name);
        }
        
        [Test]
        public void WhenWoodPlankResourceAddInLoadZone_AndWorkZoneIsNotBusy_ThenUnloadedResourceIsDefault()
        {
            _conveyor.AddResource(_woodPlank);
            _conveyor.ConvertNextResource();
            var unloadedResource = _conveyor.GetConvertedResource();
            
            Assert.AreEqual(unloadedResource, default);
        }
    }
}
