using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyMoveAgent
    {
        public bool IsReached
        {
            get { return _isReached; }
        }
        public event Action OnReachedDestination;

        [SerializeField] private MoveComponent _moveComponent;

        [SerializeField] private float _minDestinationMagnitude = 0.25f;
        
        [SerializeField] private Transform _enemyTransform;

        private Vector2 _destination;

        private bool _isReached;

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
        }

        public void OnFixedUpdate(float fixedDelta)
        {
            if (_isReached)
            {
                return;
            }

            Move(fixedDelta);
        }

        private void Move(float delta)
        {
            var vector = _destination - (Vector2)_enemyTransform.position;
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