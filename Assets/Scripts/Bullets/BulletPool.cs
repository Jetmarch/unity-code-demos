using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private int _initialCount = 50;

        [SerializeField] private Transform _container;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Bullet _prefab;

        private readonly Queue<Bullet> _bulletPool = new();

        private void Awake()
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var bullet = Instantiate(_prefab, _container);
                _bulletPool.Enqueue(bullet);
            }
        }

        public Bullet GetBullet()
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(_worldTransform);
            }
            else
            {
                bullet = Instantiate(_prefab, _worldTransform);
            }

            return bullet;
        }

        public void ReturnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(_container);
            _bulletPool.Enqueue(bullet);
        }
    }
}