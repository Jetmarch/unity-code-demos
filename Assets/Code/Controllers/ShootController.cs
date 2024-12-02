using System;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Controllers
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity _sceneEntity;
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _sceneEntity.GetShootRequest().Invoke();
            }
        }
    }
}