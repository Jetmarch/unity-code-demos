using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;

namespace OtusHomework.ECS.Systems
{
    public sealed class CheckTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Target>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            var targetPool = _filter.Pools.Inc1;

            foreach (var entity in _filter.Value)
            {
                var target = targetPool.Get(entity);

                if (target.Value.IsAlive()) continue;
                
                targetPool.Del(entity);
            }
        }
    }
}