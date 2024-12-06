using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace ZombieShooter.Controllers
{
    public sealed class RotateController : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity _sceneEntity;

        [SerializeField] private float zPositionDepth = 7f;
        private ReactiveVariable<Vector3> _rotateDirection;
        private Transform _root;
        private Camera _mainCamera;
        private void Start()
        {
            _rotateDirection = _sceneEntity.GetRotateDirection();
            _root = _sceneEntity.GetTransform();
            _mainCamera = Camera.main;
        }

        void Update()
        {
            var mousePosition = Input.mousePosition;
            var worldMousePosition = _mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, zPositionDepth));
            
            var direction = worldMousePosition - _root.position;
            var rotation = Quaternion.LookRotation(direction).eulerAngles;
            _rotateDirection.Value = new Vector3(0f, rotation.y, 0f);
        }
    }
}