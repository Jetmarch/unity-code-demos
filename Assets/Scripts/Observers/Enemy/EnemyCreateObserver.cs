using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCreateObserver : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;

        private void OnEnable()
        {
            _enemySpawner.OnEnemySpawned += OnEnemySpawned;
        }

        private void OnDisable()
        {
            _enemySpawner.OnEnemySpawned -= OnEnemySpawned;
        }

        private void OnEnemySpawned(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnDeath += _enemySpawner.DestroyEnemy;
        }
    }
}