using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Controllers
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField]
        private string _horizontalAxis = "Horizontal";
        [SerializeField]
        private string _verticalAxis = "Vertical";
        
        [SerializeField]
        private SceneEntity _sceneEntity;
        
        private ReactiveVariable<Vector3> _moveDirection;

        private float _horizontalInput;
        private float _verticalInput;
        private Vector3 _direction;

        private void Start()
        {
            _moveDirection = _sceneEntity.GetMoveDirection();
        }

        void Update()
        {
            HandleKeyboardInput();
        }

        private void HandleKeyboardInput()
        {
            _horizontalInput = Input.GetAxis(_horizontalAxis);
            _verticalInput = Input.GetAxis(_verticalAxis);
            _direction = new Vector3(_horizontalInput, 0f, _verticalInput);
            if (_direction.sqrMagnitude > 1f)
            {
                _direction.Normalize();
            }
            Move(_direction);
        }

        private void Move(Vector3 direction)
        {
            _moveDirection.Value = direction;
        }
    }
}