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
        public void ConvertResource(ConveyorResourceConfig config)
        {
            var resource = config.Clone();
            _conveyor.AddResourceAsync(resource).GetAwaiter().OnCompleted(() =>
            {
                Debug.Log("Resource added to input");
                _conveyor.ConvertNextResource().GetAwaiter().OnCompleted(() =>
                {
                    var convertedResource = _conveyor.GetConvertedResourceAsync().GetAwaiter().GetResult();
                    Debug.Log($"Resource {resource.Name} has converted to {convertedResource.Name}");
                });
            });
        }
    }
}
