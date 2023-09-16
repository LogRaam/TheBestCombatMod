// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown
{
   public class FootmanKnockedDownByBlowFeature : KnockedDownFeature
   {
      public int CalculateKnockedDownChances(
         in string[] loadedOptions,
         bool attackerIsHuman,
         bool attackerIsHero,
         bool attackerIsSoldier,
         float attackerHealth,
         float attackerMaxHealth,
         float victimHealth,
         float victimMaxHealth,
         StrikeType strikeType,
         DamageTypes damageType,
         BoneBodyPartType victimBodyPart,
         WeaponClass attackerWeaponClass,
         ArmorComponent.ArmorMaterialTypes armorMaterialType
      )
      {
         var option = Runtime.Get.KnockedDownByBlowConfiguration;

         if (!option.IsOptionActivated(loadedOptions, option.KnockedDownActiveTagValue.KnockedDownByBlow_Active)) return 0;

         var result = DoMath(
            loadedOptions,
            victimHealth,
            victimMaxHealth,
            attackerWeaponClass,
            armorMaterialType,
            attackerIsHuman && attackerIsHero && attackerIsSoldier,
            strikeType,
            damageType,
            victimBodyPart,
            attackerHealth,
            attackerMaxHealth
         );

         return (int) result;
      }

      #region private

      private float DoMath(
         in string[] loadedOptions,
         float victimHealth,
         float victimMaxHealth,
         WeaponClass attackerWeaponWeaponClass,
         ArmorComponent.ArmorMaterialTypes armorMaterialType,
         bool attackerIsSoldierOrHero,
         StrikeType strikeType,
         DamageTypes damageType,
         BoneBodyPartType victimBodyPart,
         float attackerHealth,
         float attackerMaxHealth
      )
      {
         var knockedDownProbability = Runtime.Get.KnockedDownProbability;


         var badlyHurtProbability = knockedDownProbability.WhenBadlyHurt(loadedOptions, victimHealth, victimMaxHealth);
         var armorResist = knockedDownProbability.ForStrikeAgainstArmor(loadedOptions, armorMaterialType, attackerWeaponWeaponClass, strikeType, damageType);
         var effectOnBody = knockedDownProbability.OnBodyPart(loadedOptions, damageType, strikeType, victimBodyPart, Runtime.Get.KnockedDownByBlowOptionReader);
         var healthEffect = knockedDownProbability.WhenAttackerIsHealthier(loadedOptions, victimHealth, victimMaxHealth, attackerHealth, attackerMaxHealth);
         var isNotMilitaryTrainedAdjust = knockedDownProbability.WhenAttackerIsNotTrained(loadedOptions, attackerIsSoldierOrHero);


         var result = badlyHurtProbability
                      - armorResist
                      + effectOnBody
                      + healthEffect
                      - isNotMilitaryTrainedAdjust;

         return result;
      }

      #endregion
   }
}