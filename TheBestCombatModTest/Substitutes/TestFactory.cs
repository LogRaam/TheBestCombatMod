// Code written by Gabriel Mailhot, 27/08/2023.

#region

using System;
using LogRaamConfiguration;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;
using TheBestCombatMod.Features.KnockedDown;

#endregion

namespace TheBestCombatModTest.Substitutes
{
   internal class TestFactory : Factory
   {
      public BodyPart AbdomenUnseatProbability { get; set; }
      public ArmorResistance ArmorMaterialUnseatResistance { get; set; }
      public BodyPart ArmsUnseatProbability { get; set; }
      public AttackerOptions AttackerOptions { get; set; }
      public BodyHitProbability BodyHitUnseatProbability { get; set; }
      public BodyPart ChestUnseatProbability { get; set; }
      public CombatActionEffect CombatActionEffect { get; set; }
      public ICampaignBehavior ConfigurationBehavior { get; set; }
      public ConfigurationLoader ConfigurationLoader { get; set; }
      public UnseatFeature DecideAgentDismountedByBlow { get; set; }
      public KnockedDownFeature DecideAgentKnockedDownByBlow { get; set; }
      public SituationalDefenseInfo DefenseInfo { get; set; }
      public FileTimeStamp FileInteraction { get; set; }
      public BodyPart HeadUnseatProbability { get; set; }
      public ImpactChanceOptions ImpactUnseatChanceOptions { get; set; }
      public KnockDownStrengthOption KnockDownStrengthOption { get; set; }
      public KnockedDownByBlowConfiguration KnockedDownByBlowConfiguration { get; set; }
      public KnockedDownProbability KnockedDownProbability { get; set; }
      public BodyPart LegsUnseatProbability { get; set; }
      public BodyPart NeckUnseatProbability { get; set; }
      public OptionFileContent Options { get; set; }
      public SituationalDefenseInfo ProtectionInfo { get; set; }
      public MBFastRandom Random { get; set; }
      public BodyPart ShouldersUnseatProbability { get; set; }
      public BodyPartsVulnerabilityOptions UnseatBodyPartsVulnerabilityOptions { get; set; }
      public UnseatOptionReader UnseatByBlowOptionsReader { get; set; }
      public CombatActionEffect UnseatProbability { get; set; }
      public ImpactResistanceOptions UnseatResistanceOptions { get; set; }
      public StaggerStrengthOptions UnseatStaggerStrengthOptions { get; set; }
      public WeaponStaggerForce WeaponStaggerForceValue { get; set; }
      public WeaponType Dagger(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType DaggerChainmailDto() => throw new NotImplementedException();

      public AttackType DaggerClothDto() => throw new NotImplementedException();

      public AttackType DaggerLeatherDto() => throw new NotImplementedException();

      public AttackType DaggerPlateDto() => throw new NotImplementedException();

      public WeaponType Javelin(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType JavelinChainmailDto() => throw new NotImplementedException();

      public AttackType JavelinClothDto() => throw new NotImplementedException();

      public AttackType JavelinLeatherDto() => throw new NotImplementedException();

      public AttackType JavelinPlateDto() => throw new NotImplementedException();

      public WeaponType OneHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType OneHandedAxeChainmailDto() => throw new NotImplementedException();

      public AttackType OneHandedAxeClothDto() => throw new NotImplementedException();

      public AttackType OneHandedAxeLeatherDto() => throw new NotImplementedException();

      public AttackType OneHandedAxePlateDto() => throw new NotImplementedException();

      public WeaponType OneHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType OneHandedMaceChainmailDto() => throw new NotImplementedException();

      public AttackType OneHandedMaceClothDto() => throw new NotImplementedException();

      public AttackType OneHandedMaceLeatherDto() => throw new NotImplementedException();

      public AttackType OneHandedMacePlateDto() => throw new NotImplementedException();

      public WeaponType OneHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType OneHandedPolearmChainmailDto() => throw new NotImplementedException();

      public AttackType OneHandedPolearmClothDto() => throw new NotImplementedException();

      public AttackType OneHandedPolearmLeatherDto() => throw new NotImplementedException();

      public AttackType OneHandedPolearmPlateDto() => throw new NotImplementedException();

      public WeaponType OneHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType OneHandedSwordChainmailDto() => throw new NotImplementedException();

      public AttackType OneHandedSwordClothDto() => throw new NotImplementedException();

      public AttackType OneHandedSwordLeatherDto() => throw new NotImplementedException();

      public AttackType OneHandedSwordPlateDto() => throw new NotImplementedException();

      public OptionFileContent OptionFileContent(ConfigurationLoader loader) => throw new NotImplementedException();

      public WeaponType Pick(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType PickChainmailDto() => throw new NotImplementedException();

      public AttackType PickClothDto() => throw new NotImplementedException();

      public AttackType PickLeatherDto() => throw new NotImplementedException();

      public AttackType PickPlateDto() => throw new NotImplementedException();

      public WeaponType Stone(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType StoneChainmailDto() => throw new NotImplementedException();

      public AttackType StoneClothDto() => throw new NotImplementedException();

      public AttackType StoneLeatherDto() => throw new NotImplementedException();

      public AttackType StonePlateDto() => throw new NotImplementedException();

      public WeaponType TwoHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType TwoHandedAxeChainmailDto() => throw new NotImplementedException();

      public AttackType TwoHandedAxeClothDto() => throw new NotImplementedException();

      public AttackType TwoHandedAxeLeatherDto() => throw new NotImplementedException();

      public AttackType TwoHandedAxePlateDto() => throw new NotImplementedException();

      public WeaponType TwoHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType TwoHandedMaceChainmailDto() => throw new NotImplementedException();

      public AttackType TwoHandedMaceClothDto() => throw new NotImplementedException();

      public AttackType TwoHandedMaceLeatherDto() => throw new NotImplementedException();

      public AttackType TwoHandedMacePlateDto() => throw new NotImplementedException();

      public WeaponType TwoHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType TwoHandedPolearmChainmailDto() => throw new NotImplementedException();

      public AttackType TwoHandedPolearmClothDto() => throw new NotImplementedException();

      public AttackType TwoHandedPolearmLeatherDto() => throw new NotImplementedException();

      public AttackType TwoHandedPolearmPlateDto() => throw new NotImplementedException();

      public WeaponType TwoHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => throw new NotImplementedException();

      public AttackType TwoHandedSwordChainmailDto() => throw new NotImplementedException();

      public AttackType TwoHandedSwordClothDto() => throw new NotImplementedException();

      public AttackType TwoHandedSwordLeatherDto() => throw new NotImplementedException();

      public AttackType TwoHandedSwordPlateDto() => throw new NotImplementedException();
   }
}