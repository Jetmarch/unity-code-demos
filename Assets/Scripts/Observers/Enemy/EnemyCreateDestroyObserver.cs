namespace ShootEmUp
{
    public sealed class EnemyCreateDestroyObserver : IGameStartListener, IGameFinishListener
    {
        private readonly EnemySpawner _enemySpawner;

        public EnemyCreateDestroyObserver(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
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