// Code written by Gabriel Mailhot, 28/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface Configuration
   {
      float GetFloatValueFor(in string[] loadedOptions, string valueTag);
      int GetIntegerValueFor(in string[] loadedOptions, string valueTag);
      int GetResistanceAlphaValueFor(in string[] loadedOptions, string valueTag);
      int GetStaggerAlphaValueFor(in string[] loadedOptions, string valueTag);
      bool IsOptionActivated(in string[] loadedOptions, string activeTag);
      bool RetrieveAnswerFor(in string[] loadedOptions, string tag);
   }
}