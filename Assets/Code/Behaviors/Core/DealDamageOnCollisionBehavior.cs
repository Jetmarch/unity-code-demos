using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public class DealDamageOnCollisionBehavior : IEntityInit, IEntityDispose
    {
        private ReactiveVariable<int> _damageAmount;
        private Event<SceneEntity> _onEntityTriggerEnter;
        public void Init(IEntity entity)
        {
            _damageAmount = entity.GetDamageAmount();
            _onEntityTriggerEnter = entity.GetEntityTriggerEnter();
            _onEntityTriggerEnter.Subscribe(DealDamage);
        }

        public void Dispose(IEntity entity)
        {
            _onEntityTriggerEnter.Unsubscribe(DealDamage);
        }

        private void DealDamage(SceneEntity entity)
        {
            if (entity.TryGetTakeDamageAction(out var takeDamageAction))
            {
                takeDamageAction.Invoke(_damageAmount.Value);
                Debug.Log($"DealDamage on {entity} took {_damageAmount.Value} damage");
            }
        }
    }
}