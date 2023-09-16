// Code written by Gabriel Mailhot, 28/08/2023.

#region

using System;
using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class LegsUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (UnseatOptionReader) optionReader;

         var result = typeOfDamage switch
         {
            DamageTypes.Cut when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_CUT_SWINGING_xOKtK_Value),
            DamageTypes.Cut when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_CUT_THRUSTING_hEsET_Value),
            DamageTypes.Pierce when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_PIERCE_SWINGING_6DD8t_Value),
            DamageTypes.Pierce when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_PIERCE_THRUSTING_NblKm_Value),
            DamageTypes.Blunt when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_BLUNT_SWINGING_JTLxV_Value),
            DamageTypes.Blunt when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_BLUNT_THRUSTING_awuSL_Value),
            _ => 0
         };

         return result;
      }

      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike) => throw new NotImplementedException();
   }
}