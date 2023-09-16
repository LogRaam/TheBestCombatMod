// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TheBestCombatMod.Features;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface DefenseInformation
   {
      int GetResistanceBonusFrom(in string[] loadedOptions, in WeaponClass weaponClass, in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType, Feature feature);

      public bool IsShieldCovering(in ItemCategory itemCategory, in BoneBodyPartType victimBodyPart);
   }
}