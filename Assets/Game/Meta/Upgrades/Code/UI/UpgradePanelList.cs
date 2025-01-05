using System.Collections.Generic;
using Game.Meta.Upgrades.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Game.Meta.Upgrades.UI
{
    public sealed class UpgradePanelList : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private List<UpgradePanel> _upgradePanels = new();

        [SerializeField] private Transform _panelContainer;
        [SerializeField] private UpgradePanel _panelPrefab;

        private IUpgradeListPresenter _presenter;
        
        [Inject]
        public void Construct(IUpgradeListPresenter presenter)
        {
            _presenter = presenter;
        }

        [Button]
        public void Show()
        {
            // _container.SetActive(true);
            // ClearUpgradePanels();
            var upgradePresenters = _presenter.GetUpgradePresenters();
            foreach (var upgradePresenter in upgradePresenters)
            {
                var upgradePanel = Instantiate(_panelPrefab, _panelContainer);
                upgradePanel.Configure(upgradePresenter);
                _upgradePanels.Add(upgradePanel);
            }
        }
        [Button]
        public void Hide()
        {
            ClearUpgradePanels();

            // _container.SetActive(false);
        }

        private void ClearUpgradePanels()
        {
            foreach (var upgradePanel in _upgradePanels)
            {
                upgradePanel.Hide();
                Destroy(upgradePanel.gameObject);
            }
            _upgradePanels.Clear();
        }
    }
}
