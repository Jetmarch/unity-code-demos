using OtusUnityHomework.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OtusUnityHomework.View
{
    public class UserInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _userName;
        [SerializeField] private TMP_Text _userDescription;
        [SerializeField] private Image _userIcon;
        
        private IUserInfoPresenter _presenter;

        public void Show(IUserInfoPresenter presenter)
        {
            _presenter = presenter;
            gameObject.SetActive(true);
            _presenter.OnUserInfoChanged += UpdateInfo;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            _userName.text = _presenter.Name;
            _userDescription.text = _presenter.Description;
            _userIcon.sprite = _presenter.Icon;
        }

        public void Hide()
        {
            _presenter.OnUserInfoChanged -= UpdateInfo;
            gameObject.SetActive(false);
        }
    }
}