using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class EnemySpawnerProvider
    {
        public BulletFactory BulletFactory { get; private set; }
        public GameObjectPool Pool { get; private set; }
        public EnemyPositions EnemyPositions { get; private set; }
        public Character Character { get; private set; }
        public Transform WorldTransform { get; private set; }

        [Inject]
        public EnemySpawnerProvider(BulletFactory bulletFactory, GameObjectPool pool, EnemyPositions enemyPositions, Character character, Transform worldTransform)
        {
            BulletFactory = bulletFactory;
            Pool = pool;
            EnemyPositions = enemyPositions;
            Character = character;
            WorldTransform = worldTransform;
        }
    }
}