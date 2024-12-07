using System;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class CoreInstaller
    {
        [SerializeField] private Transform _root;
        
        public void Install(IEntity entity)
        {
            entity.AddTransform(_root);
        }
    }
}