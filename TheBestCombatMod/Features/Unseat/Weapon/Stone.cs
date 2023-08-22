// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class Stone : IWeaponType
   {
      public readonly DamageTypes DamageType;
      public readonly StrikeType StrikeType;
      public ArmorComponent.ArmorMaterialTypes MaterialType;


      public Stone(in StrikeType strikeType,
                   in DamageTypes damageType,
                   in ArmorComponent.ArmorMaterialTypes materialType)
      {
         StrikeType = strikeType;
         DamageType = damageType;
         MaterialType = materialType;
      }

      public int GetResistanceBonus(in string[] loadedOptions)
      {
         var weaponForce = Runtime.WeaponStaggerForceValue.Stone;

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
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_SWING_CUT_AGAINST_CLOTH_jN5uG_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_SWING_BLUNT_AGAINST_CLOTH_kE9xR_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_THRUST_PIERCE_AGAINST_CLOTH_fG4zW_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_THRUST_BLUNT_AGAINST_CLOTH_zC8xI_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_SWING_CUT_AGAINST_LEATHER_pC3xV_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_SWING_BLUNT_AGAINST_LEATHER_uN9gS_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_THRUST_PIERCE_AGAINST_LEATHER_qH4zP_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_THRUST_BLUNT_AGAINST_LEATHER_rY8nA_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_SWING_CUT_AGAINST_CHAINMAIL_aU9gR_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_SWING_BLUNT_AGAINST_CHAINMAIL_bQ5zE_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_THRUST_PIERCE_AGAINST_CHAINMAIL_dE7rQ_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_THRUST_BLUNT_AGAINST_CHAINMAIL_fM4zG_Value);
            }
         }

         if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate)
         {
            if (StrikeType == StrikeType.Swing)
            {
               if (DamageType == DamageTypes.Cut) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_SWING_CUT_AGAINST_PLATE_zC8xG_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_SWING_BLUNT_AGAINST_PLATE_kN4zI_Value);
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_THRUST_PIERCE_AGAINST_PLATE_tH7xQ_Value);
               if (DamageType == DamageTypes.Blunt) return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.STONE_THRUST_BLUNT_AGAINST_PLATE_nY3hA_Value);
            }
         }

         return weaponForce;
      }
   }
}