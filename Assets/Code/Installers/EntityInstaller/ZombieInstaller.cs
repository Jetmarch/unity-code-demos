using System;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Behaviors;
using ZombieShooter.Behaviors.Visual;

namespace ZombieShooter.Installers
{
    [Serializable]
    public class ZombieInstaller : IEntityInstaller
    {
        [Header("Core")]
        [SerializeField] private CoreInstaller _coreInstaller;
        
        [Header("Life")]
        [SerializeField] private LifeInstaller _lifeInstaller;
        
        [Header("Movement")]
        [SerializeField] private MovementInstaller _movementInstaller;
        
        [Header("Rotation")]
        [SerializeField] private RotationInstaller _rotationInstaller;
        
        [Header("Follow Target")]
        [SerializeField] private FollowTargetInstaller _followTargetInstaller;
        
        [Header("Visual")]
        [SerializeField] private Transform _visualTransform;
        [SerializeField] private Animator _animator;
        
        public void Install(IEntity entity)
        {
            _coreInstaller.Install(entity);
            _lifeInstaller.Install(entity);
            _movementInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _followTargetInstaller.Install(entity);
            entity.AddBehaviour(new LookToTargetBehavior());

            entity.AddVisualTransform(_visualTransform);
            entity.AddAnimator(_animator);
            
            entity.GetCanTakeDamage().Append(() => !entity.GetIsDead().Value);
            entity.GetCanMove().Append(() => !entity.GetIsDead().Value);
            entity.GetCanRotate().Append(() => !entity.GetIsDead().Value);
            
            //Visual layer
            entity.AddBehaviour(new MoveAnimationBehavior());
            // entity.AddBehaviour(new ShootAnimationBehavior());
            entity.AddBehaviour(new DeathAnimationBehavior());
        }
    }
}