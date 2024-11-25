using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;

namespace OtusHomework.ECS.Systems
{
    public class UnitPushForwardSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Unit, MoveDirection, TransformView>, Exc<Target>> _filter;
        
        public void Run(IEcsSystems systems)
        {
            var moveDirectionPool = _filter.Pools.Inc2;
            var transformViewPool = _filter.Pools.Inc3;
            
            foreach (var entity in _filter.Value)
            {
                ref var moveDirection = ref moveDirectionPool.Get(entity);
                var transformView = transformViewPool.Get(entity);

                moveDirection.Value = transformView.Value.forward;
            }
        }
    }
}