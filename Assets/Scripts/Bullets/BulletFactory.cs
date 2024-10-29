using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class BulletFactory
    {
        public IReadOnlyCollection<Bullet> ActiveBullets => _activeBullets;
        public event Action<Bullet> OnBulletCreated;
        public event Action<Bullet> OnBulletRemoved;
        
        private readonly BulletFactoryProvider _factoryProvider;
        
        private readonly HashSet<Bullet> _activeBullets = new();

        public BulletFactory(BulletFactoryProvider provider)
        {
            _factoryProvider = provider;
        }

        public void CreateBullet(BulletInfo bulletInfo)
        {
            var bullet = _factoryProvider.Pool.GetObject()?.GetComponent<Bullet>();

            if (!bullet)
            {
                throw new Exception("Bullet prefab doesn't contain Bullet script!");
#if UNITY_EDITOR
                EditorApplication.isPaused = true;
#endif
            }

            bullet.Construct(_factoryProvider.WorldTransform, bulletInfo);

            if (_activeBullets.Add(bullet))
            {

                OnBulletCreated?.Invoke(bullet);
            }
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (!_activeBullets.Remove(bullet)) return;
            
            OnBulletRemoved?.Invoke(bullet);

            _factoryProvider.Pool.ReturnObject(bullet.gameObject);
        }
    }
}