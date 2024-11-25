using System;
using OtusUnityHomework.Model;
using OtusUnityHomework.Presenter;

namespace Presenter
{
    public sealed class CharacterStatPresenter : ICharacterStatPresenter
    {
        public string CharacterStat => string.Concat(_characterStat.Name, ": ", _characterStat.Value.ToString());
        public event Action OnValueChanged;

        private readonly CharacterStat _characterStat;
        
        public CharacterStatPresenter(CharacterStat characterStat)
        {
            _characterStat = characterStat;
            _characterStat.OnValueChanged += CharacterStatOnValueChanged;
        }

        private void CharacterStatOnValueChanged(int obj)
        {
            OnValueChanged?.Invoke();
        }
    }
}