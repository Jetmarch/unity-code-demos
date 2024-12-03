using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class AmmoReplenishmentBehavior : IEntityInit, IEntityUpdate, IEntityDispose
    {
        [SerializeField] private Timer _replenishmentTimer;
        [SerializeField] private ReactiveVariable<int> _replenishmentAmount;
        private ReactiveVariable<int> _ammoAmount;
        private ReactiveVariable<int> _maxAmmoAmount;
        
        public void Init(IEntity entity)
        {
            _replenishmentTimer.OnEnded += Replenish;
            _ammoAmount = entity.GetAmmoAmount();
            _maxAmmoAmount = entity.GetMaxAmmoAmount();
            _replenishmentTimer.Start();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            _replenishmentTimer.Tick(deltaTime);
        }

        private void Replenish()
        {
            _ammoAmount.Value += _replenishmentAmount.Value;
            _ammoAmount.Value = Mathf.Clamp(_ammoAmount.Value, 0, _maxAmmoAmount.Value);
            _replenishmentTimer.Start();
        }
        
        public void Dispose(IEntity entity)
        {
            _replenishmentTimer.OnEnded -= Replenish;
        }
    }
}