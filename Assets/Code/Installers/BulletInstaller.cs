using System;
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
        
        public void Install(IEntity entity)
        {
            _coreInstaller.Install(entity);
            _movementInstaller.Install(entity);
        }
    }
}