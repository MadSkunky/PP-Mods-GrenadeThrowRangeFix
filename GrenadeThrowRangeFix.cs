using Harmony;
using PhoenixPoint.Tactical.Entities.Weapons;
using System;

namespace MadSkunky.GrenadeThrowRangeFix
{
    // New config class.
    internal class ModConfig
    {
        public int ThrowRangeDivisor = 12;
    }
    public class GrenadeThrowRangeFix
    {
        // New config field.
        internal static ModConfig Config;
        public static void MainMod(Func<string, object, object> api)
        {
            // Read config and assign to field.
            Config = api("config", null) as ModConfig ?? new ModConfig();
            HarmonyInstance.Create("GrenadeThrowRangeFix.MadSkunky").PatchAll();
            api("log verbose", "Mod Initialised.");
        }
        // This "tag" allows Harmony to find this class and apply it as a patch.
        [HarmonyPatch(typeof(Weapon), "GetThrowingRange")]
        // Class can be any name, but must be static.
        internal static class GetThrowingRange_fix
        {

            // Overwrite original fuction to calculate throwing range for grenades.
            [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051")]
            private static bool Prefix(ref float __result, Weapon __instance, float rangeMultiplier)
            {
                try
                {
                    float num = __instance.TacticalActor.CharacterStats.Endurance * __instance.TacticalActor.TacticalActorDef.EnduranceToThrowMultiplier;
                    float num2 = __instance.TacticalActor.CharacterStats.BonusAttackRange.CalcModValueBasedOn(num);
                    num = num * __instance.GetDamagePayload().Range / Config.ThrowRangeDivisor;
                    __result = num / (float)__instance.Weight * rangeMultiplier + num2;
                    return false;
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }
    }
}
