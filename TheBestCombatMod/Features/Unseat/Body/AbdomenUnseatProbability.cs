// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class AbdomenUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (UnseatOptionReader) optionReader;

         var result = typeOfDamage switch
         {
            DamageTypes.Cut when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_CUT_SWINGING_tRqGA_Value),
            DamageTypes.Cut when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_CUT_THRUSTING_eypTb_Value),
            DamageTypes.Pierce when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_PIERCE_SWINGING_VTO6S_Value),
            DamageTypes.Pierce when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_PIERCE_THRUSTING_suxMY_Value),
            DamageTypes.Blunt when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_BLUNT_SWINGING_v2v6T_Value),
            DamageTypes.Blunt when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_BLUNT_THRUSTING_6gLsx_Value),
            _ => 0
         };

         return result;
      }
   }
}