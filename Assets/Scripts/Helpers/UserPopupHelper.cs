using OtusUnityHomework.Model.SO;
using OtusUnityHomework.View;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace OtusUnityHomework.Helpers
{
    public sealed class UserPopupHelper : MonoBehaviour
    {
        [SerializeField] private UserView _view;
        [SerializeField] private UserData _userData;
        
        private UserPresenterFactory _userPresenterFactory;

        [Inject]
        private void Construct(UserPresenterFactory userPresenterFactory)
        {
            _userPresenterFactory = userPresenterFactory;
        }

        [Button]
        private void ShowUserPopup()
        {
            var userPresenter = _userPresenterFactory.Create(_userData);
            _view.Show(userPresenter);
        }
        
        [Button]
        private void HideUserPopup()
        {
            _view.Hide();
        }
    }
}