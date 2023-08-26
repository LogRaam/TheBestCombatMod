// Code written by Gabriel Mailhot, 23/08/2023.

#region

using LogRaamConfiguration;

#endregion

namespace TheBestCombatModTest.Substitutes
{
   internal class ConfigLoaderSubstitute : ConfigurationLoader
   {
      private readonly ConfigLoader loader = new ConfigLoader();

      public string GetOptionFilePath() => @"C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\TheBestCombatMod\OPTIONS.txt";

      public bool IsLineExistInStruct(in string[] options, string lineToFind) => loader.IsLineExistInStruct(options, lineToFind);

      public string RetrieveAlphaValueFrom(in string[] options, string lineToFind) => loader.RetrieveAlphaValueFrom(options, lineToFind);

      public string[] RetrieveConfigDetails(string filePath) => loader.RetrieveConfigDetails(filePath);
      public float RetrieveFloatValueFrom(in string[] options, string lineToFind) => loader.RetrieveFloatValueFrom(options, lineToFind);

      public int RetrieveIntegerValueFrom(in string[] options, string lineToFind) => loader.RetrieveIntegerValueFrom(options, lineToFind);
   }
}