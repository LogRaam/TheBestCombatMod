﻿// Code written by Gabriel Mailhot, 17/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Common;
using TheBestCombatMod.Features.Knocked.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Knocked
{
   public class DecideAgentKnockedDownByBlowFeature
   {
      public int CalculateKnockedDownChances(
         in string[] loadedOptions,
         Agent attackerAgent,
         Agent victimAgent,
         in Blow blow,
         WeaponComponentData attackerWeapon,
         in AttackCollisionData collisionData
      )
      {
         var option = new KnockedDownByBlowOptions(new OptionBase(), new KnockedDownActivationRefTag(), new KnockedDownValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.KnockedDownActivationTag.KnockedDownByBlow_Active)) return 0;

         var armorMaterialType = new ArmorCharacteristics().GetArmorMaterialType(victimAgent, blow);

         var result = DoMath(
            loadedOptions,
            victimAgent.Health,
            victimAgent.Character.MaxHitPoints(),
            attackerWeapon.WeaponClass,
            armorMaterialType,
            attackerAgent.IsHuman && (attackerAgent.IsHero || attackerAgent.Character.IsSoldier),
            blow.StrikeType,
            blow.DamageType,
            blow.VictimBodyPart,
            attackerAgent.Health,
            attackerAgent.Character.MaxHitPoints()
         );

         return (int) result;
      }

      public float DoMath(
         in string[] loadedOptions,
         float victimHealth,
         int victimMaxHealth,
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
         var knockedDownProbability = new KnockedDownProbability();


         var badlyHurtProbability = knockedDownProbability.WhenBadlyHurt(loadedOptions, victimHealth, victimMaxHealth);
         var armorResist = knockedDownProbability.ForStrikeAgainstArmor(loadedOptions, armorMaterialType, attackerWeaponWeaponClass, strikeType, damageType);
         var effectOnBody = knockedDownProbability.OnBodyPart(loadedOptions, strikeType, damageType, victimBodyPart);
         var healthEffect = knockedDownProbability.WhenAttackerIsHealthier(loadedOptions, victimHealth, victimMaxHealth, attackerHealth, attackerMaxHealth);
         var isNotMilitaryTrainedAdjust = knockedDownProbability.WhenAttackerIsNotTrained(loadedOptions, attackerIsSoldierOrHero);


         var result = badlyHurtProbability
                      + armorResist
                      + effectOnBody
                      + healthEffect
                      + isNotMilitaryTrainedAdjust;

         return result;
      }
   }
}