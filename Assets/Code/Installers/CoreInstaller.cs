using System;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class CoreInstaller : IEntityInstaller
    {
        public Transform Root;
        
        public void Install(IEntity entity)
        {
            entity.AddTransform(Root);
        }
    }
}