using UnityEngine;

namespace ShootEmUp
{
    public class BulletDestroyOnCollisionObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private BulletFactory _bulletFactory;

        private void Start()
        {
            IGameListener.Register(this);
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