// Code written by Gabriel Mailhot, 24/08/2023.

#region

using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Features.Unseat
{
   [HarmonyPatch(typeof(MissionCombatMechanicsHelper), nameof(MissionCombatMechanicsHelper.DecideAgentDismountedByBlow))]
   public static class UnseatService
   {
      #region private

      private static bool Prefix(ref bool __result,
                                 Agent attackerAgent,
                                 Agent victimAgent,
                                 in AttackCollisionData collisionData,
                                 WeaponComponentData attackerWeapon,
                                 in Blow blow
      )
      {
         if (UnseatDisqualified(attackerAgent, victimAgent, attackerWeapon, blow)) return true;

         var option = Runtime.Get.UnseatOptionReader;
         var loggerActivated = option.IsOptionActivated(Runtime.LoadedOptions.GetContent(), option.GolbalActivationValues.ShowInformationMessagesInGameLogger_Active);

         if (victimAgent.WieldedOffhandWeapon.Item != null)
         {
            if (Runtime.DefenseInfo.IsShieldCovering(victimAgent.WieldedOffhandWeapon.Item.ItemCategory, blow.VictimBodyPart))
            {
               if (loggerActivated) ScreenLogger.LogMessage("Attack blocked by shield...", Color.White);

               return true;
            }
         }


         var unseatChances = Runtime.DecideAgentDismountedByBlow.CalculateStaggerChance(Runtime.LoadedOptions.GetContent(), attackerAgent, victimAgent, blow, attackerWeapon, collisionData);

         if (Runtime.Get.Random.Next(1, 100) <= unseatChances)
         {
            __result = true;


            if (loggerActivated) ScreenLogger.LogMessage("Unseat chance " + unseatChances + "%: SUCCESS   victim: " + victimAgent.Name, Color.White);

            return false;
         }

         if (loggerActivated) ScreenLogger.LogMessage("Unseat chance " + unseatChances + "%: FAILED", Color.White);

         return true;
      }

      private static bool UnseatDisqualified(Agent attackerAgent, Agent victimAgent, WeaponComponentData attackerWeapon, Blow blow)
      {
         if (!victimAgent.IsHuman) return true;
         if (attackerAgent.Team != null && victimAgent.Team != null)
         {
            if (attackerAgent.Team.Side == victimAgent.Team.Side) return true;
         }

         if (blow.IsMissile)
         {
            if (attackerWeapon.WeaponClass != WeaponClass.Stone && attackerWeapon.WeaponClass != WeaponClass.Javelin)
            {
               return true;
            }
         }

         if (blow.IsFallDamage) return true;


         return false;
      }

      #endregion
   }
}