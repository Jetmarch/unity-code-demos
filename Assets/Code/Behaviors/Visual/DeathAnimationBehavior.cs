using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors.Visual
{
    [Serializable]
    public sealed class DeathAnimationBehavior : IEntityInit, IEntityDispose
    {
        private ReactiveVariable<bool> _isDead;
        private Animator _animator;
        private int _isDeadAnimation = Animator.StringToHash("IsDead");
        
        public void Init(IEntity entity)
        {
            _isDead = entity.GetIsDead();
            _animator = entity.GetAnimator();
            _isDead.Subscribe(TriggerDeathAnimation);
        }
        public void Dispose(IEntity entity)
        {
            _isDead.Unsubscribe(TriggerDeathAnimation);
        }

        private void TriggerDeathAnimation(bool isDead)
        {
            _animator.SetBool(_isDeadAnimation, isDead);
        }

    }
}