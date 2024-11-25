using OtusUnityHomework.Model;
using Presenter;

namespace OtusUnityHomework.Helpers
{
    public sealed class CharacterStatPresenterFactory
    {
        public CharacterStatPresenter Create(CharacterStat characterStat)
        {
            return new CharacterStatPresenter(characterStat);
        }
    }
}