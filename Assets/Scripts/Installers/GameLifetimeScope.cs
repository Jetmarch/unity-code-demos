using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameManager>();
            builder.RegisterComponentInHierarchy<BulletFactory>();
            builder.RegisterComponentInHierarchy<LevelBounds>();
            builder.RegisterComponentInHierarchy<EnemyPositions>();
            builder.RegisterComponentInHierarchy<EnemySpawner>();
            builder.RegisterComponentInHierarchy<Character>();
        }
    }
}