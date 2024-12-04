using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class MovementInstaller : IEntityInstaller
    {
        public ReactiveVariable<float> MoveSpeed;
        public ReactiveVariable<Vector3> MoveDirection;
        public AndExpression CanMove;
        
        public void Install(IEntity entity)
        {
            entity.AddMoveSpeed(MoveSpeed);
            entity.AddMoveDirection(MoveDirection);
            entity.AddCanMove(CanMove);
            
            entity.AddBehaviour(new MovementBehavior());
        }
    }
}