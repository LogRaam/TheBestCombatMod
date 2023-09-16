// Code written by Gabriel Mailhot, 28/08/2023.

#region

using FluentAssertions;
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
   public class FootmanKnockedDownByBlowFeatureTest
   {
      [Test]
      public void CalculateKnockedDownChances_ItShouldReturnValueGreaterThanZero_WhenVictimHealthIs70()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var attackerIsHuman = true;
         var attackerIsHero = true;
         var attackerIsSoldier = true;
         float attackerHealth = 100;
         float attackerMaxHealth = 100;
         float victimHealth = 70;
         float victimMaxHealth = 100;
         var strikeType = StrikeType.Swing;
         var damageType = DamageTypes.Blunt;
         var victimBodyPart = BoneBodyPartType.Head;
         var attackerWeaponClass = WeaponClass.Mace;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.Chainmail;

         var sut = new FootmanKnockedDownByBlowFeature();

         //When
         var actualResult = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClass,
            armorMaterialType
         );

         //Then
         actualResult.Should().BeGreaterThan(0);
      }


      [Test]
      public void CompareKnockedDownChances_ItShouldHaveGreaterChances_IfAttackerIsHero()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var attackerIsHuman = true;
         var attackerIsHero = true;
         var attackerIsNotHero = false;
         var attackerIsSoldier = true;
         float attackerHealth = 100;
         float attackerMaxHealth = 100;
         float victimHealth = 70;
         float victimMaxHealth = 100;
         var strikeType = StrikeType.Swing;
         var damageType = DamageTypes.Blunt;
         var victimBodyPart = BoneBodyPartType.Head;
         var attackerWeaponClass = WeaponClass.Mace;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.Chainmail;

         var sut = new FootmanKnockedDownByBlowFeature();

         //When
         var KnockdownChancesWhenAttackerIsHero = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClass,
            armorMaterialType
         );

         var KnockdownChancesWhenAttackerIsNotHero = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsNotHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClass,
            armorMaterialType
         );

         //Then
         KnockdownChancesWhenAttackerIsHero.Should().BeGreaterThan(KnockdownChancesWhenAttackerIsNotHero);
      }


      [Test]
      public void CompareKnockedDownChances_ItShouldHaveGreaterChances_IfAttackerIsSoldier()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var attackerIsHuman = true;
         var attackerIsHero = true;
         var attackerIsNotSoldier = false;
         var attackerIsSoldier = true;
         float attackerHealth = 100;
         float attackerMaxHealth = 100;
         float victimHealth = 70;
         float victimMaxHealth = 100;
         var strikeType = StrikeType.Swing;
         var damageType = DamageTypes.Blunt;
         var victimBodyPart = BoneBodyPartType.Head;
         var attackerWeaponClass = WeaponClass.Mace;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.Chainmail;

         var sut = new FootmanKnockedDownByBlowFeature();

         //When
         var KnockdownChancesWhenAttackerIsHero = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClass,
            armorMaterialType
         );

         var KnockdownChancesWhenAttackerIsNotHero = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsNotSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClass,
            armorMaterialType
         );

         //Then
         KnockdownChancesWhenAttackerIsHero.Should().BeGreaterThan(KnockdownChancesWhenAttackerIsNotHero);
      }

      [Test]
      public void CompareKnockedDownChances_ItShouldHaveGreaterChances_WhenHitClothComparedToPlate()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var attackerIsHuman = true;
         var attackerIsHero = true;
         var attackerIsSoldier = true;
         float attackerHealth = 100;
         float attackerMaxHealth = 100;
         float victimHealth = 70;
         float victimMaxHealth = 100;
         var strikeType = StrikeType.Swing;
         var damageType = DamageTypes.Blunt;
         var victimBodyPart = BoneBodyPartType.Head;
         var attackerWeaponClass = WeaponClass.OneHandedSword;
         var armorMaterialTypeCloth = ArmorComponent.ArmorMaterialTypes.Cloth;
         var armorMaterialTypePlate = ArmorComponent.ArmorMaterialTypes.Plate;

         var sut = new FootmanKnockedDownByBlowFeature();

         //When
         var KnockdownChancesOnCloth = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClass,
            armorMaterialTypeCloth
         );

         var KnockdownChancesOnPlate = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClass,
            armorMaterialTypePlate
         );

         //Then
         KnockdownChancesOnCloth.Should().BeGreaterThan(KnockdownChancesOnPlate);
      }


      [Test]
      public void CompareKnockedDownChances_ItShouldHaveGreaterChances_WhenUsing2HMaceOver1HMace()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var attackerIsHuman = true;
         var attackerIsHero = true;
         var attackerIsSoldier = true;
         float attackerHealth = 100;
         float attackerMaxHealth = 100;
         float victimHealth = 70;
         float victimMaxHealth = 100;
         var strikeType = StrikeType.Swing;
         var damageType = DamageTypes.Blunt;
         var victimBodyPart = BoneBodyPartType.Head;
         var attackerWeaponClassMace = WeaponClass.TwoHandedMace;
         var attackerWeaponClassSword = WeaponClass.Mace;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.Cloth;

         var sut = new FootmanKnockedDownByBlowFeature();

         //When
         var KnockdownChancesWhenUsingMace = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClassMace,
            armorMaterialType
         );

         var KnockdownChancesWhenUsingSword = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClassSword,
            armorMaterialType
         );

         //Then
         KnockdownChancesWhenUsingMace.Should().BeGreaterThan(KnockdownChancesWhenUsingSword);
      }


      [Test]
      public void CompareKnockedDownChances_ItShouldHaveGreaterChances_WhenUsingMaceOverSword()
      {
         //Given
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         var attackerIsHuman = true;
         var attackerIsHero = true;
         var attackerIsSoldier = true;
         float attackerHealth = 100;
         float attackerMaxHealth = 100;
         float victimHealth = 70;
         float victimMaxHealth = 100;
         var strikeType = StrikeType.Swing;
         var damageType = DamageTypes.Blunt;
         var victimBodyPart = BoneBodyPartType.Head;
         var attackerWeaponClassMace = WeaponClass.Mace;
         var attackerWeaponClassSword = WeaponClass.OneHandedSword;
         var armorMaterialType = ArmorComponent.ArmorMaterialTypes.Cloth;

         var sut = new FootmanKnockedDownByBlowFeature();

         //When
         var KnockdownChancesWhenUsingMace = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClassMace,
            armorMaterialType
         );

         var KnockdownChancesWhenUsingSword = sut.CalculateKnockedDownChances(
            loadedOptions,
            attackerIsHuman,
            attackerIsHero,
            attackerIsSoldier,
            attackerHealth,
            attackerMaxHealth,
            victimHealth,
            victimMaxHealth,
            strikeType,
            damageType,
            victimBodyPart,
            attackerWeaponClassSword,
            armorMaterialType
         );

         //Then
         KnockdownChancesWhenUsingMace.Should().BeGreaterThan(KnockdownChancesWhenUsingSword);
      }


      [SetUp]
      public void Setup()
      {
         var loader = new ConfigLoaderSubstitute();
         Runtime.Update(loader);
      }
   }
}