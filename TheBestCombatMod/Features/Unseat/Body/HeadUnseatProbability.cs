// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class HeadUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (UnseatOptionReader) optionReader;

         var result = typeOfDamage switch
         {
            DamageTypes.Cut when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_CUT_SWINGING_05zN2_Value),
            DamageTypes.Cut when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_CUT_THRUSTING_IgazM_Value),
            DamageTypes.Pierce when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_PIERCE_SWINGING_JMWpz_Value),
            DamageTypes.Pierce when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_PIERCE_THRUSTING_pMa5J_Value),
            DamageTypes.Blunt when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_BLUNT_SWINGING_8VPtS_Value),
            DamageTypes.Blunt when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_BLUNT_THRUSTING_UzQhf_Value),
            _ => 0
         };

         return result;
      }
   }
}