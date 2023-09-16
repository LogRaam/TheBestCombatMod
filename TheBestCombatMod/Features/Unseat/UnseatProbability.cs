// Code written by Gabriel Mailhot, 28/08/2023.

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
      public UnseatProbability(in UnseatProbabilityConstructorParams parameters)
      {
         LoadedOptions = parameters.LoadedOptions;
         UnseatOptionReader = parameters.Reader;
         SituationalDefenseInfo = parameters.DefenseInfo;
         BodyPartsVulnerabilityOptions = parameters.BodyPartsVulnerabilityOptions;
         BodyHitProbability = parameters.BodyHitProbability;
      }

      public BodyHitProbability BodyHitProbability { get; set; }
      public BodyPartsVulnerabilityOptions BodyPartsVulnerabilityOptions { get; set; }
      public string[] LoadedOptions { get; set; }
      public SituationalDefenseInfo SituationalDefenseInfo { get; set; }
      public UnseatOptionReader UnseatOptionReader { get; set; }

      public int ForInertiaStrength(float inertia, bool attackerHasMount, float movementSpeedDamageModifier)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceTakingAccountAttackerWeaponInertia_Active)) return 0;

         inertia *= 50;
         var divisor = UnseatOptionReader.GetIntegerValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.Impact_Dismount_Chance_Weapon_Inertia_aLp7H_Value);

         divisor = ApplyMountModifier(attackerHasMount, divisor);

         return (int) (inertia / divisor);
      }

      public int ForStrikeAgainstArmor(ArmorComponent.ArmorMaterialTypes armorMaterialType, WeaponClass attackerWeaponClass, StrikeType strikeType, DamageTypes typeOfDamage)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceForStrikeAgainstArmor_Active)) return 0;

         var bonus = SituationalDefenseInfo.GetResistanceBonusFrom(LoadedOptions, attackerWeaponClass, strikeType, typeOfDamage, armorMaterialType, Feature.KnockedDown);

         return bonus;
      }

      public int ForTargetedBodyPart(in BoneBodyPartType blowVictimBodyPart)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceForTargetedBodyPart_Active)) return 0;

         return BodyPartsVulnerabilityOptions.Convert(blowVictimBodyPart);
      }

      public int ForTypeOfDamageOnBodyPart(StrikeType strike, DamageTypes typeOfDamage, BoneBodyPartType bodyPart)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.StrikeEffectOnBodyPart_Active)) return 0;
         if (bodyPart == BoneBodyPartType.None || typeOfDamage == DamageTypes.Invalid || strike == StrikeType.Invalid) return Runtime.StaggerStrength.None;

         return BodyHitProbability.GetProbabilityFor(LoadedOptions, typeOfDamage, strike, bodyPart, UnseatOptionReader);
      }

      public float IfAttackerIsWoman(in bool attackerAgentIsFemale)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceWhenAttackerIsAWoman_Active)) return 1;

         if (attackerAgentIsFemale) return UnseatOptionReader.GetFloatValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.Impact_Dismount_Chance_Attacker_Is_Woman_aUufU_Value);

         return 1;
      }

      public int WhenAttackerIsHealthier(float victimHealth, float victimMaxHealth, float attackerHealth, float attackerMaxHealth)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceWhenAttackerIsHealthier_Active)) return 0;
         if (Math.Abs(victimHealth - attackerHealth) < 0.0001) return 0;

         double attackerPercentageHealth = GetPercentageFrom(attackerHealth, attackerMaxHealth);
         double victimePercentageHealth = GetPercentageFrom(victimHealth, victimMaxHealth);
         var divisor = UnseatOptionReader.GetIntegerValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.Impact_Dismount_Chance_Attacker_Healthier_wK2Fb_Value);

         if (victimePercentageHealth > attackerPercentageHealth) return WhenDefenderIsHealthier(attackerPercentageHealth, victimePercentageHealth, divisor);

         var result = 100 - Math.Pow(victimePercentageHealth, 0.5f) * 10;
         result /= divisor;

         return (int) result;
      }

      public int WhenAttackerIsHeavier(float victimWeight, float attackerWeight)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceWhenAttackerIsHeavier_Active)) return 0;
         if (victimWeight == 0) return 0;
         if (attackerWeight == 0) return 0;
         if (victimWeight >= attackerWeight) return 0;

         victimWeight *= 100;
         attackerWeight *= 100;

         var divisor = UnseatOptionReader.GetIntegerValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.Impact_Dismount_Chance_Attacker_Heavier_uiezF_Value);
         var result = (attackerWeight - victimWeight) / divisor;

         return (int) result;
      }

      public int WhenAttackerIsNotTrained(bool isSoldierOrHero)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ReduceProbabilityForPeasants)) return 0;

         var result = UnseatOptionReader.GetIntegerValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.PEASANT_REDUCE_PROBABILITY_BY);

         if (!isSoldierOrHero) return result;

         return 0;
      }

      public int WhenAttackerIsStronger(float victimBuild, float attackerBuild)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceWhenAttackerIsStronger_Active)) return 0;

         if (victimBuild >= attackerBuild) return 0;
         if (victimBuild == 0) return 0;
         if (attackerBuild == 0) return 0;

         victimBuild *= 100;
         attackerBuild *= 100;

         var divisor = UnseatOptionReader.GetIntegerValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.Impact_Dismount_Chance_Attacker_Stronger_W3JH2_Value);
         var result = (int) ((attackerBuild - victimBuild) / divisor);

         return result;
      }

      public int WhenBlowIsCritical(in Blow blow, in int victimMaxHitPoints)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceWhenBlowIsCritical_Active)) return 0;
         if (blow.IsBlowLow(victimMaxHitPoints)) return 0;
         if (!blow.IsBlowCrit(victimMaxHitPoints)) return 0;

         return UnseatOptionReader.GetIntegerValueFor(LoadedOptions, blow.DamageType);
      }

      public int WhenThrustTipHit(bool thrustTipHit)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceWhenThrustTipHit_Active)) return 0;

         if (thrustTipHit) return UnseatOptionReader.GetIntegerValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.Impact_Dismount_Chance_Thrust_Tip_Hit_cGmzd_Value);

         return 0;
      }

      public int WhenVictimeDidNotRaiseHisGuard(in Agent.GuardMode victimCurrentGuardStance)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.ImpactDismountChanceWhenVictimDidNotRaiseHisGuard_Active)) return 0;

         if (victimCurrentGuardStance == Agent.GuardMode.None) return UnseatOptionReader.GetIntegerValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.Impact_Dismount_Chance_VictimDidNot_Raise_Guard_h8WXN_Value);

         return 0;
      }

      #region private

      private int ApplyMountModifier(bool attackerHasMount, int divisor)
      {
         if (!UnseatOptionReader.IsOptionActivated(LoadedOptions, UnseatOptionReader.UnseatActivationValues.IncreasesInertiaGivenStrikeOnHorseback_Active)) return 0;

         var b = UnseatOptionReader.GetIntegerValueFor(LoadedOptions, UnseatOptionReader.UnseatValues.Increases_Inertia_Given_Strike_On_Horseback_lqO62_Value);

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


   public class UnseatProbability_params : UnseatProbabilityConstructorParams
   {
      public BodyHitProbability BodyHitProbability { get; set; }
      public BodyPartsVulnerabilityOptions BodyPartsVulnerabilityOptions { get; set; }
      public SituationalDefenseInfo DefenseInfo { get; set; }
      public string[] LoadedOptions { get; set; }
      public UnseatOptionReader Reader { get; set; }
   }

   public interface UnseatProbabilityConstructorParams
   {
      BodyHitProbability BodyHitProbability { get; set; }
      BodyPartsVulnerabilityOptions BodyPartsVulnerabilityOptions { get; set; }
      SituationalDefenseInfo DefenseInfo { get; set; }
      string[] LoadedOptions { get; set; }
      UnseatOptionReader Reader { get; set; }
   }
}