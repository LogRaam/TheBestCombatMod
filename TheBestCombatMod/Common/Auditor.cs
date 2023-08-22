// Code written by Gabriel Mailhot, 20/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Common
{
   public static class Auditor
   {
      public static bool KnockdownDisqualified(Agent attackerAgent, Agent victimAgent, WeaponComponentData attackerWeapon, Blow blow, bool isHorseCharge)
      {
         if (!victimAgent.IsHuman) return true;
         if (isHorseCharge) return true;
         if (attackerWeapon == null) return true;
         if (attackerAgent.Team != null && victimAgent.Team != null)
         {
            if (attackerAgent.Team.Side == victimAgent.Team.Side) return true;
         }

         if (blow.IsFallDamage) return true;


         return false;
      }

      public static bool UnseatDisqualified(Agent attackerAgent, Agent victimAgent, WeaponComponentData attackerWeapon, Blow blow)
      {
         if (!victimAgent.IsHuman) return true;
         if (attackerAgent.Team != null && victimAgent.Team != null)
         {
            if (attackerAgent.Team.Side == victimAgent.Team.Side) return true;
         }

         if (blow.IsMissile)
         {
            if (attackerWeapon.WeaponClass != WeaponClass.Stone && attackerWeapon.WeaponClass != WeaponClass.Javelin)
            {
               return true;
            }
         }

         if (blow.IsFallDamage) return true;


         return false;
      }
   }
}