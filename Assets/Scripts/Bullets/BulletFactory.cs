using UnityEngine;


namespace ShootEmUp
{
    public sealed class BulletFactory : MonoBehaviour
    {
        [SerializeField] private Transform _worldTransform;
        public Bullet ConstructBullet(Bullet bullet, BulletSystem.Args args)
        {
            bullet.transform.SetParent(_worldTransform);
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.damage = args.damage;
            bullet.isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);

            return bullet;
        }
    }
}