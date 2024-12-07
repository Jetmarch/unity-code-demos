using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors.Visual
{
    [Serializable]
    public sealed class MoveAnimationBehavior : IEntityInit, IEntityUpdate
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private Transform _visualTransform;
        private Animator _animator;
        private int _horizontalMoveDirection = Animator.StringToHash("Horizontal");
        private int _verticalMoveDirection = Animator.StringToHash("Vertical");
        
        public void Init(IEntity entity)
        {
            _visualTransform = entity.GetVisualTransform();
            _moveDirection = entity.GetMoveDirection();
            _animator = entity.GetAnimator();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            var visualMoveDirection = _visualTransform.TransformDirection(_moveDirection.Value); 
            _animator.SetFloat(_verticalMoveDirection, visualMoveDirection.x);
            _animator.SetFloat(_horizontalMoveDirection, visualMoveDirection.z);
        }
    }
    
    [Serializable]
    public sealed class ShootAnimationBehavior : IEntityInit, IEntityDispose
    {
        private Atomic.Elements.Event _shootAction; 
        private Animator _animator;
        private int _shootTrigger = Animator.StringToHash("Shoot");
        
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