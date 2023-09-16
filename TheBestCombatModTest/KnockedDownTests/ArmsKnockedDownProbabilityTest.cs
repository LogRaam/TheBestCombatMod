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
   internal class ArmsKnockedDownProbabilityTest
   {
      [Test]
      public void ItShouldReturnMinimalValue_WhenHitByBluntSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new ArmsKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MINIMAL;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnMinimalValue_WhenHitByBluntthrust()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Blunt;
         var strikeType = StrikeType.Thrust;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new ArmsKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MINIMAL;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnMinimalValue_WhenHitByCutSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Cut;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new ArmsKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MINIMAL;

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

         var sut = new ArmsKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MINIMAL;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnMinimalValue_WhenHitByPierceSwing()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Pierce;
         var strikeType = StrikeType.Swing;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new ArmsKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MINIMAL;

         //When
         var actual = sut.WhenHit(loadedOptions, damageType, strikeType, optionReader);

         //Then
         actual.Should().Be((int) expected);
      }

      [Test]
      public void ItShouldReturnMinimalValue_WhenHitByPierceThrust()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var damageType = DamageTypes.Pierce;
         var strikeType = StrikeType.Thrust;
         var optionReader = new KnockedDownOptionsReader(new DefaultOptionReader(), new KnockedDownActivationRefTag(), new KnockedDownValuesRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());

         var sut = new ArmsKnockedDownProbability();
         var expected = StaggerStrengthPercentageValue.MINIMAL;

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