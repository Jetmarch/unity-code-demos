using System;

namespace OtusUnityHomework.Presenter
{
    public interface ICharacterStatPresenter
    {
        string CharacterStat { get; }
        event Action OnValueChanged;
    }
}