using UnityEngine;

namespace ShootEmUp
{
    public class EnemyFireController : MonoBehaviour
    {
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private BulletSystem _bulletSystem;

        public void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.CreateBullet(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)_bulletConfig.PhysicsLayer,
                color = _bulletConfig.Color,
                damage = _bulletConfig.Damage,
                position = position,
                velocity = direction * _bulletConfig.Speed
            });
        }
    }
}