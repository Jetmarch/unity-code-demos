using System;
using UnityEngine;


namespace ShootEmUp
{
    public class EnemyEventListener : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        public event Action<Enemy> OnEnemyReachedDestination;
        public event Action<Enemy> OnEnemyDeath;

        [SerializeField]
        private EnemySpawner _enemySpawner;

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

        private void OnEnemySpawned(Enemy obj)
        {
            
        }

        private void OnEnemyDestroyed(Enemy obj)
        {
            
        }

        
    }
}