using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> OnDeath;

        [SerializeField] private EnemyAttackAgent _attackAgent;

        [SerializeField] private EnemyMoveAgent _moveAgent;

        [SerializeField] private HitPointsComponent _hitPointsComponent;

        public void Construct(BulletFactory bulletFactory, GameObject target, Vector2 endPoint)
        {
            _moveAgent.SetDestination(endPoint);
            _attackAgent.Construct(bulletFactory, target);
            _hitPointsComponent.OnDeath += EnemyDeath;
            _moveAgent.OnReachedDestination += ReachedDestination;
        }

        private void EnemyDeath(GameObject obj)
        {
            _attackAgent.Deactivate();
            OnDeath?.Invoke(this);
        }
        private void ReachedDestination()
        {
            _attackAgent.Activate();
        }
    }
}