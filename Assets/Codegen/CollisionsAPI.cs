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
    public static class CollisionsAPI
    {
        ///Keys
        public const int EntityTriggerEnter = 21; // Event<SceneEntity>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Event<SceneEntity> GetEntityTriggerEnter(this IEntity obj) => obj.GetValue<Event<SceneEntity>>(EntityTriggerEnter);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetEntityTriggerEnter(this IEntity obj, out Event<SceneEntity> value) => obj.TryGetValue(EntityTriggerEnter, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddEntityTriggerEnter(this IEntity obj, Event<SceneEntity> value) => obj.AddValue(EntityTriggerEnter, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEntityTriggerEnter(this IEntity obj) => obj.HasValue(EntityTriggerEnter);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelEntityTriggerEnter(this IEntity obj) => obj.DelValue(EntityTriggerEnter);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetEntityTriggerEnter(this IEntity obj, Event<SceneEntity> value) => obj.SetValue(EntityTriggerEnter, value);
    }
}
