// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class TwoHandedAxe : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public TwoHandedAxe(in StrikeType strikeType,
                          in DamageTypes damageType,
                          in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedAxe;
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
               Thrust_Pierce = "W3aPx",
               Thrust_Blunt = "C7bQy",
               Swing_Blunt = "F9cRz",
               Swing_Cut = "D4dSx"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "J6eTy",
               Thrust_Blunt = "N9fUz",
               Swing_Blunt = "L3gVx",
               Swing_Cut = "B7hWy"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "E2iXz",
               Thrust_Blunt = "S5jYx",
               Swing_Blunt = "F8kAz",
               Swing_Cut = "M4lBx"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "P7mCy",
               Thrust_Blunt = "R3nDz",
               Swing_Blunt = "T5oEx",
               Swing_Cut = "V8pFy"
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
               Thrust_Pierce = "fU5zH",
               Thrust_Blunt = "kD9xL",
               Swing_Blunt = "mT8xU",
               Swing_Cut = "sN4zR"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "vE7gV",
               Thrust_Blunt = "tH3zA",
               Swing_Blunt = "nC9xI",
               Swing_Cut = "wG6xR"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "bN4zT",
               Thrust_Blunt = "rT3zG",
               Swing_Blunt = "tQ5zR",
               Swing_Cut = "aH8xV"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "sU9gH",
               Thrust_Blunt = "fT4zA",
               Swing_Blunt = "dH7gV",
               Swing_Cut = "iE8xL"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}