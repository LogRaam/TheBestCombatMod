// Code written by Gabriel Mailhot, 12/08/2023.

#region

using FluentAssertions;
using LogRaamConfiguration;
using NUnit.Framework;
using TheBestCombatMod;
using TheBestCombatMod.Features.Options;
using TheBestCombatModTest.Substitutes;

#endregion

namespace TheBestCombatModTest
{
   [TestFixture]
   public class RuntimeTest
   {
      [Test]
      [Category("Initialize")]
      public void EachPropertiesShouldBeInstanciated()
      {
         //Arrange
         var loader = new ConfigLoaderSubstitute();
         Runtime.Loader = loader;
         Runtime.LoadedOptions = new Options(loader);
         Runtime.FileInteraction = new FileInteraction(loader.GetOptionFilePath());

         //Assert
         Runtime.LoadedOptions.Should().NotBeNull();
         Runtime.FileInteraction.Should().NotBeNull();
         Runtime.UnseatBodyPartsVulnerabilityOptions.Should().NotBeNull();
         Runtime.ImpactUnseatChanceValue.Should().NotBeNull();
         Runtime.DecideAgentDismountedByBlow.Should().NotBeNull();
         Runtime.ImpactDismountChance.Should().NotBeNull();
         Runtime.UnseatImpactResistance.Should().NotBeNull();
         Runtime.StaggerStrength.Should().NotBeNull();
         Runtime.AttackerOptions.Should().NotBeNull();
         Runtime.Loader.Should().NotBeNull();
         Runtime.UnseatOptionsReader.Should().NotBeNull();
      }
   }
}