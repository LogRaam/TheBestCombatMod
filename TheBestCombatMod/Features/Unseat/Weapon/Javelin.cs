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

      public int ChainmailResistanceBonus()
      {
         return StrikeType switch
         {
            StrikeType.Swing => ChainmailSwingResistance(),
            StrikeType.Thrust => ChainmailThrustResistance(),
            _ => _weaponForce
         };
      }

      public int ChainmailSwingResistance()
      {
         return DamageType switch
         {
            DamageTypes.Cut => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CHAINMAIL_nB7eU_Value),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CHAINMAIL_pA3vR_Value),
            _ => _weaponForce
         };
      }

      public int ChainmailThrustResistance()
      {
         return DamageType switch
         {
            DamageTypes.Pierce => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CHAINMAIL_xF9cV_Value),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CHAINMAIL_zD5tL_Value),
            _ => _weaponForce
         };
      }

      public int ClothResistanceBonus()
      {
         return StrikeType switch
         {
            StrikeType.Swing => ClothSwingResistance(),
            StrikeType.Thrust => ClothThrustResistance(),
            _ => _weaponForce
         };
      }

      public int ClothSwingResistance()
      {
         return DamageType switch
         {
            DamageTypes.Cut => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CLOTH_rN5uX_Value),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CLOTH_tA1vZ_Value),
            _ => _weaponForce
         };
      }

      public int ClothThrustResistance()
      {
         return DamageType switch
         {
            DamageTypes.Pierce => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_mC9dH_Value),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_kY3gW_Value),
            _ => _weaponForce
         };
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
            case ArmorComponent.ArmorMaterialTypes.Cloth: return ClothResistanceBonus();
            case ArmorComponent.ArmorMaterialTypes.Leather: return LeatherResistanceBonus();
            case ArmorComponent.ArmorMaterialTypes.Chainmail: return ChainmailResistanceBonus();
            case ArmorComponent.ArmorMaterialTypes.Plate: return PlateResistanceBonus();
         }

         return _weaponForce;
      }

      public int LeatherResistanceBonus()
      {
         return StrikeType switch
         {
            StrikeType.Swing => LeatherSwingResistance(),
            StrikeType.Thrust => LeatherThrustResistance(),
            _ => _weaponForce
         };
      }

      public int LeatherSwingResistance()
      {
         return DamageType switch
         {
            DamageTypes.Cut => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_LEATHER_iK6xO_Value),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_LEATHER_yM4aI_Value),
            _ => _weaponForce
         };
      }

      public int LeatherThrustResistance()
      {
         return DamageType switch
         {
            DamageTypes.Pierce => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_LEATHER_pE8bQ_Value),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_LEATHER_sU7nJ_Value),
            _ => _weaponForce
         };
      }

      public int PlateResistanceBonus()
      {
         return StrikeType switch
         {
            StrikeType.Swing => PlateSwingResistance(),
            StrikeType.Thrust => PlateThrustResistance(),
            _ => _weaponForce
         };
      }

      public int PlateSwingResistance()
      {
         return DamageType switch
         {
            DamageTypes.Cut => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_CUT_AGAINST_PLATE_rC4dP_Value),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_PLATE_tZ7uO_Value),
            _ => _weaponForce
         };
      }

      public int PlateThrustResistance()
      {
         return DamageType switch
         {
            DamageTypes.Pierce => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_PLATE_oX1wM_Value),
            DamageTypes.Blunt => Runtime.UnseatImpactResistance.ResistanceBonus(_loadedOptions, _weaponForce, _option.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_PLATE_mY8bF_Value),
            _ => _weaponForce
         };
      }
   }
}