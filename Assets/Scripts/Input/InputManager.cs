using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : IGameUpdateListener
    {
        public event Action OnFire;
        public event Action<float> OnMove;

        private readonly string _horizontalAxisName = "Horizontal";

        private float _horizontalMoveAxis;

        public InputManager(string horizontalAxisName)
        {
            _horizontalAxisName = horizontalAxisName;
        }

        public void OnUpdate(float delta)
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
            _horizontalMoveAxis = Input.GetAxis(_horizontalAxisName);
            OnMove?.Invoke(_horizontalMoveAxis);
        }
    }
}