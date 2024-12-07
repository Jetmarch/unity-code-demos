/**
* Code generation. Don't modify! 
**/

using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class ShootAPI
    {
        ///Keys
        public const int CanFire = 13; // AndExpression
        public const int ShootAction = 14; // Event
        public const int ShootRequest = 15; // Event


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanFire(this IEntity obj) => obj.GetValue<AndExpression>(CanFire);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanFire(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanFire, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanFire(this IEntity obj, AndExpression value) => obj.AddValue(CanFire, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanFire(this IEntity obj) => obj.HasValue(CanFire);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanFire(this IEntity obj) => obj.DelValue(CanFire);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanFire(this IEntity obj, AndExpression value) => obj.SetValue(CanFire, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Event GetShootAction(this IEntity obj) => obj.GetValue<Event>(ShootAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootAction(this IEntity obj, out Event value) => obj.TryGetValue(ShootAction, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootAction(this IEntity obj, Event value) => obj.AddValue(ShootAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootAction(this IEntity obj) => obj.HasValue(ShootAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootAction(this IEntity obj) => obj.DelValue(ShootAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootAction(this IEntity obj, Event value) => obj.SetValue(ShootAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Event GetShootRequest(this IEntity obj) => obj.GetValue<Event>(ShootRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootRequest(this IEntity obj, out Event value) => obj.TryGetValue(ShootRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootRequest(this IEntity obj, Event value) => obj.AddValue(ShootRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootRequest(this IEntity obj) => obj.HasValue(ShootRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootRequest(this IEntity obj) => obj.DelValue(ShootRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootRequest(this IEntity obj, Event value) => obj.SetValue(ShootRequest, value);
    }
}
