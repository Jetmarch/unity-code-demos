using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        public event Action<Enemy> OnEnemySpawned;

        public event Action<Enemy> OnEnemyDestroyed;

        [SerializeField] private GameObjectPool _enemyPool;

        [SerializeField] private EnemyPositions _enemyPositions;

        [SerializeField] private GameObject _character;

        [SerializeField] private Transform _worldTransform;

        [SerializeField] private BulletFactory _bulletFactory;

        private readonly HashSet<Enemy> _activeEnemies = new();


        public void CreateEnemy()
        {
            var enemy = _enemyPool.GetObject()?.GetComponent<Enemy>();

            if (enemy == null)
            {
                Debug.LogWarning("CreateEnemy: enemy object from poll was null");
                return;
            }

            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();

            enemy.Construct(_bulletFactory, _character, attackPosition.position);

            _activeEnemies.Add(enemy);
            OnEnemySpawned?.Invoke(enemy);
        }

        public void DestroyEnemy(Enemy enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                OnEnemyDestroyed?.Invoke(enemy);
                _enemyPool.ReturnObject(enemy.gameObject);
            }
        }
    }
}