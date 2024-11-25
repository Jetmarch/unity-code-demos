using System;
using OtusUnityHomework.Model;
using UnityEngine;

namespace OtusUnityHomework.Presenter
{
    public sealed class UserInfoPresenter : IUserInfoPresenter
    {
        public string Name => _userInfo.Name;
        public string Description => _userInfo.Description;
        public Sprite Icon => _userInfo.Icon;
        public event Action OnUserInfoChanged;

        private readonly UserInfo _userInfo;
        
        public UserInfoPresenter(UserInfo userInfo)
        {
            _userInfo = userInfo;   
            _userInfo.OnNameChanged += UserInfoOnNameChanged;
            _userInfo.OnDescriptionChanged += UserInfoOnDescriptionChanged;
            _userInfo.OnIconChanged += UserInfoOnIconChanged;
        }

        private void UserInfoOnNameChanged(string obj)
        {
            OnUserInfoChanged?.Invoke();
        }

        private void UserInfoOnDescriptionChanged(string obj)
        {
            OnUserInfoChanged?.Invoke();
        }

        private void UserInfoOnIconChanged(Sprite obj)
        {
            OnUserInfoChanged?.Invoke();
        }
    }
}