namespace ShootEmUp
{
    public sealed class PlayerFireObserver : IGameStartListener, IGameFinishListener
    {
        private readonly InputManager _inputManager;

        private readonly Character _character;

        public PlayerFireObserver(InputManager inputManager, Character character)
        {
            _inputManager = inputManager;
            _character = character;
        }

        public void OnStart()
        {
            _inputManager.OnFire += OnFire;
        }

        public void OnFinish()
        {
            _inputManager.OnFire -= OnFire;
        }

        private void OnFire()
        {
            _character.Fire();
        }
    }
}