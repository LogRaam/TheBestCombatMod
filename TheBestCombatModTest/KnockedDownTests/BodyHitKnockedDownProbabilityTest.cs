// Code written by Gabriel Mailhot, 14/09/2023.

#region

using FluentAssertions;
using LogRaamConfiguration;
using NUnit.Framework;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod;
using TheBestCombatMod.Features.KnockedDown.Body;
using TheBestCombatMod.Features.KnockedDown.Options;
using TheBestCombatMod.Features.Options;
using TheBestCombatModTest.Substitutes;

#endregion

namespace TheBestCombatModTest.KnockedDownTests
{
   [TestFixture]
   internal class BodyHitKnockedDownProbabilityTest
   {
      [Test]
      public void ItShouldBeEquivalentToHitChestCompareToAbdomen_WhenSwingBlunt()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Swing;
         var reader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new BodyHitKnockedDownProbability();


         //When
         var resultChest = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, BoneBodyPartType.Chest, reader);
         var resultAbdomen = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, BoneBodyPartType.Abdomen, reader);

         //Then
         resultChest.Should().Be(resultAbdomen);
      }

      [Test]
      public void ItShouldBeMoreEffectiveToHitHeadCompareToNeck_WhenSwingCut()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Swing;
         var reader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new BodyHitKnockedDownProbability();


         //When
         var resultHead = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, BoneBodyPartType.Head, reader);
         var resultNeck = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, BoneBodyPartType.Neck, reader);

         //Then
         resultHead.Should().BeGreaterThan(resultNeck);
      }


      [Test]
      public void ItShouldBeMoreEffectiveToHitHeadCompareToShoulder_WhenSwingBlunt()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Swing;
         var reader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new BodyHitKnockedDownProbability();


         //When
         var resultHead = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, BoneBodyPartType.Head, reader);
         var resultShoulder = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, BoneBodyPartType.ShoulderRight, reader);

         //Then
         resultHead.Should().BeGreaterThan(resultShoulder);
      }


      [Test]
      public void ItShouldBeMoreEffectiveToHitLegCompareToArm_WhenSwingBlunt()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Swing;
         var reader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new BodyHitKnockedDownProbability();


         //When
         var resultLeg = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, BoneBodyPartType.Legs, reader);
         var resultArm = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, BoneBodyPartType.ArmRight, reader);

         //Then
         resultLeg.Should().BeGreaterThan(resultArm);
      }

      [Test]
      public void ItShouldReturnSomething_WhenHitHeadWithBluntSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Swing;
         var bodyPart = BoneBodyPartType.Head;
         var reader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new BodyHitKnockedDownProbability();
         var expected = 10;

         //When
         var actual = sut.GetProbabilityFor(loadedOptions, damageType, strikeType, bodyPart, reader);

         //Then
         actual.Should().Be(expected);
      }

      [SetUp]
      public void Setup()
      {
         var loader = new ConfigLoaderSubstitute();
         Runtime.Update(loader);
      }
   }
}