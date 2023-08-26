// Code written by Gabriel Mailhot, 24/08/2023.

#region

using System;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class OneHandedPolearm : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;


      public OneHandedPolearm(in StrikeType strikeType,
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
         var weaponForce = Runtime.WeaponStaggerForceValue.OneHandedPolearm;

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
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_CLOTH_lM2dH_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_CLOTH_sJ4hQ_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CLOTH_dR6zE_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CLOTH_kC9xT_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_LEATHER_eJ9xI_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_LEATHER_aF5zT_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_LEATHER_rU7gK_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_LEATHER_xM3zV_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_CHAINMAIL_tA8hK_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_CHAINMAIL_sR4zT_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CHAINMAIL_nE2dG_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CHAINMAIL_mC6xV_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_PLATE_hU9gT_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_PLATE_qM5zE_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_PLATE_yE6xJ_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_PLATE_bT2dK_Value);
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