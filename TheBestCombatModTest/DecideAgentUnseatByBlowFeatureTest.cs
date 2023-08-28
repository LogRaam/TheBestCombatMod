// Code written by Gabriel Mailhot, 13/08/2023.

#region

using LogRaamConfiguration;
using NUnit.Framework;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod;
using TheBestCombatMod.Features;
using TheBestCombatMod.Features.Options;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Body;
using TheBestCombatMod.Features.Unseat.Options;

#endregion

namespace TheBestCombatModTest
{
   [TestFixture]
   internal class DecideAgentUnseatByBlowFeatureTest
   {
      [Test]
      public void CalculateStaggerChance_Test()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var unseatProbability = new UnseatProbability(new UnseatProbabilityParams
         {
            LoadedOptions = loadedOptions,
            DefenseInfo = new ProtectionInfo(),
            Reader = new UnseatByBlowOptionsReader(new DefaultOptionReader(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag()),
            BodyHitProbability = new BodyHitUnseatProbability(),
            BodyPartsVulnerabilityOptions = new UnseatBodyPartsVulnerabilityOptions(loadedOptions)
         });

         var sut = new DecideAgentUnseatByBlowFeature();


         var attackerWeight = 0.0309f;
         var attackerHealth = 100;
         var attackerBuild = 0.3395f;
         var attackerIsFemale = false;
         var victimWeight = 0;
         var victimHealth = 65;
         var victimBuild = 0;
         var victimGuardMode = Agent.GuardMode.None;
         var victimMaxHealth = 100;
         var blow = new Blow
         {
            DamageType = DamageTypes.Blunt,
            VictimBodyPart = BoneBodyPartType.Head,
            AttackType = AgentAttackType.Standard,
            StrikeType = StrikeType.Thrust
         };
         var weaponClass = WeaponClass.TwoHandedPolearm;
         var inertia = 0.09718593f;
         var thrustTipHit = false;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.Cloth;
         var attackerMaxHealth = 100;


         //When
         var armorResist = unseatProbability.ForStrikeAgainstArmor(armorMaterialType, weaponClass, blow.StrikeType, blow.DamageType);
         var effectOnBody = unseatProbability.ForTypeOfDamageOnBodyPart(blow.StrikeType, blow.DamageType, blow.VictimBodyPart);
         var bodyPartEffect = unseatProbability.ForTargetedBodyPart(blow.VictimBodyPart);
         var weightEffect = unseatProbability.WhenAttackerIsHeavier(victimWeight, attackerWeight);
         var healthEffect = unseatProbability.WhenAttackerIsHealthier(victimHealth, victimMaxHealth, attackerHealth, attackerMaxHealth);
         var buildEffect = unseatProbability.WhenAttackerIsStronger(victimBuild, attackerBuild);
         var guardEffect = unseatProbability.WhenVictimeDidNotRaiseHisGuard(victimGuardMode);
         var blowEffect = unseatProbability.WhenBlowIsCritical(blow, victimMaxHealth);
         var genderEffect = unseatProbability.IfAttackerIsWoman(attackerIsFemale);
         var thrustEffect = unseatProbability.WhenThrustTipHit(thrustTipHit);
         var inertiaEffect = unseatProbability.ForInertiaStrength(inertia, false, 0);
         /*
                  var actualResult = sut.DoMath(
                     loadedOptions,
                     attackerWeight,
                     attackerHealth,
                     attackerMaxHealth,
                     attackerBuild,
                     attackerIsFemale,
                     victimWeight,
                     victimHealth,
                     victimBuild,
                     victimGuardMode,
                     victimMaxHealth,
                     blow,
                     weaponClass,
                     inertia,
                     thrustTipHit,
                     armorMaterialType,
                     true,
                     false,
                     0
                  );

                  var t1 = bodyPartEffect + healthEffect + buildEffect + guardEffect + blowEffect + thrustEffect + weightEffect + inertiaEffect + effectOnBody;
                  var t2 = t1 + armorResist;
                  var result = (int) ((bodyPartEffect + healthEffect + buildEffect + guardEffect + blowEffect + thrustEffect + weightEffect + inertiaEffect + effectOnBody + armorResist) / genderEffect);

                  //Then
                  armorResist.Should().Be(31);
                  effectOnBody.Should().Be(15);
                  bodyPartEffect.Should().Be(6);
                  weightEffect.Should().Be(0);
                  healthEffect.Should().Be(19);
                  buildEffect.Should().Be(0);
                  guardEffect.Should().Be(5);
                  blowEffect.Should().Be(0); //Roll for CRIT blow
                  genderEffect.Should().Be(1f);
                  thrustEffect.Should().Be(0);
                  inertiaEffect.Should().Be(00);
                  t1.Should().Be(45);
                  t2.Should().Be(76);
                  result.Should().Be(76);

                  //TODO: MAX should be 75%: two-handed mace on head cloth, two-handed polearm thrust on neck, two-handed sword cutting neck, dagger abdomen on cloth
                  //TODO: AVERAGE should be 36%: one handed axe on chainmail
                  //TODO: MIN should be 0%: dagger on plate, stone on plate

                  actualResult.Should().Be(76);
         */
      }


      [SetUp]
      public void Setup()
      {
         //TODO
      }


      [Test]
      public void UCASE_1()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var unseatProbability = new UnseatProbability(new UnseatProbabilityParams
         {
            LoadedOptions = loadedOptions,
            DefenseInfo = new ProtectionInfo(),
            Reader = new UnseatByBlowOptionsReader(new DefaultOptionReader(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag()),
            BodyHitProbability = new BodyHitUnseatProbability(),
            BodyPartsVulnerabilityOptions = new UnseatBodyPartsVulnerabilityOptions(loadedOptions)
         });
         var sut = new DecideAgentUnseatByBlowFeature();


         var attackerWeight = 0.5799866f;
         var attackerHealth = 100;
         var attackerMaxHealth = 100;
         var attackerBuild = 0.487865716f;
         var attackerIsFemale = false;

         var victimWeight = 0.442652524f;
         var victimHealth = 100;
         var victimBuild = 0.483742118f;
         var victimGuardMode = Agent.GuardMode.None;
         var victimMaxHealth = 100;

         var inertia = 2.23591423f;
         var thrustTipHit = true;

         var blow = new Blow
         {
            DamageType = DamageTypes.Pierce,
            VictimBodyPart = BoneBodyPartType.ArmRight,
            AttackType = AgentAttackType.Standard,
            StrikeType = StrikeType.Thrust
         };
         var weaponClass = WeaponClass.OneHandedPolearm;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.None;
         /*
                  //When
                  var result1 = sut.DoMath(
                     loadedOptions,
                     attackerWeight,
                     attackerHealth,
                     attackerMaxHealth,
                     attackerBuild,
                     attackerIsFemale,
                     victimWeight,
                     victimHealth,
                     victimBuild,
                     victimGuardMode,
                     victimMaxHealth,
                     blow,
                     weaponClass,
                     inertia,
                     thrustTipHit,
                     armorMaterialType,
                     true,
                     false,
                     0
                  );

                  var armorResist = unseatProbability.ForStrikeAgainstArmor(loadedOptions, armorMaterialType, weaponClass, blow.StrikeType, blow.DamageType);
                  var effectOnBody = unseatProbability.ForTypeOfDamageOnBodyPart(loadedOptions, blow.StrikeType, blow.DamageType, blow.VictimBodyPart);
                  var bodyPartEffect = unseatProbability.ForTargetedBodyPart(loadedOptions, blow.VictimBodyPart);
                  var weightEffect = unseatProbability.WhenAttackerIsHeavier(loadedOptions, victimWeight, attackerWeight);
                  var healthEffect = unseatProbability.WhenAttackerIsHealthier(loadedOptions, victimHealth, victimMaxHealth, attackerHealth, attackerMaxHealth);
                  var buildEffect = unseatProbability.WhenAttackerIsStronger(loadedOptions, victimBuild, attackerBuild);
                  var guardEffect = unseatProbability.WhenVictimeDidNotRaiseHisGuard(loadedOptions, victimGuardMode);
                  var blowEffect = unseatProbability.WhenBlowIsCritical(loadedOptions, blow, victimMaxHealth);
                  var genderEffect = unseatProbability.IfAttackerIsWoman(loadedOptions, attackerIsFemale);
                  var thrustEffect = unseatProbability.WhenThrustTipHit(loadedOptions, thrustTipHit);
                  var inertiaEffect = unseatProbability.ForInertiaStrength(loadedOptions, inertia, false, 0);

                  //Then
                  armorResist.Should().Be(17);
                  effectOnBody.Should().Be(1);
                  bodyPartEffect.Should().Be(1);
                  weightEffect.Should().Be(3);
                  healthEffect.Should().Be(0);
                  buildEffect.Should().Be(0);
                  guardEffect.Should().Be(5);
                  blowEffect.Should().Be(0); //Roll for CRIT blow
                  genderEffect.Should().Be(1f);
                  thrustEffect.Should().Be(3);
                  inertiaEffect.Should().Be(18);
                  result1.Should().Be(48);
         */
      }


      [Test]
      public void ValuesCompare()
      {
         //Given
         var sut = new DecideAgentUnseatByBlowFeature();
         var loadedOptions = Runtime.LoadedOptions.GetContent();


         var attackerWeight = 0;
         var attackerHealth = 100;
         var attackerMaxHealth = 100;
         var attackerBuild = 0;
         var attackerIsFemale = false;

         var victimWeight = 0;
         var victimHealth = 10;
         var victimBuild = 0;
         var victimGuardMode = Agent.GuardMode.None;
         var victimMaxHealth = 100;

         var inertia = 0.09718593f;
         var thrustTipHit = false;

         var blow = new Blow
         {
            DamageType = DamageTypes.Pierce,
            VictimBodyPart = BoneBodyPartType.Abdomen,
            AttackType = AgentAttackType.Standard,
            StrikeType = StrikeType.Thrust
         };
         var weaponClass = WeaponClass.TwoHandedPolearm;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.Plate;

         var blow2 = new Blow
         {
            DamageType = DamageTypes.Pierce,
            VictimBodyPart = BoneBodyPartType.Abdomen,
            AttackType = AgentAttackType.Standard,
            StrikeType = StrikeType.Thrust
         };
         var weaponClass2 = WeaponClass.OneHandedPolearm;
         var armorMaterialType2 = ArmorComponent.ArmorMaterialTypes.Plate;

         /*
                  //When
                  var result1 = sut.DoMath(
                     loadedOptions,
                     attackerWeight,
                     attackerHealth,
                     attackerMaxHealth,
                     attackerBuild,
                     attackerIsFemale,
                     victimWeight,
                     victimHealth,
                     victimBuild,
                     victimGuardMode,
                     victimMaxHealth,
                     blow,
                     weaponClass,
                     inertia,
                     thrustTipHit,
                     armorMaterialType,
                     true,
                     false,
                     0
                  );

                  var result2 = sut.DoMath(
                     loadedOptions,
                     attackerWeight,
                     attackerHealth,
                     attackerMaxHealth,
                     attackerBuild,
                     attackerIsFemale,
                     victimWeight,
                     victimHealth,
                     victimBuild,
                     victimGuardMode,
                     victimMaxHealth,
                     blow2,
                     weaponClass2,
                     inertia,
                     thrustTipHit,
                     armorMaterialType2,
                     true,
                     false,
                     0
                  );

                  //Then
                  //result1.Should().Be(9);
                  //result2.Should().Be(2);
                  result1.Should().BeGreaterThan(result2);
         */
      }
   }
}