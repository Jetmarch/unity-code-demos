using System;
using System.Collections.Generic;

namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorTransportZone
    {
        public event Action OnResourceLoaded;
        public event Action OnZoneFull;
        
        private readonly ConveyorAttributes _attributes;
        private readonly Queue<ConveyorResource> _resourceQueue;
        private readonly ConveyorTransportZoneType _type;
        public ConveyorTransportZone(ConveyorAttributes attributes, ConveyorTransportZoneType type)
        {
            _attributes = attributes;
            _type = type;
            _resourceQueue = new Queue<ConveyorResource>();
        }

        public void AddResource(ConveyorResource resource)
        {
            if (!CanLoadResource())
            {
                OnZoneFull?.Invoke();
                return;
            }
            
            if (_resourceQueue.Count >= _attributes.MaxLoadZoneCapacity)
            {
                OnZoneFull?.Invoke();
                return;
            }
            
            _resourceQueue.Enqueue(resource);
            OnResourceLoaded?.Invoke();
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

        public ConveyorResource GetNextResource()
        {
            if (_resourceQueue.TryDequeue(out var resource))
            {
                return resource;
            }

            return default;
        }
    }

    public enum ConveyorTransportZoneType : byte
    {
        Load,
        Unload
    }
}