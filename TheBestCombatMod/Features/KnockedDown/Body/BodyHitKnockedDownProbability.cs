// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown.Body
{
   public class BodyHitKnockedDownProbability : BodyHitProbability
   {
      public int GetProbabilityFor(string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, BoneBodyPartType bodyPart, OptionReader optionReader)
      {
         var result = bodyPart switch
         {
            BoneBodyPartType.Head => Runtime.Get.HeadKnockedDownProbability.WhenHit(loadedOptions, typeOfDamage, strike, optionReader),
            BoneBodyPartType.Neck => Runtime.Get.NeckKnockedDownProbability.WhenHit(loadedOptions, typeOfDamage, strike, optionReader),
            BoneBodyPartType.Chest => Runtime.Get.ChestKnockedDownProbability.WhenHit(loadedOptions, typeOfDamage, strike, optionReader),
            BoneBodyPartType.Abdomen => Runtime.Get.AbdomenKnockedDownProbability.WhenHit(loadedOptions, typeOfDamage, strike, optionReader),
            BoneBodyPartType.ShoulderLeft or BoneBodyPartType.ShoulderRight => Runtime.Get.ShouldersKnockedDownProbability.WhenHit(loadedOptions, typeOfDamage, strike, optionReader),
            BoneBodyPartType.ArmLeft or BoneBodyPartType.ArmRight => Runtime.Get.ArmsKnockedDownProbability.WhenHit(loadedOptions, typeOfDamage, strike, optionReader),
            BoneBodyPartType.Legs => Runtime.Get.LegsKnockedDownProbability.WhenHit(loadedOptions, typeOfDamage, strike, optionReader),
            _ => 0
         };

         return result;
      }
   }
}