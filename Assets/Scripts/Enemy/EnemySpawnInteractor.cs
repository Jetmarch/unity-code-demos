
namespace ShootEmUp
{
    public class EnemySpawnInteractor : IGameStartListener, IGameFinishListener, IGameUpdateListener, IGamePauseListener, IGameResumeListener
    {
        private readonly float _spawnDelay = 1f;

        private readonly EnemySpawner _enemySpawner;

        private bool _isSpawnActive;
        private float _currentDelay;

        public EnemySpawnInteractor(EnemySpawner enemySpawner, float spawnDelay)
        {
            _enemySpawner = enemySpawner;
            _spawnDelay = spawnDelay;
            _isSpawnActive = true;
        }

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnStart()
        {
            StartSpawn();
        }

        public void OnFinish()
        {
            StopSpawn();
        }

        public void OnPause()
        {
            StopSpawn();
        }

        public void OnResume()
        {
            StartSpawn();
        }

        private void StartSpawn()
        {
            _isSpawnActive = true;
        }

        private void StopSpawn()
        {
            _isSpawnActive = false;
        }

        public void OnUpdate(float delta)
        {
            Spawn(delta);
        }

        private void Spawn(float delta)
        {
            if (!_isSpawnActive) return;

            _currentDelay += delta;

            if (!(_currentDelay >= _spawnDelay)) return;

            _enemySpawner.CreateEnemy();
            _currentDelay = 0f;
        }
    }
}