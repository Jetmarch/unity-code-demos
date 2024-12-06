using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
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