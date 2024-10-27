using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerMoveObserver : IGameStartListener, IGameFinishListener
    {
        private readonly InputManager _inputManager;

        private readonly Character _character;

        public PlayerMoveObserver(InputManager inputManager, Character character)
        {
            _inputManager = inputManager;
            _character = character;
        }

        public void OnStart()
        {
            _inputManager.OnMove += _character.Move;
        }

        public void OnFinish()
        {
            _inputManager.OnMove -= _character.Move;
        }
    }
}