using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    public class ConveyorDebug : MonoBehaviour
    {
        private ConveyorController _conveyorController;
        
        [Button]
        public void AddConveyorResource(ConveyorResourceConfig config)
        {
            var resource = config.Clone();
            _conveyorController.AddResourceAsync(resource).Forget();
        }
    }
}
