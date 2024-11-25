using System;

namespace OtusHomework.ECS.Components
{
    [Serializable]
    public struct SpawnPoint
    {
        public int SpawnCount;
        public float SpawnRadius;
    }
}