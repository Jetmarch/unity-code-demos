using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb2D;

        [SerializeField] private float _speed = 5.0f;

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = _rb2D.position + vector * _speed;
            _rb2D.MovePosition(nextPosition);
        }
    }
}