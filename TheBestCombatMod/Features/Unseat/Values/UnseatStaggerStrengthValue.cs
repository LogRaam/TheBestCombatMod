// Code written by Gabriel Mailhot, 12/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Values
{
   public class StaggerStrengthValue : IAlphaValueConverter
   {
      public StaggerStrengthValue(in string[] loadedOptions)
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
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         Formidable = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Stagger_Strength_FORMIDABLE_VCMCx_Value);
         Low = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Stagger_Strength_LOW_iDpZg_Value);
         Minimal = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Stagger_Strength_MINIMAL_l4VjY_Vlaue);
         Moderate = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Stagger_Strength_MODERATE_g9CEb_Value);
         Strong = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Stagger_Strength_STRONG_Ptkiw_Value);
         None = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Stagger_Strength_NONE_wAKKZ_Value);
      }
   }
}