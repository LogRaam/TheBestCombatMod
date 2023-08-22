// Code written by Gabriel Mailhot, 12/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Common;
using TheBestCombatMod.Factories;
using TheBestCombatMod.Features.Knocked;
using TheBestCombatMod.Features.Knocked.Values;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod
{
   public class Runtime
   {
      static Runtime()
      {
         Get = new TBCMFactory();

         Loader = Get.ConfigurationLoader();
         LoadedOptions = Get.OptionFileContent();

         StaggerStrength = new StaggerStrengthValue(LoadedOptions.GetContent());
         Resistance = new ResistanceValue(LoadedOptions.GetContent());

         BodyPartUnseatStaggerValue = new BodyPartUnseatStaggerValue(LoadedOptions.GetContent());
         ImpactUnseatChanceValue = new ImpactUnseatChanceValue(LoadedOptions.GetContent());

         ArmorCharacteristics = new ArmorCharacteristics();
         UnseatContextualAdditionalValue = new UnseatContextualAdditionalValue(LoadedOptions.GetContent());
         DecideAgentDismountedByBlow = new DecideAgentUnseatByBlowFeature();
         FileInteraction = new FileInteraction(Loader.GetOptionFilePath());
         ImpactDismountChance = new UnseatProbability();
         UnseatOptions = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());
         WeaponStaggerForceValue = new WeaponStaggerForceValue(LoadedOptions.GetContent());
         DecideAgentKnockedDownByBlow = new DecideAgentKnockedDownByBlowFeature();
         KnockDownStrenghtValue = new KnockDownStrenghtValue(LoadedOptions.GetContent());
      }

      public static ArmorCharacteristics ArmorCharacteristics { get; private set; }
      public static BodyPartUnseatStaggerValue BodyPartUnseatStaggerValue { get; private set; }
      public static DecideAgentUnseatByBlowFeature DecideAgentDismountedByBlow { get; private set; }
      public static DecideAgentKnockedDownByBlowFeature DecideAgentKnockedDownByBlow { get; private set; }
      public static FileInteraction FileInteraction { get; set; }

      public static ITBCMFactory Get { get; }
      public static UnseatProbability ImpactDismountChance { get; private set; }
      public static ImpactUnseatChanceValue ImpactUnseatChanceValue { get; private set; }
      public static KnockDownStrenghtValue KnockDownStrenghtValue { get; set; }
      public static IOptionFileContent LoadedOptions { get; set; }
      public static IConfigurationLoader Loader { get; set; }
      public static ResistanceValue Resistance { get; private set; }
      public static StaggerStrengthValue StaggerStrength { get; set; }
      public static UnseatContextualAdditionalValue UnseatContextualAdditionalValue { get; private set; }
      public static UnseatByBlowOptions UnseatOptions { get; private set; }
      public static WeaponStaggerForceValue WeaponStaggerForceValue { get; private set; }

      public static void Update(IConfigurationLoader loader)
      {
         Loader = loader;
         LoadedOptions = new OptionFileContent(Loader);

         StaggerStrength = new StaggerStrengthValue(LoadedOptions.GetContent());
         Resistance = new ResistanceValue(LoadedOptions.GetContent());

         BodyPartUnseatStaggerValue = new BodyPartUnseatStaggerValue(LoadedOptions.GetContent());
         ImpactUnseatChanceValue = new ImpactUnseatChanceValue(LoadedOptions.GetContent());

         UnseatContextualAdditionalValue = new UnseatContextualAdditionalValue(LoadedOptions.GetContent());
         DecideAgentDismountedByBlow = new DecideAgentUnseatByBlowFeature();
         FileInteraction = new FileInteraction(Loader.GetOptionFilePath());
         ImpactDismountChance = new UnseatProbability();
         UnseatOptions = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());
         WeaponStaggerForceValue = new WeaponStaggerForceValue(LoadedOptions.GetContent());
         DecideAgentKnockedDownByBlow = new DecideAgentKnockedDownByBlowFeature();
         KnockDownStrenghtValue = new KnockDownStrenghtValue(LoadedOptions.GetContent());
      }
   }
}