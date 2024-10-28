using UnityEngine;

namespace ShootEmUp
{
    public class BulletDestroyOnCollisionObserver : IGameStartListener, IGameFinishListener
    {
        private readonly BulletFactory _bulletFactory;

        public BulletDestroyOnCollisionObserver(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public void OnStart()
        {
            _bulletFactory.OnBulletCreated += OnBulletCreated;
            _bulletFactory.OnBulletRemoved += OnBulletRemoved;
        }

        public void OnFinish()
        {
            _bulletFactory.OnBulletCreated -= OnBulletCreated;
            _bulletFactory.OnBulletRemoved -= OnBulletRemoved;
        }

        private void OnBulletCreated(Bullet bullet)
        {
            bullet.OnCollisionEntered += _bulletFactory.RemoveBullet;
        }

        private void OnBulletRemoved(Bullet bullet)
        {
            bullet.OnCollisionEntered -= _bulletFactory.RemoveBullet;
        }
    }
}