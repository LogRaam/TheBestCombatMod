// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface CombatActionEffect
   {
      int ForInertiaStrength(in string[] loadedOptions, float inertia, bool attackerHasMount, float movementSpeedDamageModifier);
      int ForStrikeAgainstArmor(in string[] loadedOptions, ArmorComponent.ArmorMaterialTypes armorMaterialType, WeaponClass attackerWeaponClass, StrikeType strikeType, DamageTypes blowDamageType);
      int ForTargetedBodyPart(in string[] loadedOptions, in BoneBodyPartType blowVictimBodyPart);
      int ForTypeOfDamageOnBodyPart(in string[] loadedOptions, StrikeType strike, DamageTypes typeOfDamage, BoneBodyPartType bodyPart);
      float IfAttackerIsWoman(in string[] loadedOptions, in bool attackerAgentIsFemale);
      int WhenAttackerIsHealthier(in string[] loadedOptions, float victimHealth, float victimMaxHealth, float attackerHealth, float attackerMaxHealth);
      int WhenAttackerIsHeavier(in string[] loadedOptions, float victimWeight, float attackerWeight);
      int WhenAttackerIsNotTrained(in string[] loadedOptions, bool isSoldierOrHero);
      int WhenAttackerIsStronger(in string[] loadedOptions, float victimBuild, float attackerBuild);
      int WhenBlowIsCritical(in string[] loadedOptions, in Blow blow, in int victimMaxHitPoints);
      int WhenThrustTipHit(in string[] loadedOptions, bool thrustTipHit);
      int WhenVictimeDidNotRaiseHisGuard(in string[] loadedOptions, in Agent.GuardMode victimCurrentGuardStance);
   }
}