using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        //public float HorizontalDirection { get; private set; }

        //[SerializeField]
        //private GameObject character;

        //[SerializeField]
        //private CharacterController characterController;

        public event Action OnFire;
        public event Action OnMoveLeft;
        public event Action OnMoveRight;
        public event Action OnStopMove;

        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            Fire();
            Move();
        }

        private void Fire()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }
        }
        private void Move()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnMoveLeft?.Invoke();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                OnMoveRight?.Invoke();
            }
            else
            {
                OnStopMove?.Invoke();
            }
        }
        
        //private void FixedUpdate()
        //{
        //    this.character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        //}
    }
}