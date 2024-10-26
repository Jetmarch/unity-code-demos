using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletFactory : MonoBehaviour
    {
        public IReadOnlyCollection<Bullet> ActiveBullets { get { return _activeBullets; } }

        public event Action<Bullet> OnBulletCreated;

        public event Action<Bullet> OnBulletRemoved;

        [SerializeField] private GameObjectPool _bulletPool;

        [SerializeField] private Transform _worldTransform;

        private readonly HashSet<Bullet> _activeBullets = new();

        public void CreateBullet(BulletInfo bulletInfo)
        {
            var bullet = _bulletPool.GetObject()?.GetComponent<Bullet>();

            if (!bullet)
            {
                throw new System.Exception("Bullet prefab doesn't contain Bullet script!");
#if UNITY_EDITOR
                EditorApplication.isPaused = true;
#endif
            }

            bullet.Construct(_worldTransform, bulletInfo);

            if (_activeBullets.Add(bullet))
            {

                OnBulletCreated?.Invoke(bullet);
            }
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                OnBulletRemoved?.Invoke(bullet);

                _bulletPool.ReturnObject(bullet.gameObject);
            }
        }
    }
}