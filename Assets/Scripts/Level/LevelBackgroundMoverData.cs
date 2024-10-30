using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public struct LevelBackgroundMoverData
    {
        [SerializeField] public float StartPositionY;
        [SerializeField] public float EndPositionY;
        [SerializeField] public float MovingSpeedY;
        [SerializeField] public Transform Background;
    }
}