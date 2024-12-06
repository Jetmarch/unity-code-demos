using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Behaviors;

namespace ZombieShooter.Installers
{
    [Serializable]
    public sealed class AmmoInstaller
    {
        [SerializeField] private ReactiveVariable<int> _ammoAmount;
        [SerializeField] private ReactiveVariable<int> _maxAmmoAmount;
        [SerializeField] private AmmoReplenishmentBehavior _ammoReplenishmentBehavior;
        [SerializeField] private AmmoDecreaseBehavior _ammoDecreaseBehavior;
        public void Install(IEntity entity)
        {
            entity.AddAmmoAmount(_ammoAmount);
            entity.AddMaxAmmoAmount(_maxAmmoAmount);
            
            entity.AddBehaviour(_ammoReplenishmentBehavior);
            entity.AddBehaviour(_ammoDecreaseBehavior);
        }
    }
}