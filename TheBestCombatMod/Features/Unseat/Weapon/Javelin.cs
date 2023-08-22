// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal class Javelin : IWeaponType
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

         var option = new UnseatByBlowOptions(new OptionBase(new ResistanceValue(loadedOptions)), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());


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
                  return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_SWING_CUT_AGAINST_CLOTH_rN5uX_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_SWING_BLUNT_AGAINST_CLOTH_tA1vZ_Value);
               }
            }

            if (StrikeType == StrikeType.Thrust)
            {
               if (DamageType == DamageTypes.Pierce)
               {
                  return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_mC9dH_Value);
               }

               if (DamageType == DamageTypes.Blunt)
               {
                  return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_kY3gW_Value);
               }
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather && StrikeType == StrikeType.Swing)
         {
            if (DamageType == DamageTypes.Cut)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_SWING_CUT_AGAINST_LEATHER_iK6xO_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_SWING_BLUNT_AGAINST_LEATHER_yM4aI_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Leather && StrikeType == StrikeType.Thrust)
         {
            if (DamageType == DamageTypes.Pierce)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_THRUST_PIERCE_AGAINST_LEATHER_pE8bQ_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_THRUST_BLUNT_AGAINST_LEATHER_sU7nJ_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail && StrikeType == StrikeType.Swing)
         {
            if (DamageType == DamageTypes.Cut)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_SWING_CUT_AGAINST_CHAINMAIL_nB7eU_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_SWING_BLUNT_AGAINST_CHAINMAIL_pA3vR_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Chainmail && StrikeType == StrikeType.Thrust)
         {
            if (DamageType == DamageTypes.Pierce)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_THRUST_PIERCE_AGAINST_CHAINMAIL_xF9cV_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_THRUST_BLUNT_AGAINST_CHAINMAIL_zD5tL_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate && StrikeType == StrikeType.Swing)
         {
            if (DamageType == DamageTypes.Cut)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_SWING_CUT_AGAINST_PLATE_rC4dP_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_SWING_BLUNT_AGAINST_PLATE_tZ7uO_Value);
            }
         }
         else if (MaterialType == ArmorComponent.ArmorMaterialTypes.Plate && StrikeType == StrikeType.Thrust)
         {
            if (DamageType == DamageTypes.Pierce)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_THRUST_PIERCE_AGAINST_PLATE_oX1wM_Value);
            }

            if (DamageType == DamageTypes.Blunt)
            {
               return Runtime.Resistance.ResistanceBonus(loadedOptions, weaponForce, option.UnseatValueTags.JAVELIN_THRUST_BLUNT_AGAINST_PLATE_mY8bF_Value);
            }
         }

         return weaponForce;
      }
   }
}