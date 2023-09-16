// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Features;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface ArmorResistance
   {
      int ResistanceBonus(in AttackType dto, in int weaponForce, in StrikeType strikeType, in DamageTypes damageType, Feature feature);
      int ResistanceBonus(string refTag, int weaponForce, StrikeType strikeType, DamageTypes damageType, Feature feature);
      int SwingResistance(in int weaponForce, in DamageTypes damageType, in AttackType dto, Feature feature);
      int ThrustResistance(in int weaponForce, in DamageTypes damageType, in AttackType dto, Feature feature);
   }
}