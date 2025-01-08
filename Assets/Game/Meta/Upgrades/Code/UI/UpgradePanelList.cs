using System.Collections.Generic;
using Game.Meta.Upgrades.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Meta.Upgrades.UI
{
    public sealed class UpgradePanelList : MonoBehaviour
    {
        [SerializeField] private Button _closePanelButton;
        [SerializeField] private Button _openPanelButton;
        [SerializeField] private GameObject _container;
        [SerializeField] private List<UpgradePanel> _upgradePanels = new();
        
        private IUpgradeListPresenter _presenter;
        private UpgradePanelFactory _panelFactory;

        private void Start()
        {
            Hide();
        }

        [Inject]
        public void Construct(IUpgradeListPresenter presenter, UpgradePanelFactory panelFactory)
        {
            _presenter = presenter;
            _panelFactory = panelFactory;
        }

        private void OnEnable()
        {
            _closePanelButton.onClick.AddListener(Hide);
            _openPanelButton.onClick.AddListener(Show);
        }

        private void OnDisable()
        {
            _closePanelButton.onClick.RemoveListener(Hide);
            _openPanelButton.onClick.RemoveListener(Show);
        }

        [Button]
        public void Show()
        {
            _container.SetActive(true);
            ClearUpgradePanels();
            var upgradePresenters = _presenter.GetUpgradePresenters();
            foreach (var upgradePresenter in upgradePresenters)
            {
                var upgradePanel = _panelFactory.Create();
                upgradePanel.Configure(upgradePresenter);
                _upgradePanels.Add(upgradePanel);
            }
        }
        
        [Button]
        public void Hide()
        {
            ClearUpgradePanels();
            _container.SetActive(false);
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
