using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyDestroyObserver : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        private void OnEnable()
        {
            _enemySpawner.OnEnemyDestroyed += OnEnemyDestroyed;
        }

        private void OnDisable()
        {
            _enemySpawner.OnEnemyDestroyed -= OnEnemyDestroyed;
        }

        private void OnEnemyDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnDeath -= _enemySpawner.DestroyEnemy;
        }
    }
}