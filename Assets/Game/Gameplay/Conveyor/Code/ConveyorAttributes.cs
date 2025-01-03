using System;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    [Serializable]
    public sealed class ConveyorAttributes
    {
        public int MaxUnloadZoneCapacity => _maxUnloadZoneCapacity;
        public int MaxLoadZoneCapacity => _maxLoadZoneCapacity;
        public float BaseWorkTime => _baseWorkTime;
        
        [SerializeField] private int _maxUnloadZoneCapacity;
        [SerializeField] private int _maxLoadZoneCapacity;
        [SerializeField] private float _baseWorkTime;
        
        public ConveyorAttributes(int maxLoadZoneCapacity = 4, int maxUnloadZoneCapacity = 4, float baseWorkTime = 1f)
        {
            _maxUnloadZoneCapacity = maxUnloadZoneCapacity;
            _maxLoadZoneCapacity = maxLoadZoneCapacity;
            _baseWorkTime = baseWorkTime;
        }
    }
}