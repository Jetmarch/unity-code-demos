/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using ZombieShooter.Factories;

namespace Atomic.Entities
{
    public static class FactoriesAPI
    {
        ///Keys
        public const int SceneEntityFactory = 16; // SceneEntityFactory


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SceneEntityFactory GetSceneEntityFactory(this IEntity obj) => obj.GetValue<SceneEntityFactory>(SceneEntityFactory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetSceneEntityFactory(this IEntity obj, out SceneEntityFactory value) => obj.TryGetValue(SceneEntityFactory, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddSceneEntityFactory(this IEntity obj, SceneEntityFactory value) => obj.AddValue(SceneEntityFactory, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSceneEntityFactory(this IEntity obj) => obj.HasValue(SceneEntityFactory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelSceneEntityFactory(this IEntity obj) => obj.DelValue(SceneEntityFactory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSceneEntityFactory(this IEntity obj, SceneEntityFactory value) => obj.SetValue(SceneEntityFactory, value);
    }
}
