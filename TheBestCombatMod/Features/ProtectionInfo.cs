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

      public int GetResistanceBonusFrom(in string[] loadedOptions, in WeaponClass weaponClass, in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType, Feature feature)
      {
         var result = weaponClass switch
         {
            WeaponClass.Undefined => 0,
            WeaponClass.Dagger => Runtime.Get.Dagger(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.OneHandedSword => Runtime.Get.OneHandedSword(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.TwoHandedSword => Runtime.Get.TwoHandedSword(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.OneHandedAxe => Runtime.Get.OneHandedAxe(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.TwoHandedAxe => Runtime.Get.TwoHandedAxe(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.Mace => Runtime.Get.OneHandedUnseatMace(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.Pick => Runtime.Get.Pick(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.TwoHandedMace => Runtime.Get.TwoHandedMace(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.OneHandedPolearm => Runtime.Get.OneHandedPolearm(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.TwoHandedPolearm => Runtime.Get.TwoHandedPolearm(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.Stone => Runtime.Get.Stone(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            WeaponClass.Javelin => Runtime.Get.Javelin(strikeType, damageType, materialType).GetResistanceBonus(loadedOptions, feature),
            _ => 0
         };

         return result;
      }

      public bool IsShieldCovering(in ItemCategory itemCategory, in BoneBodyPartType victimBodyPart) => itemCategory.StringId.ToLower().Contains("shield") && victimBodyPart == BoneBodyPartType.ArmLeft;

      public EquipmentElement? RetrieveArmorPieceThatHaveBeenHit(Equipment equipment, BoneBodyPartType blowVictimBodyPart) //TODO: Reduce scope from TW objects.  Here I can probably return MaterialTypes instead of ItemObject.  I can then use a converter for decoupling with TW.
      {
         EquipmentElement? result = blowVictimBodyPart switch
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

         return result;
      }
   }
}