using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner
    {
        public IReadOnlyCollection<Enemy> ActiveEnemies => _activeEnemies;
        public event Action<Enemy> OnEnemySpawned;
        public event Action<Enemy> OnEnemyDestroyed;

        private readonly EnemySpawnerProvider _spawnerProvider;

        private readonly HashSet<Enemy> _activeEnemies = new();
        private EnemySpawner(EnemySpawnerProvider spawnerProvider)
        {
            _spawnerProvider = spawnerProvider;
        }

        public void CreateEnemy()
        {
            var enemy = _spawnerProvider.Pool.GetObject()?.GetComponent<Enemy>();

            if (enemy == null)
            {
                Debug.LogWarning("CreateEnemy: enemy object from poll was null");
                return;
            }

            enemy.transform.SetParent(_spawnerProvider.WorldTransform);

            var spawnPosition = _spawnerProvider.EnemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _spawnerProvider.EnemyPositions.RandomAttackPosition();

            enemy.Construct(_spawnerProvider.BulletFactory, _spawnerProvider.Character.gameObject, attackPosition.position);

            _activeEnemies.Add(enemy);
            OnEnemySpawned?.Invoke(enemy);
        }

        public void DestroyEnemy(Enemy enemy)
        {
            if (!_activeEnemies.Remove(enemy)) return;

            OnEnemyDestroyed?.Invoke(enemy);
            _spawnerProvider.Pool.ReturnObject(enemy.gameObject);
        }
    }
}