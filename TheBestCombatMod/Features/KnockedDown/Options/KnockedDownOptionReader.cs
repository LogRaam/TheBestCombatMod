// Code written by Gabriel Mailhot, 28/08/2023.

#region

using System;
using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown.Options
{
   public class KnockedDownOptionsReader : KnockedDownOptionReader
   {
      public KnockedDownOptionsReader(OptionReader defaultOptionReader, KnockedDownActivationValue knockedDownActivationValue, KnockedDownValue knockedDownValue, GlobalActivationValue golbalActivationValues, GlobalValueRefTag globalValues)
      {
         DefaultOptionReader = defaultOptionReader;
         GolbalActivationValues = golbalActivationValues;
         GlobalValues = globalValues;
         KnockedDownActivationValues = knockedDownActivationValue;
         KnockedDownValues = knockedDownValue;
      }


      public OptionReader DefaultOptionReader { get; }
      public GlobalValueRefTag GlobalValues { get; }
      public GlobalActivationValue GolbalActivationValues { get; }
      public KnockedDownActivationValue KnockedDownActivationValues { get; }
      public KnockedDownValue KnockedDownValues { get; }

      //public int GetAlphaValueFor(in string[] content, string valueTag) => DefaultOptionReader.GetAlphaValueFor(content, valueTag);
      public int GetAlphaValueFor(in string[] content, string valueTag)
      {
         var s = new ConfigLoader().RetrieveAlphaValueFrom(content, valueTag).ToLower();

         // if (_converter == null) throw new ArgumentException("AlphaValueConverter is null.  Please ensure that the converter is injected into the DefaultOptionReader.");
         var result = new KnockDownStrenghtValue(new KnockedDownConfig_params(content, Runtime.Loader, new KnockedDownValuesRefTag())).Convert(s);

         return result;
      }

      public int GetAlphaValueFor(in string[] loadedOptions, DamageTypes damageType) => throw new NotImplementedException();

      public float GetFloatValueFor(in string[] content, string valueTag) => DefaultOptionReader.GetFloatValueFor(content, valueTag);
      public int GetIntegerValueFor(in string[] LoadedOptions, DamageTypes damageType) => DefaultOptionReader.GetAlphaValueFor(LoadedOptions, damageType);
      public int GetIntegerValueFor(in string[] content, string valueTag) => DefaultOptionReader.GetIntegerValueFor(content, valueTag);
      public bool IsOptionActivated(in string[] content, string activeTag) => DefaultOptionReader.IsOptionActivated(content, activeTag);
      public bool RetrieveAnswerFor(in string[] content, string tag) => DefaultOptionReader.RetrieveAnswerFor(content, tag);
   }
}