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
   internal class HeadKnockedDownProbabilityTest
   {
      [Test]
      public void ItShouldReturnFormidableValue_WhenHitByBluntThrust()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Thrust;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new HeadKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.FORMIDABLE;

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

         var sut = new HeadKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MINIMAL;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnModerateValue_WhenHitByPierceSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Pierce;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new HeadKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MODERATE;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnStrongValue_WhenHitByBluntSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new HeadKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.STRONG;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnStrongValue_WhenHitByCutSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Cut;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new HeadKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.STRONG;

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

         var sut = new HeadKnockedDownProbability();
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