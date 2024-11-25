namespace OtusUnityHomework.Presenter
{
    public interface IUserPresenter
    {
        IUserInfoPresenter UserInfo { get; }
        IPlayerLevelPresenter PlayerLevel { get; }
        ICharacterStatStoragePresenter CharacterStatStorage { get; }
    }
}