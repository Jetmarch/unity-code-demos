using System;
using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Code.Contexts.Installers
{
    [Serializable]
    public sealed class SceneContextInstaller : IContextInstaller
    {
        [SerializeField] private SceneEntity _player;
        
        public void Install(IContext context)
        {
            context.AddValue(SceneContextAPI.Player, _player);
        }
    }

    public static class SceneContextAPI
    {
        public static readonly int Player = 0;
    }
}