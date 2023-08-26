// Code written by Gabriel Mailhot, 24/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface UnseatActivationValue
   {
      string DismountedByBlow_Active { get; }
      string ImpactDismountChanceForStrikeAgainstArmor_Active { get; }
      string ImpactDismountChanceForTargetedBodyPart_Active { get; }
      string ImpactDismountChanceTakingAccountAttackerWeaponInertia_Active { get; }
      string ImpactDismountChanceWhenAttackerIsAWoman_Active { get; }
      string ImpactDismountChanceWhenAttackerIsHealthier_Active { get; }
      string ImpactDismountChanceWhenAttackerIsHeavier_Active { get; }
      string ImpactDismountChanceWhenAttackerIsStronger_Active { get; }
      string ImpactDismountChanceWhenBlowIsCritical_Active { get; }
      string ImpactDismountChanceWhenThrustTipHit_Active { get; }
      string ImpactDismountChanceWhenVictimDidNotRaiseHisGuard_Active { get; }
      string IncreasesInertiaGivenStrikeOnHorseback_Active { get; }
      string ReduceProbabilityForPeasants { get; }
      string StrikeEffectOnBodyPart_Active { get; }
   }
}