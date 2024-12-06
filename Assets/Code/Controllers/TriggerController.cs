using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Controllers
{
    public class TriggerController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _sceneEntity;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Entity entity))
            {
                _sceneEntity.GetEntityTriggerEnter().Invoke(entity);
            }
        }
    }
}