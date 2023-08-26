// Code written by Gabriel Mailhot, 19/08/2023.

#region

using NUnit.Framework;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod;
using TheBestCombatMod.Features.KnockedDown;
using TheBestCombatModTest.Substitutes;

#endregion

namespace TheBestCombatModTest
{
   [TestFixture]
   public class DecideAgentKnockedDownByBlowKnockedDownFeatureTest
   {
      [Test]
      public void CalculateKnockedDownChances_Test()
      {
         //Given
         var sut = new FootmanKnockedDownByBlowFeature();
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var victimHealth = 10;
         var victimMaxHealth = 100;
         var attackerWeaponWeaponClass = WeaponClass.Mace;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.Plate;
         var attackerIsSoldierOrHero = true;
         var strikeType = StrikeType.Swing;
         var damageType = DamageTypes.Blunt;
         var victimBodyPart = BoneBodyPartType.Chest;
         var attackerHealth = 100;
         var attackerMaxHealth = 100f;


         //When
         /* var actualResult = sut.DoMath( //TODO: I removed public here.  We should test from another entry point.
             loadedOptions,
             victimHealth,
             victimMaxHealth,
             attackerWeaponWeaponClass,
             armorMaterialType,
             attackerIsSoldierOrHero,
             strikeType,
             damageType,
             victimBodyPart,
             victimHealth,
             victimMaxHealth
          );

          //Then
          actualResult.Should().Be(34);*/
      }

      [SetUp]
      public void Setup()
      {
         var loader = new ConfigLoaderSubstitute();
         Runtime.Update(loader);
      }
   }
}