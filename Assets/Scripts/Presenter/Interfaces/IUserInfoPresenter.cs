using System;
using UnityEngine;

namespace OtusUnityHomework.Presenter
{
    public interface IUserInfoPresenter
    {
        string Name { get; }
        string Description { get; }
        Sprite Icon { get; }
        event Action OnUserInfoChanged;
    }
}