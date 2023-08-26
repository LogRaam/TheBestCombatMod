// Code written by Gabriel Mailhot, 24/08/2023.

#region

using System;
using LogRaamConfiguration;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;
using TheBestCombatMod.Features;
using TheBestCombatMod.Features.KnockedDown;
using TheBestCombatMod.Features.KnockedDown.Options;
using TheBestCombatMod.Features.Options;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Body;
using TheBestCombatMod.Features.Unseat.Options;
using TheBestCombatMod.Features.Unseat.Weapon;

#endregion

namespace TheBestCombatMod
{
   internal class ModFactory : Factory
   {
      private BodyPart _abdomen;
      private KnockedDownFeature _agentKnockedDownByBlow;
      private BodyPart _arms;
      private AttackerOptions _attackerOptions;
      private BodyPart _chest;
      private CombatActionEffect _CombatActionEffect;
      private ICampaignBehavior _configurationBehavior;
      private ConfigurationLoader _configurationLoader;
      private UnseatFeature _decideAgentDismountedByBlow;
      private OptionReader _defaultOptionReader;
      private FileTimeStamp _fileInteraction;
      private GlobalActivationValue _globalUnseatActivationRefTagValue;
      private GlobalValueRefTag _globalValueRefTag;
      private BodyPart _head;
      private ImpactChanceOptions _impactUnseatChanceOptions;
      private KnockDownStrengthOption _knockDownStrengthOption;
      private KnockedDownActivationValue _knockedDownActivationValues;
      private KnockedDownByBlowConfiguration _knockedDownByBlowConfig;
      private KnockedDownProbability _knockedDownProbability;
      private KnockedDownValue _knockedDownValues;
      private BodyPart _legs;
      private string[] _loadedOptions = Array.Empty<string>();
      private BodyPart _neck;
      private OptionFileContent _optionFileContent;
      private SituationalDefenseInfo _protectionInfo;
      private MBFastRandom _random;
      private BodyPart _shoulders;
      private SituationalDefenseInfo _situationalDefenseInfo;
      private StaggerStrengthOptions _staggerStrengthValue;
      private UnseatActivationValue _unseatActivationRefTag;
      private BodyPartsVulnerabilityOptions _unseatBodyPartsVulnerabilityOptions;
      private UnseatFeature _unseatFeature;
      private UnseatOptionReader _unseatOptionReader;
      private CombatActionEffect _unseatProbability;
      private ImpactResistanceOptions _unseatResistanceValue;
      private StaggerStrengthOptions _unseatStaggerStrengthOptions;
      private UnseatValue _unseatValue;
      private WeaponStaggerForce _weaponStaggerForceValue;

      public BodyPart AbdomenUnseatProbability
      {
         get => _abdomen ??= new AbdomenUnseatProbability();
         set => _abdomen = value;
      }

      public BodyPart ArmsUnseatProbability
      {
         get => _arms ??= new ArmsUnseatProbability();
         set => _arms = value;
      }

      public AttackerOptions AttackerOptions
      {
         get
         {
            if (LoadedOptions.Length > 0) _attackerOptions ??= new UnseatAttackerInfoValue(LoadedOptions);

            return _attackerOptions;
         }

         set => _attackerOptions = value;
      }

      public BodyPart ChestUnseatProbability
      {
         get => _chest ??= new ChestUnseatProbability();
         set => _chest = value;
      }

      public CombatActionEffect CombatActionEffect
      {
         get => _CombatActionEffect ??= new UnseatProbability();
         set => _CombatActionEffect = value;
      }

      public ICampaignBehavior ConfigurationBehavior
      {
         get => _configurationBehavior ??= new ConfigurationBehavior();
         set => _configurationBehavior = value;
      }

      public ConfigurationLoader ConfigurationLoader
      {
         get => _configurationLoader ??= new ConfigLoader();
         set => _configurationLoader = value;
      }

      public UnseatFeature DecideAgentDismountedByBlow
      {
         get => _decideAgentDismountedByBlow ??= new DecideAgentUnseatByBlowFeature();
         set => _decideAgentDismountedByBlow = value;
      }

      public KnockedDownFeature DecideAgentKnockedDownByBlow
      {
         get => _agentKnockedDownByBlow ??= new FootmanKnockedDownByBlowFeature();
         set => _agentKnockedDownByBlow = value;
      }

      public OptionReader DefaultOptionReader
      {
         get => _defaultOptionReader ??= new DefaultOptionReader();
         set => _defaultOptionReader = value;
      }

      public SituationalDefenseInfo DefenseInfo
      {
         get => _situationalDefenseInfo ??= new ProtectionInfo();
         set => _situationalDefenseInfo = value;
      }

      public FileTimeStamp FileInteraction
      {
         get => _fileInteraction ??= new FileInteraction(ConfigurationLoader.GetOptionFilePath());
         set => _fileInteraction = value;
      }

      public GlobalActivationValue GlobalActivationValues
      {
         get => _globalUnseatActivationRefTagValue ??= new GlobalActivationRefTag();
         set => _globalUnseatActivationRefTagValue = value;
      }

      public GlobalValueRefTag GlobalValues
      {
         get => _globalValueRefTag ??= new GlobalUnseatValueRefTag();
         set => _globalValueRefTag = value;
      }

      public BodyPart HeadUnseatProbability
      {
         get => _head ??= new HeadUnseatProbability();
         set => _head = value;
      }

      public ImpactChanceOptions ImpactUnseatChanceOptions
      {
         get
         {
            if (LoadedOptions.Length > 0) _impactUnseatChanceOptions ??= new ImpactUnseatChanceValue(LoadedOptions);

            return _impactUnseatChanceOptions;
         }
         set => _impactUnseatChanceOptions = value;
      }

      public KnockDownStrengthOption KnockDownStrengthOption
      {
         get
         {
            if (LoadedOptions.Length > 0) _knockDownStrengthOption ??= new KnockDownStrenghtValue(LoadedOptions);

            return _knockDownStrengthOption;
         }
         set => _knockDownStrengthOption = value;
      }

      public KnockedDownActivationValue KnockedDownActivationValues
      {
         get => _knockedDownActivationValues ??= new KnockedDownActivationRefTag();
         set => _knockedDownActivationValues = value;
      }

      public KnockedDownByBlowConfiguration KnockedDownByBlowConfiguration
      {
         get => _knockedDownByBlowConfig ??= new KnockedDownByBlowConfiguration(DefaultOptionReader, KnockedDownActivationValues, KnockedDownValues, GlobalActivationValues, GlobalValues);
         set => _knockedDownByBlowConfig = value;
      }

      public KnockedDownProbability KnockedDownProbability
      {
         get => _knockedDownProbability ??= new KnockedDownProbability();
         set => _knockedDownProbability = value;
      }

      public KnockedDownValue KnockedDownValues
      {
         get => _knockedDownValues ??= new KnockedDownRefTag();
         set => _knockedDownValues = value;
      }

      public BodyPart LegsUnseatProbability
      {
         get => _legs ??= new LegsUnseatProbability();
         set => _legs = value;
      }

      public string[] LoadedOptions
      {
         get => _loadedOptions = ConfigurationLoader.RetrieveConfigDetails(ConfigurationLoader.GetOptionFilePath());
         set => _loadedOptions = value;
      }

      public BodyPart NeckUnseatProbability
      {
         get => _neck ??= new NeckUnseatProbability();
         set => _neck = value;
      }

      public OptionFileContent Options
      {
         get => _optionFileContent ??= new Options(ConfigurationLoader);
         set => _optionFileContent = value;
      }

      public SituationalDefenseInfo ProtectionInfo
      {
         get => _protectionInfo ??= new ProtectionInfo();
         set => _protectionInfo = value;
      }

      public MBFastRandom Random
      {
         get => _random ??= new MBFastRandom();
         set => _random = value;
      }

      public BodyPart ShouldersUnseatProbability
      {
         get => _shoulders ??= new ShouldersUnseatProbability();
         set => _shoulders = value;
      }

      public SituationalDefenseInfo SituationalDefenseInfo
      {
         get => _situationalDefenseInfo ??= new ProtectionInfo();
         set => _situationalDefenseInfo = value;
      }

      public UnseatActivationValue UnseatActivationValues
      {
         get => _unseatActivationRefTag ??= new UnseatActivationRefTag();
         set => _unseatActivationRefTag = value;
      }

      public BodyPartsVulnerabilityOptions UnseatBodyPartsVulnerabilityOptions
      {
         get
         {
            if (LoadedOptions.Length > 0) _unseatBodyPartsVulnerabilityOptions ??= new UnseatBodyPartsVulnerabilityOptions(LoadedOptions);

            return _unseatBodyPartsVulnerabilityOptions;
         }
         set => _unseatBodyPartsVulnerabilityOptions = value;
      }


      public ImpactResistanceOptions UnseatImpactResistanceValue
      {
         get
         {
            if (LoadedOptions.Length > 0) _unseatResistanceValue ??= new UnseatImpactResistanceValue(LoadedOptions);

            return _unseatResistanceValue;
         }
         set => _unseatResistanceValue = value;
      }

      public UnseatOptionReader UnseatOptionReader
      {
         get => _unseatOptionReader ??= new UnseatByBlowOptionsReader(DefaultOptionReader, UnseatActivationValues, UnseatValues, GlobalActivationValues, GlobalValues);
         set => _unseatOptionReader = value;
      }

      public CombatActionEffect UnseatProbability
      {
         get => _unseatProbability ??= new UnseatProbability();
         set => _unseatProbability = value;
      }

      public ImpactResistanceOptions UnseatResistanceOptions
      {
         get
         {
            if (LoadedOptions.Length > 0) _unseatResistanceValue ??= new UnseatImpactResistanceValue(LoadedOptions);

            return _unseatResistanceValue;
         }
         set => _unseatResistanceValue = value;
      }

      public StaggerStrengthOptions UnseatStaggerStrengthOptions
      {
         get
         {
            if (LoadedOptions.Length > 0) _unseatStaggerStrengthOptions ??= new UnseatStaggerStrengthOptionValues(LoadedOptions);

            return _unseatStaggerStrengthOptions;
         }
         set => _unseatStaggerStrengthOptions = value;
      }

      public StaggerStrengthOptions UnseatStaggerStrengthValue
      {
         get
         {
            if (LoadedOptions.Length > 0) _staggerStrengthValue ??= new UnseatStaggerStrengthOptionValues(LoadedOptions);

            return _staggerStrengthValue;
         }
         set => _staggerStrengthValue = value;
      }

      public UnseatValue UnseatValues
      {
         get => _unseatValue ??= new UnseatValueRefTag();
         set => _unseatValue = value;
      }

      public WeaponStaggerForce WeaponStaggerForceValue
      {
         get
         {
            if (LoadedOptions.Length > 0) _weaponStaggerForceValue ??= new WeaponStaggerForceValue(LoadedOptions);

            return _weaponStaggerForceValue;
         }
         set => _weaponStaggerForceValue = value;
      }

      public WeaponType Dagger(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Dagger(in strikeType, in damageType, in materialType);
      public WeaponType Javelin(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Javelin(in strikeType, in damageType, in materialType);
      public WeaponType OneHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedAxe(in strikeType, in damageType, in materialType);
      public WeaponType OneHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedMace(in strikeType, in damageType, in materialType);
      public WeaponType OneHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedPolearm(in strikeType, in damageType, in materialType);
      public WeaponType OneHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedSword(in strikeType, in damageType, in materialType);


      public OptionFileContent OptionFileContent(ConfigurationLoader loader)
      {
         _configurationLoader = loader;
         Options = new Options(loader);
         _loadedOptions = Options.GetContent();

         return Options;
      }

      public WeaponType Pick(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Pick(in strikeType, in damageType, in materialType);
      public WeaponType Stone(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Stone(in strikeType, in damageType, in materialType);
      public WeaponType TwoHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedAxe(in strikeType, in damageType, in materialType);
      public WeaponType TwoHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedMace(in strikeType, in damageType, in materialType);
      public WeaponType TwoHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedPolearm(in strikeType, in damageType, in materialType);
      public WeaponType TwoHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedSword(in strikeType, in damageType, in materialType);
   }
}