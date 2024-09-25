using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Character : MonoBehaviour
    {
        public event Action<BulletInfo> OnRequestBullet;

        [SerializeField] private WeaponComponent _weapon;

        [SerializeField] private BulletConfig _bulletConfig;

        [SerializeField] private MoveComponent _moveComponent;

        private float _horizontalDirection;

        private void FixedUpdate()
        {
            _moveComponent.Move(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
        }

        private void ShootBullet()
        {
            OnRequestBullet?.Invoke(new BulletInfo
            {
                IsPlayer = true,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _weapon.Position,
                Velocity = _weapon.Rotation * Vector3.up * _bulletConfig.Speed
            });
        }

        public void Fire()
        {
            ShootBullet();
        }

        public void Move(float horizontalDirection)
        {
            _horizontalDirection = horizontalDirection;
        }
    }
}