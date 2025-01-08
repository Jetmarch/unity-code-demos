using System;
using Game.Gameplay.Money.UI;
using VContainer.Unity;

namespace Game.Gameplay.Money.Controllers
{
    public sealed class MoneyDebugController : IInitializable, IDisposable
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly MoneyDebugPanel _moneyDebugPanel;
        private readonly int _moneyAmount;

        public MoneyDebugController(MoneyStorage moneyStorage, MoneyDebugPanel moneyDebugPanel, int moneyAmount)
        {
            _moneyStorage = moneyStorage;
            _moneyDebugPanel = moneyDebugPanel;
            _moneyAmount = moneyAmount;
        }

        public void Initialize()
        {
            _moneyDebugPanel.OnAddMoneyBtnClicked += MoneyDebugPanelOnAddMoneyDebugBtnClicked;
            _moneyDebugPanel.OnRemoveMoneyBtnClicked += MoneyDebugPanelOnRemoveMoneyDebugBtnClicked;
            _moneyDebugPanel.OnClearMoneyBtnClicked += MoneyDebugPanelOnClearMoneyDebugBtnClicked;
            SetupButtons();
        }

        public void Dispose()
        {
            _moneyDebugPanel.OnAddMoneyBtnClicked -= MoneyDebugPanelOnAddMoneyDebugBtnClicked;
            _moneyDebugPanel.OnRemoveMoneyBtnClicked -= MoneyDebugPanelOnRemoveMoneyDebugBtnClicked;
            _moneyDebugPanel.OnClearMoneyBtnClicked -= MoneyDebugPanelOnClearMoneyDebugBtnClicked;
        }

        private void SetupButtons()
        {
            _moneyDebugPanel.SetAddMoneyText($"+{_moneyAmount}");
            _moneyDebugPanel.SetRemoveMoneyText($"-{_moneyAmount}");
            _moneyDebugPanel.SetClearMoneyText("Clear");
        }
        
        private void MoneyDebugPanelOnAddMoneyDebugBtnClicked()
        {
            _moneyStorage.Add(_moneyAmount);
        }
        
        private void MoneyDebugPanelOnRemoveMoneyDebugBtnClicked()
        {
            _moneyStorage.Get(_moneyAmount);
        }
        
        private void MoneyDebugPanelOnClearMoneyDebugBtnClicked()
        {
            _moneyStorage.Set(0);
        }
    }
}