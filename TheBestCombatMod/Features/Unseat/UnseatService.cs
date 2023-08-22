// Code written by Gabriel Mailhot, 12/08/2023.

#region

using HarmonyLib;
using LogRaamConfiguration;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Common;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

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
         if (Auditor.UnseatDisqualified(attackerAgent, victimAgent, attackerWeapon, blow)) return true;

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


         var unseatChances = Runtime.DecideAgentDismountedByBlow.CalculateStaggerChance(Runtime.LoadedOptions.GetContent(), attackerAgent, victimAgent, blow, attackerWeapon, collisionData);

         if (new MBFastRandom().Next(1, 100) <= unseatChances)
         {
            __result = true;


            if (loggerActivated) ScreenLogger.LogMessage("Unseat chance " + unseatChances + "%: SUCCESS   victim: " + victimAgent.Name, Color.White);

            return false;
         }

         if (loggerActivated) ScreenLogger.LogMessage("Unseat chance " + unseatChances + "%: FAILED", Color.White);

         return true;
      }

      #endregion
   }
}