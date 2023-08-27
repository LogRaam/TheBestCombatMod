// Code written by Gabriel Mailhot, 24/08/2023.

#region

using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat
{
   public class UnseatProbability : CombatActionEffect
   {
      private readonly string[] _loadedOptions;

      public UnseatProbability(in string[] loadedOptions)
      {
         _loadedOptions = loadedOptions;
      }

      public int ForInertiaStrength(float inertia, bool attackerHasMount, float movementSpeedDamageModifier)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceTakingAccountAttackerWeaponInertia_Active)) return 0;

         inertia *= 50;
         var divisor = option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Weapon_Inertia_aLp7H_Value);

         divisor = ApplyMountModifier(attackerHasMount, divisor);

         return (int) (inertia / divisor);
      }

      public int ForStrikeAgainstArmor(ArmorComponent.ArmorMaterialTypes armorMaterialType, WeaponClass attackerWeaponClass, StrikeType strikeType, DamageTypes typeOfDamage)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceForStrikeAgainstArmor_Active)) return 0;

         var bonus = Runtime.Get.ProtectionInfo.GetResistanceBonusFrom(_loadedOptions, attackerWeaponClass, strikeType, typeOfDamage, armorMaterialType);

         return bonus;
      }

      public int ForTargetedBodyPart(in BoneBodyPartType blowVictimBodyPart)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceForTargetedBodyPart_Active)) return 0;

         return Runtime.Get.UnseatBodyPartsVulnerabilityOptions.Convert(blowVictimBodyPart);
      }

      public int ForTypeOfDamageOnBodyPart(StrikeType strike, DamageTypes typeOfDamage, BoneBodyPartType bodyPart)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.StrikeEffectOnBodyPart_Active)) return 0;
         if (bodyPart == BoneBodyPartType.None || typeOfDamage == DamageTypes.Invalid || strike == StrikeType.Invalid) return Runtime.StaggerStrength.None;

         return Runtime.Get.BodyHitUnseatProbability.GetProbabilityFor(_loadedOptions, typeOfDamage, strike, bodyPart);
      }

      public float IfAttackerIsWoman(in bool attackerAgentIsFemale)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceWhenAttackerIsAWoman_Active)) return 1;

         if (attackerAgentIsFemale) return option.GetFloatValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Attacker_Is_Woman_aUufU_Value);

         return 1;
      }

      public int WhenAttackerIsHealthier(float victimHealth, float victimMaxHealth, float attackerHealth, float attackerMaxHealth)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceWhenAttackerIsHealthier_Active)) return 0;
         if (Math.Abs(victimHealth - attackerHealth) < 0.0001) return 0;

         double attackerPercentageHealth = GetPercentageFrom(attackerHealth, attackerMaxHealth);
         double victimePercentageHealth = GetPercentageFrom(victimHealth, victimMaxHealth);
         var divisor = option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Attacker_Healthier_wK2Fb_Value);

         if (victimePercentageHealth > attackerPercentageHealth) return WhenDefenderIsHealthier(attackerPercentageHealth, victimePercentageHealth, divisor);

         var result = 100 - Math.Pow(victimePercentageHealth, 0.5f) * 10;
         result /= divisor;

         return (int) result;
      }

      public int WhenAttackerIsHeavier(float victimWeight, float attackerWeight)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceWhenAttackerIsHeavier_Active)) return 0;
         if (victimWeight == 0) return 0;
         if (attackerWeight == 0) return 0;
         if (victimWeight >= attackerWeight) return 0;

         victimWeight *= 100;
         attackerWeight *= 100;

         var divisor = option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Attacker_Heavier_uiezF_Value);
         var result = (attackerWeight - victimWeight) / divisor;

         return (int) result;
      }

      public int WhenAttackerIsNotTrained(bool isSoldierOrHero)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ReduceProbabilityForPeasants)) return 0;

         var result = option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.PEASANT_REDUCE_PROBABILITY_BY);

         if (!isSoldierOrHero) return result;

         return 0;
      }

      public int WhenAttackerIsStronger(float victimBuild, float attackerBuild)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceWhenAttackerIsStronger_Active)) return 0;

         if (victimBuild >= attackerBuild) return 0;
         if (victimBuild == 0) return 0;
         if (attackerBuild == 0) return 0;

         victimBuild *= 100;
         attackerBuild *= 100;

         var divisor = option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Attacker_Stronger_W3JH2_Value);
         var result = (int) ((attackerBuild - victimBuild) / divisor);

         return result;
      }

      public int WhenBlowIsCritical(in Blow blow, in int victimMaxHitPoints)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceWhenBlowIsCritical_Active)) return 0;
         if (blow.IsBlowLow(victimMaxHitPoints)) return 0;
         if (!blow.IsBlowCrit(victimMaxHitPoints)) return 0;

         switch (blow.DamageType) //TODO: Move responsibility
         {
            case DamageTypes.Invalid: return 0;
            case DamageTypes.Blunt: return option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Blow_Critical_BLUNT_TI8bQ_Vlaue);
            case DamageTypes.Cut: return option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Blow_Critical_CUT_d461x_Value);
            case DamageTypes.Pierce: return option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Blow_Critical_PIERCE_WDaWG_Value);
         }

         return 0;
      }

      public int WhenThrustTipHit(bool thrustTipHit)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceWhenThrustTipHit_Active)) return 0;

         if (thrustTipHit) return option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_Thrust_Tip_Hit_cGmzd_Value);

         return 0;
      }

      public int WhenVictimeDidNotRaiseHisGuard(in Agent.GuardMode victimCurrentGuardStance)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.ImpactDismountChanceWhenVictimDidNotRaiseHisGuard_Active)) return 0;

         if (victimCurrentGuardStance == Agent.GuardMode.None) return option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Impact_Dismount_Chance_VictimDidNot_Raise_Guard_h8WXN_Value);

         return 0;
      }

      #region private

      private int ApplyMountModifier(bool attackerHasMount, int divisor)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(_loadedOptions, option.UnseatActivationValues.IncreasesInertiaGivenStrikeOnHorseback_Active)) return 0;

         var b = option.GetIntegerValueFor(_loadedOptions, option.UnseatValues.Increases_Inertia_Given_Strike_On_Horseback_lqO62_Value);

         if (attackerHasMount) divisor /= b;
         if (divisor < 1) divisor = 1;

         return divisor;
      }

      private float GetPercentageFrom(float attackerHealth, float attackerMaxHealth)
      {
         var result = (attackerHealth - 1) / (attackerMaxHealth - 1) * 100;

         return result;
      }

      private int WhenDefenderIsHealthier(double attackerPercentageHealth, double victimePercentageHealth, int divisor)
      {
         var num = victimePercentageHealth - attackerPercentageHealth;

         var result = 100 - Math.Pow(num, 0.5f) * 10;
         result /= divisor;
         result = -result;
         result /= 2;

         return (int) result;
      }

      #endregion
   }
}