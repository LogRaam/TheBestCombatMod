// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat
{
   public class DecideAgentUnseatByBlowFeature : UnseatFeature
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
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         if (!option.IsOptionActivated(loadedOptions, option.UnseatActivationValues.DismountedByBlow_Active)) return 0;

         if (attackerAgent == null) return 0;
         if (victimAgent == null) return 0;
         if (attackerWeapon == null) return 0;


         var globalProbability = Runtime.Get.ProtectionInfo;
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

      #region private

      private float DoMath(in string[] loadedOptions,
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
         var unseatProbability = Runtime.Get.UnseatProbability;

         var armorResist = unseatProbability.ForStrikeAgainstArmor(armorMaterialType, weaponClass, blow.StrikeType, blow.DamageType);
         var effectOnBody = unseatProbability.ForTypeOfDamageOnBodyPart(blow.StrikeType, blow.DamageType, blow.VictimBodyPart);
         var bodyPartEffect = unseatProbability.ForTargetedBodyPart(blow.VictimBodyPart);
         var weightEffect = unseatProbability.WhenAttackerIsHeavier(victimWeight, attackerWeight);
         var healthEffect = unseatProbability.WhenAttackerIsHealthier(victimHealth, victimMaxHealth, attackerHealth, attackerMaxHealth);
         var buildEffect = unseatProbability.WhenAttackerIsStronger(victimBuild, attackerBuild);
         var guardEffect = unseatProbability.WhenVictimeDidNotRaiseHisGuard(victimGuardMode);
         var blowEffect = unseatProbability.WhenBlowIsCritical(blow, victimMaxHealth);
         var genderEffect = unseatProbability.IfAttackerIsWoman(attackerIsFemale);
         var thrustEffect = unseatProbability.WhenThrustTipHit(thrustTipHit);
         var inertiaEffect = unseatProbability.ForInertiaStrength(inertia, attackerHasMount, movementSpeedDamageModifier);
         var isNotMilitaryTrainedAdjust = unseatProbability.WhenAttackerIsNotTrained(attackerIsSoldierOrHero);


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

      #endregion
   }
}