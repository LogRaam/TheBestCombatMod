// Code written by Gabriel Mailhot, 24/08/2023.

#region

using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Features.KnockedBack
{
   [HarmonyPatch(typeof(MissionCombatMechanicsHelper), nameof(MissionCombatMechanicsHelper.DecideAgentKnockedBackByBlow))]
   public static class KnockedBackService
   {
      #region private

      private static bool Prefix(ref bool __result,
                                 Agent attackerAgent,
                                 Agent victimAgent,
                                 in AttackCollisionData collisionData,
                                 WeaponComponentData attackerWeapon,
                                 in Blow blow
      ) =>
         //if (Auditor.UnseatDisqualified(attackerAgent, victimAgent, attackerWeapon, blow)) return true;
         true;

      #endregion
   }
}