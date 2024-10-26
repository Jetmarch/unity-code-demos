using UnityEngine;

namespace ShootEmUp
{
    public sealed class Character : MonoBehaviour, IGameFixedUpdateListener, IGameFinishListener
    {
        [SerializeField] private WeaponComponent _weapon;

        [SerializeField] private BulletConfig _bulletConfig;

        [SerializeField] private MoveComponent _moveComponent;

        private float _horizontalDirection;

        private void Start()
        {
            IGameListener.Register(this);
        }

        private void ShootBullet()
        {
            _weapon.Fire(_weapon.Rotation * Vector3.up);
        }

        public void Fire()
        {
            ShootBullet();
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