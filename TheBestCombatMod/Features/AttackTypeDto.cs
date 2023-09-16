// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features
{
   public class AttackTypeDto : AttackType
   {
      public string Swing_Blunt { get; set; }
      public string Swing_Cut { get; set; }
      public string Thrust_Blunt { get; set; }
      public string Thrust_Pierce { get; set; }
   }
}