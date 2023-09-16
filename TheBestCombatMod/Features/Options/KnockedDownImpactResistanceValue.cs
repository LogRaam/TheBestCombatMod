// Code written by Gabriel Mailhot, 30/08/2023.

#region

using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Options
{
   internal class KnockedDownImpactResistanceValue : ImpactResistanceOptions
   {
      private readonly string[] _loadedOptions;

      public KnockedDownImpactResistanceValue(in string[] loadedOptions)
      {
         _loadedOptions = loadedOptions;
         Update();
      }

      public int Formidable { get; set; }
      public int Low { get; set; }

      public int Minimal
      {
         get => Low;
         set => Low = value;
      }

      public int Moderate { get; set; }
      public int None { get; set; }
      public int Strong { get; set; }

      public int Convert(string textTag)
      {
         var t = textTag.ToLower();

         var result = t switch
         {
            "none" => None,
            "low" => Low,
            "moderate" => Moderate,
            "strong" => Strong,
            "formidable" => Formidable,
            _ => 0
         };

         return result;
      }

      public int ResistanceBonus(in string[] loadedOptions, int weaponForce, string valueTag)
      {
         var materialResistance = Runtime.Get.KnockedDownByBlowOptionReader.GetAlphaValueFor(_loadedOptions, valueTag);
         weaponForce = (int) -(weaponForce * 1.15 - materialResistance);

         return weaponForce;
      }

      public void Update()
      {
         if (_loadedOptions.Length == 0) return;

         var loader = Runtime.Get.ConfigurationLoader;

         None = loader.RetrieveIntegerValueFrom(_loadedOptions, "(lZsvs)");
         Formidable = loader.RetrieveIntegerValueFrom(_loadedOptions, "(SJxXx)");
         Low = loader.RetrieveIntegerValueFrom(_loadedOptions, "(45Iww)");
         Moderate = loader.RetrieveIntegerValueFrom(_loadedOptions, "(SCFhO)");
         Strong = loader.RetrieveIntegerValueFrom(_loadedOptions, "(wJ35Y)");
      }
   }
}