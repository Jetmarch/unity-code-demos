using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;

namespace OtusHomework.ECS.Systems
{
    public sealed class ShootToTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Target, BulletWeapon, AttackDistance, Position>> _filter;

        private readonly EcsPoolInject<FireRequest> _fireRequestPool;

        public void Run(IEcsSystems systems)
        {
            var targetPool = _filter.Pools.Inc1;
            var attackDistancePool = _filter.Pools.Inc3;
            var positionPool = _filter.Pools.Inc4;

            foreach (var entity in _filter.Value)
            {
                if (_fireRequestPool.Value.Has(entity)) continue;
                
                var target = targetPool.Get(entity);
                var attackDistance = attackDistancePool.Get(entity);
                var position = positionPool.Get(entity);

                if (!positionPool.Has(target.Value.Id)) continue;

                var targetPosition = positionPool.Get(target.Value.Id);

                if ((targetPosition.Value - position.Value).sqrMagnitude >
                    (attackDistance.Value * attackDistance.Value)) continue;
                
                _fireRequestPool.Value.Add(entity);
            }
        }
    }
}