using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCreateObserver : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemyManager;

        [SerializeField] private EnemyFireHelper _enemyFireController;

        private void OnEnable()
        {
            _enemyManager.OnEnemySpawned += OnEnemySpawned;
        }

        private void OnDisable()
        {
            _enemyManager.OnEnemySpawned -= OnEnemySpawned;
        }

        private void OnEnemySpawned(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnDeath += _enemyManager.DestroyEnemy;
            enemy.GetComponent<EnemyAttackAgent>().OnFire += _enemyFireController.OnFire;
        }
    }
}