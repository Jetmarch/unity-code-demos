using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class LifeInstaller
    {
        [SerializeField] private ReactiveVariable<int> _hitPoints;
        [SerializeField] private ReactiveVariable<bool> _isDead;
        [SerializeField] private Event<int> _takeDamageAction;
        [SerializeField] private AndExpression _canTakeDamage;
        
        public void Install(IEntity entity)
        {
            entity.AddHitPoints(_hitPoints);
            entity.AddIsDead(_isDead);
            entity.AddTakeDamageAction(_takeDamageAction);
            entity.AddCanTakeDamage(_canTakeDamage);
            
            entity.AddBehaviour(new TakeDamageBehavior());
        }
    }
}