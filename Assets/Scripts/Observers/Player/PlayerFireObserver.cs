using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerFireObserver : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;

        [SerializeField] private Character _character;

        private void OnEnable()
        {
            _inputManager.OnFire += OnFire;
        }

        private void OnDisable()
        {
            _inputManager.OnFire -= OnFire;
        }

        private void OnFire()
        {
            _character.Fire();
        }
    }
}