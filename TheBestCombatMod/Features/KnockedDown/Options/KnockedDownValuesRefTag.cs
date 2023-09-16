// Code written by Gabriel Mailhot, 28/08/2023.

#region

using System;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.KnockedDown.Options
{
   public class KnockedDownValuesRefTag : KnockedDownValue
   {
      public string ABDOMEN_BLUNT_SWINGING_D5Hdv_KNOCKEDDOWN_Value => "(D5Hdv)";
      public string ABDOMEN_BLUNT_THRUSTING_vNHgz_KNOCKEDDOWN_Value => "(vNHgz)";
      public string ABDOMEN_CUT_SWINGING_QrXgU_KNOCKEDDOWN_Value => "(QrXgU)";
      public string ABDOMEN_CUT_THRUSTING_Vt6DF_KNOCKEDDOWN_Value => "(Vt6DF)";
      public string ABDOMEN_PIERCE_SWINGING_EMsgc_KNOCKEDDOWN_Value => "(EMsgc)";
      public string ABDOMEN_PIERCE_THRUSTING_HgUNm_KNOCKEDDOWN_Value => "(HgUNm)";
      public string ARMS_BLUNT_SWINGING_AvHnv_KNOCKEDDOWN_Value => "(AvHnv)";
      public string ARMS_BLUNT_THRUSTING_1yGZ7_KNOCKEDDOWN_Value => "(1yGZ7)";
      public string ARMS_CUT_SWINGING_4qBAL_KNOCKEDDOWN_Value => "(4qBAL)";
      public string ARMS_CUT_THRUSTING_L8S6n_KNOCKEDDOWN_Value => "(L8S6n)";
      public string ARMS_PIERCE_SWINGING_hzBcV_KNOCKEDDOWN_Value => "(hzBcV)";
      public string ARMS_PIERCE_THRUSTING_nWoIs_KNOCKEDDOWN_Value => "(nWoIs)";
      public string ChanceModifierWhenBadlyHurt_Mlz88_KNOCKEDDOWN_Value => "(Mlz88)";
      public string CHEST_BLUNT_SWINGING_sKuQM_KNOCKEDDOWN_Value => "(sKuQM)";
      public string CHEST_BLUNT_THRUSTING_NXIfH_KNOCKEDDOWN_Value => "(NXIfH)";
      public string CHEST_CUT_SWINGING_CRF3J_KNOCKEDDOWN_Value => "(CRF3J)";
      public string CHEST_CUT_THRUSTING_OICbR_KNOCKEDDOWN_Value => "(OICbR)";
      public string CHEST_PIERCE_SWINGING_Khcy7_KNOCKEDDOWN_Value => "(Khcy7)";
      public string CHEST_PIERCE_THRUSTING_6d9EV_KNOCKEDDOWN_Value => "(6d9EV)";
      public string DAGGER_SWING_BLUNT_AGAINST_CLOTH_0ZV6V_KNOCKEDDOWN_Value => "(0ZV6V)";
      public string DAGGER_SWING_CUT_AGAINST_CLOTH_UbH0U_KNOCKEDDOWN_Value => "(UbH0U)";
      public string DAGGER_THRUST_BLUNT_AGAINST_CLOTH_54v8T_KNOCKEDDOWN_Value => "(54v8T)";
      public string DAGGER_THRUST_PIERCE_AGAINST_CLOTH_155we_KNOCKEDDOWN_Value => "(155we)";
      public string HEAD_BLUNT_SWINGING_cVrSS_KNOCKEDDOWN_Value => "(cVrSS)";
      public string HEAD_BLUNT_THRUSTING_fe45p_KNOCKEDDOWN_Value => "(fe45p)";
      public string HEAD_CUT_SWINGING_OQ2xO_KNOCKEDDOWN_Value => "(OQ2xO)";
      public string HEAD_CUT_THRUSTING_YcI0n_KNOCKEDDOWN_Value => "(YcI0n)";
      public string HEAD_PIERCE_SWINGING_6pmqy_KNOCKEDDOWN_Value => "(6pmqy)";
      public string HEAD_PIERCE_THRUSTING_B1pFn_KNOCKEDDOWN_Value => "(B1pFn)";
      public string Impact_Knockdown_Chance_Attacker_Healthier_0ZCKG_Value => "(0ZCKG)";
      public string JAVELIN_SWING_BLUNT_AGAINST_CLOTH_yfRpp_KNOCKEDDOWN_Value => "(yfRpp)";
      public string JAVELIN_SWING_CUT_AGAINST_CLOTH_q7iqc_KNOCKEDDOWN_Value => "(q7iqc)";
      public string JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_g5MD1_KNOCKEDDOWN_Value => "(g5MD1)";
      public string JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_ztAYD_KNOCKEDDOWN_Value => "(ztAYD)";
      public string Knockdown_Strength_FORMIDABLE_y34fA_Value => "(y34fA)";
      public string Knockdown_Strength_LOW_Sld4t_Value => "(Sld4t)";
      public string Knockdown_Strength_MINIMAL_37EAs_Vlaue => "(37EAs)";
      public string Knockdown_Strength_MODERATE_azdWq_Value => "(azdWq)";
      public string Knockdown_Strength_NONE_XBGV0_Value => "(XBGV0)";
      public string Knockdown_Strength_STRONG_Jt2ES_Value => "(Jt2ES)";
      public string KnockedDown_Sensitivity_For_Abdomen_xxxx_Value => "Not implemented yet";
      public string KnockedDown_Sensitivity_For_Arms_xxxx_Value => "Not implemented yet";
      public string KnockedDown_Sensitivity_For_Chest_xxxx_Value => "Not implemented yet";
      public string KnockedDown_Sensitivity_For_Head_xxxx_Value => "Not implemented yet";
      public string KnockedDown_Sensitivity_For_Legs_xxxx_Value => "Not implemented yet";
      public string KnockedDown_Sensitivity_For_Neck_xxxx_Value => "Not implemented yet";
      public string KnockedDown_Sensitivity_For_Shoulders_xxxx_Value => "Not implemented yet";
      public string LEGS_BLUNT_SWINGING_RiOF1_KNOCKEDDOWN_Value => "(RiOF1)";
      public string LEGS_BLUNT_THRUSTING_IFQCs_KNOCKEDDOWN_Value => "(IFQCs)";
      public string LEGS_CUT_SWINGING_QwhPA_KNOCKEDDOWN_Value => "(QwhPA)";
      public string LEGS_CUT_THRUSTING_Yi4SA_KNOCKEDDOWN_Value => "(Yi4SA)";
      public string LEGS_PIERCE_SWINGING_SyWWo_KNOCKEDDOWN_Value => "(SyWWo)";
      public string LEGS_PIERCE_THRUSTING_u26yW_KNOCKEDDOWN_Value => "(u26yW)";
      public string NECK_BLUNT_SWINGING_J4B3B_KNOCKEDDOWN_Value => "(J4B3B)";
      public string NECK_BLUNT_THRUSTING_ugKRH_KNOCKEDDOWN_Value => "(ugKRH)";
      public string NECK_CUT_SWINGING_C9LgN_KNOCKEDDOWN_Value => "(C9LgN)";
      public string NECK_CUT_THRUSTING_bI0zB_KNOCKEDDOWN_Value => "(bI0zB)";
      public string NECK_PIERCE_SWINGING_Zjr5i_KNOCKEDDOWN_Value => "(Zjr5i)";
      public string NECK_PIERCE_THRUSTING_9O8v5_KNOCKEDDOWN_Value => "(9O8v5)";
      public string ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CHAINMAIL_fIwtn_KNOCKEDDOWN_Value => "(fIwtn)";
      public string ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CLOTH_xiBqb_KNOCKEDDOWN_Value => "(xiBqb)";
      public string ONE_HANDED_AXE_SWING_BLUNT_AGAINST_LEATHER_oTezN_KNOCKEDDOWN_Value => "(oTezN)";
      public string ONE_HANDED_AXE_SWING_BLUNT_AGAINST_PLATE_tYoRa_KNOCKEDDOWN_Value => "(tYoRa)";
      public string ONE_HANDED_AXE_SWING_CUT_AGAINST_CHAINMAIL_o3hJa_KNOCKEDDOWN_Value => "(o3hJa)";
      public string ONE_HANDED_AXE_SWING_CUT_AGAINST_CLOTH_4dfIj_KNOCKEDDOWN_Value => "(4dfIj)";
      public string ONE_HANDED_AXE_SWING_CUT_AGAINST_LEATHER_eB5NV_KNOCKEDDOWN_Value => "(eB5NV)";
      public string ONE_HANDED_AXE_SWING_CUT_AGAINST_PLATE_gQosN_KNOCKEDDOWN_Value => "(gQosN)";
      public string ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CHAINMAIL_4D4tg_KNOCKEDDOWN_Value => "(4D4tg)";
      public string ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CLOTH_NCHfy_KNOCKEDDOWN_Value => "(NCHfy)";
      public string ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_LEATHER_efD8x_KNOCKEDDOWN_Value => "(efD8x)";
      public string ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_PLATE_8v6eF_KNOCKEDDOWN_Value => "(8v6eF)";
      public string ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CHAINMAIL_BCKTm_KNOCKEDDOWN_Value => "(BCKTm)";
      public string ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CLOTH_7bEDm_KNOCKEDDOWN_Value => "(7bEDm)";
      public string ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_LEATHER_f6gV5_KNOCKEDDOWN_Value => "(f6gV5)";
      public string ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_PLATE_jfxkn_KNOCKEDDOWN_Value => "(jfxkn)";
      public string PEASANT_ATTACKER_KNOCKEDDOWN_REDUCE_PROBABILITY_BY => "(J85wE)";
      public string Resistance_Strength_FORMIDABLE_SJxXx_KNOCKEDDOWN_Value => "(SJxXx)";
      public string Resistance_Strength_LOW_45Iww_KNOCKEDDOWN_Value => "(45Iww)";
      public string Resistance_Strength_MODERATE_SCFhO_KNOCKEDDOWN_Value => "(SCFhO)";
      public string Resistance_Strength_NONE_lZsvs_KNOCKEDDOWN_Value => "(lZsvs)";
      public string Resistance_Strength_STRONG_wJ35Y_KNOCKEDDOWN_Value => "(wJ35Y)";
      public string SHOULDERS_BLUNT_SWINGING_RlWlN_KNOCKEDDOWN_Value => "(RlWlN)";
      public string SHOULDERS_BLUNT_THRUSTING_k8lLo_KNOCKEDDOWN_Value => "(k8lLo)";
      public string SHOULDERS_CUT_SWINGING_EXiaJ_KNOCKEDDOWN_Value => "(EXiaJ)";
      public string SHOULDERS_CUT_THRUSTING_67y86_KNOCKEDDOWN_Value => "(67y86)";
      public string SHOULDERS_PIERCE_SWINGING_ZXZnF_KNOCKEDDOWN_Value => "(ZXZnF)";
      public string SHOULDERS_PIERCE_THRUSTING_WM1l3_KNOCKEDDOWN_Value => "(WM1l3)";
      public string TresholdValueWhenBadlyHurt_5w5jT_KNOCKEDDOWN_Value => "(5w5jT)";
      public string TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL_G8aSx_KNOCKEDDOWN_Value => "(G8aSx)";
      public string TWO_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE_K6eWy_KNOCKEDDOWN_Value => "(K6eWy)";
      public string TWO_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL_N4bTy_KNOCKEDDOWN_Value => "(N4bTy)";
      public string TWO_HANDED_MACE_SWING_CUT_AGAINST_PLATE_H9fXz_KNOCKEDDOWN_Value => "(H9fXz)";
      public string TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL_L5zRz_KNOCKEDDOWN_Value => "(L5zRz)";
      public string TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE_M3dVx_KNOCKEDDOWN_Value => "(M3dVx)";
      public string TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL_S2yQy_KNOCKEDDOWN_Value => "(S2yQy)";
      public string TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE_T7cUz_KNOCKEDDOWN_Value => "(T7cUz)";

      public string GetValuesFor(WeaponClass weaponClass, AttackMovement attackMovement, DamageTypes damageTypes, ArmorComponent.ArmorMaterialTypes armorMaterialTypes)
      {
         switch (weaponClass)
         {
            case WeaponClass.Undefined: break;
            case WeaponClass.Dagger:
               switch (attackMovement)
               {
                  case AttackMovement.SWING:
                     switch (damageTypes)
                     {
                        case DamageTypes.Invalid: break;
                        case DamageTypes.Cut:
                           switch (armorMaterialTypes)
                           {
                              case ArmorComponent.ArmorMaterialTypes.None: break;
                              case ArmorComponent.ArmorMaterialTypes.Cloth: return "(UbH0U)";
                              case ArmorComponent.ArmorMaterialTypes.Leather: return "(FxMdM)";
                              case ArmorComponent.ArmorMaterialTypes.Chainmail: return "(qtfhe)";
                              case ArmorComponent.ArmorMaterialTypes.Plate: return "(Eo6BI)";
                              default: throw new ArgumentOutOfRangeException(nameof(armorMaterialTypes), armorMaterialTypes, null);
                           }

                           break;
                        case DamageTypes.Pierce: break;
                        case DamageTypes.Blunt: break;
                        case DamageTypes.NumberOfDamageTypes: break;
                        default: throw new ArgumentOutOfRangeException(nameof(damageTypes), damageTypes, null);
                     }

                     break;
                  case AttackMovement.THRUST: break;
                  default: throw new ArgumentOutOfRangeException(nameof(attackMovement), attackMovement, null);
               }

               break;
            case WeaponClass.OneHandedSword: break;
            case WeaponClass.TwoHandedSword: break;
            case WeaponClass.OneHandedAxe: break;
            case WeaponClass.TwoHandedAxe: break;
            case WeaponClass.Mace: break;
            case WeaponClass.Pick: break;
            case WeaponClass.TwoHandedMace: break;
            case WeaponClass.OneHandedPolearm: break;
            case WeaponClass.TwoHandedPolearm: break;
            case WeaponClass.LowGripPolearm: break;
            case WeaponClass.Arrow: break;
            case WeaponClass.Bolt: break;
            case WeaponClass.Cartridge: break;
            case WeaponClass.Bow: break;
            case WeaponClass.Crossbow: break;
            case WeaponClass.Stone: break;
            case WeaponClass.Boulder: break;
            case WeaponClass.ThrowingAxe: break;
            case WeaponClass.ThrowingKnife: break;
            case WeaponClass.Javelin: break;
            case WeaponClass.Pistol: break;
            case WeaponClass.Musket: break;
            case WeaponClass.SmallShield: break;
            case WeaponClass.LargeShield: break;
            case WeaponClass.Banner: break;
            case WeaponClass.NumClasses: break;
            default: throw new ArgumentOutOfRangeException(nameof(weaponClass), weaponClass, null);
         }

         return "(UNDEFINED or NONE)";
      }
   }
}