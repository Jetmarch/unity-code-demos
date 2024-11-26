using GameEngine;
using HomeworkSaveLoad.GameData;
using HomeworkSaveLoad.SaveSystem;
using HomeworkSaveLoad.SaveSystem.SaveLoaders;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace HomeworkSaveLoad.Installers
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private Transform _unitParent;
        
        [SerializeField] private UnitManager _unitManager;

        [SerializeField] private ResourceService _resourceService;
        
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureServices(builder);
            ConfigureSaveLoaders(builder);
        }

        private void ConfigureServices(IContainerBuilder builder)
        {
            builder.RegisterInstance(_unitManager).WithParameter(_unitParent);
            builder.RegisterInstance(_resourceService);
            
            builder.Register<VContainerGameContext>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<GameRepository>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void ConfigureSaveLoaders(IContainerBuilder builder)
        {
            builder.Register<UnitsSaveLoader>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<ResourceSaveLoader>(Lifetime.Scoped).AsImplementedInterfaces();
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            _unitManager.SetupUnits(FindObjectsOfType<Unit>());
            _resourceService.SetResources(FindObjectsOfType<Resource>());
        }
        #endif
    }
}