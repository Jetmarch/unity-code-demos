using System;
using System.Collections.Generic;

namespace OtusUnityHomework.Presenter
{
    public interface ICharacterStatStoragePresenter
    {
        List<ICharacterStatPresenter> GetStats();
        event Action OnStatsUpdated;
    }
}