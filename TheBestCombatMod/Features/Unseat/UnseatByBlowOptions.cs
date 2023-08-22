// Code written by Gabriel Mailhot, 19/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat
{
   public class UnseatByBlowOptions : IOption
   {
      public readonly ActivationRefTag GlobalActivationRefTag;
      public readonly ValueRefTag GlobalValueRefTag;
      public readonly UnseatActivationRefTag UnseatActivationTag;
      public readonly UnseatValueRefTag UnseatValueTags;
      private readonly OptionBase OptionBase;


      public UnseatByBlowOptions(OptionBase optionBase, UnseatActivationRefTag activTag, UnseatValueRefTag valTag, ActivationRefTag globalActivTag, ValueRefTag globalValTag)
      {
         OptionBase = optionBase;
         GlobalActivationRefTag = globalActivTag;
         GlobalValueRefTag = globalValTag;
         UnseatActivationTag = activTag;
         UnseatValueTags = valTag;
      }

      public int GetAlphaValueFor(in string[] content, string valueTag)
      {
         return OptionBase.GetAlphaValueFor(content, valueTag);
      }

      public float GetFloatValueFor(in string[] content, string valueTag)
      {
         return OptionBase.GetFloatValueFor(content, valueTag);
      }

      public int GetIntegerValueFor(in string[] content, string valueTag)
      {
         return OptionBase.GetIntegerValueFor(content, valueTag);
      }

      public bool IsOptionActivated(in string[] content, string activeTag)
      {
         return OptionBase.IsOptionActivated(content, activeTag);
      }

      public bool RetrieveAnswerFor(in string[] content, string tag)
      {
         return OptionBase.RetrieveAnswerFor(content, tag);
      }
   }
}