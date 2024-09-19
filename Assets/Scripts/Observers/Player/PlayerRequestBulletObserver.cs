using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerRequestBulletObserver : MonoBehaviour
    {
        [SerializeField] private CharacterSystem _characterController;

        [SerializeField] private BulletSystem _bulletSystem;

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