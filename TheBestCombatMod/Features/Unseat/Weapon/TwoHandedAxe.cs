// Code written by Gabriel Mailhot, 24/08/2023.

#region

using System;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class TwoHandedAxe : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;


      public TwoHandedAxe(in StrikeType strikeType,
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
         var weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedAxe;

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
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_CLOTH_sN4zR_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_CLOTH_mT8xU_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_CLOTH_fU5zH_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_CLOTH_kD9xL_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_LEATHER_wG6xR_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_LEATHER_nC9xI_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_LEATHER_vE7gV_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_LEATHER_tH3zA_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_CHAINMAIL_aH8xV_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_CHAINMAIL_tQ5zR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_CHAINMAIL_bN4zT_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_CHAINMAIL_rT3zG_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_PLATE_iE8xL_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_PLATE_dH7gV_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_PLATE_sU9gH_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_PLATE_fT4zA_Value);
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