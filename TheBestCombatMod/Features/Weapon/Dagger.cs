// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Weapon
{
   public class Dagger : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      private ArmorComponent.ArmorMaterialTypes _materialType;
      private int _weaponForce;

      public Dagger(in StrikeType strikeType,
                    in DamageTypes damageType,
                    in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         _materialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.Dagger;
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
               Thrust_Pierce = "155we",
               Thrust_Blunt = "54v8T",
               Swing_Blunt = "0ZV6V",
               Swing_Cut = "UbH0U"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "bPOYS",
               Thrust_Blunt = "HqMt5",
               Swing_Blunt = "ETXH0",
               Swing_Cut = "FxMdM"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "OSZe2",
               Thrust_Blunt = "2s0W1",
               Swing_Blunt = "4MwvY",
               Swing_Cut = "qtfhe"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "r3to5",
               Thrust_Blunt = "dmgr7",
               Swing_Blunt = "wbhKr",
               Swing_Cut = "Eo6BI"
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
               Thrust_Pierce = "3HkLg",
               Thrust_Blunt = "hN7Ye",
               Swing_Blunt = "iM0qR",
               Swing_Cut = "J8s2F"
            },
            Leather = new AttackTypeDto
            {
               Thrust_Pierce = "9sT4p",
               Thrust_Blunt = "fR6jP",
               Swing_Blunt = "yA2wC",
               Swing_Cut = "bD1mK"
            },
            Chainmail = new AttackTypeDto
            {
               Thrust_Pierce = "cG5vL",
               Thrust_Blunt = "xU9eP",
               Swing_Blunt = "zI7qM",
               Swing_Cut = "tY3rN"
            },
            Plate = new AttackTypeDto
            {
               Thrust_Pierce = "vX2jD",
               Thrust_Blunt = "nZ8uR",
               Swing_Blunt = "qB4fS",
               Swing_Cut = "lO6wE"
            }
         };

         return new RefTagSwitch().GetRefTagFrom(dto, StrikeType, DamageType, _materialType);
      }

      #endregion
   }
}