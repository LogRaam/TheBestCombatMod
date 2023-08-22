// Code written by Gabriel Mailhot, 13/08/2023.

#region

using FluentAssertions;
using LogRaamConfiguration;
using NUnit.Framework;
using TaleWorlds.Core;
using TheBestCombatMod;
using TheBestCombatMod.Common;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Values;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatModTest
{
   [TestFixture]
   internal class UnseatProbabilityTest
   {
      [Test]
      public void ForInertiaStrength_Test()
      {
         //Given
         var sut = new UnseatProbability();
         var expectedResult = 16;

         //When
         var actualResult = sut.ForInertiaStrength(Runtime.LoadedOptions.GetContent(), 2.0f, false, 0);

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void GetBonusFrom_Test()
      {
         //Given
         var sut = new ArmorCharacteristics();
         var expectedResult = 34;
         var option = new UnseatByBlowOptions(new OptionBase(new ResistanceValue(Runtime.LoadedOptions.GetContent())), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         //When
         var actualResult = sut.GetResistanceBonusFrom(
            Runtime.LoadedOptions.GetContent(),
            WeaponClass.Dagger,
            StrikeType.Swing,
            DamageTypes.Blunt,
            ArmorComponent.ArmorMaterialTypes.Plate);

         var test2 = option.GetAlphaValueFor(Runtime.LoadedOptions.GetContent(), option.UnseatValueTags.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_CLOTH_dH8xR_Value);
         var test3 = option.GetAlphaValueFor(Runtime.LoadedOptions.GetContent(), option.UnseatValueTags.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_PLATE_lH8xR_Value);

         //Then
         test2.Should().Be(60);
         test3.Should().Be(7);
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void GivenIHaveInertia_WhenAttackerIsOnHorseback_ThenValueIsMultipliedByOptionValue()
      {
         //Given
         var sut = new UnseatProbability();
         var expectedResult = 33;

         //When
         var actualResult = sut.ForInertiaStrength(Runtime.LoadedOptions.GetContent(), 2.0f, true, 0);

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [SetUp]
      public void Setup()
      {
         var loader = new ConfigLoaderSubstitute();
         Runtime.Update(loader);
      }
   }
}