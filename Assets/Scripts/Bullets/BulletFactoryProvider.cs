using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class BulletFactoryProvider
    {
        public Transform WorldTransform { get; private set; }
        public GameObjectPool Pool { get; private set; }
        
        [Inject]
        public BulletFactoryProvider(GameObjectPool pool, Transform worldTransform)
        {
            Pool = pool;
            WorldTransform = worldTransform;
        }
    }
}