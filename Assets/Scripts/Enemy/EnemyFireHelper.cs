using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyFireHelper : MonoBehaviour
    {
        [SerializeField] private BulletConfig _bulletConfig;

        [SerializeField] private BulletFactory _bulletSystem;

        public void OnFire(Vector2 position, Vector2 direction)
        {
            _bulletSystem.CreateBullet(new BulletInfo
            {
                IsPlayer = false,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = position,
                Velocity = direction * _bulletConfig.Speed
            });
        }
    }
}