using System;
using System.Collections.Generic;

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

        public bool TryAddResource(ConveyorResource resource)
        {
            if (!CanLoadResource())
            {
                return false;
            }
            
            _resourceQueue.Enqueue(resource);
            return true;
        }

        public bool CanLoadResource()
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

        public bool TryGetNextResource(out ConveyorResource resource)
        {
            if (_resourceQueue.Count == 0)
            {
                resource = default;
                return false;
            }
            
            resource = _resourceQueue.Dequeue();
            return true;
        }
    }
}