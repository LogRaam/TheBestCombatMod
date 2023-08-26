// Code written by Gabriel Mailhot, 24/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface OptionFileContent
   {
      public string[] GetContent();
      public bool Reload();
      public void SetContent(in string[] content);
   }
}