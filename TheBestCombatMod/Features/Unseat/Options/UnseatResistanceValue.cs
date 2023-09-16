// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Options
{
   public class UnseatImpactResistanceValue : ImpactResistanceOptions
   {
      private readonly string[] _loadedOptions;

      public UnseatImpactResistanceValue(in string[] loadedOptions)
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

         switch (t)
         {
            case "none": return None;
            case "low": return Low;
            case "moderate": return Moderate;
            case "strong": return Strong;
            case "formidable": return Formidable;
            default: return 0;
         }
      }

      public int ResistanceBonus(in string[] loadedOptions, int weaponForce, string valueTag)
      {
         var materialResistance = Runtime.Get.UnseatByBlowOptionsReader.GetAlphaValueFor(_loadedOptions, valueTag);
         weaponForce = (int) -(weaponForce * 1.15 - materialResistance);

         return weaponForce;
      }

      public void Update()
      {
         if (_loadedOptions.Length == 0) return;

         var loader = Runtime.Get.ConfigurationLoader;
         var option = Runtime.Get.UnseatByBlowOptionsReader;

         None = loader.RetrieveIntegerValueFrom(_loadedOptions, option.UnseatValues.Resistance_Strength_NONE_P5V27_Value);
         Formidable = loader.RetrieveIntegerValueFrom(_loadedOptions, option.UnseatValues.Resistance_Strength_FORMIDABLE_3l4Jw_Value);
         Low = loader.RetrieveIntegerValueFrom(_loadedOptions, option.UnseatValues.Resistance_Strength_LOW_sMtnq_Value);
         Moderate = loader.RetrieveIntegerValueFrom(_loadedOptions, option.UnseatValues.Resistance_Strength_MODERATE_gEghq_Value);
         Strong = loader.RetrieveIntegerValueFrom(_loadedOptions, option.UnseatValues.Resistance_Strength_STRONG_AX48F_Value);
      }
   }
}