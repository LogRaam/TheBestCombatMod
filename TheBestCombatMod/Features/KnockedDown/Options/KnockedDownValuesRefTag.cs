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
      public string ChanceModifierWhenBadlyHurt_Mlz88_KNOCKEDDOWN_Value => "(Mlz88)";
      public string Impact_Knockdown_Chance_Attacker_Healthier_0ZCKG_Value => "(0ZCKG)";
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
      public string PEASANT_ATTACKER_KNOCKEDDOWN_REDUCE_PROBABILITY_BY => "(J85wE)";
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