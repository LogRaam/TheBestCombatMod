// Code written by Gabriel Mailhot, 13/08/2023.

#region

using FluentAssertions;
using LogRaamConfiguration;
using NUnit.Framework;
using TaleWorlds.Core;
using TheBestCombatMod;
using TheBestCombatMod.Features;
using TheBestCombatMod.Features.Options;
using TheBestCombatMod.Features.Unseat;
using TheBestCombatMod.Features.Unseat.Body;
using TheBestCombatMod.Features.Unseat.Options;
using TheBestCombatModTest.Substitutes;

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
         var loadedOptions = Runtime.Get.ConfigurationLoader.RetrieveConfigDetails(Runtime.Get.ConfigurationLoader.GetOptionFilePath());
         var sut = new UnseatProbability(new UnseatProbabilityParams
         {
            LoadedOptions = loadedOptions,
            DefenseInfo = new ProtectionInfo(),
            Reader = new UnseatByBlowOptionsReader(new DefaultOptionReader(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag()),
            BodyHitProbability = new BodyHitUnseatProbability(),
            BodyPartsVulnerabilityOptions = new UnseatBodyPartsVulnerabilityOptions(loadedOptions)
         });
         var expectedResult = 16;

         //When
         var actualResult = sut.ForInertiaStrength(2.0f, false, 0);

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void GetBonusFrom_Test()
      {
         //Given
         var sut = new ProtectionInfo();
         var expectedResult = 34;
         var option = new UnseatByBlowOptionsReader(new DefaultOptionReader(new UnseatImpactResistanceValue(Runtime.LoadedOptions.GetContent())), new UnseatActivationRefTag(), new UnseatValueRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag());
         var loadedOptions = Runtime.LoadedOptions.GetContent();

         //When
         var actualResult = sut.GetResistanceBonusFrom(
            loadedOptions,
            WeaponClass.Dagger,
            StrikeType.Swing,
            DamageTypes.Blunt,
            ArmorComponent.ArmorMaterialTypes.Plate);

         var test2 = option.GetAlphaValueFor(Runtime.LoadedOptions.GetContent(), option.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_CLOTH_dH8xR_Value);
         var test3 = option.GetAlphaValueFor(Runtime.LoadedOptions.GetContent(), option.UnseatValues.TWO_HANDED_SWORD_SWING_BLUNT_AGAINST_PLATE_lH8xR_Value);

         //Then
         test2.Should().Be(60);
         test3.Should().Be(7);
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void GivenIHaveInertia_WhenAttackerIsOnHorseback_ThenValueIsMultipliedByOptionValue()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var sut = new UnseatProbability(new UnseatProbabilityParams
         {
            LoadedOptions = loadedOptions,
            DefenseInfo = new ProtectionInfo(),
            Reader = new UnseatByBlowOptionsReader(new DefaultOptionReader(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new GlobalActivationRefTag(), new GlobalUnseatValueRefTag()),
            BodyHitProbability = new BodyHitUnseatProbability(),
            BodyPartsVulnerabilityOptions = new UnseatBodyPartsVulnerabilityOptions(loadedOptions)
         });
         var expectedResult = 33;

         //When
         var actualResult = sut.ForInertiaStrength(2.0f, true, 0);

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