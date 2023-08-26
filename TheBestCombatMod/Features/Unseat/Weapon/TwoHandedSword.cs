// Code written by Gabriel Mailhot, 24/08/2023.

#region

using System;
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


      public TwoHandedSword(in StrikeType strikeType,
                            in DamageTypes damageType,
                            in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
      }


      public int ChainmailResistanceBonus() => throw new NotImplementedException();

      public int ChainmailSwingResistance() => throw new NotImplementedException();

      public int ChainmailThrustResistance() => throw new NotImplementedException();

      public int ClothResistanceBonus() => throw new NotImplementedException();

      public int ClothSwingResistance() => throw new NotImplementedException();

      public int ClothThrustResistance() => throw new NotImplementedException();

      public int GetResistanceBonus(in string[] loadedOptions)
      {
         var weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedSword;

         var option = Runtime.Get.UnseatOptionReader;


         if (MaterialType == ArmorComponent.ArmorMaterialTypes.None)
         {
            weaponForce = (int) (weaponForce * 1.5);
            MaterialType = ArmorComponent.ArmorMaterialTypes.Cloth;
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Cloth)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_CLOTH_yN7xG_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_CLOTH_dH8xR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_CLOTH_wT9xP_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_CLOTH_nE4zA_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_LEATHER_tN7xH_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_LEATHER_lH8xV_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_LEATHER_wT9xT_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_LEATHER_xE4zG_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_CHAINMAIL_yN7xI_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_CHAINMAIL_dH8xT_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_CHAINMAIL_aT9xL_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_CHAINMAIL_fE4zR_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_PLATE_tN7xL_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_PLATE_lH8xR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_PLATE_wT9xG_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_PLATE_xE4zH_Value);
            }
         }

         return weaponForce;
      }

      public int LeatherResistanceBonus() => throw new NotImplementedException();

      public int LeatherSwingResistance() => throw new NotImplementedException();

      public int LeatherThrustResistance() => throw new NotImplementedException();

      public int PlateResistanceBonus() => throw new NotImplementedException();

      public int PlateSwingResistance() => throw new NotImplementedException();

      public int PlateThrustResistance() => throw new NotImplementedException();
   }
}