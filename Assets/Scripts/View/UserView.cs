using OtusUnityHomework.Presenter;
using UnityEngine;

namespace OtusUnityHomework.View
{
    public sealed class UserView : MonoBehaviour
    {
        [SerializeField] private UserInfoView _userInfoView;
        [SerializeField] private PlayerLevelView _playerLevelView;
        [SerializeField] private CharacterStatStorageView _characterStatStorageView;
        
        public void Show(IUserPresenter presenter)
        {
            gameObject.SetActive(true);
            _userInfoView.Show(presenter.UserInfo);
            _playerLevelView.Show(presenter.PlayerLevel);
            _characterStatStorageView.Show(presenter.CharacterStatStorage);
        }

        public void Hide()
        {
            _userInfoView.Hide();
            _playerLevelView.Hide();
            _characterStatStorageView.Hide();
            gameObject.SetActive(false);
        }
    }
}