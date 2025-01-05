using System;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    [Serializable]
    public sealed class ConveyorAttributes
    {
        public int MaxUnloadZoneCapacity
        {
            get => _maxUnloadZoneCapacity;
            set => _maxUnloadZoneCapacity = value;
        }
        public int MaxLoadZoneCapacity 
        {
            get => _maxLoadZoneCapacity;
            set => _maxLoadZoneCapacity = value;
        }
        public float BaseWorkTime
        {
            get => _baseWorkTime;
            set => _baseWorkTime = value;
        }
        
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