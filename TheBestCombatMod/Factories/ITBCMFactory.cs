// Code written by Gabriel Mailhot, 22/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Factories
{
   public interface ITBCMFactory
   {
      public IConfigurationLoader ConfigurationLoader();
      public IOptionFileContent OptionFileContent();
   }
}