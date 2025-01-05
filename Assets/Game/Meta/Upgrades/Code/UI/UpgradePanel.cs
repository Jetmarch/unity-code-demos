using Game.Meta.Upgrades.Presenters;
using TMPro;
using UnityEngine;

namespace Game.Meta.Upgrades.UI
{
    public sealed class UpgradePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _valueText;
        [SerializeField] private TextMeshProUGUI _levelText;
        
        [SerializeField] private UpgradeButton _upgradeButton;

        private IUpgradePresenter _presenter;
        
        public void Configure(IUpgradePresenter presenter)
        {
            _presenter = presenter;
            Show();
        }

        public void Show()
        {
            _container.SetActive(true);
            _nameText.text = _presenter.Name;
            _valueText.text = _presenter.Value;
            _levelText.text = _presenter.Level;
        }

        public void Hide()
        {
            _container.SetActive(false);
        }
    }
}
