// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class Stone : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public Stone(in StrikeType strikeType,
                   in DamageTypes damageType,
                   in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.Stone;
      }

      public int GetResistanceBonus(in string[] loadedOptions, Feature feature)
      {
         if (_materialType == ArmorComponent.ArmorMaterialTypes.None)
         {
            _weaponForce = (int) (_weaponForce * 1.5);
            _materialType = ArmorComponent.ArmorMaterialTypes.Cloth;
         }

         var optionRefTag = feature switch
         {
            Feature.Unseat => UnseatOptionRefTag(),
            Feature.KnockedDown => KnockedDownOptionRefTag(),
            _ => string.Empty
         };

         return Runtime.Get.ArmorMaterialResistance.ResistanceBonus(optionRefTag, _weaponForce, StrikeType, DamageType, feature);
      }

      #region private

      private string KnockedDownOptionRefTag()
      {
         var dto = new ResistanceDto
         {
            Cloth = new AttackTypeDto
            {
               Thrust_Pierce = "K1kQv",
               Thrust_Blunt = "A4lRw",
               Swing_Blunt = "E7mSx",
               Swing_Cut = "Z9nTy"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "I2oUz",
               Thrust_Blunt = "P5pVx",
               Swing_Blunt = "B8qWy",
               Swing_Cut = "F9rXz"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "T3sYx",
               Thrust_Blunt = "M6tZy",
               Swing_Blunt = "K9uAz",
               Swing_Cut = "H7vBx"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "D4wCy",
               Thrust_Blunt = "R8xKz",
               Swing_Blunt = "E2yMx",
               Swing_Cut = "L6zNv"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      private string UnseatOptionRefTag()
      {
         var dto = new ResistanceDto
         {
            Cloth = new AttackTypeDto
            {
               Thrust_Pierce = "fG4zW",
               Thrust_Blunt = "zC8xI",
               Swing_Blunt = "kE9xR",
               Swing_Cut = "jN5uG"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "qH4zP",
               Thrust_Blunt = "rY8nA",
               Swing_Blunt = "uN9gS",
               Swing_Cut = "pC3xV"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "dE7rQ",
               Thrust_Blunt = "fM4zG",
               Swing_Blunt = "bQ5zE",
               Swing_Cut = "aU9gR"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "tH7xQ",
               Thrust_Blunt = "nY3hA",
               Swing_Blunt = "kN4zI",
               Swing_Cut = "zC8xG"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}