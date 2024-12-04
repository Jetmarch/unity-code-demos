using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class MovementBehavior : IEntityInit, IEntityUpdate 
    {
        private Transform _root;
        private ReactiveVariable<float> _moveSpeed;
        private ReactiveVariable<Vector3> _moveDirection;
        private AndExpression _canMove;
        
        public void Init(IEntity entity)
        {
            _root = entity.GetTransform();
            _moveSpeed = entity.GetMoveSpeed();
            _moveDirection = entity.GetMoveDirection();
            _canMove = entity.GetCanMove();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (!_canMove.Value)
            {
                return;
            }
            
            _root.position += _moveDirection.Value * _moveSpeed.Value * deltaTime;
        }
    }
    
    [Serializable]
    public sealed class FollowTargetBehavior : IEntityInit, IEntityUpdate
    {
        
        [SerializeField] private ReactiveVariable<float> _stopDistance;
        private Transform _root;
        private Transform _target;
        private ReactiveVariable<Vector3> _moveDirection;
        
        public void Init(IEntity entity)
        {
            _root = entity.GetTransform();
            _target = entity.GetTarget();
            _moveDirection = entity.GetMoveDirection();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (!entity.HasTarget())
            {
                return;
            }
            
            if (Vector3.Distance(_target.position, _root.position) < _stopDistance.Value)
            {
                _moveDirection.Value = Vector3.zero;
                return;
            }
            
            _moveDirection.Value = (_target.position - _root.position).normalized;
        }
    }
}