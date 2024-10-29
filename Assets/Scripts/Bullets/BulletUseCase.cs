using UnityEngine;

namespace ShootEmUp
{
    public static class BulletUseCase
    {
        public static void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out ITeamable teamable))
            {
                return;
            }

            if (bullet.IsPlayer == teamable.TeamComponent.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out IHittable hittable))
            {
                hittable.HitPointsComponent.TakeDamage(bullet.Damage);
            }
        }
    }
}