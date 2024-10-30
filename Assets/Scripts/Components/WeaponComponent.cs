using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class WeaponComponent
    {
        public Vector2 Position => _firePoint.position;

        public Quaternion Rotation => _firePoint.rotation;

        [SerializeField] private Transform _firePoint;

        [SerializeField] private BulletConfig _bulletConfig;

        private BulletFactory _bulletFactory;
        
        private TeamComponent _teamComponent;

        public void Construct(BulletFactory bulletFactory, TeamComponent teamComponent)
        {
            _bulletFactory = bulletFactory;
            _teamComponent = teamComponent;
        }

        public void Fire(Vector2 direction)
        {
            _bulletFactory.CreateBullet(new BulletInfo
            {
                IsPlayer = _teamComponent.IsPlayer,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _firePoint.position,
                Velocity = direction * _bulletConfig.Speed
            });
        }
    }
}