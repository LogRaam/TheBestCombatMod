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


      public Javelin(in StrikeType strikeType,
                     in DamageTypes damageType,
                     in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
      }

      public int GetResistanceBonus(in string[] loadedOptions)
      {
         var weaponForce = Runtime.WeaponStaggerForceValue.Javelin;

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
               if (DamageType == DamageTypes.Cut)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CLOTH_rN5uX_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CLOTH_tA1vZ_Value);
               }
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_mC9dH_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_kY3gW_Value);
               }
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather && StrikeType == StrikeType.Swing)
         {
            if (DamageType == DamageTypes.Cut)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_LEATHER_iK6xO_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_LEATHER_yM4aI_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather && StrikeType == StrikeType.Thrust)
         {
            if (DamageType == DamageTypes.Pierce)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_LEATHER_pE8bQ_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_LEATHER_sU7nJ_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail && StrikeType == StrikeType.Swing)
         {
            if (DamageType == DamageTypes.Cut)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CHAINMAIL_nB7eU_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CHAINMAIL_pA3vR_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail && StrikeType == StrikeType.Thrust)
         {
            if (DamageType == DamageTypes.Pierce)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CHAINMAIL_xF9cV_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CHAINMAIL_zD5tL_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate && StrikeType == StrikeType.Swing)
         {
            if (DamageType == DamageTypes.Cut)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_PLATE_rC4dP_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_PLATE_tZ7uO_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate && StrikeType == StrikeType.Thrust)
         {
            if (DamageType == DamageTypes.Pierce)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_PLATE_oX1wM_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_PLATE_mY8bF_Value);
            }
         }

         return weaponForce;
      }
   }
}