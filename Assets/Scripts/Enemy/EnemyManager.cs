using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        public Action<GameObject> OnEnemySpawned;

        public Action<GameObject> OnEnemyDestroyed;

        [SerializeField] private float _spawnDelay = 1f;

        [SerializeField] private GameObjectPool _enemyPool;

        [SerializeField] private EnemyFactory _enemyFactory;

        private readonly HashSet<GameObject> _activeEnemies = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                CreateEnemy();
            }
        }

        public void CreateEnemy()
        {
            var enemy = _enemyPool.GetObject();

            if (enemy == null)
            {
                Debug.LogWarning("CreateEnemy: enemy object from poll was null");
                return;
            }

            _enemyFactory.ConstructEnemy(enemy);
            _activeEnemies.Add(enemy);
            OnEnemySpawned?.Invoke(enemy);
        }

        public void DestroyEnemy(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                OnEnemyDestroyed?.Invoke(enemy);
                _enemyPool.ReturnObject(enemy);
            }
        }
    }
}