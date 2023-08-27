// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class TwoHandedSword : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;
      private int _weaponForce;

      public TwoHandedSword(in StrikeType strikeType,
                            in DamageTypes damageType,
                            in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedSword;
      }


      public int GetResistanceBonus(in string[] loadedOptions)
      {
         if (MaterialType == ArmorComponent.ArmorMaterialTypes.None)
         {
            _weaponForce = (int) (_weaponForce * 1.5);
            MaterialType = ArmorComponent.ArmorMaterialTypes.Cloth;
         }

         return MaterialType switch
         {
            ArmorComponent.ArmorMaterialTypes.Cloth => Runtime.Get.ArmorMaterialUnseatResistance.ResistanceBonus(Runtime.Get.TwoHandedSwordClothDto(), _weaponForce, StrikeType, DamageType),
            ArmorComponent.ArmorMaterialTypes.Leather => Runtime.Get.ArmorMaterialUnseatResistance.ResistanceBonus(Runtime.Get.TwoHandedSwordLeatherDto(), _weaponForce, StrikeType, DamageType),
            ArmorComponent.ArmorMaterialTypes.Chainmail => Runtime.Get.ArmorMaterialUnseatResistance.ResistanceBonus(Runtime.Get.TwoHandedSwordChainmailDto(), _weaponForce, StrikeType, DamageType),
            ArmorComponent.ArmorMaterialTypes.Plate => Runtime.Get.ArmorMaterialUnseatResistance.ResistanceBonus(Runtime.Get.TwoHandedSwordPlateDto(), _weaponForce, StrikeType, DamageType),
            _ => _weaponForce
         };
      }
   }
}