// Code written by Gabriel Mailhot, 28/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface KnockedDownConfig : Configuration
   {
      KnockedDownActivationValue KnockedDownActivationValueTags { get; set; }
      KnockedDownValue KnockedDownValueTags { get; set; }
   }
}