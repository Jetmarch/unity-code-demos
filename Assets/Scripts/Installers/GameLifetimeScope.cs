using ShootEmUp.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("World")] 
        [SerializeField] private Transform _worldTransform;

        [Header("Enemy")] 
        [SerializeField] private GameObjectPoolParams _enemyPoolParams;
        
        [Header("Character")]
        [SerializeField] private GameObject _characterPrefab;
        
        [Header("Bullet")]
        [SerializeField] private GameObjectPoolParams _bulletPoolParams;
        
        [Header("UI")]
        [SerializeField] private string _pauseText;
        [SerializeField] private string _resumeText;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterGameSystem(builder);
            RegisterWorld(builder);
            RegisterEnemy(builder);
            RegisterCharacter(builder);
            RegisterBullet(builder);
            RegisterUI(builder);
            RegisterControllers(builder);
        }

        private void RegisterGameSystem(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManager>();
            builder.RegisterComponentInHierarchy<StartGameTimer>();
            builder.RegisterComponentInHierarchy<InputManager>();
            builder.Register<GameListenerInstaller>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterWorld(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<LevelBounds>();
        }

        private void RegisterEnemy(IContainerBuilder builder)
        {
            builder.Register<EnemyManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<EnemyPositions>();
            builder.Register<EnemySpawnerProvider>(Lifetime.Singleton)
                .WithParameter(new GameObjectPool(_enemyPoolParams))
                .WithParameter(_worldTransform);
            builder.Register<EnemySpawner>(Lifetime.Singleton);
        }

        private void RegisterCharacter(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<Character>().AsImplementedInterfaces().AsSelf();
        }

        private void RegisterBullet(IContainerBuilder builder)
        {
            builder.Register<BulletManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BulletFactoryProvider>(Lifetime.Singleton)
                .WithParameter(new GameObjectPool(_bulletPoolParams))
                .WithParameter(_worldTransform);
            builder.Register<BulletFactory>(Lifetime.Singleton);
            builder.Register<BulletLevelBoundsChecker>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterUI(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameView>();
            builder.RegisterComponentInHierarchy<StartGameView>();
        }

        private void RegisterControllers(IContainerBuilder builder)
        {
            builder.Register<GameUIController>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<StartGameController>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<PlayerMoveObserver>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerFireObserver>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerDeathObserver>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<EnemyCreateDestroyObserver>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BulletDestroyOnCollisionObserver>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}