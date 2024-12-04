using System;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class FollowTargetInstaller : IEntityInstaller
    {
        public Transform _target;
        public FollowTargetBehavior FollowTargetBehavior;
        public void Install(IEntity entity)
        {
            entity.AddTarget(_target);
            
            entity.AddBehaviour(FollowTargetBehavior);
        }
    }
}