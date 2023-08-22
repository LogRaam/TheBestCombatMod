// Code written by Gabriel Mailhot, 20/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Knocked.Values
{
   public class KnockDownStrenghtValue : IAlphaValueConverter
   {
      public KnockDownStrenghtValue(in string[] loadedOptions)
      {
         Update(loadedOptions);
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

      public void Update(in string[] loadedOptions)
      {
         var loader = new ConfigLoader();
         var option = new KnockedDownByBlowOptions(new OptionBase(), new KnockedDownActivationRefTag(), new KnockedDownValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         Formidable = loader.RetrieveIntegerValueFrom(loadedOptions, option.KnockedDownValueTags.Knockdown_Strength_FORMIDABLE_y34fA_Value);
         Low = loader.RetrieveIntegerValueFrom(loadedOptions, option.KnockedDownValueTags.Knockdown_Strength_LOW_Sld4t_Value);
         Minimal = loader.RetrieveIntegerValueFrom(loadedOptions, option.KnockedDownValueTags.Knockdown_Strength_MINIMAL_37EAs_Vlaue);
         Moderate = loader.RetrieveIntegerValueFrom(loadedOptions, option.KnockedDownValueTags.Knockdown_Strength_MODERATE_azdWq_Value);
         Strong = loader.RetrieveIntegerValueFrom(loadedOptions, option.KnockedDownValueTags.Knockdown_Strength_STRONG_Jt2ES_Value);
         None = loader.RetrieveIntegerValueFrom(loadedOptions, option.KnockedDownValueTags.Knockdown_Strength_NONE_XBGV0_Value);
      }
   }
}