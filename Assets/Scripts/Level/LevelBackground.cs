using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private float _startPositionY;

        [SerializeField] private float _endPositionY;

        [SerializeField] private float _movingSpeedY;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnFixedUpdate(float delta)
        {
            MoveBackground(delta);
        }

        private void MoveBackground(float delta)
        {
            if (transform.position.y <= _endPositionY)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    _startPositionY,
                    transform.position.z
                );
            }

            transform.position -= new Vector3(
                transform.position.x,
                _movingSpeedY * delta,
                transform.position.z
            );
        }
    }
}