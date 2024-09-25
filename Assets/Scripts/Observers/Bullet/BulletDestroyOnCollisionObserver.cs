using UnityEngine;

namespace ShootEmUp
{
    public class BulletDestroyOnCollisionObserver : MonoBehaviour
    {
        [SerializeField] private BulletFactory _bulletFactory;

        private void OnEnable()
        {
            _bulletFactory.OnBulletCreated += OnBulletCreated;
            _bulletFactory.OnBulletRemoved += OnBulletRemoved;
        }

        private void OnDisable()
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