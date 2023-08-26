// Code written by Gabriel Mailhot, 24/08/2023.

#region

using LogRaamConfiguration;

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
   }
}