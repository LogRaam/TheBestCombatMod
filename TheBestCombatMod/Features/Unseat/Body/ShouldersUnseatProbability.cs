// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class ShouldersUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (UnseatOptionReader) optionReader;

         var result = typeOfDamage switch
         {
            DamageTypes.Cut when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.SHOULDERS_CUT_SWINGING_8yoXK_Value),
            DamageTypes.Cut when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.SHOULDERS_CUT_THRUSTING_2Y1ez_Value),
            DamageTypes.Pierce when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.SHOULDERS_PIERCE_SWINGING_HoWbh_Value),
            DamageTypes.Pierce when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.SHOULDERS_PIERCE_THRUSTING_UhpJO_Value),
            DamageTypes.Blunt when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.SHOULDERS_BLUNT_SWINGING_TplnH_Value),
            DamageTypes.Blunt when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.SHOULDERS_BLUNT_THRUSTING_gqk9L_Value),
            _ => 0
         };

         return result;
      }
   }
}