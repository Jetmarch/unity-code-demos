using System.Threading;
using Cysharp.Threading.Tasks;

namespace Game.Gameplay.Conveyor
{
    public sealed class Conveyor
    {
        private readonly ConveyorTransportZone _input;
        private readonly ConveyorTransportZone _output;
        private readonly ConveyorWorkZone _workZone;
        
        private readonly CancellationTokenSource _cts;

        public Conveyor(ConveyorTransportZone input,
                                ConveyorTransportZone output, 
                                ConveyorWorkZone workZone, 
                                CancellationTokenSource cancellationTokenSource)
        {
            _input = input;
            _output = output;
            _workZone = workZone;
            _cts = cancellationTokenSource;
        }

        public async UniTask AddResourceAsync(ConveyorResource resource)
        {
            await _input.AddResourceAsync(resource, _cts);
        }

        public async UniTask<ConveyorResource> GetConvertedResourceAsync()
        {
            var resource = await _output.GetNextResourceAsync(_cts);
            return resource;
        }

        public async UniTask ConvertNextResource()
        {
            var resource = await _input.GetNextResourceAsync(_cts);
            var convertedResource = await _workZone.ConvertResourceAsync(resource, _cts);
            await _output.AddResourceAsync(convertedResource, _cts);
        }
    }
}
