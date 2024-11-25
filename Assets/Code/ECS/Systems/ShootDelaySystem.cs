using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;
using UnityEngine;

namespace OtusHomework.ECS.Systems
{
    public sealed class ShootDelaySystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ActionDelay>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            var actionDelayPool = _filter.Pools.Inc1;
            foreach (var entity in _filter.Value)
            {
                ref var actionDelay = ref actionDelayPool.Get(entity);
                actionDelay.Value -= Time.deltaTime;

                if (actionDelay.Value <= 0)
                {
                    actionDelayPool.Del(entity);
                }
            }
        }
    }
}