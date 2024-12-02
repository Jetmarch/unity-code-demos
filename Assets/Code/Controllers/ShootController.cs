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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _sceneEntity.GetShootRequest().Invoke();
            }
        }
    }
}