// Code written by Gabriel Mailhot, 26/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class LegsUnseatProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike)
      {
         var option = Runtime.Get.UnseatOptionReader;
         switch (typeOfDamage)
         {
            case DamageTypes.Cut when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_CUT_SWINGING_xOKtK_Value);
            case DamageTypes.Cut when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_CUT_THRUSTING_hEsET_Value);
            case DamageTypes.Pierce when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_PIERCE_SWINGING_6DD8t_Value);
            case DamageTypes.Pierce when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_PIERCE_THRUSTING_NblKm_Value);
            case DamageTypes.Blunt when strike == StrikeType.Swing: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_BLUNT_SWINGING_JTLxV_Value);
            case DamageTypes.Blunt when strike == StrikeType.Thrust: return option.GetAlphaValueFor(loadedOptions, option.UnseatValues.LEGS_BLUNT_THRUSTING_awuSL_Value);
         }

         return 0;
      }
   }
}