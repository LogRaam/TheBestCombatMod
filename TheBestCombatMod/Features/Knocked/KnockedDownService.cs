// Code written by Gabriel Mailhot, 17/08/2023.

#region

using HarmonyLib;
using LogRaamConfiguration;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Common;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Knocked
{
   [HarmonyPatch(typeof(MissionCombatMechanicsHelper), nameof(MissionCombatMechanicsHelper.DecideAgentKnockedDownByBlow))]
   public static class KnockedDownService
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
         if (Auditor.KnockdownDisqualified(attackerAgent, victimAgent, attackerWeapon, blow, collisionData.IsHorseCharge)) return true;


         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());
         var loggerActivated = option.IsOptionActivated(Runtime.LoadedOptions.GetContent(), option.GlobalActivationRefTag.ShowInformationMessagesInGameLogger_Active);

         if (victimAgent.WieldedOffhandWeapon.Item != null)
         {
            if (Runtime.ArmorCharacteristics.IsShieldCovering(victimAgent.WieldedOffhandWeapon.Item.ItemCategory, blow.VictimBodyPart))
            {
               if (loggerActivated) ScreenLogger.LogMessage("Attack blocked by shield...", Color.White);

               return true;
            }
         }


         var knockdown = Runtime.DecideAgentKnockedDownByBlow.CalculateKnockedDownChances(Runtime.LoadedOptions.GetContent(), attackerAgent, victimAgent, blow, attackerWeapon, collisionData);

         if (new MBFastRandom().Next(1, 100) <= knockdown)
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