using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;
using UnityEngine;

namespace OtusHomework.ECS.Systems
{
    public sealed class TimeToLiveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TimeToLive>> _filter;
        
        private readonly EcsPoolInject<DeathFlag> _deathFlagPool;
        
        public void Run(IEcsSystems systems)
        {
            var timeToLivePool = _filter.Pools.Inc1;
            
            foreach (var entity in _filter.Value)
            {
                ref var timeToLive = ref timeToLivePool.Get(entity);
                timeToLive.Value -= Time.deltaTime;

                if (timeToLive.Value <= 0)
                {
                    _deathFlagPool.Value.Add(entity);
                }
            }
        }
    }
}