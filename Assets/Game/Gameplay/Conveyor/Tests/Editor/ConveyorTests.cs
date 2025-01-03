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

            // _woodPlankRecipe = ScriptableObject.CreateInstance<ConveyorRecipeConfig>();
            // _woodPlankRecipe.SetPrototype(_);
            _woodLogConfig = ScriptableObject.CreateInstance<ConveyorResourceConfig>();
            _woodLogConfig.SetPrototype(_woodLog);
            _woodPlankConfig = ScriptableObject.CreateInstance<ConveyorResourceConfig>();
            _woodPlankConfig.SetPrototype(_woodPlank);
            
            _workZone = new ConveyorWorkZone(_attributes, new ConveyorRecipe(_woodLogConfig, _woodPlankConfig));
            
            _cts = new CancellationTokenSource(_ctsMillis);
            _conveyor = new Conveyor(_loadZone, _unloadZone, _workZone, _cts);
        }

        [Test]
        public async Task WhenAddWoodLogToLoadZone_AndLoadZoneIsEmpty_ThenLoadZoneHaveWoodLog()
        {
            await _loadZone.AddResourceAsync(_woodLog, _cts);
            var loadedResource = await _loadZone.GetNextResourceAsync(_cts);
            Assert.AreEqual(loadedResource, _woodLog);
        }
        
        [Test]
        public async Task WhenAddWoodLogToLoadZone_AndLoadZoneIsFull_ThenLoadZoneDoesNotHaveWoodLog()
        {
            for (int i = 0; i < _attributes.MaxLoadZoneCapacity; i++)
            {
                await _loadZone.AddResourceAsync(_woodPlank, _cts);
            }
            
            await _loadZone.AddResourceAsync(_woodLog, _cts);
            var loadedResource = await _loadZone.GetNextResourceAsync(_cts);
            Assert.AreNotEqual(loadedResource, _woodLog);
        }
        
        [Test]
        public async Task WhenAddWoodLogToUnloadZone_AndUnloadZoneIsEmpty_ThenUnloadZoneHaveWoodLog()
        {
            await _unloadZone.AddResourceAsync(_woodLog, _cts);
            var unloadedResource = await _unloadZone.GetNextResourceAsync(_cts);
            
            Assert.AreEqual(unloadedResource, _woodLog);
        }
        
        [Test]
        public async Task WhenAddWoodLogToUnloadZone_AndUnloadZoneIsFull_ThenUnloadZoneDoesNotHaveWoodLog()
        {
            for (int i = 0; i < _attributes.MaxUnloadZoneCapacity; i++)
            {
                await _unloadZone.AddResourceAsync(_woodPlank, _cts);
            }
            
            await _unloadZone.AddResourceAsync(_woodLog, _cts);
            
            Assert.AreNotEqual(_unloadZone.GetNextResourceAsync(_cts), _woodLog);
        }
        
        [Test]
        public async Task WhenWoodLogResourceInWorkZone_AndWorkZoneIsNotBusy_ThenProduceWoodPlankResource()
        {
            var convertedWoodPlank = await _workZone.ConvertResourceAsync(_woodLog, _cts);
            
            Assert.AreEqual(convertedWoodPlank.Name, _woodPlank.Name);
        }
        
        [Test]
        public async Task WhenWoodLogResourceAddInLoadZone_AndWorkZoneIsNotBusy_ThenProduceWoodPlankResource()
        {
            await _conveyor.AddResourceAsync(_woodLog);
            await _conveyor.ConvertNextResource();
            var unloadedResource = await _conveyor.GetConvertedResourceAsync();
            
            
            Assert.AreEqual(unloadedResource.Name, _woodPlank.Name);
        }
        
        [Test]
        public async Task WhenWoodPlankResourceAddInLoadZone_AndWorkZoneIsNotBusy_ThenUnloadedResourceIsDefault()
        {
            await _conveyor.AddResourceAsync(_woodPlank);
            await _conveyor.ConvertNextResource();
            var unloadedResource = await _conveyor.GetConvertedResourceAsync();
            
            Assert.AreEqual(unloadedResource, default);
        }
    }
}
