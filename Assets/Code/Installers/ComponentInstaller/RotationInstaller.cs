using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Behaviors;

namespace ZombieShooter.Installers
{
    [Serializable]
    public sealed class RotationInstaller
    {
        [SerializeField] private ReactiveVariable<float> _rotationRate;
        [SerializeField] private ReactiveVariable<Vector3> _rotateDirection;
        [SerializeField] private AndExpression _canRotate;
        
        public void Install(IEntity entity)
        {
            entity.AddRotationRate(_rotationRate);
            entity.AddRotateDirection(_rotateDirection);
            entity.AddCanRotate(_canRotate);
            
            entity.AddBehaviour(new RotationBehavior());
        }
    }
}