// Code written by Gabriel Mailhot, 28/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod
{
   public class Runtime
   {
      static Runtime()
      {
         Get = new ModFactory();
         Init();
      }

      public static AttackerOptions AttackerOptions { get; private set; }
      public static UnseatFeature DecideAgentDismountedByBlow { get; private set; }
      public static KnockedDownFeature DecideAgentKnockedDownByBlowKnockedDown { get; private set; }
      public static SituationalDefenseInfo DefenseInfo { get; private set; }
      public static FileTimeStamp FileInteraction { get; set; }
      public static Factory Get { get; set; }
      public static CombatActionEffect ImpactDismountChance { get; private set; }
      public static ImpactChanceOptions ImpactUnseatChanceValue { get; private set; }
      public static KnockDownStrengthOption KnockDownStrenghtValue { get; set; }
      public static OptionReader KnockedDownByBlowOptionsReader { get; set; }
      public static ImpactResistanceOptions KnockedDownImpactResistance { get; set; }
      public static OptionFileContent LoadedOptions { get; set; }
      public static ConfigurationLoader Loader { get; set; }
      public static StaggerStrengthOptions StaggerStrength { get; set; }
      public static BodyPartsVulnerabilityOptions UnseatBodyPartsVulnerabilityOptions { get; private set; }
      public static ImpactResistanceOptions UnseatImpactResistance { get; private set; }
      public static OptionReader UnseatOptionsReader { get; private set; }
      public static WeaponStaggerForce WeaponStaggerForceValue { get; private set; }


      public static void Update(ConfigurationLoader loader)
      {
         Loader = loader;
         LoadedOptions = Get.OptionFileContent(loader);
         Init();
      }


      public static void Update(Factory factory)
      {
         Get = factory;
      }

      #region private

      private static void ClearAllInstances()
      {
         //LoadedOptions = null;
         StaggerStrength = null;
         UnseatImpactResistance = null;
         UnseatBodyPartsVulnerabilityOptions = null;
         ImpactUnseatChanceValue = null;
         DefenseInfo = null;
         AttackerOptions = null;
         FileInteraction = null;
         ImpactDismountChance = null;
         UnseatOptionsReader = null;
         WeaponStaggerForceValue = null;
         DecideAgentKnockedDownByBlowKnockedDown = null;
         KnockDownStrenghtValue = null;
         DecideAgentDismountedByBlow = null;
      }

      private static void Init()
      {
         ClearAllInstances();
         Loader = Get.ConfigurationLoader;
         LoadedOptions = Get.Options;
         StaggerStrength = Get.UnseatStaggerStrengthOptions;
         UnseatImpactResistance = Get.UnseatResistanceOptions;
         KnockedDownImpactResistance = Get.KnockedDownImpactResistance;
         UnseatBodyPartsVulnerabilityOptions = Get.UnseatBodyPartsVulnerabilityOptions;
         if (LoadedOptions.GetContent().Length > 0) ImpactUnseatChanceValue = Get.ImpactUnseatChanceOptions;
         DefenseInfo = Get.DefenseInfo;
         AttackerOptions = Get.AttackerOptions;
         FileInteraction = Get.FileInteraction;
         ImpactDismountChance = Get.CombatActionEffect;
         UnseatOptionsReader = Get.UnseatByBlowOptionsReader;
         WeaponStaggerForceValue = Get.WeaponStaggerForceValue;
         DecideAgentKnockedDownByBlowKnockedDown = Get.DecideAgentKnockedDownByBlow;
         KnockDownStrenghtValue = Get.KnockDownStrengthOption;
         DecideAgentDismountedByBlow = Get.DecideAgentDismountedByBlow;
      }

      #endregion
   }
}