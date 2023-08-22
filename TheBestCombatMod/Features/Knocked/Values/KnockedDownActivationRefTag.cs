// Code written by Gabriel Mailhot, 17/08/2023.

#region

using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Knocked.Values
{
   public class KnockedDownActivationRefTag : IActivationRefTag
   {
      public string EffectOnBodyPart_Active => "[X] (Xa1AX)";

      public string KnockedDownByBlow_Active => "[X] (t59gx)";
      public string ReduceProbabilityForPeasants => "[X] (fQh5k)";
      public string WhenAttackerIsHealthier_Active => "[X] (YKLNt)";
      public string WhenBadlyHurt_Active => "[X] (m3UPl)";
   }
}