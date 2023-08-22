// Code written by Gabriel Mailhot, 22/08/2023.

namespace TheBestCombatMod.GeneralOptions
{
   public interface IOptionFileContent
   {
      public string[] GetContent();
      public bool Reload();
      public void SetContent(in string[] content);
   }
}