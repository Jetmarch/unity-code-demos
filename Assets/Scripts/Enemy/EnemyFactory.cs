using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;

        [SerializeField] private GameObject _character;

        [SerializeField] private Transform _worldTransform;

        public GameObject ConstructEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_character);
            return enemy;
        }
    }
}