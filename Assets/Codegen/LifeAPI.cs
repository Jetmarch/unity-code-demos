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
    public static class LifeAPI
    {
        ///Keys
        public const int HitPoints = 1; // ReactiveVariable<int>
        public const int IsDead = 2; // ReactiveVariable<bool>
        public const int TakeDamageAction = 3; // Event<int>
        public const int CanTakeDamage = 4; // AndExpression


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetHitPoints(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetHitPoints(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(HitPoints, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddHitPoints(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(HitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasHitPoints(this IEntity obj) => obj.HasValue(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelHitPoints(this IEntity obj) => obj.DelValue(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetHitPoints(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(HitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<bool> GetIsDead(this IEntity obj) => obj.GetValue<ReactiveVariable<bool>>(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsDead(this IEntity obj, out ReactiveVariable<bool> value) => obj.TryGetValue(IsDead, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsDead(this IEntity obj, ReactiveVariable<bool> value) => obj.AddValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsDead(this IEntity obj) => obj.HasValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsDead(this IEntity obj) => obj.DelValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsDead(this IEntity obj, ReactiveVariable<bool> value) => obj.SetValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Event<int> GetTakeDamageAction(this IEntity obj) => obj.GetValue<Event<int>>(TakeDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTakeDamageAction(this IEntity obj, out Event<int> value) => obj.TryGetValue(TakeDamageAction, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTakeDamageAction(this IEntity obj, Event<int> value) => obj.AddValue(TakeDamageAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTakeDamageAction(this IEntity obj) => obj.HasValue(TakeDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTakeDamageAction(this IEntity obj) => obj.DelValue(TakeDamageAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTakeDamageAction(this IEntity obj, Event<int> value) => obj.SetValue(TakeDamageAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanTakeDamage(this IEntity obj) => obj.GetValue<AndExpression>(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanTakeDamage(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanTakeDamage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanTakeDamage(this IEntity obj, AndExpression value) => obj.AddValue(CanTakeDamage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanTakeDamage(this IEntity obj) => obj.HasValue(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanTakeDamage(this IEntity obj) => obj.DelValue(CanTakeDamage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanTakeDamage(this IEntity obj, AndExpression value) => obj.SetValue(CanTakeDamage, value);
    }
}
