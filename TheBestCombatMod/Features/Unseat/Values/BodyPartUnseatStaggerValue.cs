// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Values
{
   public class BodyPartUnseatStaggerValue : IAlphaValueConverter
   {
      public const int Unknown = 0;

      public BodyPartUnseatStaggerValue(in string[] loadedOptions)
      {
         Update(loadedOptions);
      }

      public int Abdomen { get; set; }
      public int Arms { get; set; }
      public int Chest { get; set; }
      public int Head { get; set; }
      public int Legs { get; set; }
      public int Neck { get; set; }
      public int Shoulders { get; set; }

      public int Convert(string textTag)
      {
         var t = textTag.ToLower();

         switch (t)
         {
            case "unknown": return Unknown;
            case "abdomen": return Abdomen;
            case "arms": return Arms;
            case "chest": return Chest;
            case "head": return Head;
            case "legs": return Legs;
            case "neck": return Neck;
            case "shoulders": return Shoulders;
            default: return 0;
         }
      }

      public void Update(in string[] loadedOptions)
      {
         var loader = new ConfigLoader();
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         Abdomen = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Strike_Sensitivity_For_Abdomen_iNG4j_Value);
         Arms = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Strike_Sensitivity_For_Arms_NP7Xe_Value);
         Chest = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Strike_Sensitivity_For_Chest_HuSFa_Value);
         Head = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Strike_Sensitivity_For_Head_rGcYE_Value);
         Legs = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Strike_Sensitivity_For_Legs_DQndk_Value);
         Neck = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Strike_Sensitivity_For_Neck_oMvdW_Value);
         Shoulders = loader.RetrieveIntegerValueFrom(loadedOptions, option.UnseatValueTags.Strike_Sensitivity_For_Shoulders_WU5Bv_Value);
      }
   }
}