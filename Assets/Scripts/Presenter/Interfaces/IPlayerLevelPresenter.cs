using System;

namespace OtusUnityHomework.Presenter
{
    public interface IPlayerLevelPresenter
    {
        string PlayerLevelText { get; }
        string ExperienceText { get; }
        int CurrentExperience { get; }
        int RequiredExperience { get; }
        bool CanLevelUp { get; }
        void LevelUp();
        event Action OnLevelDataChanged;
    }
}