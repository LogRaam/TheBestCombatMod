// Code written by Gabriel Mailhot, 27/08/2023.

namespace TheBestCombatMod.Concept
{
   internal interface KnockedDownConfig : Configuration
   {
      int GetKnockdownAlphaValueFor(in string[] loadedOptions, string valueTag);
   }
}