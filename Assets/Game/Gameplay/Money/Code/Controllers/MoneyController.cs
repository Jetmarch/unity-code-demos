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
        }

        public void Dispose()
        {
            _moneyStorage.OnAmountChanged -= MoneyStorageOnAmountChanged;
        }
        
        private void MoneyStorageOnAmountChanged()
        {
            _moneyPanel.SetMoneyText(_moneyStorage.Amount.ToString());
        }
    }
}