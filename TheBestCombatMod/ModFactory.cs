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
using TheBestCombatMod.Features.Unseat.Armor;
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
      private ArmorResistance _armorMaterialUnseatResistance;
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

      public ArmorResistance ArmorMaterialUnseatResistance
      {
         get => _armorMaterialUnseatResistance ??= new ArmorMaterialUnseatResistance(LoadedOptions);
         set => _armorMaterialUnseatResistance = value;
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

      public AttackType DaggerChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.DAGGER_SWING_BLUNT_AGAINST_CHAINMAIL_zI7qM_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.DAGGER_SWING_CUT_AGAINST_CHAINMAIL_tY3rN_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.DAGGER_THRUST_BLUNT_AGAINST_CHAINMAIL_xU9eP_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.DAGGER_THRUST_PIERCE_AGAINST_CHAINMAIL_cG5vL_Value
         };

         return result;
      }

      public AttackType DaggerClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.DAGGER_SWING_BLUNT_AGAINST_CLOTH_iM0qR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.DAGGER_SWING_CUT_AGAINST_CLOTH_J8s2F_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.DAGGER_THRUST_BLUNT_AGAINST_CLOTH_hN7Ye_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.DAGGER_THRUST_PIERCE_AGAINST_CLOTH_3HkLg_Value
         };

         return result;
      }

      public AttackType DaggerLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.DAGGER_SWING_BLUNT_AGAINST_LEATHER_yA2wC_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.DAGGER_SWING_CUT_AGAINST_LEATHER_bD1mK_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.DAGGER_THRUST_BLUNT_AGAINST_LEATHER_fR6jP_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.DAGGER_THRUST_PIERCE_AGAINST_LEATHER_9sT4p_Value
         };

         return result;
      }

      public AttackType DaggerPlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.DAGGER_SWING_BLUNT_AGAINST_PLATE_qB4fS_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.DAGGER_SWING_CUT_AGAINST_PLATE_lO6wE_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.DAGGER_THRUST_BLUNT_AGAINST_PLATE_nZ8uR_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.DAGGER_THRUST_PIERCE_AGAINST_PLATE_vX2jD_Value
         };

         return result;
      }

      public WeaponType Javelin(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Javelin(in strikeType, in damageType, in materialType);

      public AttackType JavelinChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CHAINMAIL_pA3vR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CHAINMAIL_nB7eU_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CHAINMAIL_zD5tL_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CHAINMAIL_xF9cV_Value
         };

         return result;
      }

      public AttackType JavelinClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_CLOTH_tA1vZ_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.JAVELIN_SWING_CUT_AGAINST_CLOTH_rN5uX_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_CLOTH_kY3gW_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_CLOTH_mC9dH_Value
         };

         return result;
      }

      public AttackType JavelinLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_LEATHER_yM4aI_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.JAVELIN_SWING_CUT_AGAINST_LEATHER_iK6xO_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_LEATHER_sU7nJ_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_LEATHER_pE8bQ_Value
         };

         return result;
      }

      public AttackType JavelinPlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.JAVELIN_SWING_BLUNT_AGAINST_PLATE_tZ7uO_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.JAVELIN_SWING_CUT_AGAINST_PLATE_rC4dP_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.JAVELIN_THRUST_BLUNT_AGAINST_PLATE_mY8bF_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.JAVELIN_THRUST_PIERCE_AGAINST_PLATE_oX1wM_Value
         };

         return result;
      }

      public WeaponType OneHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedAxe(in strikeType, in damageType, in materialType);

      public AttackType OneHandedAxeChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CHAINMAIL_mF2hZ_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_CHAINMAIL_rJ9xI_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CHAINMAIL_kM3dV_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CHAINMAIL_qU7gT_Value
         };

         return result;
      }

      public AttackType OneHandedAxeClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_CLOTH_yE7rP_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_CLOTH_nJ2hQ_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_CLOTH_pC9xW_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_CLOTH_hR6zK_Value
         };

         return result;
      }

      public AttackType OneHandedAxeLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_LEATHER_cD9fY_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_LEATHER_aT5zH_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_LEATHER_jN1xL_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_LEATHER_wB4mV_Value
         };

         return result;
      }

      public AttackType OneHandedAxePlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_SWING_BLUNT_AGAINST_PLATE_vU7gQ_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_SWING_CUT_AGAINST_PLATE_tJ3hV_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_THRUST_BLUNT_AGAINST_PLATE_lN8xG_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_AXE_THRUST_PIERCE_AGAINST_PLATE_zB4mR_Value
         };

         return result;
      }

      public WeaponType OneHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedMace(in strikeType, in damageType, in materialType);

      public AttackType OneHandedMaceChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL_pF1wK_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL_jY7gI_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL_wD8eV_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL_aT2mZ_Value
         };

         return result;
      }

      public AttackType OneHandedMaceClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_CLOTH_uB9fS_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_CLOTH_mQ7aN_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_CLOTH_tE5rW_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_CLOTH_bN3hU_Value
         };

         return result;
      }

      public AttackType OneHandedMaceLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_LEATHER_hR5vQ_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_LEATHER_qJ9cK_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_LEATHER_kP6xH_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_LEATHER_gM4zD_Value
         };

         return result;
      }

      public AttackType OneHandedMacePlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE_lA8hY_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_SWING_CUT_AGAINST_PLATE_zE3dX_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE_vB9fQ_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE_nC6zT_Value
         };

         return result;
      }

      public WeaponType OneHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedPolearm(in strikeType, in damageType, in materialType);

      public AttackType OneHandedPolearmChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_CHAINMAIL_sR4zT_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_CHAINMAIL_tA8hK_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CHAINMAIL_mC6xV_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CHAINMAIL_nE2dG_Value
         };

         return result;
      }

      public AttackType OneHandedPolearmClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_CLOTH_sJ4hQ_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_CLOTH_lM2dH_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CLOTH_kC9xT_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CLOTH_dR6zE_Value
         };

         return result;
      }

      public AttackType OneHandedPolearmLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_LEATHER_aF5zT_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_LEATHER_eJ9xI_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_LEATHER_xM3zV_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_LEATHER_rU7gK_Value
         };

         return result;
      }

      public AttackType OneHandedPolearmPlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_SWING_BLUNT_AGAINST_PLATE_qM5zE_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_SWING_CUT_AGAINST_PLATE_hU9gT_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_BLUNT_AGAINST_PLATE_bT2dK_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_POLEARM_THRUST_PIERCE_AGAINST_PLATE_yE6xJ_Value
         };

         return result;
      }

      public WeaponType OneHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new OneHandedSword(in strikeType, in damageType, in materialType);

      public AttackType OneHandedSwordChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_SWING_BLUNT_AGAINST_CHAINMAIL_RgN3k_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_SWING_CUT_AGAINST_CHAINMAIL_UdBiS_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_THRUST_BLUNT_AGAINST_CHAINMAIL_Unb84_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_THRUST_PIERCE_AGAINST_CHAINMAIL_2Ng91_Value
         };

         return result;
      }

      public AttackType OneHandedSwordClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_SWING_BLUNT_AGAINST_CLOTH_64Lhv_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_SWING_CUT_AGAINST_CLOTH_U1GgF_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_THRUST_BLUNT_AGAINST_CLOTH_oGmnS_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_THRUST_PIERCE_AGAINST_CLOTH_kWNK9_Value
         };

         return result;
      }

      public AttackType OneHandedSwordLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_SWING_BLUNT_AGAINST_LEATHER_tiuYy_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_SWING_CUT_AGAINST_LEATHER_HXuje_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_THRUST_BLUNT_AGAINST_LEATHER_ljFbE_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_THRUST_PIERCE_AGAINST_LEATHER_txKI6_Value
         };

         return result;
      }

      public AttackType OneHandedSwordPlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_SWING_BLUNT_AGAINST_PLATE_qLDxk_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_SWING_CUT_AGAINST_PLATE_jgMZR_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_THRUST_BLUNT_AGAINST_PLATE_9DpM5_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.ONE_HANDED_SWORD_THRUST_PIERCE_AGAINST_PLATE_GDD4U_Value
         };

         return result;
      }


      public OptionFileContent OptionFileContent(ConfigurationLoader loader)
      {
         _configurationLoader = loader;
         Options = new Options(loader);
         _loadedOptions = Options.GetContent();

         return Options;
      }

      public WeaponType Pick(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Pick(in strikeType, in damageType, in materialType);


      public AttackType PickChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.PICK_SWING_BLUNT_AGAINST_CHAINMAIL_kF9cR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.PICK_SWING_CUT_AGAINST_CHAINMAIL_xU3gA_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.PICK_THRUST_BLUNT_AGAINST_CHAINMAIL_aN8xS_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.PICK_THRUST_PIERCE_AGAINST_CHAINMAIL_eB4mW_Value
         };

         return result;
      }

      public AttackType PickClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.PICK_SWING_BLUNT_AGAINST_CLOTH_yB7gR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.PICK_SWING_CUT_AGAINST_CLOTH_nF5zV_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.PICK_THRUST_BLUNT_AGAINST_CLOTH_qM2dA_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.PICK_THRUST_PIERCE_AGAINST_CLOTH_xC9xT_Value
         };

         return result;
      }

      public AttackType PickLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.PICK_SWING_BLUNT_AGAINST_LEATHER_sU5zH_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.PICK_SWING_CUT_AGAINST_LEATHER_bJ2hT_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.PICK_THRUST_BLUNT_AGAINST_LEATHER_pC9xV_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.PICK_THRUST_PIERCE_AGAINST_LEATHER_tR6zE_Value
         };

         return result;
      }

      public AttackType PickPlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.PICK_SWING_BLUNT_AGAINST_PLATE_lA8hY_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.PICK_SWING_CUT_AGAINST_PLATE_zE3dX_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.PICK_THRUST_BLUNT_AGAINST_PLATE_vB9fQ_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.PICK_THRUST_PIERCE_AGAINST_PLATE_nC6zT_Value
         };

         return result;
      }

      public WeaponType Stone(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new Stone(in strikeType, in damageType, in materialType);

      public AttackType StoneChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.STONE_SWING_BLUNT_AGAINST_CHAINMAIL_bQ5zE_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.STONE_SWING_CUT_AGAINST_CHAINMAIL_aU9gR_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.STONE_THRUST_BLUNT_AGAINST_CHAINMAIL_fM4zG_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.STONE_THRUST_PIERCE_AGAINST_CHAINMAIL_dE7rQ_Value
         };

         return result;
      }

      public AttackType StoneClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.STONE_SWING_BLUNT_AGAINST_CLOTH_kE9xR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.STONE_SWING_CUT_AGAINST_CLOTH_jN5uG_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.STONE_THRUST_BLUNT_AGAINST_CLOTH_zC8xI_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.STONE_THRUST_PIERCE_AGAINST_CLOTH_fG4zW_Value
         };

         return result;
      }

      public AttackType StoneLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.STONE_SWING_BLUNT_AGAINST_LEATHER_uN9gS_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.STONE_SWING_CUT_AGAINST_LEATHER_pC3xV_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.STONE_THRUST_BLUNT_AGAINST_LEATHER_rY8nA_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.STONE_THRUST_PIERCE_AGAINST_LEATHER_qH4zP_Value
         };

         return result;
      }

      public AttackType StonePlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.STONE_SWING_BLUNT_AGAINST_PLATE_kN4zI_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.STONE_SWING_CUT_AGAINST_PLATE_zC8xG_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.STONE_THRUST_BLUNT_AGAINST_PLATE_nY3hA_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.STONE_THRUST_PIERCE_AGAINST_PLATE_tH7xQ_Value
         };

         return result;
      }

      public WeaponType TwoHandedAxe(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedAxe(in strikeType, in damageType, in materialType);

      public AttackType TwoHandedAxeChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_CHAINMAIL_tQ5zR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_CHAINMAIL_aH8xV_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_CHAINMAIL_rT3zG_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_CHAINMAIL_bN4zT_Value
         };

         return result;
      }

      public AttackType TwoHandedAxeClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_CLOTH_mT8xU_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_CLOTH_sN4zR_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_CLOTH_kD9xL_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_CLOTH_fU5zH_Value
         };

         return result;
      }

      public AttackType TwoHandedAxeLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_LEATHER_nC9xI_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_LEATHER_wG6xR_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_LEATHER_tH3zA_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_LEATHER_vE7gV_Value
         };

         return result;
      }

      public AttackType TwoHandedAxePlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_SWING_BLUNT_AGAINST_PLATE_dH7gV_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_SWING_CUT_AGAINST_PLATE_iE8xL_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_THRUST_BLUNT_AGAINST_PLATE_fT4zA_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_AXE_THRUST_PIERCE_AGAINST_PLATE_sU9gH_Value
         };

         return result;
      }

      public WeaponType TwoHandedMace(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedMace(in strikeType, in damageType, in materialType);

      public AttackType TwoHandedMaceChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CHAINMAIL_mJ2hU_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_CHAINMAIL_lR5zH_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CHAINMAIL_jG8xT_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CHAINMAIL_aG6xI_Value
         };

         return result;
      }

      public AttackType TwoHandedMaceClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_CLOTH_gU5zV_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_CLOTH_qH8xG_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_CLOTH_bN4zA_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_CLOTH_zD9xT_Value
         };

         return result;
      }

      public AttackType TwoHandedMaceLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_LEATHER_kT3zR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_LEATHER_mH7gA_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_LEATHER_zE9xL_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_LEATHER_wT4zE_Value
         };

         return result;
      }

      public AttackType TwoHandedMacePlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_SWING_BLUNT_AGAINST_PLATE_pS5zE_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_SWING_CUT_AGAINST_PLATE_jC9xR_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_THRUST_BLUNT_AGAINST_PLATE_dU6xV_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_MACE_THRUST_PIERCE_AGAINST_PLATE_bH4zG_Value
         };

         return result;
      }

      public WeaponType TwoHandedPolearm(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedPolearm(in strikeType, in damageType, in materialType);

      public AttackType TwoHandedPolearmChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_CHAINMAIL_lJ2hT_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_CHAINMAIL_fR5zA_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CHAINMAIL_pG8xV_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CHAINMAIL_kG6xU_Value
         };

         return result;
      }

      public AttackType TwoHandedPolearmClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_CLOTH_vH8xR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_CLOTH_mD4zE_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_CLOTH_yN7xL_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_CLOTH_zH4zW_Value
         };

         return result;
      }

      public AttackType TwoHandedPolearmLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_LEATHER_yT3zH_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_LEATHER_bE7gA_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_LEATHER_gN4zG_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_LEATHER_cT9xI_Value
         };

         return result;
      }

      public AttackType TwoHandedPolearmPlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_SWING_BLUNT_AGAINST_PLATE_kD3zA_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_SWING_CUT_AGAINST_PLATE_rN9gR_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_BLUNT_AGAINST_PLATE_mH6xV_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_POLEARM_THRUST_PIERCE_AGAINST_PLATE_eS4zG_Value
         };

         return result;
      }

      public WeaponType TwoHandedSword(in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType) => new TwoHandedSword(in strikeType, in damageType, in materialType);

      public AttackType TwoHandedSwordChainmailDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_CHAINMAIL_dH8xT_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_CHAINMAIL_yN7xI_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_CHAINMAIL_fE4zR_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_CHAINMAIL_aT9xL_Value
         };

         return result;
      }

      public AttackType TwoHandedSwordClothDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_CLOTH_dH8xR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_CLOTH_yN7xG_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_CLOTH_nE4zA_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_CLOTH_wT9xP_Value
         };

         return result;
      }

      public AttackType TwoHandedSwordLeatherDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_LEATHER_lH8xV_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_LEATHER_tN7xH_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_LEATHER_xE4zG_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_LEATHER_wT9xT_Value
         };

         return result;
      }

      public AttackType TwoHandedSwordPlateDto()
      {
         var result = new AttackTypeDto
         {
            Swing_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_PLATE_lH8xR_Value,
            Swing_Cut = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_SWING_CUT_AGAINST_PLATE_tN7xL_Value,
            Thrust_Blunt = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_THRUST_BLUNT_AGAINST_PLATE_xE4zH_Value,
            Thrust_Pierce = UnseatOptionReader.UnseatValues.TWO_HANDED_SWORD_THRUST_PIERCE_AGAINST_PLATE_wT9xG_Value
         };

         return result;
      }
   }
}