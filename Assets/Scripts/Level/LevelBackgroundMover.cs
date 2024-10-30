using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackgroundMover : IGameFixedUpdateListener
    {
        private readonly LevelBackgroundMoverData _levelBackgroundMoverData;
        
        public LevelBackgroundMover(LevelBackgroundMoverData levelBackgroundMoverData)
        {
            _levelBackgroundMoverData = levelBackgroundMoverData;
        }

        public void OnFixedUpdate(float fixedDelta)
        {
            MoveBackground(fixedDelta);
        }

        private void MoveBackground(float delta)
        {
            if (_levelBackgroundMoverData.Background.position.y <= _levelBackgroundMoverData.EndPositionY)
            {
                _levelBackgroundMoverData.Background.position = new Vector3(
                    _levelBackgroundMoverData.Background.position.x,
                    _levelBackgroundMoverData.StartPositionY,
                    _levelBackgroundMoverData.Background.position.z
                );
            }

            _levelBackgroundMoverData.Background.position -= new Vector3(
                _levelBackgroundMoverData.Background.position.x,
                _levelBackgroundMoverData.MovingSpeedY * delta,
                _levelBackgroundMoverData.Background.position.z
            );
        }
    }
}