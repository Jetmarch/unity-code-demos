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
        private Animator _animator;
        private int _horizontalMoveDirection = Animator.StringToHash("Horizontal");
        private int _verticalMoveDirection = Animator.StringToHash("Vertical");
        
        public void Init(IEntity entity)
        {
            _moveDirection = entity.GetMoveDirection();
            _animator = entity.GetAnimator();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            _animator.SetFloat(_verticalMoveDirection, _moveDirection.Value.x);
            _animator.SetFloat(_horizontalMoveDirection, _moveDirection.Value.z);
        }
    }
}