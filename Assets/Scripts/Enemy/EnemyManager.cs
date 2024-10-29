
namespace ShootEmUp
{
    public class EnemyManager : IGameFixedUpdateListener, IGamePauseListener, IGameResumeListener, IGameFinishListener
    {
        private readonly EnemySpawner _enemySpawner;
        
        public EnemyManager(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }
        
        public void OnPause()
        {
            foreach (var enemy in _enemySpawner.ActiveEnemies)
            {
                enemy.Deactivate();
            }
        }

        public void OnResume()
        {
            foreach (var enemy in _enemySpawner.ActiveEnemies)
            {
                enemy.Activate();
            }
        }

        public void OnFinish()
        {
            foreach (var enemy in _enemySpawner.ActiveEnemies)
            {
                enemy.Deactivate();
            }
        }

        public void OnFixedUpdate(float fixedDelta)
        {
            foreach (var enemy in _enemySpawner.ActiveEnemies)
            {
                enemy.OnFixedUpdate(fixedDelta);
            }
        }
    }
}