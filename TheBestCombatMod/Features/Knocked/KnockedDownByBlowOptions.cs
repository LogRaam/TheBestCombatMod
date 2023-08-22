// Code written by Gabriel Mailhot, 20/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Features.Knocked.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Knocked
{
   public class KnockedDownByBlowOptions
   {
      public readonly ActivationRefTag GlobalActivationRefTag;
      public readonly ValueRefTag GlobalValueRefTag;
      public readonly KnockedDownActivationRefTag KnockedDownActivationTag;
      public readonly KnockedDownValueRefTag KnockedDownValueTags;
      private readonly OptionBase OptionBase;

      public KnockedDownByBlowOptions(OptionBase optionBase, KnockedDownActivationRefTag knockedDownActiveTag, KnockedDownValueRefTag knockedDownValueTag, ActivationRefTag globalActivTag, ValueRefTag globalValTag)
      {
         OptionBase = optionBase;
         GlobalActivationRefTag = globalActivTag;
         GlobalValueRefTag = globalValTag;
         KnockedDownActivationTag = knockedDownActiveTag;
         KnockedDownValueTags = knockedDownValueTag;
      }

      public float GetFloatValueFor(in string[] content, string valueTag)
      {
         return new ConfigLoader().RetrieveFloatValueFrom(content, valueTag);
      }

      public int GetIntegerValueFor(in string[] content, string valueTag)
      {
         return new ConfigLoader().RetrieveIntegerValueFrom(content, valueTag);
      }

      public int GetKnockdownAlphaValueFor(in string[] loadedOptions, string valueTag)
      {
         var s = new ConfigLoader().RetrieveAlphaValueFrom(loadedOptions, valueTag).ToLower();
         var result = Runtime.KnockDownStrenghtValue.Convert(s);

         return result;
      }

      public int GetResistanceAlphaValueFor(in string[] content, string valueTag)
      {
         var s = new ConfigLoader().RetrieveAlphaValueFrom(content, valueTag).ToLower();
         var result = Runtime.Resistance.Convert(s);

         return result;
      }

      public int GetStaggerAlphaValueFor(in string[] content, string valueTag)
      {
         var s = new ConfigLoader().RetrieveAlphaValueFrom(content, valueTag).ToLower();
         var result = Runtime.StaggerStrength.Convert(s);

         return result;
      }


      public bool IsOptionActivated(in string[] content, string activeTag)
      {
         return RetrieveAnswerFor(content, activeTag);
      }

      #region private

      private bool RetrieveAnswerFor(in string[] content, string tag)
      {
         return new ConfigLoader().IsLineExistInStruct(content, tag);
      }

      #endregion
   }
}