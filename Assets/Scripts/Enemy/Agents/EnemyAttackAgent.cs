using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);

        public event FireHandler OnFire;

        [SerializeField] private WeaponComponent _weaponComponent;

        [SerializeField] private float _attackDelay = 1f;

        private GameObject _target;

        private float _currentTime;

        private bool _isActive;

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public void Activate()
        {
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }

        public void Reset()
        {
            _currentTime = _attackDelay;
            Deactivate();
        }

        private void FixedUpdate()
        {
            if(!_isActive)
            {
                return;
            }

            DelayedAttack(Time.fixedDeltaTime);
        }

        private void DelayedAttack(float delta)
        {
            _currentTime -= delta;
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _attackDelay;
            }
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2)_target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire?.Invoke(gameObject, startPosition, direction);
        }
    }
}