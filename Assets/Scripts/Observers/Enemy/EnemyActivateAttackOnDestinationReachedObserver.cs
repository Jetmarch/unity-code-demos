using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyActivateAttackOnDestinationReachedObserver : MonoBehaviour//, IGameStartListener, IGameFinishListener
    {
        //[SerializeField] private EnemyMoveAgent _moveAgent;

        //[SerializeField] private EnemyAttackAgent _attackAgent;

        //[SerializeField] private EnemyEventListener _listener;

        //private void Start()
        //{
        //    IGameListener.Register(this);
        //}

        //public void OnStart()
        //{
        //    //_moveAgent.OnReachedDestination += _attackAgent.Activate;

        //    _listener.OnEnemyReachedDestination += OnReachedDestination;
        //}

        //public void OnFinish()
        //{
        //    //_moveAgent.OnReachedDestination -= _attackAgent.Activate;

        //    _listener.OnEnemyReachedDestination -= OnReachedDestination;
        //}

        //private void OnReachedDestination(Enemy enemy)
        //{
        //    enemy.ActivateAttack();
        //}
    }
}