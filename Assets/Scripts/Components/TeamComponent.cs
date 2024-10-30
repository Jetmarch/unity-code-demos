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
        public bool IsPlayer => _isPlayer;

        [SerializeField] private bool _isPlayer;
    }

    
}