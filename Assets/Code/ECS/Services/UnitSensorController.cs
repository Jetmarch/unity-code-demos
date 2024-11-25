using Leopotam.EcsLite.Entities;
using OtusHomework.ECS.Components;
using UnityEngine;

namespace OtusHomework.ECS.Services
{
    public sealed class UnitSensorController : MonoBehaviour
    {
        [SerializeField] private Entity _owner;
        
        private void OnTriggerEnter(Collider other)
        {
            var entity = other.GetComponent<Entity>();
            if (entity == null) return;
            if (!entity.HasData<Unit>()) return;
            _owner.SetData(new Target() { Value = entity });
        }

        private void OnTriggerExit(Collider other)
        {
            var entity = other.GetComponent<Entity>();
            if (entity == null) return;
            if (!entity.HasData<Unit>()) return;
            _owner.RemoveData<Target>();
        }
    }
}