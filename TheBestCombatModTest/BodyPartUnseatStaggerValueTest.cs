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
   internal class BodyPartUnseatStaggerValueTest
   {
      [SetUp]
      public void Setup()
      {
         var loader = new ConfigLoaderSubstitute();
         Runtime.Update(loader);
      }

      [Test]
      public void WithLoadedOptions_Abdomen_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = new BodyPartUnseatStaggerValue(Runtime.LoadedOptions.GetContent());
         var expectedResult = 3;

         //When
         var actualResult = sut.Abdomen;

         //Then
         actualResult.Should().Be(expectedResult);
      }
   }
}