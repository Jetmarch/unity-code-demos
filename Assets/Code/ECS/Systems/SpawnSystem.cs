using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using OtusHomework.ECS.Components;

namespace OtusHomework.ECS.Systems
{
    public sealed class SpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpawnRequest, Prefab, Position, Rotation>> _filter = EcsWorlds.Events;
        
        private readonly EcsWorldInject _eventWorld = EcsWorlds.Events;
        private readonly EcsCustomInject<EntityManager> _entityManager;
        
        public void Run(IEcsSystems systems)
        {
            var prefabPool = _filter.Pools.Inc2;
            var positionPool = _filter.Pools.Inc3;
            var rotationPool = _filter.Pools.Inc4;
            
            foreach (var entity in _filter.Value)
            {
                var prefab = prefabPool.Get(entity);
                var position = positionPool.Get(entity);
                var rotation = rotationPool.Get(entity);
                _entityManager.Value.Create(prefab.Value, position.Value, rotation.Value);

                _eventWorld.Value.DelEntity(entity);
            }
        }
    }
}