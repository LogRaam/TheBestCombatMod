// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class ChestUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (UnseatOptionReader) optionReader;
         switch (typeOfDamage)
         {
            case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.CHEST_CUT_SWINGING_sQmx7_Value);
            case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.CHEST_CUT_THRUSTING_dNomI_Value);
            case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.CHEST_PIERCE_SWINGING_6ssat_Value);
            case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.CHEST_PIERCE_THRUSTING_ybixm_Value);
            case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.CHEST_BLUNT_SWINGING_Ip0TE_Value);
            case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.CHEST_BLUNT_THRUSTING_ktCEu_Value);
         }

         return 0;
      }
   }
}