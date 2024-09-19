using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletLevelBoundsChecker : MonoBehaviour
    {
        public Action<Bullet> OnOutOfBounds;

        [SerializeField] private LevelBounds levelBounds;

        private readonly List<Bullet> _cache = new();

        public void CheckLevelBounds(IReadOnlyCollection<Bullet> activeBullets, Action<Bullet> OnOutOfBoundsCallback)
        {
            _cache.Clear();
            _cache.AddRange(activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    OnOutOfBoundsCallback?.Invoke(bullet);
                }
            }
        }
    }
}