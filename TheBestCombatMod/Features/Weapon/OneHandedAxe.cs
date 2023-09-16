// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   internal class OneHandedAxe : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public OneHandedAxe(in StrikeType strikeType,
                          in DamageTypes damageType,
                          in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.OneHandedAxe;
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
               Thrust_Pierce = "7bEDm",
               Thrust_Blunt = "NCHfy",
               Swing_Blunt = "xiBqb",
               Swing_Cut = "4dfIj"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "f6gV5",
               Thrust_Blunt = "efD8x",
               Swing_Blunt = "oTezN",
               Swing_Cut = "eB5NV"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "BCKTm",
               Thrust_Blunt = "4D4tg",
               Swing_Blunt = "fIwtn",
               Swing_Cut = "o3hJa"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "jfxkn",
               Thrust_Blunt = "8v6eF",
               Swing_Blunt = "tYoRa",
               Swing_Cut = "gQosN"
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
               Thrust_Pierce = "hR6zK",
               Thrust_Blunt = "pC9xW",
               Swing_Blunt = "yE7rP",
               Swing_Cut = "nJ2hQ"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "wB4mV",
               Thrust_Blunt = "jN1xL",
               Swing_Blunt = "cD9fY",
               Swing_Cut = "aT5zH"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "qU7gT",
               Thrust_Blunt = "kM3dV",
               Swing_Blunt = "mF2hZ",
               Swing_Cut = "rJ9xI"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "zB4mR",
               Thrust_Blunt = "lN8xG",
               Swing_Blunt = "vU7gQ",
               Swing_Cut = "tJ3hV"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}