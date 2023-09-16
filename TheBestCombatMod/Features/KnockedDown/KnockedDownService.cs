// Code written by Gabriel Mailhot, 28/08/2023.

#region

using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Features.KnockedDown
{
   [HarmonyPatch(typeof(MissionCombatMechanicsHelper), nameof(MissionCombatMechanicsHelper.DecideAgentKnockedDownByBlow))]
   public static class KnockedDownService
   {
      #region private

      private static bool KnockdownDisqualified(Agent attackerAgent, Agent victimAgent, WeaponComponentData attackerWeapon, Blow blow, bool isHorseCharge)
      {
         if (!victimAgent.IsHuman) return true;
         if (isHorseCharge) return true;
         if (attackerWeapon == null) return true;
         if (attackerAgent.Team != null && victimAgent.Team != null)
         {
            if (attackerAgent.Team.Side == victimAgent.Team.Side) return true;
         }

         if (blow.IsFallDamage) return true;


         return false;
      }

      private static bool Prefix(ref bool __result,
                                 Agent attackerAgent,
                                 Agent victimAgent,
                                 in AttackCollisionData collisionData,
                                 WeaponComponentData attackerWeapon,
                                 in Blow blow
      )
      {
         if (KnockdownDisqualified(attackerAgent, victimAgent, attackerWeapon, blow, collisionData.IsHorseCharge)) return true;


         var option = Runtime.Get.UnseatByBlowOptionsReader;
         var loggerActivated = option.IsOptionActivated(Runtime.LoadedOptions.GetContent(), option.GolbalActivationValues.ShowInformationMessagesInGameLogger_Active);

         if (victimAgent.WieldedOffhandWeapon.Item != null)
         {
            if (Runtime.DefenseInfo.IsShieldCovering(victimAgent.WieldedOffhandWeapon.Item.ItemCategory, blow.VictimBodyPart))
            {
               if (loggerActivated) ScreenLogger.LogMessage("Attack blocked by shield...", Color.White);

               return true;
            }
         }


         var knockdown = Runtime.DecideAgentKnockedDownByBlowKnockedDown.CalculateKnockedDownChances(
            Runtime.LoadedOptions.GetContent(),
            attackerAgent.IsHuman,
            attackerAgent.IsHero,
            attackerAgent.Character.IsSoldier,
            attackerAgent.Health,
            attackerAgent.Character.MaxHitPoints(),
            victimAgent.Health,
            victimAgent.Character.MaxHitPoints(),
            blow.StrikeType,
            blow.DamageType,
            blow.VictimBodyPart,
            attackerWeapon.WeaponClass,
            Runtime.Get.ProtectionInfo.GetArmorMaterialType(victimAgent, blow)
         );


         if (Runtime.Get.Random.Next(1, 100) <= knockdown)
         {
            __result = true;


            if (loggerActivated) ScreenLogger.LogMessage("Knockdown chance " + knockdown + "%: SUCCESS   victim: " + victimAgent.Name, Color.White);

            return false;
         }

         if (loggerActivated) ScreenLogger.LogMessage("Knockdown chance " + knockdown + "%: FAILED", Color.White);

         return true;
      }

      #endregion
   }
}