using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyDestroyObserver : MonoBehaviour//, IGameStartListener, IGameFinishListener
    {
        //[SerializeField] private EnemySpawner _enemySpawner;

        //private void Start()
        //{
        //    IGameListener.Register(this);
        //}

        //public void OnStart()
        //{
        //    _enemySpawner.OnEnemyDestroyed += OnEnemyDestroyed;
        //}

        //public void OnFinish()
        //{
        //    _enemySpawner.OnEnemyDestroyed -= OnEnemyDestroyed;
        //}

        //private void OnEnemyDestroyed(Enemy enemy)
        //{
        //    enemy.OnDeath -= _enemySpawner.DestroyEnemy;
        //    enemy.OnReachedDestination -= enemy.ActivateAttack;
        //}
    }
}