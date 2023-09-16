// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface UnseatOptionReader : OptionReader
   {
      OptionReader DefaultOptionReader { get; }
      GlobalValueRefTag GlobalValues { get; }
      GlobalActivationValue GolbalActivationValues { get; }
      UnseatActivationValue UnseatActivationValues { get; }
      UnseatValue UnseatValues { get; }
      int GetAlphaValueFor(in string[] loadedOptions, string unseatValuesAbdomenCutSwingingTRqGaValue);
      int GetIntegerValueFor(in string[] LoadedOptions, DamageTypes damageType);
   }
}