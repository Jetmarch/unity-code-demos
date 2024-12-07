using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Behaviors;

namespace ZombieShooter.Installers
{
    [Serializable]
    public class BulletInstaller : IEntityInstaller
    {
        [Header("Core")]
        [SerializeField] private CoreInstaller _coreInstaller;
        [Header("Movement")]
        [SerializeField] private MovementInstaller _movementInstaller;

        [Header("Collision")] 
        [SerializeField] private Event<SceneEntity> _entityTriggerEnter;

        [Header("Damage")]
        [SerializeField] private ReactiveVariable<int> _damageAmount;
        public void Install(IEntity entity)
        {
            _coreInstaller.Install(entity);
            _movementInstaller.Install(entity);

            entity.AddDamageAmount(_damageAmount);
            entity.AddEntityTriggerEnter(_entityTriggerEnter);
            entity.AddBehaviour(new DealDamageOnCollisionBehavior());
        }
    }
}