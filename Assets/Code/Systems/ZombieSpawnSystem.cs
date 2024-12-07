using System;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Utils;

namespace ZombieShooter.Systems
{
    [Serializable]
    public sealed class ZombieSpawnSystemData
    {
        public IEntityPool Pool;
        public Transform[] SpawnPoints;
        public float SpawnRadius;
        public Cycle SpawnCycle;
    }
    
    public sealed class ZombieSpawnSystem : IContextInit, IContextEnable, IContextDisable, IContextUpdate
    {
        private IContext _context;
        private Cycle _spawnPeriod;
        
        public void Init(IContext context)
        {
            _context = context;
            _spawnPeriod = context.GetZombieSpawnSystemData().SpawnCycle;
        }

        public void Enable(IContext context)
        {
            _spawnPeriod.Start();
            _spawnPeriod.OnCycle += Spawn;
        }

        public void Update(IContext context, float deltaTime)
        {
            _spawnPeriod.Tick(deltaTime);
        }
        
        public void Disable(IContext context)
        {
            _spawnPeriod.Stop();
            _spawnPeriod.OnCycle -= Spawn;
        }
        private void Spawn()
        {
            // _context.SpawnZombieInArea();
            Debug.Log("Spawning Zombie");
            _context.SpawnZombieInRandomPoint();
        }
    }

    [Serializable]
    public sealed class ZombieSpawnInstaller : IContextInstaller
    {
        [SerializeField] private SceneEntity _zombiePrefab;
        [SerializeField] private int _initialPoolCount;
        [SerializeField] private Transform _poolTransform;
        [SerializeField] private float _spawnPeriod;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _spawnRadius;
        
        public void Install(IContext context)
        {
            var worldTransform = context.GetWorldTransform();
            var zombieSpawnData = new ZombieSpawnSystemData
            {
                Pool = new SceneEntityPool(_zombiePrefab, worldTransform, _poolTransform, _initialPoolCount),
                SpawnPoints = _spawnPoints,
                SpawnRadius = _spawnRadius,
                SpawnCycle = new Cycle(_spawnPeriod)
            };

            context.AddZombieSpawnSystemData(zombieSpawnData);
            context.AddSystem<ZombieSpawnSystem>();
        }
    }

    public static class ZombieSpawnUseCases
    {
        public static IEntity SpawnZombieInRandomPoint(this IContext context)
        {
            var randomSpawnPoint = context.GetRandomSpawnPoint();
            return context.SpawnZombie(randomSpawnPoint.position);
        }

        public static IEntity SpawnZombie(this IContext context, Vector3 spawnPoint)
        {
            IEntityPool zombiePool = context.GetZombieSpawnSystemData().Pool;
            IEntity zombie = zombiePool.Get();
            zombie.GetTransform().position = spawnPoint;
            return zombie;
        }

        private static Transform GetRandomSpawnPoint(this IContext context)
        {
            var spawnPoints = context.GetZombieSpawnSystemData().SpawnPoints;
            var randomPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            return spawnPoints[randomPointIndex];
        }
    }
}