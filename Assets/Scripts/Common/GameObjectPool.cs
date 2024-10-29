using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class GameObjectPool
    {
        private readonly GameObjectPoolParams _poolParams;

        private readonly Queue<GameObject> _objectPool = new();

        public GameObjectPool(GameObjectPoolParams poolParams)
        {
            _poolParams = poolParams;
            InitializePool();
        }
        
        private void InitializePool()
        {
            for (var i = 0; i < _poolParams.InitialCount; i++)
            {
                var obj = Object.Instantiate(_poolParams.Prefab, _poolParams.Container);
                _objectPool.Enqueue(obj);
            }
        }

        public GameObject GetObject()
        {
            if (!_objectPool.TryDequeue(out var obj))
            {
                if (_poolParams.IsInstatiateOnEmpty)
                {
                    return Object.Instantiate(_poolParams.Prefab);
                }

                return null;
            }

            return obj;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.transform.SetParent(_poolParams.Container);
            _objectPool.Enqueue(obj);
        }
    }
}