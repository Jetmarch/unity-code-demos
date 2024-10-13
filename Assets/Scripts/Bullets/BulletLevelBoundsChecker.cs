using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletLevelBoundsChecker : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private BulletFactory _bulletFactory;

        [SerializeField] private LevelBounds _levelBounds;

        private readonly List<Bullet> _cache = new();

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void CheckLevelBounds(IReadOnlyCollection<Bullet> activeBullets, Action<Bullet> OnOutOfBoundsCallback)
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