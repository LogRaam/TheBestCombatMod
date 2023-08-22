// Code written by Gabriel Mailhot, 12/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Values
{
   public class ResistanceValue : IAlphaValueConverter
   {
      public ResistanceValue(in string[] loadedOptions)
      {
         Update(loadedOptions);
      }

      public int Formidable { get; set; }
      public int Low { get; set; }
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
         var materialResistance = new UnseatByBlowOptions(new OptionBase(this), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag()).GetAlphaValueFor(loadedOptions, valueTag);
         weaponForce = (int) -(weaponForce * 1.15 - materialResistance);

         return weaponForce;
      }

      public void Update(in string[] loadedOptions)
      {
         var loader = new ConfigLoader();
         var option = new UnseatByBlowOptions(new OptionBase(this), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         None = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Resistance_Strength_NONE_P5V27_Value);
         Formidable = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Resistance_Strength_FORMIDABLE_3l4Jw_Value);
         Low = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Resistance_Strength_LOW_sMtnq_Value);
         Moderate = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Resistance_Strength_MODERATE_gEghq_Value);
         Strong = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Resistance_Strength_STRONG_AX48F_Value);
      }
   }
}