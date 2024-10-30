using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public struct LevelBoundsData
    {
        [SerializeField] public Transform LeftBorder;

        [SerializeField] public Transform RightBorder;

        [SerializeField] public Transform DownBorder;

        [SerializeField] public Transform TopBorder;
    }
    public sealed class LevelBounds
    {
        private readonly LevelBoundsData _data;
        public LevelBounds(LevelBoundsData data)
        {
            _data = data;
        }

        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > _data.LeftBorder.position.x
                   && positionX < _data.RightBorder.position.x
                   && positionY > _data.DownBorder.position.y
                   && positionY < _data.TopBorder.position.y;
        }
    }
}