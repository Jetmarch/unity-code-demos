using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class BulletLevelBoundsChecker : MonoBehaviour, IGameFixedUpdateListener
    {
        private BulletFactory _bulletFactory;

        private LevelBounds _levelBounds;

        private readonly List<Bullet> _cache = new();

        [Inject]
        public void Construct(BulletFactory bulletFactory, LevelBounds levelBounds)
        {
            _bulletFactory = bulletFactory;
            _levelBounds = levelBounds;
        }

        private void CheckLevelBounds(IReadOnlyCollection<Bullet> activeBullets, Action<Bullet> OnOutOfBoundsCallback)
        {
            _cache.Clear();
            _cache.AddRange(activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    OnOutOfBoundsCallback?.Invoke(bullet);
                }
            }
        }

        public void OnFixedUpdate(float delta)
        {
            CheckLevelBounds(_bulletFactory.ActiveBullets, _bulletFactory.RemoveBullet);
        }
    }
}