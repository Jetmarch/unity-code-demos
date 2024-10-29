using System;
using UnityEngine;

namespace ShootEmUp
{
    public interface ITeamable
    {
        TeamComponent TeamComponent { get; }
    }
    
    [Serializable]
    public sealed class TeamComponent
    {
        public bool IsPlayer
        {
            get { return _isPlayer; }
            set { _isPlayer = value; }
        }

        [SerializeField] private bool _isPlayer;
    }

    
}