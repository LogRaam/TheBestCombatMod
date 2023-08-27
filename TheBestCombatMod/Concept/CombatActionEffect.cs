// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface CombatActionEffect
   {
      int ForInertiaStrength(float inertia, bool attackerHasMount, float movementSpeedDamageModifier);
      int ForStrikeAgainstArmor(ArmorComponent.ArmorMaterialTypes armorMaterialType, WeaponClass attackerWeaponClass, StrikeType strikeType, DamageTypes typeOfDamage);
      int ForTargetedBodyPart(in BoneBodyPartType blowVictimBodyPart);
      int ForTypeOfDamageOnBodyPart(StrikeType strike, DamageTypes typeOfDamage, BoneBodyPartType bodyPart);
      float IfAttackerIsWoman(in bool attackerAgentIsFemale);
      int WhenAttackerIsHealthier(float victimHealth, float victimMaxHealth, float attackerHealth, float attackerMaxHealth);
      int WhenAttackerIsHeavier(float victimWeight, float attackerWeight);
      int WhenAttackerIsNotTrained(bool isSoldierOrHero);
      int WhenAttackerIsStronger(float victimBuild, float attackerBuild);
      int WhenBlowIsCritical(in Blow blow, in int victimMaxHitPoints);
      int WhenThrustTipHit(bool thrustTipHit);
      int WhenVictimeDidNotRaiseHisGuard(in Agent.GuardMode victimCurrentGuardStance);
   }
}