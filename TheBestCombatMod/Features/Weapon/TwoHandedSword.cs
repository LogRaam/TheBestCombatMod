// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class TwoHandedSword : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public TwoHandedSword(in StrikeType strikeType,
                            in DamageTypes damageType,
                            in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedSword;
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
               Thrust_Pierce = "Q2wQy",
               Thrust_Blunt = "C5xRz",
               Swing_Blunt = "P8ySx",
               Swing_Cut = "F3zTx"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "L6aUz",
               Thrust_Blunt = "N9bVx",
               Swing_Blunt = "K3cWy",
               Swing_Cut = "H7dXz"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "Q2eYx",
               Thrust_Blunt = "A5fZy",
               Swing_Blunt = "E8gAz",
               Swing_Cut = "T4hBx"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "M7iCy",
               Thrust_Blunt = "N3jDz",
               Swing_Blunt = "L6kEx",
               Swing_Cut = "G9lFy"
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
               Thrust_Pierce = "kT9xP",
               Thrust_Blunt = "nE4zA",
               Swing_Blunt = "dH8xR",
               Swing_Cut = "yN7xG"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "wT9xT",
               Thrust_Blunt = "xE4zG",
               Swing_Blunt = "lH8xV",
               Swing_Cut = "tN7xH"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "aT9xL",
               Thrust_Blunt = "fE4zR",
               Swing_Blunt = "dH8xT",
               Swing_Cut = "yN7xI"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "wT9xG",
               Thrust_Blunt = "xE4zH",
               Swing_Blunt = "lH8xR",
               Swing_Cut = "tN7xL"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}