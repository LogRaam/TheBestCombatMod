// Code written by Gabriel Mailhot, 06/09/2023.

#region

using TaleWorlds.Core;

#endregion

namespace TheBestCombatMod.Features
{
   public class RefTagSwitch
   {
      public string GetRefTagFrom(ResistanceDto dto,
                                  in StrikeType strikeType,
                                  in DamageTypes damageType,
                                  in ArmorComponent.ArmorMaterialTypes materialType)
      {
         return materialType switch
         {
            ArmorComponent.ArmorMaterialTypes.None => string.Empty,
            ArmorComponent.ArmorMaterialTypes.Cloth => strikeType switch
            {
               StrikeType.Swing => damageType switch
               {
                  DamageTypes.Cut => dto.Cloth.Swing_Cut,
                  DamageTypes.Blunt => dto.Cloth.Swing_Blunt,
                  _ => string.Empty
               },
               StrikeType.Thrust => damageType switch
               {
                  DamageTypes.Pierce => dto.Cloth.Thrust_Pierce,
                  DamageTypes.Blunt => dto.Cloth.Thrust_Blunt,
                  _ => string.Empty
               },
               _ => string.Empty
            },
            ArmorComponent.ArmorMaterialTypes.Leather => strikeType switch
            {
               StrikeType.Swing => damageType switch
               {
                  DamageTypes.Cut => dto.Leather.Swing_Cut,
                  DamageTypes.Blunt => dto.Leather.Swing_Blunt,
                  _ => string.Empty
               },
               StrikeType.Thrust => damageType switch
               {
                  DamageTypes.Pierce => dto.Leather.Thrust_Pierce,
                  DamageTypes.Blunt => dto.Leather.Thrust_Blunt,
                  _ => string.Empty
               },
               _ => string.Empty
            },
            ArmorComponent.ArmorMaterialTypes.Chainmail => strikeType switch
            {
               StrikeType.Swing => damageType switch
               {
                  DamageTypes.Cut => dto.Chainmail.Swing_Cut,
                  DamageTypes.Blunt => dto.Chainmail.Swing_Blunt,
                  _ => string.Empty
               },
               StrikeType.Thrust => damageType switch
               {
                  DamageTypes.Pierce => dto.Chainmail.Thrust_Pierce,
                  DamageTypes.Blunt => dto.Chainmail.Thrust_Blunt,
                  _ => string.Empty
               },
               _ => string.Empty
            },
            ArmorComponent.ArmorMaterialTypes.Plate => strikeType switch
            {
               StrikeType.Swing => damageType switch
               {
                  DamageTypes.Cut => dto.Plate.Swing_Cut,
                  DamageTypes.Blunt => dto.Plate.Swing_Blunt,
                  _ => string.Empty
               },
               StrikeType.Thrust => damageType switch
               {
                  DamageTypes.Pierce => dto.Plate.Thrust_Pierce,
                  DamageTypes.Blunt => dto.Plate.Thrust_Blunt,
                  _ => string.Empty
               },
               _ => string.Empty
            },
            _ => string.Empty
         };
      }
   }
}