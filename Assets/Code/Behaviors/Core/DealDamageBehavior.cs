using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public class DealDamageBehavior : IEntityInit
    {
        [SerializeField] private ReactiveVariable<int> _damage;
        
        public void Init(IEntity entity)
        {
            //Get event with 
        }
    }
}