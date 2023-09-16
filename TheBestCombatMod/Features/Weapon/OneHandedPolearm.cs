// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class OneHandedPolearm : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public OneHandedPolearm(in StrikeType strikeType,
                              in DamageTypes damageType,
                              in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.OneHandedPolearm;
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
               Thrust_Pierce = "mno4p",
               Thrust_Blunt = "aB3cD",
               Swing_Blunt = "E9fGh",
               Swing_Cut = "I1jK2"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "LmN3o",
               Thrust_Blunt = "P4qRs",
               Swing_Blunt = "T5uVw",
               Swing_Cut = "X6yZ7"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "7BdF",
               Thrust_Blunt = "E8gHj",
               Swing_Blunt = "K6mNp",
               Swing_Cut = "Q9rSt"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "A2bC4",
               Thrust_Blunt = "D7eF9",
               Swing_Blunt = "G3hI5",
               Swing_Cut = "J6kL8"
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
               Thrust_Pierce = "dR6zE",
               Thrust_Blunt = "kC9xT",
               Swing_Blunt = "sJ4hQ",
               Swing_Cut = "lM2dH"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "rU7gK",
               Thrust_Blunt = "xM3zV",
               Swing_Blunt = "aF5zT",
               Swing_Cut = "eJ9xI"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "nE2dG",
               Thrust_Blunt = "mC6xV",
               Swing_Blunt = "sR4zT",
               Swing_Cut = "tA8hK"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "yE6xJ",
               Thrust_Blunt = "bT2dK",
               Swing_Blunt = "qM5zE",
               Swing_Cut = "hU9gT"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}