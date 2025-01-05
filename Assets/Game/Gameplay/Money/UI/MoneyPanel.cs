using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay.Money.UI
{
    public class MoneyPanel : MonoBehaviour
    {
        #if UNITY_EDITOR
        public event Action OnAddMoneyBtnClicked;
        public event Action OnRemoveMoneyBtnClicked;  
        public event Action OnClearMoneyBtnClicked;  
        #endif
        
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private Button _addMoneyButton;
        [SerializeField] private Button _removeMoneyButton;
        [SerializeField] private Button _clearMoneyButton;

        public void SetMoneyText(string moneyText)
        {
            _moneyText.text = moneyText;
        }
        #if UNITY_EDITOR
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
        #endif
    }
}
