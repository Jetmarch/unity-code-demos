using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;
using UnityEngine;

namespace OtusHomework.ECS.Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Position, MoveDirection, MoveSpeed>> _filter;

        
        public void Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;

            var positionPool = _filter.Pools.Inc1;
            var moveDirectionPool = _filter.Pools.Inc2;
            var moveSpeedPool = _filter.Pools.Inc3;
            
            foreach (var entity in _filter.Value)
            {
                ref var position = ref positionPool.Get(entity);
                var moveDirection = moveDirectionPool.Get(entity);
                var moveSpeed = moveSpeedPool.Get(entity);
                
                position.Value += moveDirection.Value * (moveSpeed.Value * deltaTime);
            }
        }
    }
}