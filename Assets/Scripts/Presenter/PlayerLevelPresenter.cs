using System;
using OtusUnityHomework.Model;

namespace OtusUnityHomework.Presenter
{
    public sealed class PlayerLevelPresenter : IPlayerLevelPresenter
    {
        public string PlayerLevelText => GetPlayerLevelText();

        public string ExperienceText => GetExperienceText();

        public int CurrentExperience => _playerLevel.CurrentExperience;

        public int RequiredExperience => _playerLevel.RequiredExperience;
        
        public bool CanLevelUp => _playerLevel.CanLevelUp();
        
        public event Action OnLevelDataChanged;

        private readonly PlayerLevel _playerLevel;
        
        public PlayerLevelPresenter(PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            _playerLevel.OnLevelUp += PlayerLevelOnLevelUp;
            _playerLevel.OnExperienceChanged += PlayerLevelOnExperienceChanged;
        }

        public void LevelUp()
        {
            _playerLevel.LevelUp();
        }

        private string GetPlayerLevelText()
        {
            return string.Concat("Level: ", _playerLevel.CurrentLevel.ToString());
        }

        private string GetExperienceText()
        {
            return string.Concat("XP: ", _playerLevel.CurrentExperience.ToString(), 
                " / ", _playerLevel.RequiredExperience.ToString());
        }

        private void PlayerLevelOnLevelUp()
        {
            OnLevelDataChanged?.Invoke();
        }
        
        private void PlayerLevelOnExperienceChanged(int _)
        {
            OnLevelDataChanged?.Invoke();
        }
    }
}