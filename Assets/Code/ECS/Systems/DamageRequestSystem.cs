using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;

namespace OtusHomework.ECS.Systems
{
    public sealed class DamageRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageRequest>> _filter;
        
        private readonly EcsPoolInject<Health> _healthPool;
        private readonly EcsPoolInject<DeathFlag> _deathFlagPool;
        
        public void Run(IEcsSystems systems)
        {
            var damageRequestPool = _filter.Pools.Inc1;
            
            foreach (var entity in _filter.Value)
            {
                if (!_healthPool.Value.Has(entity))
                {
                    damageRequestPool.Del(entity);
                    continue;
                }
                
                ref var health = ref _healthPool.Value.Get(entity);
                var damageRequest = damageRequestPool.Get(entity);
                
                health.Value -= damageRequest.Value;

                if (health.Value <= 0)
                {
                    _deathFlagPool.Value.Add(entity);
                }
                damageRequestPool.Del(entity);
            }
        }
    }
}