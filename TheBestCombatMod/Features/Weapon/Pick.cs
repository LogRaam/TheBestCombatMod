// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class Pick : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public Pick(in StrikeType strikeType,
                  in DamageTypes damageType,
                  in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.Pick;
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
               Thrust_Pierce = "3tRfG",
               Thrust_Blunt = "P8jKq",
               Swing_Blunt = "d4ZvB",
               Swing_Cut = "L7mXy"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "g2FpQ",
               Thrust_Blunt = "R9uWn",
               Swing_Blunt = "J5cYv",
               Swing_Cut = "S6kBz"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "N1aHp",
               Thrust_Blunt = "X4bJt",
               Swing_Blunt = "M7dKx",
               Swing_Cut = "G9fLz"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "Q2gMy",
               Thrust_Blunt = "V5hNz",
               Swing_Blunt = "C8iOx",
               Swing_Cut = "T6jPw"
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
               Thrust_Pierce = "xC9xT",
               Thrust_Blunt = "qM2dA",
               Swing_Blunt = "yB7gR",
               Swing_Cut = "nF5zV"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "tR6zE",
               Thrust_Blunt = "pC9xV",
               Swing_Blunt = "sU5zH",
               Swing_Cut = "bJ2hT"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "eB4mW",
               Thrust_Blunt = "aN8xS",
               Swing_Blunt = "kF9cR",
               Swing_Cut = "xU3gA"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "mJ7hV",
               Thrust_Blunt = "iM3zA",
               Swing_Blunt = "wE9xR",
               Swing_Cut = "rB6gS"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}