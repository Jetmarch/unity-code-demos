using Cysharp.Threading.Tasks;
using Game.Meta.Upgrades;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Game.Gameplay.Conveyor
{
    public class ConveyorDebug : MonoBehaviour
    {
        [SerializeField] private Conveyor _conveyor;
        [SerializeField] private UpgradeManager _upgradeManager;
        
        [Inject]
        private void Configure(Conveyor conveyor, UpgradeManager upgradeManager)
        {
            _conveyor = conveyor;
            _upgradeManager = upgradeManager;
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

        [Button]
        public void LevelUpConveyor(UpgradeConfig upgradeConfig)
        {
            _upgradeManager.LevelUp(upgradeConfig.Id);
        }
    }
}
