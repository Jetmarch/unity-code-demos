using System;
using Atomic.Elements;
using Atomic.Entities;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class LifeInstaller : IEntityInstaller
    {
        public ReactiveVariable<int> HitPoints;
        public ReactiveVariable<bool> IsDead;
        public Event<int> TakeDamageAction;
        public AndExpression CanTakeDamage;
        
        public void Install(IEntity entity)
        {
            entity.AddHitPoints(HitPoints);
            entity.AddIsDead(IsDead);
            entity.AddTakeDamageAction(TakeDamageAction);
            entity.AddCanTakeDamage(CanTakeDamage);
            
            entity.AddBehaviour(new TakeDamageBehavior());
        }
    }
}