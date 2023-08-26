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
      private readonly UnseatOptionReader _option;
      private int _weaponForce;

      public Javelin(in StrikeType strikeType,
                     in DamageTypes damageType,
                     in ArmorComponent.ArmorMaterialTypes materialType)
      {
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
            case ArmorComponent.ArmorMaterialTypes.Cloth: return ClothResistanceBonus(loadedOptions, StrikeType, DamageType);

            case ArmorComponent.ArmorMaterialTypes.Leather when StrikeType == StrikeType.Swing:
            {
               if (DamageType == DamageTypes.Cut)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_LEATHER_iK6xO_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_LEATHER_yM4aI_Value);
               }

               break;
            }
            case ArmorComponent.ArmorMaterialTypes.Leather when StrikeType == StrikeType.Thrust:
            {
               if (DamageType == DamageTypes.Pierce)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_LEATHER_pE8bQ_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_LEATHER_sU7nJ_Value);
               }

               break;
            }
            case ArmorComponent.ArmorMaterialTypes.Chainmail when StrikeType == StrikeType.Swing:
            {
               if (DamageType == DamageTypes.Cut)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CHAINMAIL_nB7eU_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CHAINMAIL_pA3vR_Value);
               }

               break;
            }
            case ArmorComponent.ArmorMaterialTypes.Chainmail when StrikeType == StrikeType.Thrust:
            {
               if (DamageType == DamageTypes.Pierce)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CHAINMAIL_xF9cV_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CHAINMAIL_zD5tL_Value);
               }

               break;
            }
            case ArmorComponent.ArmorMaterialTypes.Plate when StrikeType == StrikeType.Swing:
            {
               if (DamageType == DamageTypes.Cut)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_PLATE_rC4dP_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_PLATE_tZ7uO_Value);
               }

               break;
            }
            case ArmorComponent.ArmorMaterialTypes.Plate when StrikeType == StrikeType.Thrust:
            {
               if (DamageType == DamageTypes.Pierce)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_PLATE_oX1wM_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_PLATE_mY8bF_Value);
               }

               break;
            }
         }

         return _weaponForce;
      }

      #region private

      private int ClothResistanceBonus(in string[] loadedOptions, StrikeType strikeType, DamageTypes damageType)
      {
         switch (strikeType)
         {
            case StrikeType.Swing: return ClothSwingResistance(loadedOptions, damageType);
            case StrikeType.Thrust: return ClothThrustResistance(loadedOptions, damageType);
            default: return _weaponForce;
         }
      }

      private int ClothSwingResistance(in string[] loadedOptions, DamageTypes damageType)
      {
         switch (damageType)
         {
            case DamageTypes.Cut: return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CLOTH_rN5uX_Value);
            case DamageTypes.Blunt: return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CLOTH_tA1vZ_Value);
            default: return _weaponForce;
         }
      }

      private int ClothThrustResistance(in string[] loadedOptions, DamageTypes damageType)
      {
         switch (damageType)
         {
            case DamageTypes.Pierce: return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_mC9dH_Value);
            case DamageTypes.Blunt: return Runtime.UnseatImpactResistance.ResistanceBonus(loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_kY3gW_Value);
            default: return _weaponForce;
         }
      }

      #endregion
   }
}