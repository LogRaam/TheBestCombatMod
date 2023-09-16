// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class TwoHandedPolearm : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public TwoHandedPolearm(in StrikeType strikeType,
                              in DamageTypes damageType,
                              in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedPolearm;
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
               Thrust_Pierce = "",
               Thrust_Blunt = "",
               Swing_Blunt = "",
               Swing_Cut = ""
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "",
               Thrust_Blunt = "",
               Swing_Blunt = "",
               Swing_Cut = ""
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "",
               Thrust_Blunt = "",
               Swing_Blunt = "",
               Swing_Cut = ""
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "",
               Thrust_Blunt = "",
               Swing_Blunt = "",
               Swing_Cut = ""
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
               Thrust_Pierce = "zH4zW",
               Thrust_Blunt = "yN7xL",
               Swing_Blunt = "vH8xR",
               Swing_Cut = "mD4zE"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "cT9xI",
               Thrust_Blunt = "gN4zG",
               Swing_Blunt = "yT3zH",
               Swing_Cut = "bE7gA"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "kG6xU",
               Thrust_Blunt = "pG8xV",
               Swing_Blunt = "lJ2hT",
               Swing_Cut = "fR5zA"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "eS4zG",
               Thrust_Blunt = "mH6xV",
               Swing_Blunt = "kD3zA",
               Swing_Cut = "rN9gR"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}