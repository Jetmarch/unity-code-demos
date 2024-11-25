using OtusUnityHomework.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OtusUnityHomework.View
{
    public sealed class PlayerLevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerLevelText;
        [SerializeField] private Slider _experienceSlider;
        [SerializeField] private TMP_Text _experienceSliderText;
        [SerializeField] private Button _levelUpButton;
        
        private IPlayerLevelPresenter _presenter;

        public void Show(IPlayerLevelPresenter presenter)
        {
            _presenter = presenter;
            gameObject.SetActive(true);
            _presenter.OnLevelDataChanged += UpdateView;
            _levelUpButton.onClick.AddListener(RequestLevelUp);
            
            UpdateView();
        }
        
        public void Hide()
        {
            _levelUpButton.onClick.RemoveListener(RequestLevelUp);
            _presenter.OnLevelDataChanged -= UpdateView;
            gameObject.SetActive(false);
        }

        private void RequestLevelUp()
        {
            if (_presenter.CanLevelUp)
            {
                _presenter.LevelUp();
            }
        }

        private void UpdateView()
        {
            _playerLevelText.text = _presenter.PlayerLevelText;
            _levelUpButton.interactable = _presenter.CanLevelUp;
            _experienceSliderText.text = _presenter.ExperienceText;
            _experienceSlider.maxValue = _presenter.RequiredExperience;
            _experienceSlider.value = _presenter.CurrentExperience;
        }
    }
}