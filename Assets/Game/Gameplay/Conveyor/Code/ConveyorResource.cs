using System;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    [Serializable]
    public sealed class ConveyorResource
    {
        public string Name => _name;
        public float ConvertTimeModifier => _convertTimeModifier;

        [SerializeField] private string _name;
        [SerializeField] private float _convertTimeModifier;
        
        public ConveyorResource(string name, float convertTimeModifier = 1f)
        {
            _name = name;
            _convertTimeModifier = convertTimeModifier;
        }
    }
}