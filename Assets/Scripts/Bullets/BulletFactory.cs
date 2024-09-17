using UnityEngine;


namespace ShootEmUp
{
    public class BulletFactory : MonoBehaviour
    {
        public Bullet ConstructBullet(Bullet bullet, BulletSystem.Args args)
        {
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