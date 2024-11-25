using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;

namespace OtusHomework.ECS.Systems
{
    public sealed class ArmySpawnSystem : IEcsInitSystem
    {
        private readonly EcsFilterInject<Inc<Position, Rotation, Prefab, SpawnPoint>> _filter;
        
        private readonly EcsWorldInject _eventWorld = EcsWorlds.Events;
        private readonly EcsPoolInject<SpawnRequest> _spawnRequestPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Position> _positionPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Rotation> _rotationPool = EcsWorlds.Events;
        private readonly EcsPoolInject<Prefab> _prefabPool = EcsWorlds.Events;
        
        public void Init(IEcsSystems systems)
        {
            var positionPool = _filter.Pools.Inc1;
            var rotationPool = _filter.Pools.Inc2;
            var prefabPool = _filter.Pools.Inc3;
            var spawnPointPool = _filter.Pools.Inc4;
            
            foreach (var entity in _filter.Value)
            {
                var position = positionPool.Get(entity);
                var rotation = rotationPool.Get(entity);
                var prefab = prefabPool.Get(entity);
                var spawnPoint = spawnPointPool.Get(entity);

                for (int i = 0; i < spawnPoint.SpawnCount; i++)
                {
                    var entityPosition =
                        (UnityEngine.Random.insideUnitSphere * spawnPoint.SpawnRadius) + position.Value;
                    entityPosition.y = position.Value.y;
                    
                    var spawnRequest = _eventWorld.Value.NewEntity();
                    _spawnRequestPool.Value.Add(spawnRequest);
                    _positionPool.Value.Add(spawnRequest) = new Position { Value = entityPosition };
                    _rotationPool.Value.Add(spawnRequest) = new Rotation { Value = rotation.Value };
                    _prefabPool.Value.Add(spawnRequest) = new Prefab { Value = prefab.Value };
                }
            }
        }
    }
}