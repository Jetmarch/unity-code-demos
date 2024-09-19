using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameObjectPool : MonoBehaviour
    {
        [SerializeField] private int _initialCount = 50;

        [SerializeField] private Transform _container;

        [SerializeField] private GameObject _prefab;

        [SerializeField] private bool _isInstatiateOnEmpty;

        private readonly Queue<GameObject> _objectPool = new();

        private void Awake()
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var obj = Instantiate(_prefab, _container);
                _objectPool.Enqueue(obj);
            }
        }

        public GameObject GetObject()
        {
            if (!_objectPool.TryDequeue(out var obj))
            {
                if (_isInstatiateOnEmpty)
                {
                    return Instantiate(_prefab);
                }

                return null;
            }

            return obj;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.transform.SetParent(_container);
            _objectPool.Enqueue(obj);
        }
    }
}