using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Controllers
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity _sceneEntity;
        
        private ReactiveVariable<Vector3> _moveDirection;

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
            Move(Vector3.zero);
            
            if (Input.GetKey(KeyCode.W))
            {
                Move(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Move(Vector3.back);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Move(Vector3.right);
            }
        }

        private void Move(Vector3 direction)
        {
            _moveDirection.Value = direction;
        }
    }
}