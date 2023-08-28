// Code written by Gabriel Mailhot, 28/08/2023.

#region

using FluentAssertions;
using NUnit.Framework;
using TheBestCombatMod;
using TheBestCombatModTest.Substitutes;

#endregion

namespace TheBestCombatModTest
{
   /// <summary>
   ///   (05zN2) HEAD -&gt; DAMAGE TYPE CUT -&gt; WHEN SWINGING = Strong
   ///   (IgazM) HEAD -&gt; DAMAGE TYPE CUT -&gt; WHEN THRUSTING = Minimal
   ///   (JMWpz) HEAD -&gt; DAMAGE TYPE PIERCE -&gt; WHEN SWINGING = Moderate
   ///   (pMa5J) HEAD -&gt; DAMAGE TYPE PIERCE -&gt; WHEN THRUSTING = Strong
   ///   (8VPtS) HEAD -&gt; DAMAGE TYPE BLUNT -&gt; WHEN SWINGING = Strong
   ///   (UzQhf) HEAD -&gt; DAMAGE TYPE BLUNT -&gt; WHEN THRUSTING = Formidable
   ///   (OJ42D) NECK -&gt; DAMAGE TYPE CUT -&gt; WHEN SWINGING = Moderate
   ///   (JDsUb) NECK -&gt; DAMAGE TYPE CUT -&gt; WHEN THRUSTING = Minimal
   ///   (16Tqb) NECK -&gt; DAMAGE TYPE PIERCE -&gt; WHEN SWINGING = Low
   ///   (PwjyT) NECK -&gt; DAMAGE TYPE PIERCE -&gt; WHEN THRUSTING = Strong
   ///   (Z19yv) NECK -&gt; DAMAGE TYPE BLUNT -&gt; WHEN SWINGING = Moderate
   ///   (yZEV1) NECK -&gt; DAMAGE TYPE BLUNT -&gt; WHEN THRUSTING = Formidable
   ///   (sQmx7) CHEST -&gt; DAMAGE TYPE CUT -&gt; WHEN SWINGING = Low
   ///   (dNomI) CHEST -&gt; DAMAGE TYPE CUT -&gt; WHEN THRUSTING = Minimal
   ///   (6ssat) CHEST -&gt; DAMAGE TYPE PIERCE -&gt; WHEN SWINGING = Low
   ///   (ybixm) CHEST -&gt; DAMAGE TYPE PIERCE -&gt; WHEN THRUSTING = Moderate
   ///   (Ip0TE) CHEST -&gt; DAMAGE TYPE BLUNT -&gt; WHEN SWINGING = Moderate
   ///   (ktCEu) CHEST -&gt; DAMAGE TYPE BLUNT -&gt; WHEN THRUSTING = Strong
   ///   (tRqGA) ABDOMEN -&gt; DAMAGE TYPE CUT -&gt; WHEN SWINGING = Low
   ///   (eypTb) ABDOMEN -&gt; DAMAGE TYPE CUT -&gt; WHEN THRUSTING = Minimal
   ///   (VTO6S) ABDOMEN -&gt; DAMAGE TYPE PIERCE -&gt; WHEN SWINGING = Low
   ///   (suxMY) ABDOMEN -&gt; DAMAGE TYPE PIERCE -&gt; WHEN THRUSTING = Moderate
   ///   (v2v6T) ABDOMEN -&gt; DAMAGE TYPE BLUNT -&gt; WHEN SWINGING = Moderate
   ///   (6gLsx) ABDOMEN -&gt; DAMAGE TYPE BLUNT -&gt; WHEN THRUSTING = Strong
   ///   (8yoXK) SHOULDERS -&gt; DAMAGE TYPE CUT -&gt; WHEN SWINGING = Minimal
   ///   (2Y1ez) SHOULDERS -&gt; DAMAGE TYPE CUT -&gt; WHEN THRUSTING = Low
   ///   (HoWbh) SHOULDERS -&gt; DAMAGE TYPE PIERCE -&gt; WHEN SWINGING = Minimal
   ///   (UhpJO) SHOULDERS -&gt; DAMAGE TYPE PIERCE -&gt; WHEN THRUSTING = Low
   ///   (TplnH) SHOULDERS -&gt; DAMAGE TYPE BLUNT -&gt; WHEN SWINGING = Low
   ///   (gqk9L) SHOULDERS -&gt; DAMAGE TYPE BLUNT -&gt; WHEN THRUSTING = Moderate
   ///   (eMIfX) ARMS -&gt; DAMAGE TYPE CUT -&gt; WHEN SWINGING = Minimal
   ///   (uHDMI) ARMS -&gt; DAMAGE TYPE CUT -&gt; WHEN THRUSTING = Minimal
   ///   (ScPD3) ARMS -&gt; DAMAGE TYPE PIERCE -&gt; WHEN SWINGING = Minimal
   ///   (7R3oW) ARMS -&gt; DAMAGE TYPE PIERCE -&gt; WHEN THRUSTING = Minimal
   ///   (zwGj0) ARMS -&gt; DAMAGE TYPE BLUNT -&gt; WHEN SWINGING = Minimal
   ///   (E9s8D) ARMS -&gt; DAMAGE TYPE BLUNT -&gt; WHEN THRUSTING = Minimal
   ///   (xOKtK) LEGS -&gt; DAMAGE TYPE CUT -&gt; WHEN SWINGING = Low
   ///   (hEsET) LEGS -&gt; DAMAGE TYPE CUT -&gt; WHEN THRUSTING = Low
   ///   (6DD8t) LEGS -&gt; DAMAGE TYPE PIERCE -&gt; WHEN SWINGING = Low
   ///   (NblKm) LEGS -&gt; DAMAGE TYPE PIERCE -&gt; WHEN THRUSTING = Moderate
   ///   (JTLxV) LEGS -&gt; DAMAGE TYPE BLUNT -&gt; WHEN SWINGING = Moderate
   ///   (awuSL) LEGS -&gt; DAMAGE TYPE BLUNT -&gt; WHEN THRUSTING = Strong
   /// </summary>
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
      public void WithLoadedOptions_AbdomenBluntSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.ABDOMEN_BLUNT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_AbdomenBluntThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.STRONG;

         //When
         var actualResult = sut.ABDOMEN_BLUNT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_AbdomenCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.ABDOMEN_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_AbdomenCutThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.ABDOMEN_CUT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_AbdomenPierceSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.ABDOMEN_PIERCE_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_AbdomenPierceThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.ABDOMEN_PIERCE_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ArmsBluntSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.ARMS_BLUNT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ArmsBluntThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.ARMS_BLUNT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ArmsCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.ARMS_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ArmsCutThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.ARMS_CUT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ArmsPierceSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.ARMS_PIERCE_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ArmsPierceThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.ARMS_PIERCE_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ChestBluntSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.CHEST_BLUNT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ChestBluntThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.STRONG;

         //When
         var actualResult = sut.CHEST_BLUNT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ChestCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.CHEST_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ChestCutThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.CHEST_CUT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ChestPierceSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.CHEST_PIERCE_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ChestPierceThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.CHEST_PIERCE_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_HeadBluntSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.STRONG;

         //When
         var actualResult = sut.HEAD_BLUNT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_HeadBluntThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.FORMIDABLE;

         //When
         var actualResult = sut.HEAD_BLUNT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_HeadCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.STRONG;

         //When
         var actualResult = sut.HEAD_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_HeadCutThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.HEAD_CUT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_HeadPierceSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.HEAD_PIERCE_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_HeadPierceThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.STRONG;

         //When
         var actualResult = sut.HEAD_PIERCE_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_LegsBluntSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.LEGS_BLUNT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_LegsBluntThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.STRONG;

         //When
         var actualResult = sut.LEGS_BLUNT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_LegsCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.LEGS_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_LegsCutThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.LEGS_CUT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_LegsPierceSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.LEGS_PIERCE_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_LegsPierceThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.LEGS_PIERCE_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_NeckBluntSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.NECK_BLUNT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_NeckBluntThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.FORMIDABLE;

         //When
         var actualResult = sut.NECK_BLUNT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_NeckCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.NECK_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_NeckCutThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.NECK_CUT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_NeckPierceSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.NECK_PIERCE_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_NeckPierceThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.STRONG;

         //When
         var actualResult = sut.NECK_PIERCE_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ShouldersBluntSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.SHOULDERS_BLUNT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ShouldersBluntThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MODERATE;

         //When
         var actualResult = sut.SHOULDERS_BLUNT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ShouldersCutSwiging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.SHOULDERS_CUT_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void WithLoadedOptions_ShouldersCutThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.SHOULDERS_CUT_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ShouldersPierceSwinging_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.MINIMAL;

         //When
         var actualResult = sut.SHOULDERS_PIERCE_SWINGING();

         //Then
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void WithLoadedOptions_ShouldersPierceThrusting_ShouldCorrespondWithOptionFile()
      {
         //Given
         var sut = Runtime.Get.ImpactUnseatChanceOptions;
         var expectedResult = Values.LOW;

         //When
         var actualResult = sut.SHOULDERS_PIERCE_THRUSTING();

         //Then
         actualResult.Should().Be(expectedResult);
      }


      private class Values
      {
         internal static readonly int FORMIDABLE = 15;
         internal static readonly int LOW = 3;
         internal static readonly int MINIMAL = 1;
         internal static readonly int MODERATE = 6;
         internal static readonly int NONE = 0;
         internal static readonly int STRONG = 10;
      }
   }
}