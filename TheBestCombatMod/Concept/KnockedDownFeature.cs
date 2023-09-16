// Code written by Gabriel Mailhot, 28/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface KnockedDownFeature
   {
      int CalculateKnockedDownChances(
         in string[] loadedOptions,
         bool attackerIsHuman,
         bool attackerIsHero,
         bool attackerIsSoldier,
         float attackerHealth,
         float attackerMaxHealth,
         float victimHealth,
         float victimMaxHealth,
         StrikeType strikeType,
         DamageTypes damageType,
         BoneBodyPartType victimBodyPart,
         WeaponClass attackerWeaponClass,
         ArmorComponent.ArmorMaterialTypes armorMaterialType
      );
   }
}