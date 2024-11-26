using HomeworkSaveLoad.SaveSystem;
using VContainer;

namespace HomeworkSaveLoad.GameData
{
    public sealed class VContainerGameContext : IGameContext
    {
        private readonly IObjectResolver _resolver;
        
        public VContainerGameContext(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public T GetService<T>()
        {
            return _resolver.Resolve<T>();
        }
    }
}