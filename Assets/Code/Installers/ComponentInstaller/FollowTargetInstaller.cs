using System;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class FollowTargetInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _target;
        [SerializeField] private FollowTargetBehavior _followTargetBehavior;
        public void Install(IEntity entity)
        {
            entity.AddTarget(_target);
            
            entity.AddBehaviour(_followTargetBehavior);
        }
    }
}