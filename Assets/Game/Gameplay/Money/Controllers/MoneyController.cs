using System;
using Game.Gameplay.Money.UI;
using VContainer.Unity;

namespace Game.Gameplay.Money.Controllers
{
    public sealed class MoneyController : IInitializable, IDisposable
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly MoneyPanel _moneyPanel;

        public MoneyController(MoneyStorage moneyStorage, MoneyPanel moneyPanel)
        {
            _moneyStorage = moneyStorage;
            _moneyPanel = moneyPanel;
        }

        public void Initialize()
        {
            _moneyStorage.OnAmountChanged += MoneyStorageOnAmountChanged;
            #if UNITY_EDITOR
            _moneyPanel.OnAddMoneyBtnClicked += MoneyPanelOnAddMoneyBtnClicked;
            _moneyPanel.OnRemoveMoneyBtnClicked += MoneyPanelOnRemoveMoneyBtnClicked;
            _moneyPanel.OnClearMoneyBtnClicked += MoneyPanelOnClearMoneyBtnClicked;
            #endif
        }

        public void Dispose()
        {
            _moneyStorage.OnAmountChanged -= MoneyStorageOnAmountChanged;
            #if UNITY_EDITOR
            _moneyPanel.OnAddMoneyBtnClicked -= MoneyPanelOnAddMoneyBtnClicked;
            _moneyPanel.OnRemoveMoneyBtnClicked -= MoneyPanelOnRemoveMoneyBtnClicked;
            _moneyPanel.OnClearMoneyBtnClicked -= MoneyPanelOnClearMoneyBtnClicked;
            #endif
        }
        
        private void MoneyStorageOnAmountChanged()
        {
            _moneyPanel.SetMoneyText(_moneyStorage.Amount.ToString());
        }
        
        #if UNITY_EDITOR
        /// <summary>
        /// Method for testing
        /// </summary>
        private void MoneyPanelOnAddMoneyBtnClicked()
        {
            _moneyStorage.Add(100);
        }
        
        /// <summary>
        /// Method for testing
        /// </summary>
        private void MoneyPanelOnRemoveMoneyBtnClicked()
        {
            _moneyStorage.Get(100);
        }
        
        /// <summary>
        /// Method for testing
        /// </summary>
        private void MoneyPanelOnClearMoneyBtnClicked()
        {
            _moneyStorage.Set(0);
        }
        #endif 
    }
}