// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class BodyHitUnseatProbability : BodyHitProbability
   {
      public int GetProbabilityFor(string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, BoneBodyPartType bodyPart, OptionReader optionReader)
      {
         var option = (UnseatOptionReader) optionReader;

         var result = bodyPart switch
         {
            BoneBodyPartType.Head => Runtime.Get.HeadUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike, option),
            BoneBodyPartType.Neck => Runtime.Get.NeckUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike, option),
            BoneBodyPartType.Chest => Runtime.Get.ChestUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike, option),
            BoneBodyPartType.Abdomen => Runtime.Get.AbdomenUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike, option),
            BoneBodyPartType.ShoulderLeft or BoneBodyPartType.ShoulderRight => Runtime.Get.ShouldersUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike, option),
            BoneBodyPartType.ArmLeft or BoneBodyPartType.ArmRight => Runtime.Get.ArmsUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike, option),
            BoneBodyPartType.Legs => Runtime.Get.LegsUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike, option),
            _ => 0
         };

         return result;
      }
   }
}