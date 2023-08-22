// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class Pick : IWeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;


      public Pick(in StrikeType strikeType,
                  in DamageTypes damageType,
                  in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
      }

      public int GetResistanceBonus(in string[] loadedOptions)
      {
         var weaponForce = Runtime.WeaponStaggerForceValue.Pick;

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
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_SWING_CUT_AGAINST_CLOTH_nF5zV_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_SWING_BLUNT_AGAINST_CLOTH_yB7gR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_THRUST_PIERCE_AGAINST_CLOTH_xC9xT_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_THRUST_BLUNT_AGAINST_CLOTH_qM2dA_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_SWING_CUT_AGAINST_LEATHER_bJ2hT_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_SWING_BLUNT_AGAINST_LEATHER_sU5zH_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_THRUST_PIERCE_AGAINST_LEATHER_tR6zE_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_THRUST_BLUNT_AGAINST_LEATHER_pC9xV_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_SWING_CUT_AGAINST_CHAINMAIL_xU3gA_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_SWING_BLUNT_AGAINST_CHAINMAIL_kF9cR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_THRUST_PIERCE_AGAINST_CHAINMAIL_eB4mW_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_THRUST_BLUNT_AGAINST_CHAINMAIL_aN8xS_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_SWING_CUT_AGAINST_PLATE_zE3dX_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_SWING_BLUNT_AGAINST_PLATE_lA8hY_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_THRUST_PIERCE_AGAINST_PLATE_nC6zT_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.PICK_THRUST_BLUNT_AGAINST_PLATE_vB9fQ_Value);
            }
         }

         return weaponForce;
      }
   }
}