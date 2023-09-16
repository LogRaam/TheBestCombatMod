// Code written by Gabriel Mailhot, 28/08/2023.

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
      BodyPart AbdomenKnockedDownProbability { get; set; }
      BodyPart AbdomenUnseatProbability { get; set; }

      ArmorResistance ArmorMaterialResistance { get; set; }

      BodyPart ArmsKnockedDownProbability { get; set; }
      BodyPart ArmsUnseatProbability { get; set; }
      AttackerOptions AttackerOptions { get; set; }
      BodyHitProbability BodyHitUnseatProbability { get; set; }
      BodyPart ChestKnockedDownProbability { get; set; }
      BodyPart ChestUnseatProbability { get; set; }
      CombatActionEffect CombatActionEffect { get; set; }
      ICampaignBehavior ConfigurationBehavior { get; set; }
      ConfigurationLoader ConfigurationLoader { get; set; }
      UnseatFeature DecideAgentDismountedByBlow { get; set; }
      KnockedDownFeature DecideAgentKnockedDownByBlow { get; set; }
      SituationalDefenseInfo DefenseInfo { get; set; }
      FileTimeStamp FileInteraction { get; set; }
      BodyPart HeadKnockedDownProbability { get; set; }
      BodyPart HeadUnseatProbability { get; set; }
      ImpactChanceOptions ImpactUnseatChanceOptions { get; set; }
      KnockDownStrengthOption KnockDownStrengthOption { get; set; }
      KnockedDownByBlowConfiguration KnockedDownByBlowConfiguration { get; set; }
      KnockedDownOptionReader KnockedDownByBlowOptionReader { get; set; }
      ImpactResistanceOptions KnockedDownImpactResistance { get; set; }
      KnockedDownProbability KnockedDownProbability { get; set; }
      BodyPart LegsKnockedDownProbability { get; set; }
      BodyPart LegsUnseatProbability { get; set; }
      BodyPart NeckKnockedDownProbability { get; set; }
      BodyPart NeckUnseatProbability { get; set; }
      OptionFileContent Options { get; set; }
      SituationalDefenseInfo ProtectionInfo { get; set; }
      MBFastRandom Random { get; set; }
      BodyPart ShouldersKnockedDownProbability { get; set; }
      BodyPart ShouldersUnseatProbability { get; set; }
      BodyPartsVulnerabilityOptions UnseatBodyPartsVulnerabilityOptions { get; set; }
      UnseatOptionReader UnseatByBlowOptionsReader { get; set; }
      CombatActionEffect UnseatProbability { get; set; }
      ImpactResistanceOptions UnseatResistanceOptions { get; set; }
      StaggerStrengthOptions UnseatStaggerStrengthOptions { get; set; }
      WeaponStaggerForce WeaponStaggerForceValue { get; set; }
      WeaponType Dagger(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType DaggerChainmailKnockedDownDto();
      AttackType DaggerChainmailUnseatDto();
      AttackType DaggerClothKnockedDownDto();
      AttackType DaggerClothUnseatDto();
      AttackType DaggerLeatherKnockedDownDto();
      AttackType DaggerLeatherUnseatDto();
      AttackType DaggerPlateKnockedDownDto();
      AttackType DaggerPlateUnseatDto();
      WeaponType Javelin(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType JavelinChainmailKnockedDownDto();
      AttackType JavelinChainmailUnseatDto();
      AttackType JavelinClothKnockedDownDto();
      AttackType JavelinClothUnseatDto();
      AttackType JavelinLeatherKnockedDownDto();
      AttackType JavelinLeatherUnseatDto();
      AttackType JavelinPlateKnockedDownDto();
      AttackType JavelinPlateUnseatDto();
      WeaponType OneHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType OneHandedAxeChainmailKnockedDownDto();
      AttackType OneHandedAxeChainmailUnseatDto();
      AttackType OneHandedAxeClothKnockedDownDto();
      AttackType OneHandedAxeClothUnseatDto();
      AttackType OneHandedAxeLeatherKnockedDownDto();
      AttackType OneHandedAxeLeatherUnseatDto();
      AttackType OneHandedAxePlateKnockedDownDto();
      AttackType OneHandedAxePlateUnseatDto();
      AttackType OneHandedMaceChainmailKnockedDownDto();
      AttackType OneHandedMaceChainmailUnseatDto();
      AttackType OneHandedMaceClothKnockedDownDto();
      AttackType OneHandedMaceClothUnseatDto();
      AttackType OneHandedMaceLeatherKnockedDownDto();
      AttackType OneHandedMaceLeatherUnseatDto();
      AttackType OneHandedMacePlateKnockedDownDto();
      AttackType OneHandedMacePlateUnseatDto();
      WeaponType OneHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType OneHandedPolearmChainmailUnseatDto();
      AttackType OneHandedPolearmClothUnseatDto();
      AttackType OneHandedPolearmLeatherUnseatDto();
      AttackType OneHandedPolearmPlateUnseatDto();
      WeaponType OneHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType OneHandedSwordChainmailUnseatDto();
      AttackType OneHandedSwordClothUnseatDto();
      AttackType OneHandedSwordLeatherUnseatDto();
      AttackType OneHandedSwordPlateUnseatDto();
      WeaponType OneHandedUnseatMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      OptionFileContent OptionFileContent(ConfigurationLoader loader);
      WeaponType Pick(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType PickChainmailUnseatDto();
      AttackType PickClothUnseatDto();
      AttackType PickLeatherUnseatDto();
      AttackType PickPlateUnseatDto();
      WeaponType Stone(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType StoneChainmailUnseatDto();
      AttackType StoneClothUnseatDto();
      AttackType StoneLeatherUnseatDto();
      AttackType StonePlateUnseatDto();
      WeaponType TwoHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType TwoHandedAxeChainmailUnseatDto();
      AttackType TwoHandedAxeClothUnseatDto();
      AttackType TwoHandedAxeLeatherUnseatDto();
      AttackType TwoHandedAxePlateUnseatDto();
      WeaponType TwoHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType TwoHandedMaceChainmailKnockedDownDto();
      AttackType TwoHandedMaceChainmailUnseatDto();
      AttackType TwoHandedMaceClothKnockedDownDto();
      AttackType TwoHandedMaceClothUnseatDto();
      AttackType TwoHandedMaceLeatherKnockedDownDto();
      AttackType TwoHandedMaceLeatherUnseatDto();
      AttackType TwoHandedMacePlateKnockedDownDto();
      AttackType TwoHandedMacePlateUnseatDto();
      WeaponType TwoHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType TwoHandedPolearmChainmailUnseatDto();
      AttackType TwoHandedPolearmClothUnseatDto();
      AttackType TwoHandedPolearmLeatherUnseatDto();
      AttackType TwoHandedPolearmPlateUnseatDto();
      WeaponType TwoHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      AttackType TwoHandedSwordChainmailUnseatDto();
      AttackType TwoHandedSwordClothUnseatDto();
      AttackType TwoHandedSwordLeatherUnseatDto();
      AttackType TwoHandedSwordPlateUnseatDto();
   }
}