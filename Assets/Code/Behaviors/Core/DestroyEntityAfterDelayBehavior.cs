using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class DestroyEntityAfterDelayBehavior : IEntityInit, IEntityUpdate
    {
        [SerializeField] private Timer _destroyTimer;
        private Transform _root;
        public void Init(IEntity entity)
        {
            _destroyTimer.Start();
            _root = entity.GetTransform();
            _destroyTimer.OnEnded += OnTimerEnded;
        }
        public void OnUpdate(IEntity entity, float deltaTime)
        {
            _destroyTimer.Tick(deltaTime);
        }

        private void OnTimerEnded()
        {
            //TODO: Send signal to destroy this object
        }
    }
}