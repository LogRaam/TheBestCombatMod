// Code written by Gabriel Mailhot, 27/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface BodyHitProbability
   {
      int GetProbabilityFor(string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, BoneBodyPartType bodyPart);
   }
}