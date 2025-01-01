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

        [SetUp]
        public void Configure()
        {
            _attributes = new ConveyorAttributes(4, 4,0.1f);
            _woodLog = new ConveyorResource("woodLog");
            _woodPlank = new ConveyorResource("woodPlank");
            _loadZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Load);
            _unloadZone = new ConveyorTransportZone(_attributes, ConveyorTransportZoneType.Unload);
            _workZone = new ConveyorWorkZone(_attributes, new ConveyorRecipe(_woodLog, _woodPlank));
        }

        [Test]
        public void WhenAddWoodLogToLoadZone_AndLoadZoneIsEmpty_ThenLoadZoneHaveWoodLog()
        {
            _loadZone.AddResource(_woodLog);
            
            Assert.AreEqual(_loadZone.GetNextResource(), _woodLog);
        }
        
        [Test]
        public void WhenAddWoodLogToLoadZone_AndLoadZoneIsFull_ThenLoadZoneDoesNotHaveWoodLog()
        {
            for (int i = 0; i < _attributes.MaxLoadZoneCapacity; i++)
            {
                _loadZone.AddResource(_woodPlank);
            }
            
            _loadZone.AddResource(_woodLog);
            
            Assert.AreNotEqual(_loadZone.GetNextResource(), _woodLog);
        }
        
        [Test]
        public void WhenAddWoodLogToUnloadZone_AndUnloadZoneIsEmpty_ThenUnloadZoneHaveWoodLog()
        {
            _unloadZone.AddResource(_woodLog);
            
            Assert.AreEqual(_unloadZone.GetNextResource(), _woodLog);
        }
        
        [Test]
        public void WhenAddWoodLogToUnloadZone_AndUnloadZoneIsFull_ThenUnloadZoneDoesNotHaveWoodLog()
        {
            for (int i = 0; i < _attributes.MaxUnloadZoneCapacity; i++)
            {
                _unloadZone.AddResource(_woodPlank);
            }
            
            _unloadZone.AddResource(_woodLog);
            
            Assert.AreNotEqual(_unloadZone.GetNextResource(), _woodLog);
        }
        
        [Test]
        public async Task WhenWoodLogResourceInWorkZone_AndWorkZoneIsNotBusy_ThenProduceWoodPlankResource()
        {
            var convertedWoodPlank = await _workZone.ConvertResource(_woodLog);
            
            Assert.AreEqual(convertedWoodPlank.Name, _woodPlank.Name);
        }
        
        [Test]
        public async Task WhenWoodLogResourceAddInLoadZone_AndWorkZoneIsNotBusy_ThenProduceWoodPlankResource()
        {
            _loadZone.AddResource(_woodLog);
            var convertedResource = await _workZone.ConvertResource(_loadZone.GetNextResource());
            _unloadZone.AddResource(convertedResource);
            
            Assert.AreEqual(_unloadZone.GetNextResource().Name, _woodPlank.Name);
        }
    }
}
