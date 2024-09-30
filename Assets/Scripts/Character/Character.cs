using UnityEngine;

namespace ShootEmUp
{
    public sealed class Character : MonoBehaviour
    {
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
            _weapon.Fire(_weapon.Rotation * Vector3.up);
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