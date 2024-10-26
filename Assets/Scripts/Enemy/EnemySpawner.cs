using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        public event Action<Enemy> OnEnemySpawned;

        public event Action<Enemy> OnEnemyDestroyed;

        [SerializeField] private GameObjectPool _enemyPool;

        [SerializeField] private Transform _worldTransform;
        
        // [SerializeField] private GameObject _character;
        
        private Character _character;
        
        private EnemyPositions _enemyPositions;
        
        private BulletFactory _bulletFactory;

        private readonly HashSet<Enemy> _activeEnemies = new();

        [Inject]
        private void Construct(BulletFactory bulletFactory, EnemyPositions enemyPositions, Character character)
        {
            _bulletFactory = bulletFactory;
            _enemyPositions = enemyPositions;
            _character = character;
        }
        
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

            enemy.Construct(_bulletFactory, _character.gameObject, attackPosition.position);

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