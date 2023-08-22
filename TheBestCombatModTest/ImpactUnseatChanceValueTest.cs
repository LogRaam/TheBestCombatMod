// Code written by Gabriel Mailhot, 13/08/2023.

#region

using FluentAssertions;
using NUnit.Framework;
using TheBestCombatMod;
using TheBestCombatMod.Features.Unseat.Values;

#endregion

namespace TheBestCombatModTest
{
   [TestFixture]
   internal class ImpactUnseatChanceValueTest
   {
      [SetUp]
      public void Setup()
      {
         var loader = new ConfigLoaderSubstitute();
         Runtime.Update(loader);
      }

      [Test]
      public void WithLoadedOptions_NeckCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = new ImpactUnseatChanceValue(Runtime.LoadedOptions.GetContent());
         var expectedResult = 6;

         //When
         var actualResult = sut.NECK_CUT_SWINGING_OJ42D;

         //Then
         actualResult.Should().Be(expectedResult);
      }
   }
}