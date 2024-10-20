using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp.UI
{
    public class ButtonView : MonoBehaviour
    {
        public event Action OnButtonClick;

        [SerializeField] private GameObject _container;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _buttonText;

        private void Start()
        {
            _button.onClick.AddListener(ButtonClick);
        }

        private void ButtonClick()
        {
            OnButtonClick?.Invoke();
        }

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }

        public void UpdateText(string text)
        {
            _buttonText.text = text;
        }
    }
}