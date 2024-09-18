using UnityEngine;

namespace ShootEmUp
{
    public class PlayerFireObserver : MonoBehaviour
    {
        [SerializeField]
        private InputManager _inputManager;

        [SerializeField]
        private CharacterSystem _characterController;

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