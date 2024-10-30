using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    [Serializable]
    public struct EnemyPositionsData
    {
        [SerializeField] public Transform[] SpawnPositions;

        [SerializeField] public Transform[] AttackPositions;
    }

    public sealed class EnemyPositions
    {
        private readonly EnemyPositionsData _data;

        public EnemyPositions(EnemyPositionsData data)
        {
            _data = data;
        }

        public Transform RandomSpawnPosition()
        {
            return RandomTransform(_data.SpawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return RandomTransform(_data.AttackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}