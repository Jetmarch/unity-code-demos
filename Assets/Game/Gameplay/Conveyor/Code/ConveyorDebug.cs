using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Game.Gameplay.Conveyor
{
    public class ConveyorDebug : MonoBehaviour
    {
        private Conveyor _conveyor;

        [Inject]
        private void Configure(Conveyor conveyor)
        {
            _conveyor = conveyor;
        }
        
        [Button]
        public void AddResource(ConveyorResourceConfig config)
        {
            var resource = config.Clone();
            _conveyor.AddResourceAsync(resource).Forget();
        }
        
        [Button]
        public void ConvertNextResource()
        {
            _conveyor.ConvertNextResourceAsync().Forget();
        }

        [Button]
        public void GetConvertedResource()
        {
            var task = _conveyor.GetConvertedResourceAsync();
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                var resource = task.GetAwaiter().GetResult();
                Debug.Log($"Resource obtained: {resource.Name}");
            });
        }
    }
}
