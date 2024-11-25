
namespace OtusUnityHomework.Presenter
{
    public sealed class UserPresenter : IUserPresenter
    {
        public IUserInfoPresenter UserInfo { get; }
        public IPlayerLevelPresenter PlayerLevel { get; }
        public ICharacterStatStoragePresenter CharacterStatStorage { get; }
        
        public UserPresenter(IUserInfoPresenter userInfo, IPlayerLevelPresenter playerLevel, ICharacterStatStoragePresenter characterStatStorage)
        {
            UserInfo = userInfo;
            PlayerLevel = playerLevel;
            CharacterStatStorage = characterStatStorage;
        }
    }
}