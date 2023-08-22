// Code written by Gabriel Mailhot, 22/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Factories
{
   internal class TBCMFactory : ITBCMFactory
   {
      private IConfigurationLoader _configurationLoader;
      private IOptionFileContent _optionFileContent;

      private IConfigurationLoader configurationLoader => _configurationLoader ??= new ConfigLoader();
      private IOptionFileContent optionFileContent => _optionFileContent ??= new OptionFileContent(configurationLoader);

      public IConfigurationLoader ConfigurationLoader() => configurationLoader;

      public IOptionFileContent OptionFileContent() => optionFileContent;
   }
}