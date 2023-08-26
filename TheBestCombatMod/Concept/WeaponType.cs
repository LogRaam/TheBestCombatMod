// Code written by Gabriel Mailhot, 24/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface WeaponType
   {
      int GetResistanceBonus(in string[] loadedOptions);
   }
}