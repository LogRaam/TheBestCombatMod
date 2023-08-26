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
      AttackerOptions AttackerOptions { get; set; }
      CombatActionEffect CombatActionEffect { get; set; }
      ICampaignBehavior ConfigurationBehavior { get; set; }
      ConfigurationLoader ConfigurationLoader { get; set; }
      UnseatFeature DecideAgentDismountedByBlow { get; set; }
      KnockedDownFeature DecideAgentKnockedDownByBlow { get; set; }
      SituationalDefenseInfo DefenseInfo { get; set; }
      FileTimeStamp FileInteraction { get; set; }
      ImpactChanceOptions ImpactUnseatChanceOptions { get; set; }
      KnockDownStrengthOption KnockDownStrengthOption { get; set; }
      KnockedDownByBlowConfiguration KnockedDownByBlowConfiguration { get; set; }
      KnockedDownProbability KnockedDownProbability { get; set; }
      OptionFileContent Options { get; set; }
      SituationalDefenseInfo ProtectionInfo { get; set; }
      MBFastRandom Random { get; set; }
      BodyPartsVulnerabilityOptions UnseatBodyPartsVulnerabilityOptions { get; set; }
      UnseatOptionReader UnseatOptionReader { get; set; }
      CombatActionEffect UnseatProbability { get; set; }
      ImpactResistanceOptions UnseatResistanceOptions { get; set; }
      StaggerStrengthOptions UnseatStaggerStrengthOptions { get; set; }
      WeaponStaggerForce WeaponStaggerForceValue { get; set; }
      OptionFileContent OptionFileContent(ConfigurationLoader loader);
   }
}