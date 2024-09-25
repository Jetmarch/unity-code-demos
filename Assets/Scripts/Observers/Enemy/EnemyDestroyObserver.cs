using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyDestroyObserver : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemyManager;

        [SerializeField] private EnemyFireHelper _enemyFireController;
        private void OnEnable()
        {
            _enemyManager.OnEnemyDestroyed += OnEnemyDestroyed;
        }

        private void OnDisable()
        {
            _enemyManager.OnEnemyDestroyed -= OnEnemyDestroyed;
        }

        private void OnEnemyDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnDeath -= _enemyManager.DestroyEnemy;
            enemy.GetComponent<EnemyAttackAgent>().OnFire -= _enemyFireController.OnFire;
        }
    }
}