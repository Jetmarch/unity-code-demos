using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class CoreInstaller : IEntityInstaller
    {
        public Transform Root;
        
        public void Install(IEntity entity)
        {
            entity.AddTransform(Root);
        }
    }

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
    
    [Serializable]
    public sealed class LifeInstaller : IEntityInstaller
    {
        public ReactiveVariable<int> HitPoints;
        public ReactiveVariable<bool> IsDead;
        public Event<int> TakeDamageAction;
        public AndExpression CanTakeDamage;
        
        public void Install(IEntity entity)
        {
            entity.AddHitPoints(HitPoints);
            entity.AddIsDead(IsDead);
            entity.AddTakeDamageAction(TakeDamageAction);
            entity.AddCanTakeDamage(CanTakeDamage);
            
            entity.AddBehaviour(new TakeDamageBehavior());
        }
    }
}