using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCreateDestroyObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private EnemySpawner _enemySpawner;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnStart()
        {
            _enemySpawner.OnEnemySpawned += OnEnemySpawned;
            _enemySpawner.OnEnemyDestroyed += OnEnemyDestroyed;
        }

        public void OnFinish()
        {
            _enemySpawner.OnEnemySpawned -= OnEnemySpawned;
            _enemySpawner.OnEnemyDestroyed -= OnEnemyDestroyed;
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            enemy.OnDeath += _enemySpawner.DestroyEnemy;
        }

        private void OnEnemyDestroyed(Enemy enemy)
        {
            enemy.OnDeath -= _enemySpawner.DestroyEnemy;
        }
    }
}