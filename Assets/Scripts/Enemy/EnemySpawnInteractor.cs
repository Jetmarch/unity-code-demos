using System.Collections;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class EnemySpawnInteractor : MonoBehaviour, IGameStartListener, IGameFinishListener, IGamePauseListener, IGameResumeListener
    {
        [SerializeField] private float _spawnDelay = 1f;

        private EnemySpawner _enemySpawner;

        private Coroutine _spawnCoroutine;

        [Inject]
        private void Construct(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnStart()
        {
            StartSpawn();
        }

        public void OnFinish()
        {
            StopSpawn();
        }

        public void OnPause()
        {
            StopSpawn();
        }

        public void OnResume()
        {
            StartSpawn();
        }

        private void StartSpawn()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
            }
            _spawnCoroutine = StartCoroutine(Spawn());
        }
        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                _enemySpawner.CreateEnemy();
            }
        }

        private void StopSpawn()
        {
            StopCoroutine(_spawnCoroutine);
        }

    }
}