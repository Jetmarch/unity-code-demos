using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class PlayerRequestBulletObserver : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
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