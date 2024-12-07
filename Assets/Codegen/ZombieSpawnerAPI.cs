/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Contexts;
using System.Runtime.CompilerServices;

namespace Atomic.Contexts
{
	public static class ZombieSpawnerAPI
	{
		///Keys
		public const int ZombieSpawnSystemData = 2; // ZombieShooter.Systems.ZombieSpawnSystemData


		///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ZombieShooter.Systems.ZombieSpawnSystemData GetZombieSpawnSystemData(this IContext obj) => obj.ResolveValue<ZombieShooter.Systems.ZombieSpawnSystemData>(ZombieSpawnSystemData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetZombieSpawnSystemData(this IContext obj, out ZombieShooter.Systems.ZombieSpawnSystemData value) => obj.TryResolveValue(ZombieSpawnSystemData, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddZombieSpawnSystemData(this IContext obj, ZombieShooter.Systems.ZombieSpawnSystemData value) => obj.AddValue(ZombieSpawnSystemData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelZombieSpawnSystemData(this IContext obj) => obj.DelValue(ZombieSpawnSystemData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetZombieSpawnSystemData(this IContext obj, ZombieShooter.Systems.ZombieSpawnSystemData value) => obj.SetValue(ZombieSpawnSystemData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasZombieSpawnSystemData(this IContext obj) => obj.HasValue(ZombieSpawnSystemData);
    }
}
