// Code written by Gabriel Mailhot, 24/08/2023.

#region

using LogRaamConfiguration;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TheBestCombatMod.Features.KnockedDown;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface Factory
   {
      BodyPart AbdomenUnseatProbability { get; set; }
      ArmorResistance ArmorMaterialUnseatResistance { get; set; }
      BodyPart ArmsUnseatProbability { get; set; }
      AttackerOptions AttackerOptions { get; set; }
      BodyHitProbability BodyHitUnseatProbability { get; set; }
      BodyPart ChestUnseatProbability { get; set; }
      CombatActionEffect CombatActionEffect { get; set; }
      ICampaignBehavior ConfigurationBehavior { get; set; }
      ConfigurationLoader ConfigurationLoader { get; set; }
      UnseatFeature DecideAgentDismountedByBlow { get; set; }
      KnockedDownFeature DecideAgentKnockedDownByBlow { get; set; }
      SituationalDefenseInfo DefenseInfo { get; set; }
      FileTimeStamp FileInteraction { get; set; }
      BodyPart HeadUnseatProbability { get; set; }
      ImpactChanceOptions ImpactUnseatChanceOptions { get; set; }
      KnockDownStrengthOption KnockDownStrengthOption { get; set; }
      KnockedDownByBlowConfiguration KnockedDownByBlowConfiguration { get; set; }
      KnockedDownProbability KnockedDownProbability { get; set; }
      BodyPart LegsUnseatProbability { get; set; }
      BodyPart NeckUnseatProbability { get; set; }
      OptionFileContent Options { get; set; }
      SituationalDefenseInfo ProtectionInfo { get; set; }
      MBFastRandom Random { get; set; }
      BodyPart ShouldersUnseatProbability { get; set; }
      BodyPartsVulnerabilityOptions UnseatBodyPartsVulnerabilityOptions { get; set; }
      UnseatOptionReader UnseatByBlowOptionsReader { get; set; }
      CombatActionEffect UnseatProbability { get; set; }
      ImpactResistanceOptions UnseatResistanceOptions { get; set; }
      StaggerStrengthOptions UnseatStaggerStrengthOptions { get; set; }
      WeaponStaggerForce WeaponStaggerForceValue { get; set; }
      WeaponType Dagger(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType DaggerChainmailDto();
      AttackType DaggerClothDto();
      AttackType DaggerLeatherDto();
      AttackType DaggerPlateDto();
      WeaponType Javelin(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType JavelinChainmailDto();
      AttackType JavelinClothDto();
      AttackType JavelinLeatherDto();
      AttackType JavelinPlateDto();
      WeaponType OneHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType OneHandedAxeChainmailDto();
      AttackType OneHandedAxeClothDto();
      AttackType OneHandedAxeLeatherDto();
      AttackType OneHandedAxePlateDto();
      WeaponType OneHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType OneHandedMaceChainmailDto();
      AttackType OneHandedMaceClothDto();
      AttackType OneHandedMaceLeatherDto();
      AttackType OneHandedMacePlateDto();
      WeaponType OneHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType OneHandedPolearmChainmailDto();
      AttackType OneHandedPolearmClothDto();
      AttackType OneHandedPolearmLeatherDto();
      AttackType OneHandedPolearmPlateDto();
      WeaponType OneHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType OneHandedSwordChainmailDto();
      AttackType OneHandedSwordClothDto();
      AttackType OneHandedSwordLeatherDto();
      AttackType OneHandedSwordPlateDto();
      OptionFileContent OptionFileContent(ConfigurationLoader loader);
      WeaponType Pick(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType PickChainmailDto();
      AttackType PickClothDto();
      AttackType PickLeatherDto();
      AttackType PickPlateDto();
      WeaponType Stone(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType StoneChainmailDto();
      AttackType StoneClothDto();
      AttackType StoneLeatherDto();
      AttackType StonePlateDto();
      WeaponType TwoHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType TwoHandedAxeChainmailDto();
      AttackType TwoHandedAxeClothDto();
      AttackType TwoHandedAxeLeatherDto();
      AttackType TwoHandedAxePlateDto();
      WeaponType TwoHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType TwoHandedMaceChainmailDto();
      AttackType TwoHandedMaceClothDto();
      AttackType TwoHandedMaceLeatherDto();
      AttackType TwoHandedMacePlateDto();
      WeaponType TwoHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType TwoHandedPolearmChainmailDto();
      AttackType TwoHandedPolearmClothDto();
      AttackType TwoHandedPolearmLeatherDto();
      AttackType TwoHandedPolearmPlateDto();
      WeaponType TwoHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType TwoHandedSwordChainmailDto();
      AttackType TwoHandedSwordClothDto();
      AttackType TwoHandedSwordLeatherDto();
      AttackType TwoHandedSwordPlateDto();
   }
}