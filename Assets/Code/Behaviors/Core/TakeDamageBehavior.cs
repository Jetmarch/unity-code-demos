using System;
using Atomic.Elements;
using Atomic.Entities;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class TakeDamageBehavior : IEntityInit
    {
        private ReactiveVariable<bool> _isDead;
        private ReactiveVariable<int> _hitPoints;
        private AndExpression _canTakeDamage;
        
        public void Init(IEntity entity)
        {
            _hitPoints = entity.GetHitPoints();
            _isDead = entity.GetIsDead();
            _canTakeDamage = entity.GetCanTakeDamage();
            
            entity.GetTakeDamageAction().Subscribe(TakeDamage);
        }

        private void TakeDamage(int damage)
        {
            if (!_canTakeDamage.Value)
            {
                return;
            }
            
            _hitPoints.Value -= damage;

            if (_hitPoints.Value <= 0)
            {
                _isDead.Value = true;
            }
        }
    }
}