// Code written by Gabriel Mailhot, 24/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown
{
   public class KnockedDownByBlowConfiguration
   {
      public readonly GlobalActivationValue GlobalUnseatActivationRefTagValue;
      public readonly GlobalValueRefTag GlobalValueRefTag;
      public readonly KnockedDownActivationValue KnockedDownUnseatActivationTagValue;
      public readonly KnockedDownValue KnockedDownUnseatValueTags;
      private readonly OptionReader _defaultOptionReader;

      public KnockedDownByBlowConfiguration(OptionReader defaultOptionReader, KnockedDownActivationValue knockedDownUnseatActiveTagValue, KnockedDownValue knockedDownUnseatValueTag, GlobalActivationValue globalActivTagValue, GlobalValueRefTag globalValTag)
      {
         _defaultOptionReader = defaultOptionReader;
         GlobalUnseatActivationRefTagValue = globalActivTagValue;
         GlobalValueRefTag = globalValTag;
         KnockedDownUnseatActivationTagValue = knockedDownUnseatActiveTagValue;
         KnockedDownUnseatValueTags = knockedDownUnseatValueTag;
      }

      public float GetFloatValueFor(in string[] content, string valueTag) => Runtime.Get.ConfigurationLoader.RetrieveFloatValueFrom(content, valueTag);

      public int GetIntegerValueFor(in string[] content, string valueTag) => Runtime.Get.ConfigurationLoader.RetrieveIntegerValueFrom(content, valueTag);

      public int GetKnockdownAlphaValueFor(in string[] loadedOptions, string valueTag)
      {
         var s = Runtime.Get.ConfigurationLoader.RetrieveAlphaValueFrom(loadedOptions, valueTag).ToLower();
         var result = Runtime.KnockDownStrenghtValue.Convert(s);

         return result;
      }

      public int GetResistanceAlphaValueFor(in string[] content, string valueTag)
      {
         var s = Runtime.Get.ConfigurationLoader.RetrieveAlphaValueFrom(content, valueTag).ToLower();
         var result = Runtime.UnseatImpactResistance.Convert(s);

         return result;
      }

      public int GetStaggerAlphaValueFor(in string[] content, string valueTag)
      {
         var s = Runtime.Get.ConfigurationLoader.RetrieveAlphaValueFrom(content, valueTag).ToLower();
         var result = Runtime.StaggerStrength.Convert(s);

         return result;
      }


      public bool IsOptionActivated(in string[] content, string activeTag) => RetrieveAnswerFor(content, activeTag);

      #region private

      private bool RetrieveAnswerFor(in string[] content, string tag) => Runtime.Get.ConfigurationLoader.IsLineExistInStruct(content, tag);

      #endregion
   }
}