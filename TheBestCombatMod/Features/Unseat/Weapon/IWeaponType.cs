// Code written by Gabriel Mailhot, 10/08/2023.

#region

#endregion

namespace TheBestCombatMod.Features.Unseat.Weapon
{
   internal interface IWeaponType
   {
      int GetResistanceBonus(in string[] loadedOptions);
   }
}