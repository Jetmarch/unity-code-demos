using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using ZombieShooter.Behaviors;
using ZombieShooter.Factories;

namespace ZombieShooter.Installers
{
    [Serializable]
    public sealed class ShootInstaller
    {
        [SerializeField] private ShootBehavior _shootBehavior;
        [SerializeField] private AndExpression _canFire;
        [SerializeField] private Atomic.Elements.Event _shootAction;
        [SerializeField] private Atomic.Elements.Event _shootRequest;
        [SerializeField] private SceneEntityFactory _sceneEntityFactory;
        public void Install(IEntity entity)
        {
            entity.AddCanFire(_canFire);
            entity.AddShootAction(_shootAction);
            entity.AddShootRequest(_shootRequest);
            entity.AddSceneEntityFactory(_sceneEntityFactory);
            entity.AddBehaviour(_shootBehavior);
        }
    }
}