using System;
using UnityEngine;

namespace ShootEmUp
{
    public interface IHittable
    {
        HitPointsComponent HitPointsComponent { get; }
    }
    
    [Serializable]
    public sealed class HitPointsComponent
    {
        public event Action<GameObject> OnDeath;

        [SerializeField] private int _hitPoints;
        
        private GameObject _owner;
        public void Construct(GameObject owner)
        {
            _owner = owner;
        }
        
        public bool IsHitPointsExists()
        {
            return _hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                OnDeath?.Invoke(_owner);
            }
        }
    }
}