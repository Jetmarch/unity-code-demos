using UnityEngine;

namespace ShootEmUp
{
    public class EnemyActivateAttackOnDestinationReachedObserver : MonoBehaviour
    {
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private EnemyAttackAgent _attackAgent;

        private void OnEnable()
        {
            _moveAgent.OnReachedDestination += _attackAgent.Activate;
        }

        private void OnDisable()
        {
            _moveAgent.OnReachedDestination -= _attackAgent.Activate;
        }
    }
}