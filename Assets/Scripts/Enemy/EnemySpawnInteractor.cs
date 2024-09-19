using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawnInteractor : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 1f;
        
        [SerializeField] private EnemyManager _enemyManager;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                _enemyManager.CreateEnemy();
            }
        }
    }
}