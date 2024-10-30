using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class BulletLevelBoundsChecker : IGameFixedUpdateListener
    {
        private readonly BulletFactory _bulletFactory;

        private readonly LevelBounds _levelBounds;

        private readonly List<Bullet> _cache = new();

        public BulletLevelBoundsChecker(BulletFactory bulletFactory, LevelBounds levelBounds)
        {
            _bulletFactory = bulletFactory;
            _levelBounds = levelBounds;
        }

        private void CheckLevelBounds(IReadOnlyCollection<Bullet> activeBullets, Action<Bullet> outOfBoundsCallback)
        {
            _cache.Clear();
            _cache.AddRange(activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    outOfBoundsCallback?.Invoke(bullet);
                }
            }
        }

        public void OnFixedUpdate(float delta)
        {
            CheckLevelBounds(_bulletFactory.ActiveBullets, _bulletFactory.RemoveBullet);
        }
    }
}