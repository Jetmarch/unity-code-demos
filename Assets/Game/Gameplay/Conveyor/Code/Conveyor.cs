using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

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

        public void AddResource(ConveyorResource resource)
        {
            if (_input.TryAddResource(resource))
            {
                OnAddResourceToInput?.Invoke();
            }
        }

        public ConveyorResource GetConvertedResource()
        {
            if (!_output.TryGetNextResource(out var resource)) return default;
            
            OnRemoveResourceFromOutput?.Invoke();
            return resource;
        }

        public async UniTask ConvertNextResource()
        {
            if (!_output.CanLoadResource())
            {
                return;
            }

            if (_workZone.IsBusy)
            {
                return;
            }
            
            if (!_input.TryGetNextResource(out var resource))
            {
                return;
            }
            
            OnRemoveResourceFromInput?.Invoke();
            
            OnStartConvert?.Invoke();
            var convertedResource = await _workZone.ConvertResourceAsync(resource, _cts);
            OnFinishConvert?.Invoke();
            
            if (_output.TryAddResource(convertedResource))
            {
                OnAddResourceToOutput?.Invoke();
            }
        }
    }
}
