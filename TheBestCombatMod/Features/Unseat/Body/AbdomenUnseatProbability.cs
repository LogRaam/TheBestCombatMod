// Code written by Gabriel Mailhot, 26/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class AbdomenUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;
         switch (typeOfDamage)
         {
            case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_CUT_SWINGING_tRqGA_Value);
            case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_CUT_THRUSTING_eypTb_Value);
            case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_PIERCE_SWINGING_VTO6S_Value);
            case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_PIERCE_THRUSTING_suxMY_Value);
            case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_BLUNT_SWINGING_v2v6T_Value);
            case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.ABDOMEN_BLUNT_THRUSTING_6gLsx_Value);
         }

         return 0;
      }
   }
}