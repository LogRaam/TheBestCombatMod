// Code written by Gabriel Mailhot, 14/09/2023.

#region

using FluentAssertions;
using LogRaamConfiguration;
using NUnit.Framework;
using TaleWorlds.Core;
using TheBestCombatMod;
using TheBestCombatMod.Features.KnockedDown.Body;
using TheBestCombatMod.Features.KnockedDown.Options;
using TheBestCombatMod.Features.Options;
using TheBestCombatModTest.Substitutes;

#endregion

namespace TheBestCombatModTest.KnockedDownTests
{
   [TestFixture]
   internal class NeckKnockedDownProbabilityTest
   {
      [Test]
      public void ItShouldReturnFormidableValue_WhenHitByBluntthrust()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Thrust;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new NeckKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.FORMIDABLE;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnLowValue_WhenHitByPierceSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Pierce;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new NeckKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.LOW;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnMinimalValue_WhenHitByCutThrust()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Cut;
         var strikeType = StrikeType.Thrust;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new NeckKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MINIMAL;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnModerateValue_WhenHitByBluntSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new NeckKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MODERATE;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnModerateValue_WhenHitByCutSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Cut;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new NeckKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MODERATE;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnStrongValue_WhenHitByPierceThrust()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Pierce;
         var strikeType = StrikeType.Thrust;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new NeckKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.STRONG;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [SetUp]
      public void Setup()
      {
         var loader = new ConfigLoaderSubstitute();
         Runtime.Update(loader);
      }
   }
}