// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface UnseatFeature
   {
      int CalculateStaggerChance(
         in string[] loadedOptions,
         Agent attackerAgent,
         Agent victimAgent,
         in Blow blow,
         WeaponComponentData attackerWeapon,
         AttackCollisionData collision
      );
   }
}