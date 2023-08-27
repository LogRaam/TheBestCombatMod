// Code written by Gabriel Mailhot, 24/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown.Options
{
   public class KnockDownStrenghtValue : KnockDownStrengthOption
   {
      private readonly ConfigurationLoader _configLoader;
      private readonly KnockedDownValue _knockedDownValue;
      private readonly string[] _loadedOptions;

      public KnockDownStrenghtValue(UnseatConfigConstructorParams parameters)
      {
         _loadedOptions = parameters.LoadedOptions;
         _configLoader = parameters.ConfigLoader;
         _knockedDownValue = parameters.KnockedDownValue;
         Update();
      }

      public int Formidable { get; set; }
      public int Low { get; set; }
      public int Minimal { get; set; }
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
            case "minimal": return Minimal;
            case "moderate": return Moderate;
            case "strong": return Strong;
            case "formidable": return Formidable;
            default: return 0;
         }
      }

      public void Update()
      {
         if (_loadedOptions.Length == 0) return;

         Formidable = _configLoader.RetrieveIntegerValueFrom(_loadedOptions, _knockedDownValue.Knockdown_Strength_FORMIDABLE_y34fA_Value);
         Low = _configLoader.RetrieveIntegerValueFrom(_loadedOptions, _knockedDownValue.Knockdown_Strength_LOW_Sld4t_Value);
         Minimal = _configLoader.RetrieveIntegerValueFrom(_loadedOptions, _knockedDownValue.Knockdown_Strength_MINIMAL_37EAs_Vlaue);
         Moderate = _configLoader.RetrieveIntegerValueFrom(_loadedOptions, _knockedDownValue.Knockdown_Strength_MODERATE_azdWq_Value);
         Strong = _configLoader.RetrieveIntegerValueFrom(_loadedOptions, _knockedDownValue.Knockdown_Strength_STRONG_Jt2ES_Value);
         None = _configLoader.RetrieveIntegerValueFrom(_loadedOptions, _knockedDownValue.Knockdown_Strength_NONE_XBGV0_Value);
      }
   }


   public class UnseatConfigParams : UnseatConfigConstructorParams
   {
      public UnseatConfigParams(in string[] loadedOptions,
                                in ConfigurationLoader configLoader,
                                KnockedDownValue knockedDownValue)
      {
         ConfigLoader = configLoader;
         LoadedOptions = loadedOptions;
         KnockedDownValue = knockedDownValue;
      }

      public ConfigurationLoader ConfigLoader { get; set; }
      public KnockedDownValue KnockedDownValue { get; set; }
      public string[] LoadedOptions { get; set; }
   }


   public interface UnseatConfigConstructorParams
   {
      ConfigurationLoader ConfigLoader { get; set; }
      KnockedDownValue KnockedDownValue { get; set; }
      string[] LoadedOptions { get; set; }
   }
}