using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerRequestBulletObserver : MonoBehaviour
    {
        [SerializeField] private Character _characterController;

        [SerializeField] private BulletFactory _bulletSystem;

        private void OnEnable()
        {
            _characterController.OnRequestBullet += _bulletSystem.CreateBullet;
        }

        private void OnDisable()
        {
            _characterController.OnRequestBullet -= _bulletSystem.CreateBullet;
        }
    }
}