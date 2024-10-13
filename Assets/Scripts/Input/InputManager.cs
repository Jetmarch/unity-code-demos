using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour, IGameUpdateListener
    {
        public event Action OnFire;

        public event Action<float> OnMove;

        [SerializeField] private string _horizontalAxisName = "Horizontal";

        private float _horizontalMoveAxis;

        private void Start()
        {
            IGameListener.Register(this);
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