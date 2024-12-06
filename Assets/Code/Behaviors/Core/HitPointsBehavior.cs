using System;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class HitPointsBehavior : IEntityInit
    {
        public void Init(IEntity entity)
        {
            var hitPoints = entity.GetHitPoints();
            hitPoints.Subscribe(OnHitPointsChanged);
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            Debug.Log($"Hit points changed = {hitPoints}");
        }
    }
}