using System;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors.Visual
{
    [Serializable]
    public sealed class ShootAnimationBehavior : IEntityInit, IEntityDispose
    {
        private Atomic.Elements.Event _shootAction; 
        private Animator _animator;
        private int _shootTrigger = Animator.StringToHash("Attack");
        
        public void Init(IEntity entity)
        {
            _shootAction = entity.GetShootAction();
            _animator = entity.GetAnimator();

            _shootAction.Subscribe(TriggerShootAnimation);
        }
        public void Dispose(IEntity entity)
        {
            _shootAction.Unsubscribe(TriggerShootAnimation);
        }

        private void TriggerShootAnimation()
        {
            _animator.SetTrigger(_shootTrigger);
        }
    }
}