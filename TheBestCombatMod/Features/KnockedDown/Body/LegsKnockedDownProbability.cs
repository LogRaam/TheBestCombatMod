// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown.Body
{
   public class LegsKnockedDownProbability : BodyPart
   {
      public int WhenHit(in string[] loadedOptions, DamageTypes typeOfDamage, StrikeType strike, OptionReader optionReader)
      {
         var option = (KnockedDownOptionReader) optionReader;

         var result = typeOfDamage switch
         {
            DamageTypes.Cut when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(QwhPA)"),
            DamageTypes.Cut when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(Yi4SA)"),
            DamageTypes.Pierce when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(SyWWo)"),
            DamageTypes.Pierce when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(u26yW)"),
            DamageTypes.Blunt when strike == StrikeType.Swing => option.GetAlphaValueFor(loadedOptions, "(RiOF1)"),
            DamageTypes.Blunt when strike == StrikeType.Thrust => option.GetAlphaValueFor(loadedOptions, "(IFQCs)"),
            _ => 0
         };

         return result;
      }
   }
}