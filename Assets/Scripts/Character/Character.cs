using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public sealed class Character : MonoBehaviour, IGameFixedUpdateListener, IGameFinishListener, ITeamable, IHittable
    {
        public HitPointsComponent HitPointsComponent => _hitPoints;
        public TeamComponent TeamComponent => _teamComponent;
        
        [SerializeField] private HitPointsComponent _hitPoints;
        
        [SerializeField] private WeaponComponent _weaponComponent;

        [SerializeField] private MoveComponent _moveComponent;
        
        [SerializeField] private TeamComponent _teamComponent;

        private float _horizontalDirection;

        [Inject]
        private void Construct(BulletFactory bulletFactory)
        {
            _weaponComponent.Construct(bulletFactory, _teamComponent);
            _hitPoints.Construct(gameObject);
        }

        public void Fire()
        {
            _weaponComponent.Fire(_weaponComponent.Rotation * Vector3.up);
        }

        public void Move(float horizontalDirection)
        {
            _horizontalDirection = horizontalDirection;
        }

        public void OnFixedUpdate(float fixedDelta)
        {
            _moveComponent.Move(new Vector2(_horizontalDirection, 0) * fixedDelta);
        }

        public void OnFinish()
        {
            Move(0);
        }


        
    }
}