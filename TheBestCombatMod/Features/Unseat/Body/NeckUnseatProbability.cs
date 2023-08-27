// Code written by Gabriel Mailhot, 26/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class NeckUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike)
      {
         var option = Runtime.Get.UnseatByBlowOptionsReader;
         switch (typeOfDamage)
         {
            case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_CUT_SWINGING_OJ42D_Value);
            case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_CUT_THRUSTING_JDsUb_Value);
            case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_PIERCE_SWINGING_16Tqb_Value);
            case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_PIERCE_THRUSTING_PwjyT_Value);
            case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_BLUNT_SWINGING_Z19yv_Value);
            case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.NECK_BLUNT_THRUSTING_yZEV1_Value);
         }

         return 0;
      }
   }
}