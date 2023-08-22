// Code written by Gabriel Mailhot, 13/08/2023.

#region

using LogRaamConfiguration;

#endregion

namespace TheBestCombatModTest
{
   internal class ConfigLoaderSubstitute : IConfigurationLoader
   {
      private readonly ConfigLoader loader = new ConfigLoader();

      public string GetOptionFilePath()
      {
         return @"C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\TheBestCombatMod\OPTIONS.txt";
      }

      public bool IsLineExistInStruct(in string[] options, string lineToFind)
      {
         return loader.IsLineExistInStruct(options, lineToFind);
      }

      public string RetrieveAlphaValueFrom(in string[] options, string lineToFind)
      {
         return loader.RetrieveAlphaValueFrom(options, lineToFind);
      }

      public string[] RetrieveConfigDetails(string filePath)
      {
         return loader.RetrieveConfigDetails(filePath);
      }

      public int RetrieveIntegerValueFrom(in string[] options, string lineToFind)
      {
         return loader.RetrieveIntegerValueFrom(options, lineToFind);
      }
   }
}