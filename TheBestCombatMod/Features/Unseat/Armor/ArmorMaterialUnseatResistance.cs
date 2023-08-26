// Code written by Gabriel Mailhot, 26/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Armor
{
   public class ArmorMaterialUnseatResistance : ArmorResistance
   {
      private readonly string[] _loadedOptions;

      public ArmorMaterialUnseatResistance(in string[] loadedOptions)
      {
         _loadedOptions = loadedOptions;
      }

      public int ResistanceBonus(in AttackType dto, in int weaponForce, in StrikeType strikeType, in DamageTypes damageType)
      {
         return strikeType switch
         {
            StrikeType.Swing => SwingResistance(weaponForce, damageType, dto),
            StrikeType.Thrust => ThrustResistance(weaponForce, damageType, dto),
            _ => weaponForce
         };
      }

      public int SwingResistance(in int weaponForce, in DamageTypes damageType, AttackType dto)
      {
         return damageType switch
         {
            DamageTypes.Cut => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Swing_Cut),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Swing_Blunt),
            _ => weaponForce
         };
      }

      public int ThrustResistance(in int weaponForce, in DamageTypes damageType, AttackType dto)
      {
         return damageType switch
         {
            DamageTypes.Pierce => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Thrust_Pierce),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Thrust_Blunt),
            _ => weaponForce
         };
      }
   }
}