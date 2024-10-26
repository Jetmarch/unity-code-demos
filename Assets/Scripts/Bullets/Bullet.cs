using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnCollisionEntered;
        public bool IsPlayer => _bulletInfo.IsPlayer;
        public int Damage => _bulletInfo.Damage;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private MoveComponent _moveComponent;

        private BulletInfo _bulletInfo;
        private Vector2 _currentVelocity;
        
        public void Construct(Transform worldTransform, BulletInfo bulletInfo)
        {
            _bulletInfo = bulletInfo;
            transform.SetParent(worldTransform);
            transform.position = bulletInfo.Position;
            _spriteRenderer.color = bulletInfo.Color;
            gameObject.layer = bulletInfo.PhysicsLayer;
            _currentVelocity = bulletInfo.Velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            BulletUseCase.DealDamage(this, collision.gameObject);
            OnCollisionEntered?.Invoke(this);
        }

        public void StopMove()
        {
            _currentVelocity = Vector2.zero;
        }

        public void ResumeMove()
        {
            _currentVelocity = _bulletInfo.Velocity;
        }

        public void Move(float fixedDelta)
        {
            _moveComponent.Move(_currentVelocity * fixedDelta);
        }
    }
}