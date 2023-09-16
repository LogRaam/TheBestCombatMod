// Code written by Gabriel Mailhot, 28/08/2023.

#region

using System;
using LogRaamConfiguration;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TheBestCombatMod.Concept;
using TheBestCombatMod.Features;
using TheBestCombatMod.Features.KnockedDown;
using TheBestCombatMod.Features.KnockedDown.Body;
using TheBestCombatMod.Features.KnockedDown.Options;
using TheBestCombatMod.Features.Options;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Body;
using TheBestCombatMod.Features.Unseat.Options;
using TheBestCombatMod.Features.Weapon;

#endregion

namespace TheBestCombatMod
{
   internal class ModFactory : Factory
   {
      private BodyPart _abdomen;
      private KnockedDownFeature _agentKnockedDownByBlow;
      private ArmorResistance _armorMaterialUnseatResistance;
      private ArmorResistance _armorResistance;
      private BodyPart _arms;
      private AttackerOptions _attackerOptions;
      private BodyHitProbability _bodyHitKnockedDownProbability;
      private BodyHitProbability _bodyHitUnseatProbability;
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
      private ImpactUnseatChanceValueConstructorParams _impactUnseatChanceValue_params;
      private KnockedDownConfigConstructorParams _knockDownStrenght_params;
      private KnockDownStrengthOption _knockDownStrengthOption;
      private BodyPart _knockedDownAbdomen;
      private KnockedDownActivationValue _knockedDownActivationValues;
      private BodyPart _knockedDownArms;
      private BodyPartsVulnerabilityOptions _knockedDownBodyPartVulnerabilityOptions;
      private KnockedDownByBlowConfiguration _knockedDownByBlowConfig;
      private KnockedDownByBlowConfigurationConstructorParams _knockedDownByBlowConfigurationConstructor_params;
      private KnockedDownOptionReader _knockedDownByBlowOptionReader;
      private BodyPart _knockedDownChest;
      private BodyPart _knockedDownHead;
      private ImpactResistanceOptions _knockedDownImpactResistanceValue;
      private BodyPart _knockedDownLegs;
      private BodyPart _knockedDownNeck;
      private KnockedDownProbability _knockedDownProbability;
      private KnockedDownProbabilityConstructorParams _knockedDownProbabilityConstructor_params;
      private BodyPart _knockedDownShoulders;
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
      private UnseatOptionReader _unseatOptionReader;
      private WeaponStaggerForceValueConstructorParams _unseatOptions_params;
      private CombatActionEffect _unseatProbability;
      private UnseatProbabilityConstructorParams _unseatProbability_params;
      private ImpactResistanceOptions _unseatResistanceValue;
      private StaggerStrengthOptions _unseatStaggerStrengthOptions;
      private UnseatValue _unseatValue;
      private WeaponStaggerForce _weaponStaggerForceValue;

      public BodyPart AbdomenKnockedDownProbability
      {
         get => _knockedDownAbdomen ??= new AbdomenKnockedDownProbability();
         set => _knockedDownAbdomen = value;
      }

      public BodyPart AbdomenUnseatProbability
      {
         get => _abdomen ??= new AbdomenUnseatProbability();
         set => _abdomen = value;
      }


      public ArmorResistance ArmorMaterialResistance
      {
         get => _armorResistance ??= new ArmorMaterialResistance(LoadedOptions);
         set => _armorResistance = value;
      }


      public BodyPart ArmsKnockedDownProbability
      {
         get => _knockedDownArms ??= new ArmsKnockedDownProbability();
         set => _knockedDownArms = value;
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

      public BodyHitProbability BodyHitKnockedDownProbability
      {
         get => _bodyHitKnockedDownProbability ??= new BodyHitKnockedDownProbability();
         set => _bodyHitKnockedDownProbability = value;
      }

      public BodyHitProbability BodyHitUnseatProbability
      {
         get => _bodyHitUnseatProbability ??= new BodyHitUnseatProbability();
         set => _bodyHitUnseatProbability = value;
      }

      public BodyPartsVulnerabilityOptions BodyPartVulnerabilityOptions
      {
         get => _knockedDownBodyPartVulnerabilityOptions ??= new KnockedDownBodyPartVulnerabilityOptions(LoadedOptions);
         set => _knockedDownBodyPartVulnerabilityOptions = value;
      }

      public BodyPart ChestKnockedDownProbability
      {
         get => _knockedDownChest ??= new ChestKnockedDownProbability();
         set => _knockedDownChest = value;
      }

      public BodyPart ChestUnseatProbability
      {
         get => _chest ??= new ChestUnseatProbability();
         set => _chest = value;
      }

      public CombatActionEffect CombatActionEffect
      {
         get => _CombatActionEffect ??= new UnseatProbability(UnseatProbability_params);
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

      public BodyPart HeadKnockedDownProbability
      {
         get => _knockedDownHead ??= new HeadKnockedDownProbability();
         set => _knockedDownHead = value;
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
            if (LoadedOptions.Length > 0) _impactUnseatChanceOptions ??= new ImpactUnseatChanceValue(ImpactUnseatChanceValue_params);

            return _impactUnseatChanceOptions;
         }
         set => _impactUnseatChanceOptions = value;
      }

      public ImpactUnseatChanceValueConstructorParams ImpactUnseatChanceValue_params
      {
         get => _impactUnseatChanceValue_params ??= new ImpactUnseatChanceValue_params(LoadedOptions, ConfigurationLoader, UnseatByBlowOptionsReader, UnseatStaggerStrengthOptions);
         set => _impactUnseatChanceValue_params = value;
      }

      public KnockedDownConfigConstructorParams KnockDownStrenght_params
      {
         get => _knockDownStrenght_params ??= new KnockedDownConfig_params(LoadedOptions, ConfigurationLoader, KnockedDownValues);
         set => _knockDownStrenght_params = value;
      }


      public KnockDownStrengthOption KnockDownStrengthOption
      {
         get
         {
            if (LoadedOptions.Length > 0) _knockDownStrengthOption ??= new KnockDownStrenghtValue(KnockDownStrenght_params);

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
         get => _knockedDownByBlowConfig ??= new KnockedDownByBlowConfiguration(KnockedDownByBlowConfiguration_params);
         set => _knockedDownByBlowConfig = value;
      }

      public KnockedDownByBlowConfigurationConstructorParams KnockedDownByBlowConfiguration_params
      {
         get => _knockedDownByBlowConfigurationConstructor_params ??= new KnockedDownByBlowConfiguration_params(
            /*DefaultOptionReader(),*/
            KnockedDownActivationValues,
            KnockedDownValues,
            GlobalActivationValues,
            GlobalValues,
            ConfigurationLoader,
            UnseatImpactResistanceValue, //todo: Unseat?
            UnseatStaggerStrengthOptions,
            KnockDownStrengthOption
         );
         set => _knockedDownByBlowConfigurationConstructor_params = value;
      }

      public KnockedDownOptionReader KnockedDownByBlowOptionReader
      {
         //todo:KnockedDownImpactResistanceValue may be the wrong class
         get => _knockedDownByBlowOptionReader ??= new KnockedDownOptionsReader(DefaultOptionReader(), KnockedDownActivationValues, KnockedDownValues, GlobalActivationValues, GlobalValues);
         set => _knockedDownByBlowOptionReader = value;
      }

      public ImpactResistanceOptions KnockedDownImpactResistance
      {
         get
         {
            if (LoadedOptions.Length > 0) _knockedDownImpactResistanceValue ??= new KnockedDownImpactResistanceValue(LoadedOptions);

            return _knockedDownImpactResistanceValue;
         }
         set => _knockedDownImpactResistanceValue = value;
      }

      public KnockedDownProbability KnockedDownProbability
      {
         get => _knockedDownProbability ??= new KnockedDownProbability(KnockedDownProbability_params);
         set => _knockedDownProbability = value;
      }

      public KnockedDownProbabilityConstructorParams KnockedDownProbability_params
      {
         get => _knockedDownProbabilityConstructor_params ??= new KnockedDownProbability_params
         {
            LoadedOptions = LoadedOptions,
            KnockedDownByBlowConfiguration = KnockedDownByBlowConfiguration,
            DefenseInfo = DefenseInfo,
            BodyHitProbability = BodyHitKnockedDownProbability,
            BodyPartsVulnerabilityOptions = BodyPartVulnerabilityOptions,
            KnockedDownOptionReader = KnockedDownByBlowOptionReader
         };
         set => _knockedDownProbabilityConstructor_params = value;
      }

      public KnockedDownValue KnockedDownValues
      {
         get => _knockedDownValues ??= new KnockedDownValuesRefTag();
         set => _knockedDownValues = value;
      }

      public BodyPart LegsKnockedDownProbability
      {
         get => _knockedDownLegs ??= new LegsKnockedDownProbability();
         set => _knockedDownLegs = value;
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

      public BodyPart NeckKnockedDownProbability
      {
         get => _knockedDownNeck ??= new NeckKnockedDownProbability();
         set => _knockedDownNeck = value;
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

      public BodyPart ShouldersKnockedDownProbability
      {
         get => _knockedDownShoulders ??= new ShouldersKnockedDownProbability();
         set => _knockedDownShoulders = value;
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

      public UnseatOptionReader UnseatByBlowOptionsReader
      {
         get => _unseatOptionReader ??= new UnseatByBlowOptionsReader(DefaultOptionReader(), UnseatActivationValues, UnseatValues, GlobalActivationValues, GlobalValues);
         set => _unseatOptionReader = value;
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

      public CombatActionEffect UnseatProbability
      {
         get => _unseatProbability ??= new UnseatProbability(UnseatProbability_params);
         set => _unseatProbability = value;
      }

      public UnseatProbabilityConstructorParams UnseatProbability_params
      {
         get => _unseatProbability_params ??= new UnseatProbability_params
         {
            LoadedOptions = LoadedOptions,
            BodyHitProbability = BodyHitUnseatProbability,
            BodyPartsVulnerabilityOptions = UnseatBodyPartsVulnerabilityOptions,
            DefenseInfo = ProtectionInfo,
            Reader = UnseatByBlowOptionsReader
         };

         set => _unseatProbability_params = value;
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


      public UnseatValue UnseatValues
      {
         get => _unseatValue ??= new UnseatValueRefTag();
         set => _unseatValue = value;
      }

      public WeaponStaggerForce WeaponStaggerForceValue
      {
         get
         {
            if (LoadedOptions.Length > 0) _weaponStaggerForceValue ??= new WeaponStaggerForceValue(WeaponStaggerForceValue_params);

            return _weaponStaggerForceValue;
         }
         set => _weaponStaggerForceValue = value;
      }

      public WeaponStaggerForceValueConstructorParams WeaponStaggerForceValue_params
      {
         get => _unseatOptions_params ??= new WeaponStaggerForceValue_params(LoadedOptions, UnseatByBlowOptionsReader);
         set => _unseatOptions_params = value;
      }

      public WeaponType Dagger(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Dagger(in strikeType, in damageType, in materialType);


      public OptionReader DefaultOptionReader() => new DefaultOptionReader();

      public WeaponType Javelin(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Javelin(in strikeType, in damageType, in materialType);


      public WeaponType OneHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedAxe(in strikeType, in damageType, in materialType);


      public WeaponType OneHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedPolearm(in strikeType, in damageType, in materialType);


      public WeaponType OneHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedSword(in strikeType, in damageType, in materialType);


      public WeaponType OneHandedUnseatMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedMace(in strikeType, in damageType, in materialType);


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

      public AttackType TwoHandedMaceChainmailKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL_G8aSx_KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL_N4bTy_KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL_L5zRz_KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL_S2yQy_KNOCKEDDOWN_Value
         };

         return result;
      }


      public AttackType TwoHandedMaceChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL_mJ2hU_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL_lR5zH_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL_jG8xT_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL_aG6xI_Value
         };

         return result;
      }

      public AttackType TwoHandedMaceClothKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE_K6eWy_KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_PLATE_H9fXz_KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE_M3dVx_KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE_T7cUz_KNOCKEDDOWN_Value
         };

         return result;
      }


      public WeaponType TwoHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedPolearm(in strikeType, in damageType, in materialType);


      public WeaponType TwoHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedSword(in strikeType, in damageType, in materialType);
   }
}