using System;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    [Serializable]
    public sealed class ConveyorAttributes
    {
        [field: SerializeReference] public int MaxUnloadZoneCapacity { get; }
        [field: SerializeReference] public int MaxLoadZoneCapacity { get; }
        [field: SerializeReference] public float BaseWorkTime { get; }
        
        public ConveyorAttributes(int maxLoadZoneCapacity, int maxUnloadZoneCapacity, float baseWorkTime)
        {
            MaxLoadZoneCapacity = maxLoadZoneCapacity;
            BaseWorkTime = baseWorkTime;
            MaxUnloadZoneCapacity = maxUnloadZoneCapacity;
        }
    }
}