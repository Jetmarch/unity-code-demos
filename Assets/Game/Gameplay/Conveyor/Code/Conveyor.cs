using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    [Serializable]
    public sealed class Conveyor
    {
        public event Action OnAddResourceToInput;
        public event Action OnRemoveResourceFromInput;
        public event Action OnAddResourceToOutput;
        public event Action OnRemoveResourceFromOutput;
        public event Action OnStartConvert;
        public event Action OnFinishConvert;
        [ShowInInspector] public ConveyorAttributes Attributes => _attributes;
        
        private readonly ConveyorTransportZone _input;
        private readonly ConveyorTransportZone _output;
        private readonly ConveyorWorkZone _workZone;
        private readonly ConveyorAttributes _attributes;
        
        private readonly CancellationTokenSource _cts;

        public Conveyor(ConveyorZones zones, ConveyorAttributes attributes, CancellationTokenSource cancellationTokenSource)
        {
            _input = zones.InputZone;
            _output = zones.OutputZone;
            _workZone = zones.WorkZone;
            _attributes = attributes;
            _cts = cancellationTokenSource;
        }

        public async UniTask AddResourceAsync(ConveyorResource resource)
        {
            await _input.AddResourceAsync(resource, _cts);
            OnAddResourceToInput?.Invoke();
        }

        public async UniTask<ConveyorResource> GetConvertedResourceAsync()
        {
            var resource = await _output.GetNextResourceAsync(_cts);
            OnRemoveResourceFromOutput?.Invoke();
            return resource;
        }

        public async UniTask ConvertNextResourceAsync()
        {
            var resource = await _input.GetNextResourceAsync(_cts);
            OnRemoveResourceFromInput?.Invoke();
            OnStartConvert?.Invoke();
            var convertedResource = await _workZone.ConvertResourceAsync(resource, _cts);
            OnFinishConvert?.Invoke();
            await _output.AddResourceAsync(convertedResource, _cts);
            OnAddResourceToOutput?.Invoke();
        }
    }
}
