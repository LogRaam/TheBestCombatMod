// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class TwoHandedMace : IWeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;


      public TwoHandedMace(in StrikeType strikeType,
                           in DamageTypes damageType,
                           in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
      }

      public int GetResistanceBonus(in string[] loadedOptions)
      {
         var weaponForce = Runtime.WeaponStaggerForceValue.TwoHandedMace;

         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());


         if (MaterialType == ArmorComponent.ArmorMaterialTypes.None)
         {
            weaponForce = (int) (weaponForce * 1.5);
            MaterialType = ArmorComponent.ArmorMaterialTypes.Cloth;
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Cloth)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_SWING_CUT_AGAINST_CLOTH_qH8xG_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CLOTH_gU5zV_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CLOTH_zD9xT_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CLOTH_bN4zA_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_SWING_CUT_AGAINST_LEATHER_mH7gA_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_LEATHER_kT3zR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_LEATHER_wT4zE_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_LEATHER_zE9xL_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL_lR5zH_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL_mJ2hU_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL_aG6xI_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL_jG8xT_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_SWING_CUT_AGAINST_PLATE_jC9xR_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE_pS5zE_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE_bH4zG_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE_dU6xV_Value);
            }
         }

         return weaponForce;
      }
   }
}