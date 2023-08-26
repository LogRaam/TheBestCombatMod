// Code written by Gabriel Mailhot, 24/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface KnockedDownActivationValue
   {
      string EffectOnBodyPart_Active { get; }
      string KnockedDownByBlow_Active { get; }
      string ReduceProbabilityForPeasants { get; }
      string WhenAttackerIsHealthier_Active { get; }
      string WhenBadlyHurt_Active { get; }
   }
}