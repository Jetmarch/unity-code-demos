using System;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Behaviors;
using ZombieShooter.Behaviors.Visual;

// ReSharper disable InconsistentNaming

namespace ZombieShooter.Installers
{
    [Serializable]
    public class CharacterInstaller : IEntityInstaller
    {
        [Header("Core")]
        [SerializeField] private CoreInstaller _coreInstaller;
        
        [Header("Life")]
        [SerializeField] private LifeInstaller _lifeInstaller;
        
        [Header("Movement")]
        [SerializeField] private MovementInstaller _movementInstaller;
        
        [Header("Rotation")]
        [SerializeField] private RotationInstaller _rotationInstaller;
        
        [Header("Visual")]
        [SerializeField] private Transform _visualTransform;
        [SerializeField] private Animator _animator;

        [Header("Shoot")]
        [SerializeField] private ShootInstaller _shootInstaller;
        
        [Header("Ammo")] 
        [SerializeField] private AmmoInstaller _ammoInstaller;

        public void Install(IEntity entity)
        {
            _coreInstaller.Install(entity);
            _lifeInstaller.Install(entity);
            _movementInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _shootInstaller.Install(entity);
            _ammoInstaller.Install(entity);

            entity.AddVisualTransform(_visualTransform);
            entity.AddAnimator(_animator);
            
            entity.GetCanTakeDamage().Append(() => !entity.GetIsDead().Value);
            entity.GetCanMove().Append(() => !entity.GetIsDead().Value);
            entity.GetCanRotate().Append(() => !entity.GetIsDead().Value);
            entity.GetCanFire().Append(() => !entity.GetIsDead().Value);
            entity.GetCanFire().Append(() => entity.GetAmmoAmount().Value > 0);
            
            //Visual layer
            entity.AddBehaviour(new MoveAnimationBehavior());
        }
    }
}