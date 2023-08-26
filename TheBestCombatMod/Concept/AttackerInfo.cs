// Code written by Gabriel Mailhot, 24/08/2023.

namespace TheBestCombatMod.Concept
{
   public interface AttackerInfo
   {
      int ATTACKER_IS_HEALTHIER { get; set; }
      int ATTACKER_IS_HEAVIER { get; set; }
      int ATTACKER_IS_STRONGER { get; set; }
      float ATTACKER_IS_WOMAN { get; set; }
      int ATTACKER_WEAPON_INERTIA { get; set; }
      int BLOW_ISCRITICAL_BLUNT { get; set; }
      int BLOW_ISCRITICAL_CUT { get; set; }
      int BLOW_ISCRITICAL_PIERCE { get; set; }
      int THRUST_TIP_HIT { get; set; }
      int VICTIME_DIDNOT_RAISE_GUARD { get; set; }
   }
}