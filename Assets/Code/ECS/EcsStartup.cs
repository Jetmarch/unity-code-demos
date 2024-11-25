using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using OtusHomework.ECS.Systems;
using UnityEngine;

namespace OtusHomework.ECS
{
    public sealed class EcsStartup : MonoBehaviour 
    {
        private EcsWorld _defaultWorld;        
        private EcsWorld _eventWorld;        
        private IEcsSystems _systems;
        private EntityManager _entityManager;

        private void Awake()
        {
            _entityManager = new EntityManager();
            _defaultWorld = new EcsWorld();
            _eventWorld = new EcsWorld();
            _systems = new EcsSystems(_defaultWorld);
            _systems.AddWorld(_eventWorld, EcsWorlds.Events);
            _systems
                .Add(new ArmySpawnSystem())
                .Add(new DamageRequestSystem())
                .Add(new DeathSystem())
                .Add(new FireRequestSystem())
                .Add(new ShootDelaySystem())
                .Add(new MovementSystem())
                .Add(new SpawnSystem())
                
                .Add(new CheckTargetSystem())
                .Add(new UnitPushForwardSystem())
                .Add(new MoveToTargetSystem())
                .Add(new ShootToTargetSystem())
                .Add(new TimeToLiveSystem())
                
                
                .Add(new TransformViewSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem(EcsWorlds.Events));
#endif
        }

        private void Start()
        {
            _entityManager.Initialize(_defaultWorld);
            _systems.Inject(_entityManager);
            _systems.Init();
        }
        
        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy() 
        {
            if (_systems != null) 
            {
                _systems.Destroy();
                _systems = null;
            }
            
            if (_eventWorld != null) 
            {
                _eventWorld.Destroy();
                _eventWorld = null;
            }
            
            if (_defaultWorld != null) 
            {
                _defaultWorld.Destroy();
                _defaultWorld = null;
            }
        }
    }
}