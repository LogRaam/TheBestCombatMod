// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   public class Javelin : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public Javelin(in StrikeType strikeType,
                     in DamageTypes damageType,
                     in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.Javelin;
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
               Thrust_Pierce = "ztAYD",
               Thrust_Blunt = "g5MD1",
               Swing_Blunt = "yfRpp",
               Swing_Cut = "q7iqc"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "5GJGZ",
               Thrust_Blunt = "9FWJE",
               Swing_Blunt = "hGBPr",
               Swing_Cut = "T4ePF"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "fW9TC",
               Thrust_Blunt = "q0cIE",
               Swing_Blunt = "EHwKS",
               Swing_Cut = "6NgkD"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "IzxqS",
               Thrust_Blunt = "R3iIf",
               Swing_Blunt = "e6xoc",
               Swing_Cut = "q4oUQ"
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
               Thrust_Pierce = "mC9dH",
               Thrust_Blunt = "kY3gW",
               Swing_Blunt = "tA1vZ",
               Swing_Cut = "rN5uX"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "pE8bQ",
               Thrust_Blunt = "sU7nJ",
               Swing_Blunt = "yM4aI",
               Swing_Cut = "iK6xO"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "xF9cV",
               Thrust_Blunt = "zD5tL",
               Swing_Blunt = "pA3vR",
               Swing_Cut = "nB7eU"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "oX1wM",
               Thrust_Blunt = "mY8bF",
               Swing_Blunt = "tZ7uO",
               Swing_Cut = "rC4dP"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}