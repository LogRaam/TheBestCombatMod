﻿// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Common;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat
{
   public class DecideAgentUnseatByBlowFeature
   {
      public int CalculateStaggerChance(
         in string[] loadedOptions,
         Agent attackerAgent,
         Agent victimAgent,
         in Blow blow,
         WeaponComponentData attackerWeapon,
         AttackCollisionData collision
      )
      {
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationTag.DismountedByBlow_Active)) return 0;

         if (attackerAgent == null) return 0;
         if (victimAgent == null) return 0;
         if (attackerWeapon == null) return 0;


         var globalProbability = new ArmorCharacteristics();
         var armorMaterialType = globalProbability.GetArmorMaterialType(victimAgent, blow);


         var result = DoMath(
            loadedOptions,
            attackerAgent.BodyPropertiesValue.Weight,
            attackerAgent.Health,
            attackerAgent.Character.MaxHitPoints(),
            attackerAgent.BodyPropertiesValue.Build,
            attackerAgent.IsFemale,
            victimAgent.BodyPropertiesValue.Weight,
            victimAgent.Health,
            victimAgent.BodyPropertiesValue.Build,
            victimAgent.CurrentGuardMode,
            victimAgent.Character.MaxHitPoints(),
            blow,
            attackerWeapon.WeaponClass,
            attackerWeapon.Inertia,
            collision.ThrustTipHit,
            armorMaterialType,
            attackerAgent.IsHuman && (attackerAgent.IsHero || attackerAgent.Character.IsSoldier),
            attackerAgent.HasMount,
            blow.MovementSpeedDamageModifier
         );

         return (int) result;
      }

      public float DoMath(in string[] loadedOptions,
                          float attackerWeight,
                          float attackerHealth,
                          float attackerMaxHealth,
                          float attackerBuild,
                          bool attackerIsFemale,
                          float victimWeight,
                          float victimHealth,
                          float victimBuild,
                          Agent.GuardMode victimGuardMode,
                          int victimMaxHealth,
                          Blow blow,
                          WeaponClass weaponClass,
                          float inertia,
                          bool thrustTipHit,
                          ArmorComponent.ArmorMaterialTypes armorMaterialType,
                          bool attackerIsSoldierOrHero,
                          bool attackerHasMount,
                          float movementSpeedDamageModifier
      )
      {
         var unseatProbability = new UnseatProbability();

         var armorResist = unseatProbability.ForStrikeAgainstArmor(loadedOptions, armorMaterialType, weaponClass, blow.StrikeType, blow.DamageType);
         var effectOnBody = unseatProbability.ForTypeOfDamageOnBodyPart(loadedOptions, blow.StrikeType, blow.DamageType, blow.VictimBodyPart);
         var bodyPartEffect = unseatProbability.ForTargetedBodyPart(loadedOptions, blow.VictimBodyPart);
         var weightEffect = unseatProbability.WhenAttackerIsHeavier(loadedOptions, victimWeight, attackerWeight);
         var healthEffect = unseatProbability.WhenAttackerIsHealthier(loadedOptions, victimHealth, victimMaxHealth, attackerHealth, attackerMaxHealth);
         var buildEffect = unseatProbability.WhenAttackerIsStronger(loadedOptions, victimBuild, attackerBuild);
         var guardEffect = unseatProbability.WhenVictimeDidNotRaiseHisGuard(loadedOptions, victimGuardMode);
         var blowEffect = unseatProbability.WhenBlowIsCritical(loadedOptions, blow, victimMaxHealth);
         var genderEffect = unseatProbability.IfAttackerIsWoman(loadedOptions, attackerIsFemale);
         var thrustEffect = unseatProbability.WhenThrustTipHit(loadedOptions, thrustTipHit);
         var inertiaEffect = unseatProbability.ForInertiaStrength(loadedOptions, inertia, attackerHasMount, movementSpeedDamageModifier);
         var isNotMilitaryTrainedAdjust = unseatProbability.WhenAttackerIsNotTrained(loadedOptions, attackerIsSoldierOrHero);


         var result = (int) ((bodyPartEffect
                              + healthEffect
                              + buildEffect
                              + guardEffect
                              + blowEffect
                              + thrustEffect
                              + weightEffect
                              + inertiaEffect
                              + effectOnBody
                              + armorResist
                              + isNotMilitaryTrainedAdjust)
                             / genderEffect);

         return result;
      }
   }
}