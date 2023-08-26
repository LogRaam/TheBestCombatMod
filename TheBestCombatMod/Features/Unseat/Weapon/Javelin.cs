// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class Javelin : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;
      private readonly string[] _loadedOptions;
      private readonly UnseatOptionReader _option;
      private int _weaponForce;

      public Javelin(in string[] loadedOptions,
                     in StrikeType strikeType,
                     in DamageTypes damageType,
                     in ArmorComponent.ArmorMaterialTypes materialType)
      {
         _loadedOptions = loadedOptions;
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
         _weaponForce = Runtime.WeaponStaggerForceValue.Javelin;
         _option = Runtime.Get.UnseatOptionReader;
      }


      public int GetResistanceBonus(in string[] loadedOptions)
      {
         if (MaterialType == ArmorComponent.ArmorMaterialTypes.None)
         {
            _weaponForce = (int) (_weaponForce * 1.5);
            MaterialType = ArmorComponent.ArmorMaterialTypes.Cloth;
         }

         switch (MaterialType)
         {
            case ArmorComponent.ArmorMaterialTypes.Cloth: return Runtime.Get.ArmorMaterialUnseatResistance.ResistanceBonus(Runtime.Get.JavelinClothDto(), _weaponForce, StrikeType, DamageType);
            case ArmorComponent.ArmorMaterialTypes.Leather: return Runtime.Get.ArmorMaterialUnseatResistance.ResistanceBonus(Runtime.Get.JavelinLeatherDto(), _weaponForce, StrikeType, DamageType);
            case ArmorComponent.ArmorMaterialTypes.Chainmail: return Runtime.Get.ArmorMaterialUnseatResistance.ResistanceBonus(Runtime.Get.JavelinChainmailDto(), _weaponForce, StrikeType, DamageType);
            case ArmorComponent.ArmorMaterialTypes.Plate: return Runtime.Get.ArmorMaterialUnseatResistance.ResistanceBonus(Runtime.Get.JavelinPlateDto(), _weaponForce, StrikeType, DamageType);
         }

         return _weaponForce;
      }
   }
}