using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weaponComponent;

        [SerializeField] private float _attackDelay = 1f;

        private GameObject _target;

        private float _currentTime;

        private bool _isActive;

        public void Construct(BulletFactory bulletFactory, GameObject target)
        {
            _weaponComponent.Construct(bulletFactory);
            SetTarget(target);
        }

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
            if (!_isActive)
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
            var direction = ((Vector2)_target.transform.position - _weaponComponent.Position).normalized;
            _weaponComponent.Fire(direction);
        }
    }
}