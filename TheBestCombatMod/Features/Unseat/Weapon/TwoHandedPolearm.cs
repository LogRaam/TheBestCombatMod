// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class TwoHandedPolearm : WeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;


      public TwoHandedPolearm(in StrikeType strikeType,
                              in DamageTypes damageType,
                              in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
      }

      public int GetResistanceBonus(in string[] loadedOptions)
      {
         var weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedPolearm;

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
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_CLOTH_mD4zE_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_CLOTH_vH8xR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CLOTH_zH4zW_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CLOTH_yN7xL_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_LEATHER_bE7gA_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_LEATHER_yT3zH_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_LEATHER_cT9xI_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_LEATHER_gN4zG_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_CHAINMAIL_fR5zA_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_CHAINMAIL_lJ2hT_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CHAINMAIL_kG6xU_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CHAINMAIL_pG8xV_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_PLATE_rN9gR_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_PLATE_kD3zA_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_PLATE_eS4zG_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_PLATE_mH6xV_Value);
            }
         }

         return weaponForce;
      }
   }
}