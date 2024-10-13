using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerFireObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private InputManager _inputManager;

        [SerializeField] private Character _character;

        private void Start()
        {
            IGameListener.Register(this);
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