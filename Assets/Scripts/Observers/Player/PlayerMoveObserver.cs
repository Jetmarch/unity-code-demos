using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerMoveObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private InputManager _inputManager;

        [SerializeField] private Character _character;

        private void Start()
        {
            IGameListener.Register(this);
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