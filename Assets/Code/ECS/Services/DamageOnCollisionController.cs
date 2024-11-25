using Leopotam.EcsLite.Entities;
using OtusHomework.ECS.Components;
using UnityEngine;

namespace OtusHomework.ECS.Services
{
    public sealed class DamageOnCollisionController : MonoBehaviour
    {
        [SerializeField] private float _damage;
        
        private void OnTriggerEnter(Collider other)
        {
            var entity = other.GetComponent<Entity>();
            if (entity == null) return;
            if (entity.HasData<DamageRequest>())
            {
                entity.GetData<DamageRequest>().Value += _damage;
                return;
            }
            
            entity.AddData(new DamageRequest() { Value = _damage });
        }
    }
}