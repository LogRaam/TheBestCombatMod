// Code written by Gabriel Mailhot, 26/08/2023.

#region

using TaleWorlds.Core;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface ArmorResistance
   {
      int ResistanceBonus(in AttackType dto, in int weaponForce, in StrikeType strikeType, in DamageTypes damageType);
      int SwingResistance(in int weaponForce, in DamageTypes damageType, AttackType dto);
      int ThrustResistance(in int weaponForce, in DamageTypes damageType, AttackType dto);
   }
}