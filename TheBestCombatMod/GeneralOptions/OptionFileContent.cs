// Code written by Gabriel Mailhot, 17/08/2023.

#region

using LogRaamConfiguration;

#endregion

namespace TheBestCombatMod.GeneralOptions
{
   public class OptionFileContent : IOptionFileContent
   {
      private readonly IConfigurationLoader _loader;
      private string[] _content;

      public OptionFileContent(IConfigurationLoader loader)
      {
         _loader = loader;
         _content = _loader.RetrieveConfigDetails(_loader.GetOptionFilePath());
      }

      public string[] GetContent()
      {
         return _content;
      }

      public bool Reload()
      {
         if (Runtime.FileInteraction.IsOptionFileUpdated()) return false;

         _content = _loader.RetrieveConfigDetails(_loader.GetOptionFilePath());

         return true;
      }

      public void SetContent(in string[] content)
      {
         _content = content;
      }
   }
}