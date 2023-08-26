// Code written by Gabriel Mailhot, 24/08/2023.

namespace TheBestCombatMod.Concept
{
   internal interface WeaponType
   {
      int GetResistanceBonus(in string[] loadedOptions);
   }
}