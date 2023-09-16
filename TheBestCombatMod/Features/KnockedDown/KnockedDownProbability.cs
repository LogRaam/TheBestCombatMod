// Code written by Gabriel Mailhot, 28/08/2023.

#region

using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown
{
   public class KnockedDownProbability
   {
      public KnockedDownProbability(in KnockedDownProbabilityConstructorParams parameters)
      {
         LoadedOptions = parameters.LoadedOptions;
         KnockedDownOptionReader = parameters.KnockedDownOptionReader;
         BodyHitProbability = parameters.BodyHitProbability;
         Configuration = parameters.KnockedDownByBlowConfiguration;
         DefenseInfo = parameters.DefenseInfo;
      }

      public BodyHitProbability BodyHitProbability { get; set; }
      public KnockedDownByBlowConfiguration Configuration { get; set; }

      public SituationalDefenseInfo DefenseInfo { get; set; }
      public KnockedDownOptionReader KnockedDownOptionReader { get; set; }
      public string[] LoadedOptions { get; set; }

      public int ForStrikeAgainstArmor(in string[] loadedOptions, ArmorComponent.ArmorMaterialTypes armorMaterialType, WeaponClass attackerWeaponClass, StrikeType strikeType, DamageTypes blowDamageType)
      {
         if (IsNotActivated(loadedOptions, Configuration.KnockedDownActiveTagValue.KnockedDownByBlow_Active)) return 0;

         var bonus = DefenseInfo.GetResistanceBonusFrom(loadedOptions, attackerWeaponClass, strikeType, blowDamageType, armorMaterialType, Feature.KnockedDown);

         return bonus;
      }


      public int OnBodyPart(string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, BoneBodyPartType bodyPart, KnockedDownOptionReader optionReader)
      {
         if (IsNotActivated(loadedOptions, Configuration.KnockedDownActiveTagValue.EffectOnBodyPart_Active)) return 0;

         var result = BodyHitProbability.GetProbabilityFor(loadedOptions, typeOfDamage, strike, bodyPart, optionReader);

         return result;
      }


      public int WhenAttackerIsHealthier(in string[] loadedOptions, float victimHealth, float victimMaxHealth, float attackerHealth, float attackerMaxHealth)
      {
         if (IsNotActivated(loadedOptions, Configuration.KnockedDownActiveTagValue.WhenAttackerIsHealthier_Active)) return 0;

         if (Math.Abs(victimHealth - attackerHealth) < 0.0001) return 0;

         double attackerPercentageHealth = GetPercentageFrom(attackerHealth, attackerMaxHealth);
         double victimePercentageHealth = GetPercentageFrom(victimHealth, victimMaxHealth);
         var divisor = Configuration.GetIntegerValueFor(loadedOptions, Configuration.KnockedDownValueTags.Impact_Knockdown_Chance_Attacker_Healthier_0ZCKG_Value);

         if (victimePercentageHealth > attackerPercentageHealth) return WhenDefenderIsHealthier(attackerPercentageHealth, victimePercentageHealth, divisor);

         var result = 100 - Math.Pow(victimePercentageHealth, 0.5f) * 10;
         result /= divisor;

         return (int) result;
      }

      public int WhenAttackerIsNotTrained(in string[] loadedOptions, bool isSoldierOrHero)
      {
         var option = Runtime.Get.KnockedDownByBlowConfiguration;

         if (!Configuration.IsOptionActivated(loadedOptions, Configuration.KnockedDownActiveTagValue.ReduceProbabilityForPeasants)) return 0;

         var result = Configuration.GetIntegerValueFor(loadedOptions, Configuration.KnockedDownValueTags.PEASANT_ATTACKER_KNOCKEDDOWN_REDUCE_PROBABILITY_BY);

         if (!isSoldierOrHero) return result;

         return 0;
      }


      public int WhenBadlyHurt(in string[] loadedOptions, float victimHealth, float victimMaxHealth)
      {
         if (IsNotActivated(loadedOptions, Configuration.KnockedDownActiveTagValue.WhenBadlyHurt_Active)) return 0;

         var result = GetPercentageFrom(victimHealth, victimMaxHealth);
         var treshold = Configuration.GetIntegerValueFor(loadedOptions, Configuration.KnockedDownValueTags.TresholdValueWhenBadlyHurt_5w5jT_KNOCKEDDOWN_Value);

         if (result > treshold) return 0;

         var bonus = Configuration.GetIntegerValueFor(loadedOptions, Configuration.KnockedDownValueTags.ChanceModifierWhenBadlyHurt_Mlz88_KNOCKEDDOWN_Value);

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
         if (!Configuration.IsOptionActivated(loadedOptions, activationTag)) return true;

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


   public class KnockedDownProbability_params : KnockedDownProbabilityConstructorParams
   {
      public BodyHitProbability BodyHitProbability { get; set; }
      public BodyPartsVulnerabilityOptions BodyPartsVulnerabilityOptions { get; set; }
      public SituationalDefenseInfo DefenseInfo { get; set; }
      public KnockedDownByBlowConfiguration KnockedDownByBlowConfiguration { get; set; }
      public KnockedDownOptionReader KnockedDownOptionReader { get; set; }
      public string[] LoadedOptions { get; set; }
   }

   public interface KnockedDownProbabilityConstructorParams
   {
      BodyHitProbability BodyHitProbability { get; set; }
      BodyPartsVulnerabilityOptions BodyPartsVulnerabilityOptions { get; set; }
      public SituationalDefenseInfo DefenseInfo { get; set; }
      KnockedDownByBlowConfiguration KnockedDownByBlowConfiguration { get; set; }
      KnockedDownOptionReader KnockedDownOptionReader { get; set; }
      string[] LoadedOptions { get; set; }
   }
}