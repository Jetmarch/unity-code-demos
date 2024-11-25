using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using OtusHomework.ECS.Components;

namespace OtusHomework.ECS.Systems
{
    public sealed class DeathSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DeathFlag, TransformView>> _filter;
        
        private readonly EcsCustomInject<EntityManager> _entityManager;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                _entityManager.Value.Destroy(entity);
            }
        }
    }
}