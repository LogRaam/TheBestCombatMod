// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class OneHandedSword : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public OneHandedSword(in StrikeType strikeType,
                            in DamageTypes damageType,
                            in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.OneHandedSword;
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
               Thrust_Pierce = "NjNm9",
               Thrust_Blunt = "ObiR3",
               Swing_Blunt = "tdivm",
               Swing_Cut = "eL4H7"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "fhdnO",
               Thrust_Blunt = "n9cZi",
               Swing_Blunt = "oSu6Q",
               Swing_Cut = "xA9AT"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "g5DJs",
               Thrust_Blunt = "ZAqDI",
               Swing_Blunt = "szZ22",
               Swing_Cut = "b6ZR3"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "ab3c8",
               Thrust_Blunt = "d9e2f",
               Swing_Blunt = "1gh5i",
               Swing_Cut = "j6k7l"
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
               Thrust_Pierce = "kWNK9",
               Thrust_Blunt = "oGmnS",
               Swing_Blunt = "64Lhv",
               Swing_Cut = "U1GgF"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "txKI6",
               Thrust_Blunt = "ljFbE",
               Swing_Blunt = "tiuYy",
               Swing_Cut = "HXuje"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "2Ng91",
               Thrust_Blunt = "Unb84",
               Swing_Blunt = "RgN3k",
               Swing_Cut = "UdBiS"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "GDD4U",
               Thrust_Blunt = "9DpM5",
               Swing_Blunt = "qLDxk",
               Swing_Cut = "jgMZR"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}