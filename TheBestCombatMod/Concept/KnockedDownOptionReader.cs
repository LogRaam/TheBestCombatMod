// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface KnockedDownOptionReader : OptionReader
   {
      OptionReader DefaultOptionReader { get; }
      GlobalValueRefTag GlobalValues { get; }
      GlobalActivationValue GolbalActivationValues { get; }
      KnockedDownActivationValue KnockedDownActivationValues { get; }
      KnockedDownValue KnockedDownValues { get; }
      int GetAlphaValueFor(in string[] loadedOptions, string valueTag);
      int GetIntegerValueFor(in string[] LoadedOptions, DamageTypes damageType);
   }
}