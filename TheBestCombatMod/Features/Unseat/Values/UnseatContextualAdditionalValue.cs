﻿// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Values
{
   public class UnseatContextualAdditionalValue
   {
      public UnseatContextualAdditionalValue(in string[] loadedOptions)
      {
         Update(loadedOptions);
      }

      public int ATTACKER_IS_HEALTHIER { get; set; }
      public int ATTACKER_IS_HEAVIER { get; set; }
      public int ATTACKER_IS_STRONGER { get; set; }
      public float ATTACKER_IS_WOMAN { get; set; }
      public int ATTACKER_WEAPON_INERTIA { get; set; }
      public int BLOW_ISCRITICAL_BLUNT { get; set; }
      public int BLOW_ISCRITICAL_CUT { get; set; }
      public int BLOW_ISCRITICAL_PIERCE { get; set; }
      public int THRUST_TIP_HIT { get; set; }
      public int VICTIME_DIDNOT_RAISE_GUARD { get; set; }

      public void Update(in string[] loadedOptions)
      {
         var loader = new ConfigLoader();
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         ATTACKER_IS_HEALTHIER = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Attacker_Healthier_wK2Fb_Value);
         ATTACKER_IS_HEAVIER = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Attacker_Heavier_uiezF_Value);
         ATTACKER_IS_STRONGER = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Attacker_Stronger_W3JH2_Value);
         ATTACKER_IS_WOMAN = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Attacker_Is_Woman_aUufU_Value);
         ATTACKER_WEAPON_INERTIA = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Weapon_Inertia_aLp7H_Value);
         BLOW_ISCRITICAL_BLUNT = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Blow_Critical_BLUNT_TI8bQ_Vlaue);
         BLOW_ISCRITICAL_CUT = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Blow_Critical_CUT_d461x_Value);
         BLOW_ISCRITICAL_PIERCE = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Blow_Critical_PIERCE_WDaWG_Value);
         THRUST_TIP_HIT = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_Thrust_Tip_Hit_cGmzd_Value);
         VICTIME_DIDNOT_RAISE_GUARD = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Impact_Dismount_Chance_VictimDidNot_Raise_Guard_h8WXN_Value);
      }
   }
}