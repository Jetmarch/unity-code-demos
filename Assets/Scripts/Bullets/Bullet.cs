using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour, IGamePauseListener, IGameResumeListener, IGameFinishListener, IGameFixedUpdateListener
    {
        public event Action<Bullet> OnCollisionEntered;

        public bool IsPlayer { get { return _bulletInfo.IsPlayer; } }

        public int Damage { get { return _bulletInfo.Damage; } }

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private MoveComponent _moveComponent;

        private BulletInfo _bulletInfo;
        private Vector2 _currentVelocity;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void Construct(Transform worldTransform, BulletInfo bulletInfo)
        {
            _bulletInfo = bulletInfo;
            transform.SetParent(worldTransform);
            SetPosition(bulletInfo.Position);
            SetColor(bulletInfo.Color);
            SetPhysicsLayer(bulletInfo.PhysicsLayer);
            SetVelocity(bulletInfo.Velocity);
        }

        public void SetVelocity(Vector2 velocity)
        {
            _currentVelocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            BulletUseCase.DealDamage(this, collision.gameObject);
            OnCollisionEntered?.Invoke(this);
        }

        public void OnPause()
        {
            SetVelocity(Vector2.zero);
        }

        public void OnResume()
        {
            SetVelocity(_bulletInfo.Velocity);
        }

        public void OnFinish()
        {
            SetVelocity(Vector2.zero);
        }

        public void OnFixedUpdate(float delta)
        {
            _moveComponent.Move(_currentVelocity * delta);
        }
    }
}