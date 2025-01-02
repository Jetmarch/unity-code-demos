using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Game.Gameplay.Conveyor
{
    [Serializable]
    public sealed class ConveyorTransportZone
    {
        private readonly ConveyorAttributes _attributes;
        private readonly Queue<ConveyorResource> _resourceQueue;
        private readonly  ConveyorTransportZoneType _type;
        public ConveyorTransportZone(ConveyorAttributes attributes, ConveyorTransportZoneType type)
        {
            _attributes = attributes;
            _type = type;
            _resourceQueue = new Queue<ConveyorResource>();
        }

        public async UniTask AddResourceAsync(ConveyorResource resource, CancellationTokenSource cts)
        {
            if (!CanLoadResource())
            {
                await UniTask.WaitUntil(() => CanLoadResource() == true, cancellationToken: cts.Token);
                return;
            }
            
            _resourceQueue.Enqueue(resource);
        }

        private bool CanLoadResource()
        {
            switch (_type)
            {
                case ConveyorTransportZoneType.Load when _resourceQueue.Count >= _attributes.MaxLoadZoneCapacity:
                case ConveyorTransportZoneType.Unload when _resourceQueue.Count >= _attributes.MaxUnloadZoneCapacity:
                    return false;
                default:
                    return true;
            }
        }

        public async UniTask<ConveyorResource> GetNextResourceAsync(CancellationTokenSource cts)
        {
            if (_resourceQueue.Count == 0)
            {
                await UniTask.WaitUntil(() => _resourceQueue.Count > 0, cancellationToken: cts.Token);
            }
            
            var resource = _resourceQueue.Dequeue();

            return resource;
        }
    }

    [Serializable]
    public enum ConveyorTransportZoneType : byte
    {
        Load,
        Unload
    }
}