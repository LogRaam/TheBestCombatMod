// Code written by Gabriel Mailhot, 24/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat
{
   public class UnseatByBlowOptionsReader : DefaultOptionReader, UnseatOptionReader
   {
      public UnseatByBlowOptionsReader(OptionReader defaultOptionReader, UnseatActivationValue unseatActivationValues, UnseatValue unseatValues, GlobalActivationValue golbalActivationValues, GlobalValueRefTag globalValues)
      {
         DefaultOptionReader = defaultOptionReader;
         GolbalActivationValues = golbalActivationValues;
         GlobalValues = globalValues;
         UnseatActivationValues = unseatActivationValues;
         UnseatValues = unseatValues;
      }

      public OptionReader DefaultOptionReader { get; }
      public GlobalValueRefTag GlobalValues { get; }
      public GlobalActivationValue GolbalActivationValues { get; }
      public UnseatActivationValue UnseatActivationValues { get; }
      public UnseatValue UnseatValues { get; }

      public int GetAlphaValueFor(in string[] content, string valueTag) => DefaultOptionReader.GetAlphaValueFor(content, valueTag);

      public float GetFloatValueFor(in string[] content, string valueTag) => DefaultOptionReader.GetFloatValueFor(content, valueTag);

      public int GetIntegerValueFor(in string[] content, string valueTag) => DefaultOptionReader.GetIntegerValueFor(content, valueTag);

      public bool IsOptionActivated(in string[] content, string activeTag) => DefaultOptionReader.IsOptionActivated(content, activeTag);

      public bool RetrieveAnswerFor(in string[] content, string tag) => DefaultOptionReader.RetrieveAnswerFor(content, tag);
   }
}