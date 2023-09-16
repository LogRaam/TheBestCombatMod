// Code written by Gabriel Mailhot, 05/09/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features
{
   internal class ArmorMaterialResistance : ArmorResistance
   {
      private readonly string[] _loadedOptions;

      public ArmorMaterialResistance(in string[] loadedOptions)
      {
         _loadedOptions = loadedOptions;
      }

      public int ResistanceBonus(in AttackType dto, in int weaponForce, in StrikeType strikeType, in DamageTypes damageType, Feature feature)
      {
         return strikeType switch
         {
            StrikeType.Swing => SwingResistance(weaponForce, damageType, dto, feature),
            StrikeType.Thrust => ThrustResistance(weaponForce, damageType, dto, feature),
            _ => weaponForce
         };
      }


      public int ResistanceBonus(string refTag, int weaponForce, StrikeType strikeType, DamageTypes damageType, Feature feature)
      {
         return feature switch
         {
            Feature.Unseat => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, refTag),
            Feature.KnockedDown => Runtime.KnockedDownImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, refTag),
            _ => 0
         };
      }


      public int SwingResistance(in int weaponForce, in DamageTypes damageType, in AttackType dto, Feature feature)
      {
         return feature switch
         {
            Feature.Unseat => damageType switch
            {
               DamageTypes.Cut => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Swing_Cut),
               DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Swing_Blunt),
               _ => weaponForce
            },
            Feature.KnockedDown => damageType switch
            {
               DamageTypes.Cut => Runtime.KnockedDownImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Swing_Cut),
               DamageTypes.Blunt => Runtime.KnockedDownImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Swing_Blunt),
               _ => weaponForce
            },
            _ => 0
         };
      }


      public int ThrustResistance(in int weaponForce, in DamageTypes damageType, in AttackType dto, Feature feature)
      {
         return feature switch
         {
            Feature.Unseat => damageType switch
            {
               DamageTypes.Pierce => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Thrust_Pierce),
               DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Thrust_Blunt),
               _ => weaponForce
            },
            Feature.KnockedDown => damageType switch
            {
               DamageTypes.Pierce => Runtime.KnockedDownImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Thrust_Pierce),
               DamageTypes.Blunt => Runtime.KnockedDownImpactResistance.ResistanceBonus(_loadedOptions, weaponForce, dto.Thrust_Blunt),
               _ => weaponForce
            },
            _ => 0
         };
      }
   }
}