using System;
using Cysharp.Threading.Tasks;

namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorWorkZone
    {
        public event Action<ConveyorResource> OnResourceConverted;
        public event Action<ConveyorResource> OnResourceCannotConvert;
        public event Action OnConveyorBusy;
        public bool IsBusy { get; private set; }

        private readonly ConveyorAttributes _attributes;
        private readonly ConveyorRecipe _currentRecipe;

        public ConveyorWorkZone(ConveyorAttributes attributes, ConveyorRecipe recipe)
        {
            _attributes = attributes;
            _currentRecipe = recipe;
        }

        public async UniTask<ConveyorResource> ConvertResource(ConveyorResource resource)
        {
            if (IsBusy)
            {
                OnConveyorBusy?.Invoke();
                return default;
            }

            if (!CanConvert(resource))
            {
                OnResourceCannotConvert?.Invoke(resource);
                return default;
            }

            IsBusy = true;
            
            var convertTimeInSeconds = _attributes.BaseWorkTime * resource.ConvertModifier;
            await UniTask.Delay(TimeSpan.FromSeconds(convertTimeInSeconds));
            OnResourceConverted?.Invoke(_currentRecipe.RequiredResource);
            
            IsBusy = false;
            return _currentRecipe.ResultingResource;
        }

        private bool CanConvert(ConveyorResource resource)
        {
            return _currentRecipe.RequiredResource.Name == resource.Name;
        }
    }
}