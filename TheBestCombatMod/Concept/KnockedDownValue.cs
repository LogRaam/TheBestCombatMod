// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Features;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface KnockedDownValue
   {
      string ChanceModifierWhenBadlyHurt_Mlz88_KNOCKEDDOWN_Value { get; }

      string Impact_Knockdown_Chance_Attacker_Healthier_0ZCKG_Value { get; }

      string Knockdown_Strength_FORMIDABLE_y34fA_Value { get; }
      string Knockdown_Strength_LOW_Sld4t_Value { get; }
      string Knockdown_Strength_MINIMAL_37EAs_Vlaue { get; }
      string Knockdown_Strength_MODERATE_azdWq_Value { get; }
      string Knockdown_Strength_NONE_XBGV0_Value { get; }
      string Knockdown_Strength_STRONG_Jt2ES_Value { get; }
      string KnockedDown_Sensitivity_For_Abdomen_xxxx_Value { get; }
      string KnockedDown_Sensitivity_For_Arms_xxxx_Value { get; }
      string KnockedDown_Sensitivity_For_Chest_xxxx_Value { get; }
      string KnockedDown_Sensitivity_For_Head_xxxx_Value { get; }
      string KnockedDown_Sensitivity_For_Legs_xxxx_Value { get; }
      string KnockedDown_Sensitivity_For_Neck_xxxx_Value { get; }
      string KnockedDown_Sensitivity_For_Shoulders_xxxx_Value { get; }

      string PEASANT_ATTACKER_KNOCKEDDOWN_REDUCE_PROBABILITY_BY { get; }

      string TresholdValueWhenBadlyHurt_5w5jT_KNOCKEDDOWN_Value { get; }
      string TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL_G8aSx_KNOCKEDDOWN_Value { get; }
      string TWO_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE_K6eWy_KNOCKEDDOWN_Value { get; }
      string TWO_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL_N4bTy_KNOCKEDDOWN_Value { get; }
      string TWO_HANDED_MACE_SWING_CUT_AGAINST_PLATE_H9fXz_KNOCKEDDOWN_Value { get; }
      string TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL_L5zRz_KNOCKEDDOWN_Value { get; }
      string TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE_M3dVx_KNOCKEDDOWN_Value { get; }
      string TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL_S2yQy_KNOCKEDDOWN_Value { get; }
      string TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE_T7cUz_KNOCKEDDOWN_Value { get; }
      string GetValuesFor(WeaponClass dagger, AttackMovement swing, DamageTypes blunt, ArmorComponent.ArmorMaterialTypes chainmail);
   }
}