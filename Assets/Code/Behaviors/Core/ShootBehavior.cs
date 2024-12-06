using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Factories;
using Event = Atomic.Elements.Event;

namespace ZombieShooter.Behaviors
{
    [Serializable]
    public sealed class ShootBehavior : IEntityInit, IEntityUpdate
    {
        [SerializeField] private Timer _reloadTimer;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private SceneEntity _bulletPrefab;
        private AndExpression _canFire;
        private Event _shootAction;
        private SceneEntityFactory _factory;
        
        public void Init(IEntity entity)
        {
            _canFire = entity.GetCanFire();
            entity.GetShootRequest().Subscribe(Shoot);
            _shootAction = entity.GetShootAction();
            _factory = entity.GetSceneEntityFactory();
        }

        public void OnUpdate(IEntity entity, float deltaTime) 
        {
            _reloadTimer.Tick(deltaTime);
        }

        public void Shoot()
        {
            if (!_canFire.Value)
            {
                return;
            }

            if (_reloadTimer.IsPlaying())
            {
                return;
            }
            
            var bullet = _factory.CreateSceneEntity(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            var moveDirection = bullet.GetMoveDirection();
            moveDirection.Value = _firePoint.forward;
            
            _shootAction.Invoke();
            _reloadTimer.Start();
        }
    }
}