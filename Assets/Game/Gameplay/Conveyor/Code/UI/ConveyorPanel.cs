using UnityEngine;
using UnityEngine.UI;
using VContainer;
using Sirenix.OdinInspector;

namespace Game.Gameplay.Conveyor
{
    public sealed class ConveyorPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private Button _addResourceButton;
        [SerializeField] private Button _convertResourceButton;
        [SerializeField] private Button _removeResourceFromOutputButton;

        [SerializeField] private ConveyorResourceConfig _resourceConfigToAdd;

        private IConveyorPresenter _presenter;
        
        [Inject]
        private void Configure(IConveyorPresenter presenter)
        {
            _presenter = presenter;
            Show();
        }

        [Button]
        public void Show()
        {
            _container.SetActive(true);
            _addResourceButton.onClick.AddListener(AddResource);
            _convertResourceButton.onClick.AddListener(_presenter.ConvertResource);
            _removeResourceFromOutputButton.onClick.AddListener(_presenter.RemoveResourceFromOutput);
        }

        [Button]
        public void Hide()
        {
            _addResourceButton.onClick.RemoveListener(AddResource);
            _convertResourceButton.onClick.RemoveListener(_presenter.ConvertResource);
            _removeResourceFromOutputButton.onClick.RemoveListener(_presenter.RemoveResourceFromOutput);
            _container.SetActive(false);
        }

        private void AddResource()
        {
            _presenter.AddResource(_resourceConfigToAdd);
        }
    }
}
