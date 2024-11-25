using OtusUnityHomework.Helpers;
using OtusUnityHomework.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OtusUnityHomework.Installers
{
    public class UILifetimeScope : LifetimeScope
    {
        [SerializeField] private CharacterStatViewFactoryParams _characterStatViewFactoryParams;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<CharacterStatPresenterFactory>(Lifetime.Scoped);
            builder.Register<UserPresenterFactory>(Lifetime.Scoped);
            builder.Register<CharacterStatViewFactory>(Lifetime.Scoped)
                .WithParameter(_characterStatViewFactoryParams);
        }
    }
}