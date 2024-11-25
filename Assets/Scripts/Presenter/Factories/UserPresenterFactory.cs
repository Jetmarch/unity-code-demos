using OtusUnityHomework.Model.SO;
using OtusUnityHomework.Presenter;

namespace OtusUnityHomework.Helpers
{
    public sealed class UserPresenterFactory
    {
        private readonly CharacterStatPresenterFactory _characterStatPresenterFactory;

        public UserPresenterFactory(CharacterStatPresenterFactory characterStatPresenterFactory)
        {
            _characterStatPresenterFactory = characterStatPresenterFactory;
        }
        
        public UserPresenter Create(UserData userData)
        {
            var userInfoPresenter = new UserInfoPresenter(userData.UserInfo);
            var playerLevelPresenter = new PlayerLevelPresenter(userData.PlayerLevel);
            var playerStatsPresenter = new CharacterStatStoragePresenter(userData.CharacterStatStorage, _characterStatPresenterFactory);
            
            var userPresenter = new UserPresenter(userInfoPresenter, playerLevelPresenter, playerStatsPresenter);
            return userPresenter;
        }
    }
}