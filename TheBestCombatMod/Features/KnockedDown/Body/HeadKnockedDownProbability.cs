// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown.Body
{
   public class HeadKnockedDownProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (KnockedDownOptionReader) optionReader;

         var result = typeOfDamage switch
         {
            DamageTypes.Cut when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(OQ2xO)"),
            DamageTypes.Cut when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(YcI0n)"),
            DamageTypes.Pierce when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(6pmqy)"),
            DamageTypes.Pierce when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(B1pFn)"),
            DamageTypes.Blunt when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(cVrSS)"),
            DamageTypes.Blunt when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(fe45p)"),
            _ => 0
         };

         return result;
      }
   }
}