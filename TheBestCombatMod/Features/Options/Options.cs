// Code written by Gabriel Mailhot, 24/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Options
{
   public class Options : OptionFileContent
   {
      private readonly ConfigurationLoader _loader;
      private string[] _content;

      public Options(ConfigurationLoader loader)
      {
         _loader = loader;
         _content = _loader.RetrieveConfigDetails(_loader.GetOptionFilePath());
      }

      public string[] GetContent() => _content;

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