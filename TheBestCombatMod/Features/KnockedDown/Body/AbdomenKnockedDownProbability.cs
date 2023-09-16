// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown.Body
{
   public class AbdomenKnockedDownProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (KnockedDownOptionReader) optionReader;

         var result = typeOfDamage switch
         {
            DamageTypes.Cut when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(QrXgU)"),
            DamageTypes.Cut when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(Vt6DF)"),
            DamageTypes.Pierce when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(EMsgc)"),
            DamageTypes.Pierce when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(HgUNm)"),
            DamageTypes.Blunt when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(D5Hdv)"),
            DamageTypes.Blunt when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(vNHgz)"),
            _ => 0
         };

         return result;
      }
   }
}