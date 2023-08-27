// Code written by Gabriel Mailhot, 27/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Body
{
   public class BodyHitUnseatProbability : BodyHitProbability
   {
      public int GetProbabilityFor(string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, BoneBodyPartType bodyPart)
      {
         return bodyPart switch
         {
            BoneBodyPartType.Head => Runtime.Get.HeadUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike),
            BoneBodyPartType.Neck => Runtime.Get.NeckUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike),
            BoneBodyPartType.Chest => Runtime.Get.ChestUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike),
            BoneBodyPartType.Abdomen => Runtime.Get.AbdomenUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike),
            BoneBodyPartType.ShoulderLeft or BoneBodyPartType.ShoulderRight => Runtime.Get.ShouldersUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike),
            BoneBodyPartType.ArmLeft or BoneBodyPartType.ArmRight => Runtime.Get.ArmsUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike),
            BoneBodyPartType.Legs => Runtime.Get.LegsUnseatProbability.WhenHit(loadedOptions, typeOfDamage, strike),
            _ => 0
         };
      }
   }
}