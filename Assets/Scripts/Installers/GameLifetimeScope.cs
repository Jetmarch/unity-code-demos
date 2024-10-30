using ShootEmUp.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Game System")]
        [SerializeField] private string _horizontalInputAxisName = "Horizontal";
        [SerializeField] private int _startGameDelayInSeconds = 3;

        [Header("World")]
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBackgroundMoverData _levelBackgroundMoverData;
        [SerializeField] private LevelBoundsData _levelBoundsData;

        [Header("Enemy")]
        [SerializeField] private EnemyPositionsData _enemyPositionsData;
        [SerializeField] private float _enemySpawnDelay;
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
            builder.Register<StartGameTimer>(Lifetime.Singleton)
                .WithParameter(_startGameDelayInSeconds);
            builder.Register<InputManager>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf()
                .WithParameter(_horizontalInputAxisName);
            builder.Register<GameListenerInstaller>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterWorld(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<LevelBounds>();
            builder.Register<LevelBackgroundMover>(Lifetime.Singleton).AsImplementedInterfaces()
                .WithParameter(_levelBackgroundMoverData);
            builder.Register<LevelBounds>(Lifetime.Singleton)
                .WithParameter(_levelBoundsData);
        }

        private void RegisterEnemy(IContainerBuilder builder)
        {
            builder.Register<EnemyManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<EnemyPositions>(Lifetime.Singleton)
                .WithParameter(_enemyPositionsData);
            builder.Register<EnemySpawnerProvider>(Lifetime.Singleton)
                .WithParameter(new GameObjectPool(_enemyPoolParams))
                .WithParameter(_worldTransform);
            builder.Register<EnemySpawner>(Lifetime.Singleton);
            builder.Register<EnemySpawnInteractor>(Lifetime.Singleton).AsImplementedInterfaces()
                .WithParameter(_enemySpawnDelay);
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