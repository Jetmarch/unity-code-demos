using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;

        [SerializeField] private Transform container;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Bullet prefab;

        private readonly Queue<Bullet> _bulletPool = new();

        private void Awake()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, container);
                _bulletPool.Enqueue(bullet);
            }
        }

        public Bullet GetBullet()
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
            }
            else
            {
                bullet = Instantiate(prefab, worldTransform);
            }

            return bullet;
        }

        public void ReturnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(container);
            _bulletPool.Enqueue(bullet);
        }
    }
}