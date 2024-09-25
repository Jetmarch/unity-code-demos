using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached
        {
            get { return _isReached; }
        }

        public event Action OnReachedDestination;

        [SerializeField] private MoveComponent _moveComponent;

        [SerializeField] private float _minDestinationMagnitude = 0.25f;

        private Vector2 _destination;

        private bool _isReached;

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
        }

        private void FixedUpdate()
        {
            if (_isReached)
            {
                return;
            }

            Move(Time.fixedDeltaTime);
        }

        private void Move(float delta)
        {
            var vector = _destination - (Vector2)transform.position;
            if (vector.magnitude <= _minDestinationMagnitude)
            {
                _isReached = true;
                OnReachedDestination?.Invoke();
                return;
            }

            var direction = vector.normalized * delta;
            _moveComponent.Move(direction);
        }
    }
}