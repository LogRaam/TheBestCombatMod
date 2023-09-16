// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface BodyPart
   {
      int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader);
   }
}