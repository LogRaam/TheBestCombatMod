// Code written by Gabriel Mailhot, 19/08/2023.

#region

using System;
using LogRaamConfiguration;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Common;
using TheBestCombatMod.Features.Knocked.Values;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Knocked
{
   internal class KnockedDownProbability
   {
      private readonly KnockedDownByBlowOptions _option = new(new OptionBase(), new KnockedDownActivationRefTag(), new KnockedDownValueRefTag(), new ActivationRefTag(), new ValueRefTag());

      public int ForStrikeAgainstArmor(in string[] loadedOptions, ArmorComponent.ArmorMaterialTypes armorMaterialType, WeaponClass attackerWeaponClass, StrikeType strikeType, DamageTypes blowDamageType)
      {
         if (IsNotActivated(loadedOptions, _option.KnockedDownActivationTag.KnockedDownByBlow_Active)) return 0;

         var bonus = new ArmorCharacteristics().GetResistanceBonusFrom(loadedOptions, attackerWeaponClass, strikeType, blowDamageType, armorMaterialType);

         return bonus;


         return 1;
      }


      public int OnBodyPart(in string[] loadedOptions, StrikeType strike, DamageTypes damageType, BoneBodyPartType victimBodyPart)
      {
         if (IsNotActivated(loadedOptions, _option.KnockedDownActivationTag.EffectOnBodyPart_Active)) return 0;

         if (victimBodyPart == BoneBodyPartType.None || damageType == DamageTypes.Invalid || strike == StrikeType.Invalid)
         {
            return Runtime.StaggerStrength.None;
         }

         var option = new KnockedDownByBlowOptions(new OptionBase(new BodyPartUnseatStaggerValue(loadedOptions)), new KnockedDownActivationRefTag(), new KnockedDownValueRefTag(), new ActivationRefTag(), new ValueRefTag());


         switch (victimBodyPart)
         {
            case BoneBodyPartType.Head:
               switch (damageType)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.HEAD_CUT_SWINGING_OQ2xO_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.HEAD_CUT_THRUSTING_YcI0n_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.HEAD_PIERCE_SWINGING_6pmqy_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.HEAD_PIERCE_THRUSTING_B1pFn_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.HEAD_BLUNT_SWINGING_cVrSS_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.HEAD_BLUNT_THRUSTING_fe45p_Value);
               }

               break;
            case BoneBodyPartType.Neck:
               switch (damageType)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.NECK_CUT_SWINGING_C9LgN_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.NECK_CUT_THRUSTING_bI0zB_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.NECK_PIERCE_SWINGING_Zjr5i_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.NECK_PIERCE_THRUSTING_9O8v5_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.NECK_BLUNT_SWINGING_J4B3B_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.NECK_BLUNT_THRUSTING_ugKRH_Value);
               }

               break;
            case BoneBodyPartType.Chest:
               switch (damageType)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.CHEST_CUT_SWINGING_CRF3J_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.CHEST_CUT_THRUSTING_OICbR_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.CHEST_PIERCE_SWINGING_Khcy7_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.CHEST_PIERCE_THRUSTING_6d9EV_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.CHEST_BLUNT_SWINGING_sKuQM_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.CHEST_BLUNT_THRUSTING_NXIfH_Value);
               }

               break;
            case BoneBodyPartType.Abdomen:
               switch (damageType)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ABDOMEN_CUT_SWINGING_QrXgU_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ABDOMEN_CUT_THRUSTING_Vt6DF_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ABDOMEN_PIERCE_SWINGING_EMsgc_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ABDOMEN_PIERCE_THRUSTING_HgUNm_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ABDOMEN_BLUNT_SWINGING_D5Hdv_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ABDOMEN_BLUNT_THRUSTING_vNHgz_Value);
               }

               break;
            case BoneBodyPartType.ShoulderLeft or BoneBodyPartType.ShoulderRight:
               switch (damageType)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.SHOULDERS_CUT_SWINGING_EXiaJ_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.SHOULDERS_CUT_THRUSTING_67y86_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.SHOULDERS_PIERCE_SWINGING_ZXZnF_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.SHOULDERS_PIERCE_THRUSTING_WM1l3_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.SHOULDERS_BLUNT_SWINGING_RlWlN_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.SHOULDERS_BLUNT_THRUSTING_k8lLo_Value);
               }

               break;
            case BoneBodyPartType.ArmLeft or BoneBodyPartType.ArmRight:
               switch (damageType)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ARMS_CUT_SWINGING_4qBAL_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ARMS_CUT_THRUSTING_L8S6n_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ARMS_PIERCE_SWINGING_hzBcV_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ARMS_PIERCE_THRUSTING_nWoIs_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ARMS_BLUNT_SWINGING_AvHnv_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.ARMS_BLUNT_THRUSTING_1yGZ7_Value);
               }

               break;
            case BoneBodyPartType.Legs:
               switch (damageType)
               {
                  case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.LEGS_CUT_SWINGING_QwhPA_Value);
                  case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.LEGS_CUT_THRUSTING_Yi4SA_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.LEGS_PIERCE_SWINGING_SyWWo_Value);
                  case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.LEGS_PIERCE_THRUSTING_u26yW_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.LEGS_BLUNT_SWINGING_RiOF1_Value);
                  case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetKnockdownAlphaValueFor(loadedOptions, option.KnockedDownValueTags.LEGS_BLUNT_THRUSTING_IFQCs_Value);
               }

               break;
         }


         return 0;
      }


      public int WhenAttackerIsHealthier(in string[] loadedOptions, float victimHealth, int victimMaxHealth, float attackerHealth, float attackerMaxHealth)
      {
         if (IsNotActivated(loadedOptions, _option.KnockedDownActivationTag.WhenAttackerIsHealthier_Active)) return 0;

         if (Math.Abs(victimHealth - attackerHealth) < 0.0001) return 0;

         double attackerPercentageHealth = GetPercentageFrom(attackerHealth, attackerMaxHealth);
         double victimePercentageHealth = GetPercentageFrom(victimHealth, victimMaxHealth);
         var divisor = _option.GetIntegerValueFor(loadedOptions, _option.KnockedDownValueTags.Impact_Knockdown_Chance_Attacker_Healthier_0ZCKG_Value);

         if (victimePercentageHealth > attackerPercentageHealth) return WhenDefenderIsHealthier(attackerPercentageHealth, victimePercentageHealth, divisor);

         var result = 100 - Math.Pow(victimePercentageHealth, 0.5f) * 10;
         result /= divisor;

         return (int) result;
      }

      public int WhenAttackerIsNotTrained(in string[] loadedOptions, bool isSoldierOrHero)
      {
         var option = new KnockedDownByBlowOptions(new OptionBase(), new KnockedDownActivationRefTag(), new KnockedDownValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.KnockedDownActivationTag.ReduceProbabilityForPeasants)) return 0;

         var result = option.GetIntegerValueFor(loadedOptions, option.KnockedDownValueTags.PEASANT_REDUCE_PROBABILITY_BY);

         if (!isSoldierOrHero) return result;

         return 0;
      }


      public int WhenBadlyHurt(in string[] loadedOptions, float victimHealth, int victimMaxHealth)
      {
         if (IsNotActivated(loadedOptions, _option.KnockedDownActivationTag.WhenBadlyHurt_Active)) return 0;

         var result = GetPercentageFrom(victimHealth, victimMaxHealth);
         var treshold = _option.GetIntegerValueFor(loadedOptions, _option.KnockedDownValueTags.TresholdValueWhenBadlyHurt_5w5jT_Value);

         if (result > treshold) return 0;

         var bonus = _option.GetIntegerValueFor(loadedOptions, _option.KnockedDownValueTags.ChanceModifierWhenBadlyHurt_Mlz88_Value);

         return bonus;
      }

      #region private

      private float GetPercentageFrom(float attackerHealth, float attackerMaxHealth)
      {
         var result = (attackerHealth - 1) / (attackerMaxHealth - 1) * 100;

         return result;
      }

      private bool IsNotActivated(string[] loadedOptions, string activationTag)
      {
         if (!_option.IsOptionActivated(loadedOptions, activationTag)) return true;

         return false;
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