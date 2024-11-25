using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using OtusHomework.ECS.Components;

namespace OtusHomework.ECS.Systems
{
    public sealed class TransformViewSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Position, TransformView>> _filter;
        private readonly EcsPoolInject<Rotation> _rotationPool;
        
        public void Run(IEcsSystems systems)
        {
            var positionPool = _filter.Pools.Inc1;
            var transformViewPool = _filter.Pools.Inc2;
            
            foreach (var entity in _filter.Value)
            {
                var position = positionPool.Get(entity);
                ref var transformView = ref transformViewPool.Get(entity);
                
                transformView.Value.position = position.Value;

                if (!_rotationPool.Value.Has(entity)) continue;
                
                var rotation = _rotationPool.Value.Get(entity).Value;
                transformView.Value.rotation = rotation;
            }
        }
    }
}