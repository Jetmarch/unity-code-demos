using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public Vector2 Position
        {
            get { return _firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return _firePoint.rotation; }
        }

        [SerializeField] private bool _isPlayer;

        [SerializeField] private Transform _firePoint;

        [SerializeField] private BulletConfig _bulletConfig;

        [SerializeField] private BulletFactory _bulletFactory;

        public void Construct(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public void Fire(Vector2 direction)
        {
            _bulletFactory.CreateBullet(new BulletInfo
            {
                IsPlayer = _isPlayer,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _firePoint.position,
                Velocity = direction * _bulletConfig.Speed
            });
        }
    }
}