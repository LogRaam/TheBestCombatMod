// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class TwoHandedMace : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public TwoHandedMace(in StrikeType strikeType,
                           in DamageTypes damageType,
                           in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedMace;
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
               Thrust_Pierce = "N2qGz",
               Thrust_Blunt = "H5rHx",
               Swing_Blunt = "P8sKy",
               Swing_Cut = "M3tLz"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "G6uMx",
               Thrust_Blunt = "C9vNy",
               Swing_Blunt = "W3wOz",
               Swing_Cut = "E7xPx"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "S2yQy",
               Thrust_Blunt = "L5zRz",
               Swing_Blunt = "G8aSx",
               Swing_Cut = "N4bTy"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "T7cUz",
               Thrust_Blunt = "M3dVx",
               Swing_Blunt = "K6eWy",
               Swing_Cut = "H9fXz"
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
               Thrust_Pierce = "zD9xT",
               Thrust_Blunt = "bN4zA",
               Swing_Blunt = "gU5zV",
               Swing_Cut = "qH8xG"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "wT4zE",
               Thrust_Blunt = "zE9xL",
               Swing_Blunt = "kT3zR",
               Swing_Cut = "mH7gA"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "aG6xI",
               Thrust_Blunt = "jG8xT",
               Swing_Blunt = "mJ2hU",
               Swing_Cut = "lR5zH"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "bH4zG",
               Thrust_Blunt = "dU6xV",
               Swing_Blunt = "pS5zE",
               Swing_Cut = "jC9xR"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}