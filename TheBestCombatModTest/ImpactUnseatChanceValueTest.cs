// Code written by Gabriel Mailhot, 13/08/2023.

#region

using FluentAssertions;
using NUnit.Framework;
using TheBestCombatMod;
using TheBestCombatMod.Features.Unseat.Options;

#endregion

namespace TheBestCombatModTest
{
   [TestFixture]
   internal class ImpactUnseatChanceValueTest
   {
      [SetUp]
      public void Setup()
      {
         //TODO: FactorySubstitute
      }

      [Test]
      public void WithLoadedOptions_NeckCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = new ImpactUnseatChanceValue(Runtime.LoadedOptions.GetContent());
         var expectedResult = 6;

         //When
         var actualResult = sut.NECK_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }
   }
}