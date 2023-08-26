// Code written by Gabriel Mailhot, 24/08/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod.Concept
{
   public interface TW_DefenseInformation
   {
      public ArmorComponent.ArmorMaterialTypes GetArmorMaterialType(Agent victimAgent, Blow blow);
      public EquipmentElement? RetrieveArmorPieceThatHaveBeenHit(Equipment equipment, BoneBodyPartType blowVictimBodyPart);
   }
}