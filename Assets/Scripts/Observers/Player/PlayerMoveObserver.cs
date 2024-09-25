using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerMoveObserver : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;

        [SerializeField] private Character _character;

        private void OnEnable()
        {
            _inputManager.OnMove += _character.Move;
        }

        private void OnDisable()
        {
            _inputManager.OnMove -= _character.Move;
        }
    }
}