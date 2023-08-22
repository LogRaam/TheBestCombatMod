// Code written by Gabriel Mailhot, 19/08/2023.

#region

using FluentAssertions;
using NUnit.Framework;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod;
using TheBestCombatMod.Features.Knocked;

#endregion

namespace TheBestCombatModTest
{
   [TestFixture]
   public class DecideAgentKnockedDownByBlowFeatureTest
   {
      [Test]
      public void CalculateKnockedDownChances_Test()
      {
         //Given
         var sut = new DecideAgentKnockedDownByBlowFeature();
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
         var actualResult = sut.DoMath(
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
         actualResult.Should().Be(34);
      }

      [SetUp]
      public void Setup()
      {
         var loader = new ConfigLoaderSubstitute();
         Runtime.Update(loader);
      }
   }
}