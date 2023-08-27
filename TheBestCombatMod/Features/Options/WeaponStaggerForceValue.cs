// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Options
{
   public class WeaponStaggerForceValue : WeaponStaggerForce
   {
      private readonly string[] _loadedOptions;
      private readonly UnseatOptionReader _options;

      public WeaponStaggerForceValue(in WeaponStaggerForceValueConstructorParams parameters)
      {
         _loadedOptions = parameters.LoadedOptions;
         _options = parameters.UnseatOptionReader;
         Update();
      }

      public int Dagger { get; set; }
      public int Javelin { get; set; }
      public int Mace { get; set; }
      public int None => 0;
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

      public void Update()
      {
         if (_loadedOptions.Length == 0) return;

         Dagger = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_Dagger_n1XdZ_Value);
         Javelin = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_Javelin_Xsa8Z_Value);
         Mace = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_Mace_gFe0e_Value);
         OneHandedAxe = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_OneHandedAxe_4DlEy_Value);
         OneHandedPolearm = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_OneHandedPolearm_7N5Ag_Value);
         OneHandedSword = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_OneHandedSword_w5XQZ_Value);
         Pick = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_Pick_vtQof_Value);
         Stone = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_Stone_q0Ak2_Value);
         ThrowingAxe = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_ThrowingAxe_GuSl7_Value);
         ThrowingKnife = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_ThrowingKnife_5hKU8_Value);
         TwoHandedAxe = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_TwoHandedAxe_nA05d_Value);
         TwoHandedMace = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_TwoHandedMace_E78By_Value);
         TwoHandedPolearm = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_TwoHandedPolearm_2SCK0_Value);
         TwoHandedSword = _options.GetIntegerValueFor(_loadedOptions, _options.UnseatValues.Base_Stagger_Force_TwoHandedSword_cU7uE_Value);
      }
   }


   public class WeaponStaggerForceValueParams : WeaponStaggerForceValueConstructorParams
   {
      public WeaponStaggerForceValueParams(in string[] loadedOptions, in UnseatOptionReader reader)
      {
         LoadedOptions = loadedOptions;
         UnseatOptionReader = reader;
      }

      public string[] LoadedOptions { get; set; }
      public UnseatOptionReader UnseatOptionReader { get; set; }
   }


   public interface WeaponStaggerForceValueConstructorParams
   {
      string[] LoadedOptions { get; set; }
      UnseatOptionReader UnseatOptionReader { get; set; }
   }
}