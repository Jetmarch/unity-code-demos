using System;
using System.Collections.Generic;
using OtusUnityHomework.Helpers;
using OtusUnityHomework.Model;

namespace OtusUnityHomework.Presenter
{
    public sealed class CharacterStatStoragePresenter : ICharacterStatStoragePresenter
    {
        public event Action OnStatsUpdated;
        
        private readonly CharacterStatStorage _characterStatStorage;
        private readonly CharacterStatPresenterFactory _characterStatPresenterFactory;
        public CharacterStatStoragePresenter(CharacterStatStorage characterStatStorage, CharacterStatPresenterFactory characterStatPresenterFactory)
        {
            _characterStatStorage = characterStatStorage;
            _characterStatPresenterFactory = characterStatPresenterFactory;
            _characterStatStorage.OnStatAdded += CharacterStatStorageOnStatAdded;
            _characterStatStorage.OnStatRemoved += CharacterStatStorageOnStatRemoved;
        }
        public List<ICharacterStatPresenter> GetStats()
        {
            var characterStats = _characterStatStorage.GetStats();
            var characterStatPresenters = new List<ICharacterStatPresenter>();
            for (int i = 0; i < characterStats.Length; i++)
            {
                if (characterStats[i] == null)
                {
                    continue;
                }
                
                var characterStatPresenter = _characterStatPresenterFactory.Create(characterStats[i]);
                characterStatPresenters.Add(characterStatPresenter);
            }
            
            return characterStatPresenters;
        }

        private void CharacterStatStorageOnStatAdded(CharacterStat obj)
        {
            OnStatsUpdated?.Invoke();
        }
        private void CharacterStatStorageOnStatRemoved(CharacterStat obj)
        {
            OnStatsUpdated?.Invoke();
        }
    }
}