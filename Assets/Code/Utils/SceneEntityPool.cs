using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Utils
{
    public interface IEntityPool
    {
        public IEntity Get();
        public void Return(IEntity entity);
    }
    
    public sealed class SceneEntityPool : IEntityPool
    {
        private readonly SceneEntity _prefab;
        private readonly Transform _worldTransform;
        private readonly Transform _poolTransform;

        private readonly Queue<SceneEntity> _entities = new();


        public SceneEntityPool(SceneEntity prefab, Transform worldTransform, Transform poolTransform,  int initialCount = 0)
        {
            _prefab = prefab;
            _worldTransform = worldTransform;
            _poolTransform = poolTransform;

            for (int i = 0; i < initialCount; i++)
            {
                var sceneEntity = SceneEntity.Instantiate(_prefab, _poolTransform);
                _entities.Enqueue(sceneEntity);
            }
        }

        public IEntity Get()
        {
            if (_entities.TryDequeue(out var entity))
            {
                entity.transform.SetParent(_worldTransform);
                return entity;
            }
            
            return SceneEntity.Instantiate(_prefab, _worldTransform);
        }

        public void Return(IEntity entity)
        {
            var sceneEntity = SceneEntity.Cast(entity);
            sceneEntity.transform.SetParent(_poolTransform);
            _entities.Enqueue(sceneEntity);
        }
    }
}