using UnityEngine;

namespace ShootEmUp
{
    public class PlayerMoveObserver : MonoBehaviour
    {
        [SerializeField]
        private InputManager _inputManager;

        [SerializeField]
        private CharacterSystem _characterController;

        private void OnEnable()
        {
            _inputManager.OnMoveLeft += OnMoveLeft;
            _inputManager.OnMoveRight += OnMoveRight;
            _inputManager.OnStopMove += OnStopMove;
        }

        private void OnDisable()
        {
            _inputManager.OnStopMove -= OnStopMove;
            _inputManager.OnMoveRight -= OnMoveRight;
            _inputManager.OnMoveLeft -= OnMoveLeft;
        }

        private void OnMoveRight()
        {
            _characterController.MoveRight();
        }

        private void OnMoveLeft()
        {
            _characterController.MoveLeft();
        }

        private void OnStopMove()
        {
            _characterController.StopMove();
        }
    }
}