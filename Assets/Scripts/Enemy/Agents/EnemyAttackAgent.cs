using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyAttackAgent
    {
        [SerializeField] private WeaponComponent _weaponComponent;

        [SerializeField] private float _attackDelay = 1f;

        private GameObject _target;

        private float _currentTime;

        private bool _isActive;

        public void Construct(BulletFactory bulletFactory, GameObject target, TeamComponent teamComponent)
        {
            _weaponComponent.Construct(bulletFactory, teamComponent);
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

        public void OnFixedUpdate(float fixedDelta)
        {
            if (!_isActive)
            {
                return;
            }

            DelayedAttack(fixedDelta);
        }

        public void Reset()
        {
            _currentTime = _attackDelay;
            Deactivate();
        }

        private void DelayedAttack(float delta)
        {
            _currentTime -= delta;
            if (!(_currentTime <= 0)) return;
            
            Fire();
            _currentTime += _attackDelay;
        }

        private void Fire()
        {
            var direction = ((Vector2)_target.transform.position - _weaponComponent.Position).normalized;
            _weaponComponent.Fire(direction);
        }
    }
}