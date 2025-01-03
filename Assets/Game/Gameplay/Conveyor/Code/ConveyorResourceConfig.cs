using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    [CreateAssetMenu(menuName = "Configs/Conveyor/Resource Config", fileName = "ConveyorResourceConfig")]
    public sealed class ConveyorResourceConfig : ScriptableObject
    {
        public ConveyorResource Prototype => _prototype;
        
        [SerializeField] private ConveyorResource _prototype;

        public ConveyorResource Clone()
        {
            return new ConveyorResource(_prototype.Name, _prototype.ConvertTimeModifier);
        }
        
        #if UNITY_EDITOR
        public void SetPrototype(ConveyorResource prototype)
        {
            _prototype = prototype;
        }
        
        #endif
    }
}