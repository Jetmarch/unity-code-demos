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
    public static class AmmoAPI
    {
        ///Keys
        public const int AmmoAmount = 17; // ReactiveVariable<int>
        public const int MaxAmmoAmount = 18; // ReactiveVariable<int>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetAmmoAmount(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(AmmoAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAmmoAmount(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(AmmoAmount, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAmmoAmount(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(AmmoAmount, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAmmoAmount(this IEntity obj) => obj.HasValue(AmmoAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAmmoAmount(this IEntity obj) => obj.DelValue(AmmoAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAmmoAmount(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(AmmoAmount, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetMaxAmmoAmount(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(MaxAmmoAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxAmmoAmount(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(MaxAmmoAmount, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxAmmoAmount(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(MaxAmmoAmount, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxAmmoAmount(this IEntity obj) => obj.HasValue(MaxAmmoAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxAmmoAmount(this IEntity obj) => obj.DelValue(MaxAmmoAmount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxAmmoAmount(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(MaxAmmoAmount, value);
    }
}
