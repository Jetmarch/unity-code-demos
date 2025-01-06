using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorTransportZoneView : MonoBehaviour
    {
        [SerializeField] private GameObject _resourcePrefab;
        [SerializeField] private float _yAxisOffset = 1f;
        private readonly Stack<GameObject> _resources = new();
        
        [Button]
        public void AddResource()
        {
            var resourcePosition = transform.position;
            resourcePosition.y += _yAxisOffset * _resources.Count;
            var resource = Instantiate(_resourcePrefab, resourcePosition, Quaternion.identity, transform);
            
            _resources.Push(resource);
        }
        [Button]
        public void RemoveResource()
        {
            if (_resources.Count <= 0) return;
            
            var resource = _resources.Pop();
            Destroy(resource);
        }
    }
}