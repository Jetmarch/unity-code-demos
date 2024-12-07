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
    public static class DamageAPI
    {
        ///Keys
        public const int DamageAmount = 22; // ReactiveVariable<int>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetDamageAmount(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(DamageAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamageAmount(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(DamageAmount, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamageAmount(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(DamageAmount, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamageAmount(this IEntity obj) => obj.HasValue(DamageAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamageAmount(this IEntity obj) => obj.DelValue(DamageAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamageAmount(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(DamageAmount, value);
    }
}
