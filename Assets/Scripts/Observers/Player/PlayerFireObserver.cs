using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerFireObserver : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;

        [SerializeField] private Character _characterController;

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
            _characterController.Fire();
        }
    }
}