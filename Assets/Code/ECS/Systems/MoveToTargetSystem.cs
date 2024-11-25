using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;
using UnityEngine;

namespace OtusHomework.ECS.Systems
{
    public sealed class MoveToTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Target, MoveDirection, Position, Rotation, AttackDistance>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            var targetPool = _filter.Pools.Inc1;
            var moveDirectionPool = _filter.Pools.Inc2;
            var positionPool = _filter.Pools.Inc3;
            var rotationPool = _filter.Pools.Inc4;
            var attackDistancePool = _filter.Pools.Inc5;
            
            foreach (var entity in _filter.Value)
            {
                var target = targetPool.Get(entity);
                ref var moveDirection = ref moveDirectionPool.Get(entity);
                var position = positionPool.Get(entity);
                ref var rotation = ref rotationPool.Get(entity);
                var attackDistance = attackDistancePool.Get(entity);

                if (!positionPool.Has(target.Value.Id)) continue;
                
                var targetPosition = positionPool.Get(target.Value.Id);

                var newMoveDirection = targetPosition.Value - position.Value;

                moveDirection.Value = newMoveDirection.sqrMagnitude <= (attackDistance.Value * attackDistance.Value) ? Vector3.zero : newMoveDirection.normalized;
                
                rotation.Value = Quaternion.LookRotation(newMoveDirection, Vector3.up);
            }
        }
    }
}