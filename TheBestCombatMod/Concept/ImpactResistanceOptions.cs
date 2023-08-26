// Code written by Gabriel Mailhot, 24/08/2023.

#region

using LogRaamConfiguration;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface ImpactResistanceOptions : AlphaValueConverter, ValuesUpdater, StrengthLevels
   {
      int ResistanceBonus(in string[] loadedOptions, int weaponForce, string valueTag);
   }
}