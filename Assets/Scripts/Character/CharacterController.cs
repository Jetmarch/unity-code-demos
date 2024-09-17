using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private HitPointsComponent _hitPointsComponent;

        private float _horizontalDirection;
        private bool _fireRequired;

        public Action<BulletSystem.Args> OnRequestBullet;

        private void FixedUpdate()
        {
            if (_fireRequired)
            {
                ShootBullet();

                _fireRequired = false;
            }

            _moveComponent.MoveByRigidbodyVelocity(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
        }

        private void ShootBullet()
        {
            var weapon = character.GetComponent<WeaponComponent>();

            OnRequestBullet?.Invoke(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)_bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * _bulletConfig.speed
            });
        }

        public void Fire()
        {
            _fireRequired = true;
        }

        public void MoveRight()
        {
            _horizontalDirection = 1;
        }

        public void MoveLeft()
        {
            _horizontalDirection = -1;
        }

        public void StopMove()
        {
            _horizontalDirection = 0;
        }
    }
}