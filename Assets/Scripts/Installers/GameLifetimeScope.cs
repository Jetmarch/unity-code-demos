using ShootEmUp.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private string _pauseText;
        [SerializeField] private string _resumeText;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManager>();
            builder.RegisterComponentInHierarchy<BulletFactory>();
            builder.RegisterComponentInHierarchy<LevelBounds>();
            builder.RegisterComponentInHierarchy<EnemyPositions>();
            builder.RegisterComponentInHierarchy<EnemySpawner>();
            builder.RegisterComponentInHierarchy<Character>();
            //TODO: Remove to PlayerLifetimeScope
            builder.RegisterComponentInHierarchy<HitPointsComponent>();
            builder.RegisterComponentInHierarchy<StartGameTimer>();
            builder.RegisterComponentInHierarchy<InputManager>();
            builder.Register<GameListenerInstaller>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<BulletManager>(Lifetime.Singleton).AsImplementedInterfaces();
            
            RegisterUI(builder);
            RegisterControllers(builder);
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