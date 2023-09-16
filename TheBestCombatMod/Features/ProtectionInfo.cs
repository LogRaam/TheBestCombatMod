// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features
{
   public class ProtectionInfo : SituationalDefenseInfo
   {
      public ArmorComponent.ArmorMaterialTypes GetArmorMaterialType(Agent victimAgent, Blow blow)
      {
         var item = RetrieveArmorPieceThatHaveBeenHit(victimAgent.SpawnEquipment, blow.VictimBodyPart)?.Item;

         if (item?.ItemComponent == null) return ArmorComponent.ArmorMaterialTypes.None;

         var armorMaterialType = ((ArmorComponent) RetrieveArmorPieceThatHaveBeenHit(victimAgent.SpawnEquipment, blow.VictimBodyPart).Value.Item.ItemComponent).MaterialType;

         return armorMaterialType;
      }


      /*
      public int GetKnockedDownResistanceBonusFrom(in string[] loadedOptions, WeaponClass attackerWeaponClass, StrikeType strikeType, DamageTypes damageType, ArmorComponent.ArmorMaterialTypes materialType)
      {
         switch (attackerWeaponClass)
         {
            case WeaponClass.Undefined: return 0;
            case WeaponClass.Dagger: return Runtime.Get.Dagger(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.OneHandedSword: return Runtime.Get.OneHandedSword(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.TwoHandedSword: return Runtime.Get.TwoHandedSword(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.OneHandedAxe: return Runtime.Get.OneHandedAxe(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.TwoHandedAxe: return Runtime.Get.TwoHandedAxe(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.Mace: return Runtime.Get.OneHandedUnseatMace(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.Pick: return Runtime.Get.Pick(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.TwoHandedMace: return Runtime.Get.TwoHandedMace(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.OneHandedPolearm: return Runtime.Get.OneHandedPolearm(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.TwoHandedPolearm: return Runtime.Get.TwoHandedPolearm(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.Stone: return Runtime.Get.Stone(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.Javelin: return Runtime.Get.Javelin(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);

            default:
               return 0;
         }
      }

      public int GetUnseatResistanceBonusFrom(in string[] loadedOptions, in WeaponClass weaponClass, in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType, Feature feature)
      {
         switch (weaponClass)
         {
            case WeaponClass.Undefined: return 0;
            case WeaponClass.Dagger: return Runtime.Get.Dagger(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.OneHandedSword: return Runtime.Get.OneHandedSword(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.TwoHandedSword: return Runtime.Get.TwoHandedSword(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.OneHandedAxe: return Runtime.Get.OneHandedAxe(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.TwoHandedAxe: return Runtime.Get.TwoHandedAxe(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.Mace: return Runtime.Get.OneHandedUnseatMace(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.Pick: return Runtime.Get.Pick(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.TwoHandedMace: return Runtime.Get.TwoHandedMace(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.OneHandedPolearm: return Runtime.Get.OneHandedPolearm(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.TwoHandedPolearm: return Runtime.Get.TwoHandedPolearm(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.Stone: return Runtime.Get.Stone(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);
            case WeaponClass.Javelin: return Runtime.Get.Javelin(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, Feature.KnockedDown);

            default:
               return 0;
         }
      }
      */

      public int GetResistanceBonusFrom(in string[] loadedOptions, in WeaponClass weaponClass, in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType, Feature feature)
      {
         switch (weaponClass)
         {
            case WeaponClass.Undefined: return 0;
            case WeaponClass.Dagger: return Runtime.Get.Dagger(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.OneHandedSword: return Runtime.Get.OneHandedSword(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.TwoHandedSword: return Runtime.Get.TwoHandedSword(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.OneHandedAxe: return Runtime.Get.OneHandedAxe(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.TwoHandedAxe: return Runtime.Get.TwoHandedAxe(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.Mace: return Runtime.Get.OneHandedUnseatMace(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.Pick: return Runtime.Get.Pick(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.TwoHandedMace: return Runtime.Get.TwoHandedMace(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.OneHandedPolearm: return Runtime.Get.OneHandedPolearm(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.TwoHandedPolearm: return Runtime.Get.TwoHandedPolearm(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.Stone: return Runtime.Get.Stone(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);
            case WeaponClass.Javelin: return Runtime.Get.Javelin(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature);

            default:
               return 0;
         }
      }

      public bool IsShieldCovering(in ItemCategory itemCategory, in BoneBodyPartType victimBodyPart) => itemCategory.StringId.ToLower().Contains("shield") && victimBodyPart == BoneBodyPartType.ArmLeft;

      public EquipmentElement? RetrieveArmorPieceThatHaveBeenHit(Equipment equipment, BoneBodyPartType blowVictimBodyPart) //TODO: Reduce scope from TW objects.  Here I can probably return MaterialTypes instead of ItemObject.  I can then use a converter for decoupling with TW.
      {
         return blowVictimBodyPart switch
         {
            BoneBodyPartType.None => null,
            BoneBodyPartType.Head => equipment.GetEquipmentFromSlot(EquipmentIndex.Head),
            BoneBodyPartType.Neck => equipment.GetEquipmentFromSlot(EquipmentIndex.Head),
            BoneBodyPartType.Chest => equipment.GetEquipmentFromSlot(EquipmentIndex.Body),
            BoneBodyPartType.Abdomen => equipment.GetEquipmentFromSlot(EquipmentIndex.Body),
            BoneBodyPartType.ShoulderLeft => equipment.GetEquipmentFromSlot(EquipmentIndex.Body),
            BoneBodyPartType.ShoulderRight => equipment.GetEquipmentFromSlot(EquipmentIndex.Body),
            BoneBodyPartType.ArmLeft => equipment.GetEquipmentFromSlot(EquipmentIndex.Gloves),
            BoneBodyPartType.ArmRight => equipment.GetEquipmentFromSlot(EquipmentIndex.Gloves),
            BoneBodyPartType.Legs => equipment.GetEquipmentFromSlot(EquipmentIndex.Leg),
            BoneBodyPartType.NumOfBodyPartTypes => null,
            _ => null
         };
      }
   }
}