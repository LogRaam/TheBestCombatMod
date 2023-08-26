// Code written by Gabriel Mailhot, 24/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface WeaponType
   {
      int ChainmailResistanceBonus();
      int ChainmailSwingResistance();
      int ChainmailThrustResistance();
      int ClothResistanceBonus();
      int ClothSwingResistance();
      int ClothThrustResistance();
      int GetResistanceBonus(in string[] loadedOptions);
      int LeatherResistanceBonus();
      int LeatherSwingResistance();
      int LeatherThrustResistance();
      int PlateResistanceBonus();
      int PlateSwingResistance();
      int PlateThrustResistance();
   }
}