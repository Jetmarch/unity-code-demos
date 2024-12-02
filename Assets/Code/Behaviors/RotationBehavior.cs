using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Object = System.Object;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class RotationBehavior : IEntityInit, IEntityUpdate 
    {
        private Transform _visualRoot;
        private ReactiveVariable<float> _rotationRate;
        private ReactiveVariable<Vector3> _rotateDirection;
        private AndExpression _canRotate;
        
        public void Init(IEntity entity)
        {
            _visualRoot = entity.GetVisualTransform();
            _rotationRate = entity.GetRotationRate();
            _rotateDirection = entity.GetRotateDirection();
            _canRotate = entity.GetCanRotate();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (!_canRotate.Value)
            {
                return;
            }

            if (_rotateDirection.Value == Vector3.zero)
            {
                return;
            }
            
            // var targetRotation = Quaternion.LookRotation(_rotateDirection.Value, Vector3.up);
            var targetRotation = Quaternion.Euler(_rotateDirection.Value);
            _visualRoot.rotation = Quaternion.Lerp(_visualRoot.rotation, targetRotation, _rotationRate.Value);
        }
    }
}