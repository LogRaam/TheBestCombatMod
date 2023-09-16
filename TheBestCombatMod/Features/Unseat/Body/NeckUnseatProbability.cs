// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class NeckUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (UnseatOptionReader) optionReader;

         var result = typeOfDamage switch
         {
            DamageTypes.Cut when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_CUT_SWINGING_OJ42D_Value),
            DamageTypes.Cut when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_CUT_THRUSTING_JDsUb_Value),
            DamageTypes.Pierce when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_PIERCE_SWINGING_16Tqb_Value),
            DamageTypes.Pierce when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_PIERCE_THRUSTING_PwjyT_Value),
            DamageTypes.Blunt when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_BLUNT_SWINGING_Z19yv_Value),
            DamageTypes.Blunt when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_BLUNT_THRUSTING_yZEV1_Value),
            _ => 0
         };

         return result;
      }
   }
}