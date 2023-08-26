// Code written by Gabriel Mailhot, 26/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class HeadUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike)
      {
         var option = Runtime.Get.UnseatOptionReader;
         switch (typeOfDamage)
         {
            case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_CUT_SWINGING_05zN2_Value);
            case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_CUT_THRUSTING_IgazM_Value);
            case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_PIERCE_SWINGING_JMWpz_Value);
            case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_PIERCE_THRUSTING_pMa5J_Value);
            case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_BLUNT_SWINGING_8VPtS_Value);
            case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.HEAD_BLUNT_THRUSTING_UzQhf_Value);
         }

         return 0;
      }
   }
}