// Code written by Gabriel Mailhot, 28/08/2023.

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

         Dagger = _options.GetIntegerValueFor(_loadedOptions, "(n1XdZ)");
         Javelin = _options.GetIntegerValueFor(_loadedOptions, "(Xsa8Z)");
         Mace = _options.GetIntegerValueFor(_loadedOptions, "(gFe0e)");
         OneHandedAxe = _options.GetIntegerValueFor(_loadedOptions, "(4DlEy)");
         OneHandedPolearm = _options.GetIntegerValueFor(_loadedOptions, "(7N5Ag)");
         OneHandedSword = _options.GetIntegerValueFor(_loadedOptions, "(w5XQZ)");
         Pick = _options.GetIntegerValueFor(_loadedOptions, "(vtQof)");
         Stone = _options.GetIntegerValueFor(_loadedOptions, "(q0Ak2)");
         ThrowingAxe = _options.GetIntegerValueFor(_loadedOptions, "(GuSl7)");
         ThrowingKnife = _options.GetIntegerValueFor(_loadedOptions, "(5hKU8)");
         TwoHandedAxe = _options.GetIntegerValueFor(_loadedOptions, "(nA05d)");
         TwoHandedMace = _options.GetIntegerValueFor(_loadedOptions, "(E78By)");
         TwoHandedPolearm = _options.GetIntegerValueFor(_loadedOptions, "(2SCK0)");
         TwoHandedSword = _options.GetIntegerValueFor(_loadedOptions, "(cU7uE)");
      }
   }


   public class WeaponStaggerForceValue_params : WeaponStaggerForceValueConstructorParams
   {
      public WeaponStaggerForceValue_params(in string[] loadedOptions, in UnseatOptionReader reader)
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