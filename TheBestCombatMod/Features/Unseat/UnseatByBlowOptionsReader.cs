// Code written by Gabriel Mailhot, 28/08/2023.

#region

using System;
using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;
using TheBestCombatMod.Features.Unseat.Options;

#endregion

namespace TheBestCombatMod.Features.Unseat
{
   public class UnseatByBlowOptionsReader : UnseatOptionReader
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


      public int GetAlphaValueFor(in string[] content, string valueTag)
      {
         var s = new ConfigLoader().RetrieveAlphaValueFrom(content, valueTag).ToLower();

         var result = new UnseatImpactResistanceValue(content).Convert(s);

         return result;
      }

      public int GetAlphaValueFor(in string[] loadedOptions, DamageTypes damageType) => throw new NotImplementedException();

      public float GetFloatValueFor(in string[] content, string valueTag) => DefaultOptionReader.GetFloatValueFor(content, valueTag);

      public int GetIntegerValueFor(in string[] content, string valueTag) => DefaultOptionReader.GetIntegerValueFor(content, valueTag);

      public int GetIntegerValueFor(in string[] LoadedOptions, DamageTypes damageType)
      {
         return damageType switch
         {
            DamageTypes.Invalid => 0,
            DamageTypes.Blunt => GetIntegerValueFor(LoadedOptions, UnseatValues.Impact_Dismount_Chance_Blow_Critical_BLUNT_TI8bQ_Vlaue),
            DamageTypes.Cut => GetIntegerValueFor(LoadedOptions, UnseatValues.Impact_Dismount_Chance_Blow_Critical_CUT_d461x_Value),
            DamageTypes.Pierce => GetIntegerValueFor(LoadedOptions, UnseatValues.Impact_Dismount_Chance_Blow_Critical_PIERCE_WDaWG_Value),
            _ => 0
         };
      }

      public bool IsOptionActivated(in string[] content, string activeTag) => DefaultOptionReader.IsOptionActivated(content, activeTag);

      public bool RetrieveAnswerFor(in string[] content, string tag) => DefaultOptionReader.RetrieveAnswerFor(content, tag);
   }
}