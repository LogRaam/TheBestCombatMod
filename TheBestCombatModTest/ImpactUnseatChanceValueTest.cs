// Code written by Gabriel Mailhot, 13/08/2023.

#region

using FluentAssertions;
using LogRaamConfiguration;
using NUnit.Framework;
using TheBestCombatMod;
using TheBestCombatMod.Features.KnockedDown.Options;
using TheBestCombatMod.Features.Options;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Options;
using TheBestCombatModTest.Substitutes;

#endregion

namespace TheBestCombatModTest
{
   [TestFixture]
   internal class ImpactUnseatChanceValueTest
   {
      private TestFactory _factory;

      [SetUp]
      public void Setup()
      {
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         _factory = new TestFactory
         {
            ImpactUnseatChanceOptions = new ImpactUnseatChanceValue(
               new ImpactUnseatChanceValueParams(
                  loadedOptions,
                  new ConfigLoaderSubstitute(),
                  new UnseatByBlowOptionsReader(new DefaultOptionReader(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag()),
                  new UnseatStaggerStrengthOptionValues(loadedOptions))
            ),
            KnockDownStrengthOption = new KnockDownStrenghtValue(new UnseatConfigParams(loadedOptions, new ConfigLoaderSubstitute(), new KnockedDownRefTag()))
         };
      }

      [Test]
      public void WithLoadedOptions_NeckCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given

         var sut = _factory.ImpactUnseatChanceOptions;
         var expectedResult = 6;

         //When
         var actualResult = sut.NECK_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }
   }
}