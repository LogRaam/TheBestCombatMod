// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Common
{
   public class WeaponStaggerForceValue
   {
      public int None = 0;

      public WeaponStaggerForceValue(in string[] loadedOptions)
      {
         Update(loadedOptions);
      }

      public int Dagger { get; set; }
      public int Javelin { get; set; }
      public int Mace { get; set; }
      public int OneHandedAxe { get; set; }
      public int OneHandedPolearm { get; set; }
      public int OneHandedSword { get; set; }
      public int Pick { get; set; }
      public int Stone { get; set; }
      public int ThrowingAxe { get; set; }
      public int ThrowingKnife { get; set; }
      public int TwoHandedAxe { get; set; }
      public int TwoHandedMace { get; set; }
      public int TwoHandedPolearm { get; set; }
      public int TwoHandedSword { get; set; }

      public void Update(in string[] loadedOptions)
      {
         var loader = new ConfigLoader();
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         Dagger = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_Dagger_n1XdZ_Value);
         Javelin = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_Javelin_Xsa8Z_Value);
         Mace = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_Mace_gFe0e_Value);
         OneHandedAxe = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_OneHandedAxe_4DlEy_Value);
         OneHandedPolearm = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_OneHandedPolearm_7N5Ag_Value);
         OneHandedSword = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_OneHandedSword_w5XQZ_Value);
         Pick = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_Pick_vtQof_Value);
         Stone = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_Stone_q0Ak2_Value);
         ThrowingAxe = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_ThrowingAxe_GuSl7_Value);
         ThrowingKnife = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_ThrowingKnife_5hKU8_Value);
         TwoHandedAxe = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_TwoHandedAxe_nA05d_Value);
         TwoHandedMace = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_TwoHandedMace_E78By_Value);
         TwoHandedPolearm = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_TwoHandedPolearm_2SCK0_Value);
         TwoHandedSword = option.GetIntegerValueFor(loadedOptions, option.UnseatValueTags.Base_Stagger_Force_TwoHandedSword_cU7uE_Value);
      }
   }
}