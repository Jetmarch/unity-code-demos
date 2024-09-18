using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _maxEnemyCount = 7;

        private readonly Queue<GameObject> _enemyPool = new();

        private void Awake()
        {
            for (var i = 0; i < _maxEnemyCount; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!_enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }
    }
}