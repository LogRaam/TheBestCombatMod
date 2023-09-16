// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TheBestCombatMod.Features;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface WeaponType
   {
      int GetResistanceBonus(in string[] loadedOptions, Feature feature);
   }
}