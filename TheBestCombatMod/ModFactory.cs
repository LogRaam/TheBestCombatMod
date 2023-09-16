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
      public AttackType DaggerChainmailKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType DaggerChainmailKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = Dagger(StrikeType.Swing, DamageTypes.Blunt, ArmorComponent.ArmorMaterialTypes.Chainmail) //KnockedDownByBlowOptionReader.KnockedDownValues.GetValuesFor(WeaponClass.Dagger, AttackMovement.SWING, DamageTypes.Blunt, ArmorComponent.ArmorMaterialTypes.Chainmail), // .DAGGER_SWING_BLUNT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_SWING_CUT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_THRUST_BLUNT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_THRUST_PIERCE_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value
         };

         return result;
      }
      */

      public AttackType DaggerChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.DAGGER_SWING_BLUNT_AGAINST_CHAINMAIL_zI7qM_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.DAGGER_SWING_CUT_AGAINST_CHAINMAIL_tY3rN_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.DAGGER_THRUST_BLUNT_AGAINST_CHAINMAIL_xU9eP_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.DAGGER_THRUST_PIERCE_AGAINST_CHAINMAIL_cG5vL_Value
         };

         return result;
      }

      public AttackType DaggerClothKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_SWING_BLUNT_AGAINST_CLOTH_0ZV6V_KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_SWING_CUT_AGAINST_CLOTH_UbH0U_KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_THRUST_BLUNT_AGAINST_CLOTH_54v8T_KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_THRUST_PIERCE_AGAINST_CLOTH_155we_KNOCKEDDOWN_Value
         };

         return result;
      }

      public AttackType DaggerClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.DAGGER_SWING_BLUNT_AGAINST_CLOTH_iM0qR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.DAGGER_SWING_CUT_AGAINST_CLOTH_J8s2F_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.DAGGER_THRUST_BLUNT_AGAINST_CLOTH_hN7Ye_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.DAGGER_THRUST_PIERCE_AGAINST_CLOTH_3HkLg_Value
         };

         return result;
      }

      public AttackType DaggerLeatherKnockedDownDto() => throw new NotImplementedException();

      /*
      public AttackType DaggerLeatherKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_SWING_BLUNT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_SWING_CUT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_THRUST_BLUNT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_THRUST_PIERCE_AGAINST_LEATHER__KNOCKEDDOWN_Value
         };

         return result;
      }
      */

      public AttackType DaggerLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.DAGGER_SWING_BLUNT_AGAINST_LEATHER_yA2wC_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.DAGGER_SWING_CUT_AGAINST_LEATHER_bD1mK_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.DAGGER_THRUST_BLUNT_AGAINST_LEATHER_fR6jP_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.DAGGER_THRUST_PIERCE_AGAINST_LEATHER_9sT4p_Value
         };

         return result;
      }

      public AttackType DaggerPlateKnockedDownDto() => throw new NotImplementedException();

      /*
      public AttackType DaggerPlateKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_SWING_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_SWING_CUT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_THRUST_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.DAGGER_THRUST_PIERCE_AGAINST_PLATE__KNOCKEDDOWN_Value
         };

         return result;
      }

      */

      public AttackType DaggerPlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.DAGGER_SWING_BLUNT_AGAINST_PLATE_qB4fS_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.DAGGER_SWING_CUT_AGAINST_PLATE_lO6wE_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.DAGGER_THRUST_BLUNT_AGAINST_PLATE_nZ8uR_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.DAGGER_THRUST_PIERCE_AGAINST_PLATE_vX2jD_Value
         };

         return result;
      }

      public OptionReader DefaultOptionReader() => new DefaultOptionReader();

      public WeaponType Javelin(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Javelin(in strikeType, in damageType, in materialType);
      public AttackType JavelinChainmailKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType JavelinChainmailKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_SWING_BLUNT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_SWING_CUT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_THRUST_BLUNT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_THRUST_PIERCE_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value
         };

         return result;
      }

        */


      public AttackType JavelinChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CHAINMAIL_pA3vR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CHAINMAIL_nB7eU_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CHAINMAIL_zD5tL_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CHAINMAIL_xF9cV_Value
         };

         return result;
      }

      public AttackType JavelinClothKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_SWING_BLUNT_AGAINST_CLOTH_yfRpp_KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_SWING_CUT_AGAINST_CLOTH_q7iqc_KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_g5MD1_KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_ztAYD_KNOCKEDDOWN_Value
         };

         return result;
      }

      public AttackType JavelinClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CLOTH_tA1vZ_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CLOTH_rN5uX_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_kY3gW_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_mC9dH_Value
         };

         return result;
      }

      public AttackType JavelinLeatherKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType JavelinLeatherKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_SWING_BLUNT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_SWING_CUT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_THRUST_BLUNT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_THRUST_PIERCE_AGAINST_LEATHER__KNOCKEDDOWN_Value
         };

         return result;
      }

        */

      public AttackType JavelinLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_LEATHER_yM4aI_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_SWING_CUT_AGAINST_LEATHER_iK6xO_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_LEATHER_sU7nJ_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_LEATHER_pE8bQ_Value
         };

         return result;
      }

      public AttackType JavelinPlateKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType JavelinPlateKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_SWING_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_SWING_CUT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_THRUST_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.JAVELIN_THRUST_PIERCE_AGAINST_PLATE__KNOCKEDDOWN_Value
         };

         return result;
      }

        */

      public AttackType JavelinPlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_PLATE_tZ7uO_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_SWING_CUT_AGAINST_PLATE_rC4dP_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_PLATE_mY8bF_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_PLATE_oX1wM_Value
         };

         return result;
      }

      public WeaponType OneHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedAxe(in strikeType, in damageType, in materialType);

      public AttackType OneHandedAxeChainmailKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CHAINMAIL_fIwtn_KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_CHAINMAIL_o3hJa_KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CHAINMAIL_4D4tg_KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CHAINMAIL_BCKTm_KNOCKEDDOWN_Value
         };

         return result;
      }

      public AttackType OneHandedAxeChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CHAINMAIL_mF2hZ_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_CHAINMAIL_rJ9xI_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CHAINMAIL_kM3dV_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CHAINMAIL_qU7gT_Value
         };

         return result;
      }

      public AttackType OneHandedAxeClothKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CLOTH_xiBqb_KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_CLOTH_4dfIj_KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CLOTH_NCHfy_KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CLOTH_7bEDm_KNOCKEDDOWN_Value
         };

         return result;
      }

      public AttackType OneHandedAxeClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CLOTH_yE7rP_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_CLOTH_nJ2hQ_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CLOTH_pC9xW_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CLOTH_hR6zK_Value
         };

         return result;
      }

      public AttackType OneHandedAxeLeatherKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_LEATHER_oTezN_KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_LEATHER_eB5NV_KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_LEATHER_efD8x_KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_LEATHER_f6gV5_KNOCKEDDOWN_Value
         };

         return result;
      }

      public AttackType OneHandedAxeLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_LEATHER_cD9fY_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_LEATHER_aT5zH_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_LEATHER_jN1xL_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_LEATHER_wB4mV_Value
         };

         return result;
      }

      public AttackType OneHandedAxePlateKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_PLATE_tYoRa_KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_PLATE_gQosN_KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_PLATE_8v6eF_KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_PLATE_jfxkn_KNOCKEDDOWN_Value
         };

         return result;
      }

      public AttackType OneHandedAxePlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_PLATE_vU7gQ_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_PLATE_tJ3hV_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_PLATE_lN8xG_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_PLATE_zB4mR_Value
         };

         return result;
      }

      public AttackType OneHandedMaceChainmailKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType OneHandedMaceChainmailKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL__KNOCKEDDOWN_Value
         };

         return result;
      }

        */

      public AttackType OneHandedMaceChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL_pF1wK_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL_jY7gI_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL_wD8eV_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL_aT2mZ_Value
         };

         return result;
      }

      public AttackType OneHandedMaceClothKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType OneHandedMaceClothKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE__KNOCKEDDOWN_Value
         };

         return result;
      }

        */


      public AttackType OneHandedMaceClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_CLOTH_uB9fS_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_CLOTH_mQ7aN_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_CLOTH_tE5rW_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_CLOTH_bN3hU_Value
         };

         return result;
      }

      public AttackType OneHandedMaceLeatherKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType OneHandedMaceLeatherKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_LEATHER__KNOCKEDDOWN_Value
         };

         return result;
      }

        */

      public AttackType OneHandedMaceLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_LEATHER_hR5vQ_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_LEATHER_qJ9cK_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_LEATHER_kP6xH_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_LEATHER_gM4zD_Value
         };

         return result;
      }

      public AttackType OneHandedMacePlateKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType OneHandedMacePlateKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE__KNOCKEDDOWN_Value
         };

         return result;
      }

        */

      public AttackType OneHandedMacePlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE_lA8hY_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_PLATE_zE3dX_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE_vB9fQ_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE_nC6zT_Value
         };

         return result;
      }

      public WeaponType OneHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedPolearm(in strikeType, in damageType, in materialType);

      public AttackType OneHandedPolearmChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_CHAINMAIL_sR4zT_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_CHAINMAIL_tA8hK_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CHAINMAIL_mC6xV_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CHAINMAIL_nE2dG_Value
         };

         return result;
      }

      public AttackType OneHandedPolearmClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_CLOTH_sJ4hQ_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_CLOTH_lM2dH_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CLOTH_kC9xT_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CLOTH_dR6zE_Value
         };

         return result;
      }

      public AttackType OneHandedPolearmLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_LEATHER_aF5zT_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_LEATHER_eJ9xI_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_LEATHER_xM3zV_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_LEATHER_rU7gK_Value
         };

         return result;
      }

      public AttackType OneHandedPolearmPlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_PLATE_qM5zE_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_PLATE_hU9gT_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_PLATE_bT2dK_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_PLATE_yE6xJ_Value
         };

         return result;
      }

      public WeaponType OneHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedSword(in strikeType, in damageType, in materialType);

      public AttackType OneHandedSwordChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_SWING_BLUNT_AGAINST_CHAINMAIL_RgN3k_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_SWING_CUT_AGAINST_CHAINMAIL_UdBiS_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_THRUST_BLUNT_AGAINST_CHAINMAIL_Unb84_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_THRUST_PIERCE_AGAINST_CHAINMAIL_2Ng91_Value
         };

         return result;
      }

      public AttackType OneHandedSwordClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_SWING_BLUNT_AGAINST_CLOTH_64Lhv_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_SWING_CUT_AGAINST_CLOTH_U1GgF_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_THRUST_BLUNT_AGAINST_CLOTH_oGmnS_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_THRUST_PIERCE_AGAINST_CLOTH_kWNK9_Value
         };

         return result;
      }

      public AttackType OneHandedSwordLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_SWING_BLUNT_AGAINST_LEATHER_tiuYy_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_SWING_CUT_AGAINST_LEATHER_HXuje_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_THRUST_BLUNT_AGAINST_LEATHER_ljFbE_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_THRUST_PIERCE_AGAINST_LEATHER_txKI6_Value
         };

         return result;
      }

      public AttackType OneHandedSwordPlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_SWING_BLUNT_AGAINST_PLATE_qLDxk_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_SWING_CUT_AGAINST_PLATE_jgMZR_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_THRUST_BLUNT_AGAINST_PLATE_9DpM5_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.ONE_HANDED_SWORD_THRUST_PIERCE_AGAINST_PLATE_GDD4U_Value
         };

         return result;
      }

      public WeaponType OneHandedUnseatMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedMace(in strikeType, in damageType, in materialType);


      public OptionFileContent OptionFileContent(ConfigurationLoader loader)
      {
         _configurationLoader = loader;
         Options = new Options(loader);
         _loadedOptions = Options.GetContent();

         return Options;
      }

      public WeaponType Pick(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Pick(in strikeType, in damageType, in materialType);


      public AttackType PickChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.PICK_SWING_BLUNT_AGAINST_CHAINMAIL_kF9cR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.PICK_SWING_CUT_AGAINST_CHAINMAIL_xU3gA_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.PICK_THRUST_BLUNT_AGAINST_CHAINMAIL_aN8xS_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.PICK_THRUST_PIERCE_AGAINST_CHAINMAIL_eB4mW_Value
         };

         return result;
      }

      public AttackType PickClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.PICK_SWING_BLUNT_AGAINST_CLOTH_yB7gR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.PICK_SWING_CUT_AGAINST_CLOTH_nF5zV_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.PICK_THRUST_BLUNT_AGAINST_CLOTH_qM2dA_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.PICK_THRUST_PIERCE_AGAINST_CLOTH_xC9xT_Value
         };

         return result;
      }

      public AttackType PickLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.PICK_SWING_BLUNT_AGAINST_LEATHER_sU5zH_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.PICK_SWING_CUT_AGAINST_LEATHER_bJ2hT_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.PICK_THRUST_BLUNT_AGAINST_LEATHER_pC9xV_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.PICK_THRUST_PIERCE_AGAINST_LEATHER_tR6zE_Value
         };

         return result;
      }

      public AttackType PickPlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.PICK_SWING_BLUNT_AGAINST_PLATE_lA8hY_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.PICK_SWING_CUT_AGAINST_PLATE_zE3dX_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.PICK_THRUST_BLUNT_AGAINST_PLATE_vB9fQ_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.PICK_THRUST_PIERCE_AGAINST_PLATE_nC6zT_Value
         };

         return result;
      }

      public WeaponType Stone(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Stone(in strikeType, in damageType, in materialType);

      public AttackType StoneChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.STONE_SWING_BLUNT_AGAINST_CHAINMAIL_bQ5zE_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.STONE_SWING_CUT_AGAINST_CHAINMAIL_aU9gR_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.STONE_THRUST_BLUNT_AGAINST_CHAINMAIL_fM4zG_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.STONE_THRUST_PIERCE_AGAINST_CHAINMAIL_dE7rQ_Value
         };

         return result;
      }

      public AttackType StoneClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.STONE_SWING_BLUNT_AGAINST_CLOTH_kE9xR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.STONE_SWING_CUT_AGAINST_CLOTH_jN5uG_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.STONE_THRUST_BLUNT_AGAINST_CLOTH_zC8xI_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.STONE_THRUST_PIERCE_AGAINST_CLOTH_fG4zW_Value
         };

         return result;
      }

      public AttackType StoneLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.STONE_SWING_BLUNT_AGAINST_LEATHER_uN9gS_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.STONE_SWING_CUT_AGAINST_LEATHER_pC3xV_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.STONE_THRUST_BLUNT_AGAINST_LEATHER_rY8nA_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.STONE_THRUST_PIERCE_AGAINST_LEATHER_qH4zP_Value
         };

         return result;
      }

      public AttackType StonePlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.STONE_SWING_BLUNT_AGAINST_PLATE_kN4zI_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.STONE_SWING_CUT_AGAINST_PLATE_zC8xG_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.STONE_THRUST_BLUNT_AGAINST_PLATE_nY3hA_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.STONE_THRUST_PIERCE_AGAINST_PLATE_tH7xQ_Value
         };

         return result;
      }

      public WeaponType TwoHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedAxe(in strikeType, in damageType, in materialType);

      public AttackType TwoHandedAxeChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_CHAINMAIL_tQ5zR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_CHAINMAIL_aH8xV_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_CHAINMAIL_rT3zG_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_CHAINMAIL_bN4zT_Value
         };

         return result;
      }

      public AttackType TwoHandedAxeClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_CLOTH_mT8xU_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_CLOTH_sN4zR_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_CLOTH_kD9xL_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_CLOTH_fU5zH_Value
         };

         return result;
      }

      public AttackType TwoHandedAxeLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_LEATHER_nC9xI_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_LEATHER_wG6xR_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_LEATHER_tH3zA_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_LEATHER_vE7gV_Value
         };

         return result;
      }

      public AttackType TwoHandedAxePlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_PLATE_dH7gV_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_PLATE_iE8xL_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_PLATE_fT4zA_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_PLATE_sU9gH_Value
         };

         return result;
      }

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

      public AttackType TwoHandedMaceClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CLOTH_gU5zV_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_CLOTH_qH8xG_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CLOTH_bN4zA_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CLOTH_zD9xT_Value
         };

         return result;
      }

      public AttackType TwoHandedMaceLeatherKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType TwoHandedMaceLeatherKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_LEATHER__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_LEATHER__KNOCKEDDOWN_Value
         };

         return result;
      }

        */

      public AttackType TwoHandedMaceLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_LEATHER_kT3zR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_LEATHER_mH7gA_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_LEATHER_zE9xL_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_LEATHER_wT4zE_Value
         };

         return result;
      }

      public AttackType TwoHandedMacePlateKnockedDownDto() => throw new NotImplementedException();


      /*
      public AttackType TwoHandedMacePlateKnockedDownDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Swing_Cut = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Blunt = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE__KNOCKEDDOWN_Value,
            Thrust_Pierce = KnockedDownByBlowOptionReader.KnockedDownValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE__KNOCKEDDOWN_Value
         };

         return result;
      }

        */


      public AttackType TwoHandedMacePlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE_pS5zE_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_PLATE_jC9xR_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE_dU6xV_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE_bH4zG_Value
         };

         return result;
      }

      public WeaponType TwoHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedPolearm(in strikeType, in damageType, in materialType);

      public AttackType TwoHandedPolearmChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_CHAINMAIL_lJ2hT_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_CHAINMAIL_fR5zA_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CHAINMAIL_pG8xV_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CHAINMAIL_kG6xU_Value
         };

         return result;
      }

      public AttackType TwoHandedPolearmClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_CLOTH_vH8xR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_CLOTH_mD4zE_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CLOTH_yN7xL_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CLOTH_zH4zW_Value
         };

         return result;
      }

      public AttackType TwoHandedPolearmLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_LEATHER_yT3zH_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_LEATHER_bE7gA_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_LEATHER_gN4zG_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_LEATHER_cT9xI_Value
         };

         return result;
      }

      public AttackType TwoHandedPolearmPlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_PLATE_kD3zA_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_PLATE_rN9gR_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_PLATE_mH6xV_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_PLATE_eS4zG_Value
         };

         return result;
      }

      public WeaponType TwoHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedSword(in strikeType, in damageType, in materialType);

      public AttackType TwoHandedSwordChainmailUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_CHAINMAIL_dH8xT_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_CHAINMAIL_yN7xI_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_CHAINMAIL_fE4zR_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_CHAINMAIL_aT9xL_Value
         };

         return result;
      }

      public AttackType TwoHandedSwordClothUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_CLOTH_dH8xR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_CLOTH_yN7xG_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_CLOTH_nE4zA_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_CLOTH_wT9xP_Value
         };

         return result;
      }

      public AttackType TwoHandedSwordLeatherUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_LEATHER_lH8xV_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_LEATHER_tN7xH_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_LEATHER_xE4zG_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_LEATHER_wT9xT_Value
         };

         return result;
      }

      public AttackType TwoHandedSwordPlateUnseatDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_PLATE_lH8xR_Value,
            Swing_Cut = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_PLATE_tN7xL_Value,
            Thrust_Blunt = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_PLATE_xE4zH_Value,
            Thrust_Pierce = UnseatByBlowOptionsReader.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_PLATE_wT9xG_Value
         };

         return result;
      }
   }
}