using UnityEngine;

namespace Game.Gameplay.Conveyor
{
    [CreateAssetMenu(fileName = "ConveyorRecipe", menuName = "Configs/Conveyor/Recipe")]
    public sealed class ConveyorRecipeConfig : ScriptableObject
    {
        [SerializeField] private ConveyorRecipe _prototype;
        public ConveyorRecipe Clone()
        {
            return new ConveyorRecipe(_prototype.RequiredResource, _prototype.ResultingResource);
        }
        
        #if UNITY_EDITOR
        public void SetPrototype(ConveyorRecipe prototype)
        {
            _prototype = prototype;
        }
        #endif
    }
}