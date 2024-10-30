using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : MonoBehaviour, ITeamable, IHittable
    {
        public event Action<Enemy> OnDeath;
        public TeamComponent TeamComponent => _teamComponent;
        public HitPointsComponent HitPointsComponent => _hitPointsComponent;

        [SerializeField] private EnemyAttackAgent _attackAgent;

        [SerializeField] private EnemyMoveAgent _moveAgent;

        [SerializeField] private HitPointsComponent _hitPointsComponent;
        
        [SerializeField] private TeamComponent _teamComponent;

        private bool _isActive;

        public void Construct(BulletFactory bulletFactory, GameObject target, Vector2 endPoint)
        {
            _moveAgent.SetDestination(endPoint);
            _attackAgent.Construct(bulletFactory, target, _teamComponent);
            _hitPointsComponent.Construct(gameObject);
            _hitPointsComponent.OnDeath += EnemyDeath;
            _moveAgent.OnReachedDestination += ReachedDestination;
            Activate();
        }

        private void EnemyDeath(GameObject obj)
        {
            Deactivate();
            _hitPointsComponent.OnDeath -= EnemyDeath;
            _moveAgent.OnReachedDestination -= ReachedDestination;
            OnDeath?.Invoke(this);
        }
        private void ReachedDestination()
        {
            _attackAgent.Activate();
        }

        public void OnFixedUpdate(float fixedDelta)
        {
            if (!_isActive) return;
            
            _moveAgent.OnFixedUpdate(fixedDelta);
            _attackAgent.OnFixedUpdate(fixedDelta);
        }

        public void Deactivate()
        {
            _isActive = false;
        }

        public void Activate()
        {
            _isActive = true;
        }
    }
}