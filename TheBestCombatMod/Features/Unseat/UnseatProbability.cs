// Code written by Gabriel Mailhot, 10/08/2023.

#region

using System;
using LogRaamConfiguration;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Common;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat
{
   public class UnseatProbability
   {
      public int ForInertiaStrength(in string[] loadedOptions, float inertia, bool attackerHasMount, float movementSpeedDamageModifier)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());


         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceTakingAccountAttackerWeaponInertia_Active)) return 0;


         inertia *= 50;
         var divisor = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Weapon_Inertia_aLp7H_Value);


         divisor = ApplyMountModifier(loadedOptions, attackerHasMount, divisor);

         return (int) (inertia / divisor);
      }

      public int ForStrikeAgainstArmor(in string[] loadedOptions, ArmorComponent.ArmorMaterialTypes armorMaterialType, WeaponClass attackerWeaponClass, StrikeType strikeType, DamageTypes blowDamageType)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceForStrikeAgainstArmor_Active)) return 0;

         var bonus = new ArmorCharacteristics().GetResistanceBonusFrom(loadedOptions, attackerWeaponClass, strikeType, blowDamageType, armorMaterialType);

         return bonus;
      }

      public int ForTargetedBodyPart(in string[] loadedOptions, in BoneBodyPartType blowVictimBodyPart)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceForTargetedBodyPart_Active)) return 0;


         var stagger = new BodyPartUnseatStaggerValue(loadedOptions);

         if (blowVictimBodyPart == BoneBodyPartType.None) return BodyPartUnseatStaggerValue.Unknown;
         if (blowVictimBodyPart == BoneBodyPartType.Head) return stagger.Head;
         if (blowVictimBodyPart == BoneBodyPartType.Neck) return stagger.Neck;
         if (blowVictimBodyPart == BoneBodyPartType.Chest) return stagger.Chest;
         if (blowVictimBodyPart == BoneBodyPartType.Abdomen) return stagger.Abdomen;
         if (blowVictimBodyPart is BoneBodyPartType.ShoulderLeft or BoneBodyPartType.ShoulderRight) return stagger.Shoulders;
         if (blowVictimBodyPart is BoneBodyPartType.ArmLeft or BoneBodyPartType.ArmRight) return stagger.Arms;
         if (blowVictimBodyPart == BoneBodyPartType.Legs) return stagger.Legs;

         return BodyPartUnseatStaggerValue.Unknown;
      }

      public int ForTypeOfDamageOnBodyPart(in string[] loadedOptions, StrikeType strike, DamageTypes typeOfDamage, BoneBodyPartType bodyPart)
      {
         var option = new UnseatByBlowOptions(new OptionBase(new StaggerStrengthValue(loadedOptions)), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.StrikeEffectOnBodyPart_Active)) return 0;


         if (bodyPart == BoneBodyPartType.None || typeOfDamage == DamageTypes.Invalid || strike == StrikeType.Invalid)
         {
            return Runtime.StaggerStrength.None;
         }

         switch (bodyPart)
         {
            case BoneBodyPartType.Head:
               switch (typeOfDamage)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.HEAD_CUT_SWINGING_05zN2_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.HEAD_CUT_THRUSTING_IgazM_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.HEAD_PIERCE_SWINGING_JMWpz_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.HEAD_PIERCE_THRUSTING_pMa5J_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.HEAD_BLUNT_SWINGING_8VPtS_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.HEAD_BLUNT_THRUSTING_UzQhf_Value);
               }

               break;
            case BoneBodyPartType.Neck:
               switch (typeOfDamage)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.NECK_CUT_SWINGING_OJ42D_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.NECK_CUT_THRUSTING_JDsUb_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.NECK_PIERCE_SWINGING_16Tqb_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.NECK_PIERCE_THRUSTING_PwjyT_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.NECK_BLUNT_SWINGING_Z19yv_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.NECK_BLUNT_THRUSTING_yZEV1_Value);
               }

               break;
            case BoneBodyPartType.Chest:
               switch (typeOfDamage)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.CHEST_CUT_SWINGING_sQmx7_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.CHEST_CUT_THRUSTING_dNomI_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.CHEST_PIERCE_SWINGING_6ssat_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.CHEST_PIERCE_THRUSTING_ybixm_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.CHEST_BLUNT_SWINGING_Ip0TE_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.CHEST_BLUNT_THRUSTING_ktCEu_Value);
               }

               break;
            case BoneBodyPartType.Abdomen:
               switch (typeOfDamage)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ABDOMEN_CUT_SWINGING_tRqGA_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ABDOMEN_CUT_THRUSTING_eypTb_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ABDOMEN_PIERCE_SWINGING_VTO6S_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ABDOMEN_PIERCE_THRUSTING_suxMY_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ABDOMEN_BLUNT_SWINGING_v2v6T_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ABDOMEN_BLUNT_THRUSTING_6gLsx_Value);
               }

               break;
            case BoneBodyPartType.ShoulderLeft or BoneBodyPartType.ShoulderRight:
               switch (typeOfDamage)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.SHOULDERS_CUT_SWINGING_8yoXK_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.SHOULDERS_CUT_THRUSTING_2Y1ez_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.SHOULDERS_PIERCE_SWINGING_HoWbh_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.SHOULDERS_PIERCE_THRUSTING_UhpJO_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.SHOULDERS_BLUNT_SWINGING_TplnH_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.SHOULDERS_BLUNT_THRUSTING_gqk9L_Value);
               }

               break;
            case BoneBodyPartType.ArmLeft or BoneBodyPartType.ArmRight:
               switch (typeOfDamage)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ARMS_CUT_SWINGING_eMIfX_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ARMS_CUT_THRUSTING_uHDMI_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ARMS_PIERCE_SWINGING_ScPD3_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ARMS_PIERCE_THRUSTING_7R3oW_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ARMS_BLUNT_SWINGING_zwGj0_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.ARMS_BLUNT_THRUSTING_E9s8D_Value);
               }

               break;
            case BoneBodyPartType.Legs:
               switch (typeOfDamage)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.LEGS_CUT_SWINGING_xOKtK_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.LEGS_CUT_THRUSTING_hEsET_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.LEGS_PIERCE_SWINGING_6DD8t_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.LEGS_PIERCE_THRUSTING_NblKm_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.LEGS_BLUNT_SWINGING_JTLxV_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValueTags.LEGS_BLUNT_THRUSTING_awuSL_Value);
               }

               break;
         }


         return 0;
      }

      public float IfAttackerIsWoman(in string[] loadedOptions, in bool attackerAgentIsFemale)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceWhenAttackerIsAWoman_Active)) return 1;

         if (attackerAgentIsFemale) return option.GetFloatValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Attacker_Is_Woman_aUufU_Value);

         return 1;
      }

      public int WhenAttackerIsHealthier(in string[] loadedOptions, float victimHealth, float victimMaxHealth, float attackerHealth, float attackerMaxHealth)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceWhenAttackerIsHealthier_Active)) return 0;
         if (Math.Abs(victimHealth - attackerHealth) < 0.0001) return 0;

         double attackerPercentageHealth = GetPercentageFrom(attackerHealth, attackerMaxHealth);
         double victimePercentageHealth = GetPercentageFrom(victimHealth, victimMaxHealth);
         var divisor = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Attacker_Healthier_wK2Fb_Value);

         if (victimePercentageHealth > attackerPercentageHealth) return WhenDefenderIsHealthier(attackerPercentageHealth, victimePercentageHealth, divisor);

         var result = 100 - Math.Pow(victimePercentageHealth, 0.5f) * 10;
         result /= divisor;

         return (int) result;
      }

      public int WhenAttackerIsHeavier(in string[] loadedOptions, float victimWeight, float attackerWeight)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceWhenAttackerIsHeavier_Active)) return 0;
         if (victimWeight == 0) return 0;
         if (attackerWeight == 0) return 0;

         if (victimWeight >= attackerWeight) return 0;

         victimWeight *= 100;
         attackerWeight *= 100;

         var divisor = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Attacker_Heavier_uiezF_Value);
         var result = (attackerWeight - victimWeight) / divisor;

         return (int) result;
      }

      public int WhenAttackerIsNotTrained(in string[] loadedOptions, bool isSoldierOrHero)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ReduceProbabilityForPeasants)) return 0;

         var result = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.PEASANT_REDUCE_PROBABILITY_BY);

         if (!isSoldierOrHero) return result;

         return 0;
      }

      public int WhenAttackerIsStronger(in string[] loadedOptions, float victimBuild, float attackerBuild)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceWhenAttackerIsStronger_Active)) return 0;

         if (victimBuild >= attackerBuild) return 0;
         if (victimBuild == 0) return 0;
         if (attackerBuild == 0) return 0;

         victimBuild *= 100;
         attackerBuild *= 100;

         var divisor = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Attacker_Stronger_W3JH2_Value);
         var result = (int) ((attackerBuild - victimBuild) / divisor);

         return result;
      }

      public int WhenBlowIsCritical(in string[] loadedOptions, in Blow blow, in int victimMaxHitPoints)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceWhenBlowIsCritical_Active)) return 0;


         if (blow.IsBlowLow(victimMaxHitPoints)) return 0;
         if (!blow.IsBlowCrit(victimMaxHitPoints)) return 0;

         switch (blow.DamageType)
         {
            case DamageTypes.Invalid: return 0;
            case DamageTypes.Blunt: return option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Blow_Critical_BLUNT_TI8bQ_Vlaue);
            case DamageTypes.Cut: return option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Blow_Critical_CUT_d461x_Value);
            case DamageTypes.Pierce: return option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Blow_Critical_PIERCE_WDaWG_Value);
         }

         return 0;
      }

      public int WhenThrustTipHit(in string[] loadedOptions, bool thrustTipHit)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceWhenThrustTipHit_Active)) return 0;

         if (thrustTipHit) return option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Thrust_Tip_Hit_cGmzd_Value);

         return 0;
      }

      public int WhenVictimeDidNotRaiseHisGuard(in string[] loadedOptions, in Agent.GuardMode victimCurrentGuardStance)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.ImpactDismountChanceWhenVictimDidNotRaiseHisGuard_Active)) return 0;

         if (victimCurrentGuardStance == Agent.GuardMode.None) return option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_VictimDidNot_Raise_Guard_h8WXN_Value);

         return 0;
      }

      #region private

      private int ApplyMountModifier(in string[] loadedOptions, bool attackerHasMount, int divisor)
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.IncreasesInertiaGivenStrikeOnHorseback_Active)) return 0;

         var b = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Increases_Inertia_Given_Strike_On_Horseback_lqO62_Value);

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