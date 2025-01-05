using Game.Meta.Upgrades.Presenters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Meta.Upgrades.UI
{
    public sealed class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private GameObject _maxLevelImage;

        private IUpgradeButtonPresenter _presenter;
        public void Configure(IUpgradeButtonPresenter presenter)
        {
            _presenter = presenter;
            
        }
        public void Show()
        {
            _container.SetActive(true);
            _buyButton.onClick.AddListener(LevelUp);
            _presenter.OnMoneyChanged += OnMoneyChanged;
            UpdateButtonState();
        }

        public void Hide()
        {
            _buyButton.onClick.RemoveListener(LevelUp);
            _presenter.OnMoneyChanged -= OnMoneyChanged;
            _container.SetActive(false);
        }

        private void UpdateButtonState()
        {
            _priceText.text = _presenter.Price;
            _buyButton.interactable = _presenter.CanBuy;
            _maxLevelImage.SetActive(!_presenter.CanLevelUp);
        }
        
        private void LevelUp()
        {
            _presenter.LevelUp();
            UpdateButtonState();
        }
        
        private void OnMoneyChanged()
        {
            UpdateButtonState();
        }
    }
}