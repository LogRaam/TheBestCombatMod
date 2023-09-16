// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class OneHandedMace : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public OneHandedMace(in StrikeType strikeType,
                           in DamageTypes damageType,
                           in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.Mace;
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
               Thrust_Pierce = "nBPtL",
               Thrust_Blunt = "JTiV7",
               Swing_Blunt = "AwH5a",
               Swing_Cut = "xlNry"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "IqG3z",
               Thrust_Blunt = "rrqwV",
               Swing_Blunt = "wX4QZ",
               Swing_Cut = "FqEmO"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "VBO8D",
               Thrust_Blunt = "nQojh",
               Swing_Blunt = "e0ub6",
               Swing_Cut = "MaNml"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "vGfog",
               Thrust_Blunt = "Za2rw",
               Swing_Blunt = "9HiAE",
               Swing_Cut = "tI4UP"
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
               Thrust_Pierce = "bN3hU",
               Thrust_Blunt = "tE5rW",
               Swing_Blunt = "uB9fS",
               Swing_Cut = "mQ7aN"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "gM4zD",
               Thrust_Blunt = "kP6xH",
               Swing_Blunt = "hR5vQ",
               Swing_Cut = "qJ9cK"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "aT2mZ",
               Thrust_Blunt = "wD8eV",
               Swing_Blunt = "pF1wK",
               Swing_Cut = "jY7gI"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "nC6zT",
               Thrust_Blunt = "vB9fQ",
               Swing_Blunt = "lA8hY",
               Swing_Cut = "zE3dX"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}