using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class AmmoDecreaseBehavior : IEntityInit, IEntityDispose
    {
        [SerializeField] private ReactiveVariable<int> _decreaseAmount;
        private ReactiveVariable<int> _ammoAmount;
        
        public void Init(IEntity entity)
        {
            _ammoAmount = entity.GetAmmoAmount();
            entity.GetShootAction().Subscribe(DecreaseAmmo);
        }

        private void DecreaseAmmo()
        {
            if (_ammoAmount.Value <= 0)
            {
                return;
            }
            
            _ammoAmount.Value -= _decreaseAmount.Value;
        }
        
        public void Dispose(IEntity entity)
        {
            entity.GetShootAction().Unsubscribe(DecreaseAmmo);
        }
    }
}