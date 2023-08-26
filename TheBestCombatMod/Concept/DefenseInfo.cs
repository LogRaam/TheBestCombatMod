// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface DefenseInformation
   {
      public int GetResistanceBonusFrom(in string[] loadedOptions, in WeaponClass weaponClass, in StrikeType strikeType, in DamageTypes damageType, in ArmorComponent.ArmorMaterialTypes materialType);
      public bool IsShieldCovering(in ItemCategory itemCategory, in BoneBodyPartType victimBodyPart);
   }
}