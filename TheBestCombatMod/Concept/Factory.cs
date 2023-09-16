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

      WeaponType Javelin(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType OneHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType OneHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType OneHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType OneHandedUnseatMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      OptionFileContent OptionFileContent(ConfigurationLoader loader);
      WeaponType Pick(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType Stone(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType TwoHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType TwoHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType TwoHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);

      WeaponType TwoHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
   }
}