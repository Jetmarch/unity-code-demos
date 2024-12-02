using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Factories
{
    public class SceneEntityFactory : MonoBehaviour
    {
        [SerializeField] private SceneEntityWorld _sceneEntityWorld;

        public SceneEntity CreateSceneEntity(SceneEntity prefab, Vector3 position, Quaternion rotation)
        {
            // var newEntity = Instantiate(prefab, position, rotation);
            // _sceneEntityWorld.AddEntity(newEntity);
            var newEntity = _sceneEntityWorld.InstantiateEntity(prefab, position, rotation, null);
            _sceneEntityWorld.AddEntity(newEntity);
            return newEntity;
        }
    }
}