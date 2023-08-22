// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class Dagger : IWeaponType
   {
      public readonly DamageTypes DamageType;

      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;


      public Dagger(in StrikeType strikeType,
                    in DamageTypes damageType,
                    in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
      }

      public int GetResistanceBonus(in string[] loadedOptions)
      {
         var weaponForce = Runtime.WeaponStaggerForceValue.Dagger;

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
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_SWING_CUT_AGAINST_CLOTH_J8s2F_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_SWING_BLUNT_AGAINST_CLOTH_iM0qR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_THRUST_PIERCE_AGAINST_CLOTH_3HkLg_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_THRUST_BLUNT_AGAINST_CLOTH_hN7Ye_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_SWING_CUT_AGAINST_LEATHER_bD1mK_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_SWING_BLUNT_AGAINST_LEATHER_yA2wC_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_THRUST_PIERCE_AGAINST_LEATHER_9sT4p_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_THRUST_BLUNT_AGAINST_LEATHER_fR6jP_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_SWING_CUT_AGAINST_CHAINMAIL_tY3rN_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_SWING_BLUNT_AGAINST_CHAINMAIL_zI7qM_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_THRUST_PIERCE_AGAINST_CHAINMAIL_cG5vL_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_THRUST_BLUNT_AGAINST_CHAINMAIL_xU9eP_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_SWING_CUT_AGAINST_PLATE_lO6wE_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_SWING_BLUNT_AGAINST_PLATE_qB4fS_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_THRUST_PIERCE_AGAINST_PLATE_vX2jD_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.DAGGER_THRUST_BLUNT_AGAINST_PLATE_nZ8uR_Value);
            }
         }

         return weaponForce;
      }
   }
}