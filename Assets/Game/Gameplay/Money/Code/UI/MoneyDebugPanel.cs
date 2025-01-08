using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay.Money.UI
{
    public sealed class MoneyDebugPanel : MonoBehaviour
    {
        public event Action OnAddMoneyBtnClicked;
        public event Action OnRemoveMoneyBtnClicked;
        public event Action OnClearMoneyBtnClicked;
        
        [SerializeField] private Button _addMoneyButton;
        [SerializeField] private Button _removeMoneyButton;
        [SerializeField] private Button _clearMoneyButton;

        public void SetAddMoneyText(string text)
        {
            _addMoneyButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        public void SetRemoveMoneyText(string text)
        {
            _removeMoneyButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        public void SetClearMoneyText(string text)
        {
            _clearMoneyButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
        
        private void OnEnable()
        {
            _addMoneyButton.onClick.AddListener(NotifyAddMoney);
            _removeMoneyButton.onClick.AddListener(NotifyRemoveMoney);
            _clearMoneyButton.onClick.AddListener(NotifyClearMoney);
        }

        private void OnDisable()
        {
            _addMoneyButton.onClick.RemoveListener(NotifyAddMoney);
            _removeMoneyButton.onClick.RemoveListener(NotifyRemoveMoney);
            _clearMoneyButton.onClick.RemoveListener(NotifyClearMoney);
        }

        private void NotifyAddMoney()
        {
            OnAddMoneyBtnClicked?.Invoke();   
        }

        private void NotifyRemoveMoney()
        {
            OnRemoveMoneyBtnClicked?.Invoke();
        }

        private void NotifyClearMoney()
        {
            OnClearMoneyBtnClicked?.Invoke();
        }
    }
}