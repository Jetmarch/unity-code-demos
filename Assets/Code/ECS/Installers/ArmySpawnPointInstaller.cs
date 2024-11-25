using Leopotam.EcsLite.Entities;
using OtusHomework.ECS.Components;
using UnityEngine;

namespace OtusHomework.ECS.Installers
{
    public sealed class ArmySpawnPointInstaller : EntityInstaller
    {
        [SerializeField] private Entity _unitPrefab;
        [SerializeField] private int _spawnCount = 100;
        [SerializeField] private float _spawnRadius = 20f;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new Position { Value = transform.position });
            entity.AddData(new Rotation { Value = transform.rotation });
            entity.AddData(new Prefab { Value = _unitPrefab, });
            entity.AddData(new SpawnPoint
            {
                SpawnCount = _spawnCount,
                SpawnRadius = _spawnRadius
            });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}