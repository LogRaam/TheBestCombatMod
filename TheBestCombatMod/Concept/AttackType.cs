// Code written by Gabriel Mailhot, 26/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface AttackType
   {
      string Swing_Blunt { get; set; }
      string Swing_Cut { get; set; }
      string Thrust_Blunt { get; set; }
      string Thrust_Pierce { get; set; }
   }
}