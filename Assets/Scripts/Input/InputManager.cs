using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
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
    }
}