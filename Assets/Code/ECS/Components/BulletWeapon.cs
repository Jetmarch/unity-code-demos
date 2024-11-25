using System;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace OtusHomework.ECS.Components
{
    [Serializable]
    public struct BulletWeapon
    {
        public Transform FirePoint;
        public Entity BulletPrefab;
        public float FireRate;
    }
}