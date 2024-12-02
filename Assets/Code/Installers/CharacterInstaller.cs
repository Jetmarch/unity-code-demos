using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Behaviors;
using ZombieShooter.Factories;

// ReSharper disable InconsistentNaming

namespace ZombieShooter.Installers
{
    [Serializable]
    public class CharacterInstaller : IEntityInstaller
    {
        [Header("Core")]
        public Transform Root;
        
        [Header("Life")]
        public ReactiveVariable<int> HitPoints;
        public ReactiveVariable<bool> IsDead;
        public Event<int> TakeDamageAction;
        public AndExpression CanTakeDamage;
        
        [Header("Movement")]
        public ReactiveVariable<float> MoveSpeed;
        public ReactiveVariable<Vector3> MoveDirection;
        public AndExpression CanMove;
        
        [Header("Rotation")]
        public ReactiveVariable<float> RotationRate;
        public ReactiveVariable<Vector3> RotationDirection;
        public AndExpression CanRotate;
        
        [Header("Visual")]
        public Transform VisualTransform;

        [Header("Shoot")]
        public ShootBehavior ShootBehavior;
        public AndExpression CanFire;
        public Atomic.Elements.Event ShootAction;
        public Atomic.Elements.Event ShootRequest;
        
        public SceneEntityFactory SceneEntityFactory;
        
        public void Install(IEntity entity)
        {
            entity.AddTransform(Root);
            
            entity.AddHitPoints(HitPoints);
            entity.AddIsDead(IsDead);
            entity.AddTakeDamageAction(TakeDamageAction);
            entity.AddCanTakeDamage(CanTakeDamage);
            
            entity.AddMoveSpeed(MoveSpeed);
            entity.AddMoveDirection(MoveDirection);
            entity.AddCanMove(CanMove);
            
            entity.AddRotationRate(RotationRate);
            entity.AddRotateDirection(RotationDirection);
            entity.AddCanRotate(CanRotate);

            entity.AddCanFire(CanFire);
            entity.AddShootAction(ShootAction);
            entity.AddShootRequest(ShootRequest);
            
            entity.AddVisualTransform(VisualTransform);

            entity.AddSceneEntityFactory(SceneEntityFactory);
            
            CanTakeDamage.Append(() => !IsDead.Value);
            CanMove.Append(() => !IsDead.Value);
            CanRotate.Append(() => !IsDead.Value);
            CanFire.Append(() => !IsDead.Value);
            
            entity.AddBehaviour(new HitPointsBehavior());
            entity.AddBehaviour(new TakeDamageBehavior());
            entity.AddBehaviour(new MovementBehavior());
            entity.AddBehaviour(new RotationBehavior());
            entity.AddBehaviour(ShootBehavior);
        }
    }
}