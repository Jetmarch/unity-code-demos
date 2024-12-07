using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Behaviors;

namespace ZombieShooter.Installers
{
    [Serializable]
    public sealed class MovementInstaller
    {
        [SerializeField] private ReactiveVariable<float> _moveSpeed;
        [SerializeField] private ReactiveVariable<Vector3> _moveDirection;
        [SerializeField] private AndExpression _canMove;
        
        public void Install(IEntity entity)
        {
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddMoveDirection(_moveDirection);
            entity.AddCanMove(_canMove);
            
            entity.AddBehaviour(new MovementBehavior());
        }
    }
}