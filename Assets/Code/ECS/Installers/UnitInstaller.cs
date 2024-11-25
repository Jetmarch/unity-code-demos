using Leopotam.EcsLite.Entities;
using OtusHomework.ECS.Components;
using UnityEngine;

namespace OtusHomework.ECS.Installers
{
    public sealed class UnitInstaller : EntityInstaller
    {
        [SerializeField] private float _moveSpeed = 5.0f;
        [SerializeField] private float _health = 5f;
        [SerializeField] private float _attackDistance = 5f;
        [SerializeField] private float _fireRate = 1f;

        [SerializeField] private UnitTeam _team;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Entity _bulletPrefab;
        
        protected override void Install(Entity entity)
        {
            entity.AddData(new Unit { Team = _team});
            entity.AddData(new Position { Value = transform.position });
            entity.AddData(new Rotation { Value = transform.rotation });
            entity.AddData(new MoveDirection { Value = transform.forward });
            entity.AddData(new MoveSpeed { Value = _moveSpeed });
            entity.AddData(new TransformView { Value = transform });
            entity.AddData(new BulletWeapon
            {
                FirePoint = _firePoint,
                BulletPrefab = _bulletPrefab,
                FireRate = _fireRate
            });
            entity.AddData(new Health { Value = _health });
            entity.AddData(new AttackDistance { Value = _attackDistance });
        }

        protected override void Dispose(Entity entity)
        {
        }
    }
}