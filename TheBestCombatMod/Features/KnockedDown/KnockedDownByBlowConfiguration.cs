// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown
{
   public class KnockedDownByBlowConfiguration : Configuration
   {
      public KnockedDownByBlowConfiguration(KnockedDownByBlowConfigurationConstructorParams parameters)
      {
         //DefaultOptionsReader = parameters.DefaultOptionReader;
         GlobalUnseatActivationRefTag = parameters.GlobalActivTagValue;
         GlobalUnseatValueRefTag = parameters.GlobalValTag;
         KnockedDownActiveTagValue = parameters.KnockedDownUnseatActiveTagValue;
         KnockedDownValueTags = parameters.KnockedDownUnseatValueTag;
         Loader = parameters.ConfigurationLoader;
         UnseatImpactResistance = parameters.ImpactResistanceOptions;
         StaggerStrength = parameters.StaggerStrengthOptions;
         KnockDownStrengthOption = parameters.KnockDownStrengthOption;
      }

      //public OptionReader DefaultOptionsReader { get; set; }
      public GlobalActivationValue GlobalUnseatActivationRefTag { get; set; }
      public GlobalValueRefTag GlobalUnseatValueRefTag { get; set; }
      public KnockDownStrengthOption KnockDownStrengthOption { get; set; }
      public KnockedDownActivationValue KnockedDownActiveTagValue { get; set; }
      public KnockedDownValue KnockedDownValueTags { get; set; }
      public ConfigurationLoader Loader { get; set; }
      public StaggerStrengthOptions StaggerStrength { get; set; }
      public ImpactResistanceOptions UnseatImpactResistance { get; set; }


      public float GetFloatValueFor(in string[] loadedOptions, string valueTag) => Loader.RetrieveFloatValueFrom(loadedOptions, valueTag);

      public int GetIntegerValueFor(in string[] loadedOptions, string valueTag) => Loader.RetrieveIntegerValueFrom(loadedOptions, valueTag);

      public int GetKnockdownAlphaValueFor(in string[] loadedOptions, string valueTag)
      {
         var s = Loader.RetrieveAlphaValueFrom(loadedOptions, valueTag).ToLower();
         var result = KnockDownStrengthOption.Convert(s);

         return result;
      }

      public int GetResistanceAlphaValueFor(in string[] loadedOptions, string valueTag)
      {
         var s = Loader.RetrieveAlphaValueFrom(loadedOptions, valueTag).ToLower();
         var result = UnseatImpactResistance.Convert(s);

         return result;
      }

      public int GetStaggerAlphaValueFor(in string[] loadedOptions, string valueTag)
      {
         var s = Loader.RetrieveAlphaValueFrom(loadedOptions, valueTag).ToLower();
         var result = StaggerStrength.Convert(s);

         return result;
      }


      public bool IsOptionActivated(in string[] loadedOptions, string activeTag) => RetrieveAnswerFor(loadedOptions, activeTag);

      public bool RetrieveAnswerFor(in string[] loadedOptions, string tag) => Runtime.Get.ConfigurationLoader.IsLineExistInStruct(loadedOptions, tag);
   }


   public class KnockedDownByBlowConfiguration_params : KnockedDownByBlowConfigurationConstructorParams
   {
      public KnockedDownByBlowConfiguration_params( /*OptionReader defaultOptionReader,*/
         KnockedDownActivationValue knockedDownUnseatActiveTagValue,
         KnockedDownValue knockedDownUnseatValueTag,
         GlobalActivationValue globalActivTagValue,
         GlobalValueRefTag globalValTag,
         ConfigurationLoader loader,
         ImpactResistanceOptions impactResistanceOptions,
         StaggerStrengthOptions staggerStrengthOptions,
         KnockDownStrengthOption knockDownStrengthOption)
      {
         //DefaultOptionReader = defaultOptionReader;
         GlobalActivTagValue = globalActivTagValue;
         GlobalValTag = globalValTag;
         KnockedDownUnseatActiveTagValue = knockedDownUnseatActiveTagValue;
         KnockedDownUnseatValueTag = knockedDownUnseatValueTag;
         ConfigurationLoader = loader;
         ImpactResistanceOptions = impactResistanceOptions;
         StaggerStrengthOptions = staggerStrengthOptions;
         KnockDownStrengthOption = knockDownStrengthOption;
      }

      public ConfigurationLoader ConfigurationLoader { get; set; }
      public OptionReader DefaultOptionReader { get; set; }
      public GlobalActivationValue GlobalActivTagValue { get; set; }
      public GlobalValueRefTag GlobalValTag { get; set; }
      public ImpactResistanceOptions ImpactResistanceOptions { get; set; }
      public KnockDownStrengthOption KnockDownStrengthOption { get; set; }
      public KnockedDownActivationValue KnockedDownUnseatActiveTagValue { get; set; }
      public KnockedDownValue KnockedDownUnseatValueTag { get; set; }
      public StaggerStrengthOptions StaggerStrengthOptions { get; set; }
   }

   public interface KnockedDownByBlowConfigurationConstructorParams
   {
      ConfigurationLoader ConfigurationLoader { get; set; }
      OptionReader DefaultOptionReader { get; set; }
      GlobalActivationValue GlobalActivTagValue { get; set; }
      GlobalValueRefTag GlobalValTag { get; set; }
      ImpactResistanceOptions ImpactResistanceOptions { get; set; }
      KnockDownStrengthOption KnockDownStrengthOption { get; set; }
      KnockedDownActivationValue KnockedDownUnseatActiveTagValue { get; set; }
      KnockedDownValue KnockedDownUnseatValueTag { get; set; }
      StaggerStrengthOptions StaggerStrengthOptions { get; set; }
   }
}