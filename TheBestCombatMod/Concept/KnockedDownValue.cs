// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TaleWorlds.Core;
using TheBestCombatMod.Features;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface KnockedDownValue
   {
      string ABDOMEN_BLUNT_SWINGING_D5Hdv_KNOCKEDDOWN_Value { get; }
      string ABDOMEN_BLUNT_THRUSTING_vNHgz_KNOCKEDDOWN_Value { get; }
      string ABDOMEN_CUT_SWINGING_QrXgU_KNOCKEDDOWN_Value { get; }
      string ABDOMEN_CUT_THRUSTING_Vt6DF_KNOCKEDDOWN_Value { get; }
      string ABDOMEN_PIERCE_SWINGING_EMsgc_KNOCKEDDOWN_Value { get; }
      string ABDOMEN_PIERCE_THRUSTING_HgUNm_KNOCKEDDOWN_Value { get; }
      string ARMS_BLUNT_SWINGING_AvHnv_KNOCKEDDOWN_Value { get; }
      string ARMS_BLUNT_THRUSTING_1yGZ7_KNOCKEDDOWN_Value { get; }
      string ARMS_CUT_SWINGING_4qBAL_KNOCKEDDOWN_Value { get; }
      string ARMS_CUT_THRUSTING_L8S6n_KNOCKEDDOWN_Value { get; }
      string ARMS_PIERCE_SWINGING_hzBcV_KNOCKEDDOWN_Value { get; }
      string ARMS_PIERCE_THRUSTING_nWoIs_KNOCKEDDOWN_Value { get; }
      string ChanceModifierWhenBadlyHurt_Mlz88_KNOCKEDDOWN_Value { get; }
      string CHEST_BLUNT_SWINGING_sKuQM_KNOCKEDDOWN_Value { get; }
      string CHEST_BLUNT_THRUSTING_NXIfH_KNOCKEDDOWN_Value { get; }
      string CHEST_CUT_SWINGING_CRF3J_KNOCKEDDOWN_Value { get; }
      string CHEST_CUT_THRUSTING_OICbR_KNOCKEDDOWN_Value { get; }
      string CHEST_PIERCE_SWINGING_Khcy7_KNOCKEDDOWN_Value { get; }
      string CHEST_PIERCE_THRUSTING_6d9EV_KNOCKEDDOWN_Value { get; }
      string DAGGER_SWING_BLUNT_AGAINST_CLOTH_0ZV6V_KNOCKEDDOWN_Value { get; }
      string DAGGER_SWING_CUT_AGAINST_CLOTH_UbH0U_KNOCKEDDOWN_Value { get; }
      string DAGGER_THRUST_BLUNT_AGAINST_CLOTH_54v8T_KNOCKEDDOWN_Value { get; }
      string DAGGER_THRUST_PIERCE_AGAINST_CLOTH_155we_KNOCKEDDOWN_Value { get; }
      string HEAD_BLUNT_SWINGING_cVrSS_KNOCKEDDOWN_Value { get; }
      string HEAD_BLUNT_THRUSTING_fe45p_KNOCKEDDOWN_Value { get; }
      string HEAD_CUT_SWINGING_OQ2xO_KNOCKEDDOWN_Value { get; }
      string HEAD_CUT_THRUSTING_YcI0n_KNOCKEDDOWN_Value { get; }
      string HEAD_PIERCE_SWINGING_6pmqy_KNOCKEDDOWN_Value { get; }
      string HEAD_PIERCE_THRUSTING_B1pFn_KNOCKEDDOWN_Value { get; }
      string Impact_Knockdown_Chance_Attacker_Healthier_0ZCKG_Value { get; }
      string JAVELIN_SWING_BLUNT_AGAINST_CLOTH_yfRpp_KNOCKEDDOWN_Value { get; }
      string JAVELIN_SWING_CUT_AGAINST_CLOTH_q7iqc_KNOCKEDDOWN_Value { get; }
      string JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_g5MD1_KNOCKEDDOWN_Value { get; }
      string JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_ztAYD_KNOCKEDDOWN_Value { get; }
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
      string LEGS_BLUNT_SWINGING_RiOF1_KNOCKEDDOWN_Value { get; }
      string LEGS_BLUNT_THRUSTING_IFQCs_KNOCKEDDOWN_Value { get; }
      string LEGS_CUT_SWINGING_QwhPA_KNOCKEDDOWN_Value { get; }
      string LEGS_CUT_THRUSTING_Yi4SA_KNOCKEDDOWN_Value { get; }
      string LEGS_PIERCE_SWINGING_SyWWo_KNOCKEDDOWN_Value { get; }
      string LEGS_PIERCE_THRUSTING_u26yW_KNOCKEDDOWN_Value { get; }
      string NECK_BLUNT_SWINGING_J4B3B_KNOCKEDDOWN_Value { get; }
      string NECK_BLUNT_THRUSTING_ugKRH_KNOCKEDDOWN_Value { get; }
      string NECK_CUT_SWINGING_C9LgN_KNOCKEDDOWN_Value { get; }
      string NECK_CUT_THRUSTING_bI0zB_KNOCKEDDOWN_Value { get; }
      string NECK_PIERCE_SWINGING_Zjr5i_KNOCKEDDOWN_Value { get; }
      string NECK_PIERCE_THRUSTING_9O8v5_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CHAINMAIL_fIwtn_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CLOTH_xiBqb_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_SWING_BLUNT_AGAINST_LEATHER_oTezN_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_SWING_BLUNT_AGAINST_PLATE_tYoRa_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_SWING_CUT_AGAINST_CHAINMAIL_o3hJa_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_SWING_CUT_AGAINST_CLOTH_4dfIj_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_SWING_CUT_AGAINST_LEATHER_eB5NV_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_SWING_CUT_AGAINST_PLATE_gQosN_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CHAINMAIL_4D4tg_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CLOTH_NCHfy_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_LEATHER_efD8x_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_PLATE_8v6eF_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CHAINMAIL_BCKTm_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CLOTH_7bEDm_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_LEATHER_f6gV5_KNOCKEDDOWN_Value { get; }
      string ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_PLATE_jfxkn_KNOCKEDDOWN_Value { get; }
      string PEASANT_ATTACKER_KNOCKEDDOWN_REDUCE_PROBABILITY_BY { get; }
      string Resistance_Strength_FORMIDABLE_SJxXx_KNOCKEDDOWN_Value { get; }
      string Resistance_Strength_LOW_45Iww_KNOCKEDDOWN_Value { get; }
      string Resistance_Strength_MODERATE_SCFhO_KNOCKEDDOWN_Value { get; }
      string Resistance_Strength_NONE_lZsvs_KNOCKEDDOWN_Value { get; }
      string Resistance_Strength_STRONG_wJ35Y_KNOCKEDDOWN_Value { get; }
      string SHOULDERS_BLUNT_SWINGING_RlWlN_KNOCKEDDOWN_Value { get; }
      string SHOULDERS_BLUNT_THRUSTING_k8lLo_KNOCKEDDOWN_Value { get; }
      string SHOULDERS_CUT_SWINGING_EXiaJ_KNOCKEDDOWN_Value { get; }
      string SHOULDERS_CUT_THRUSTING_67y86_KNOCKEDDOWN_Value { get; }
      string SHOULDERS_PIERCE_SWINGING_ZXZnF_KNOCKEDDOWN_Value { get; }
      string SHOULDERS_PIERCE_THRUSTING_WM1l3_KNOCKEDDOWN_Value { get; }
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