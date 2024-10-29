using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class MoveComponent
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _speed = 1.0f;

        public void Move(Vector2 vector)
        {
            var nextPosition = _rigidbody2D.position + vector * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}