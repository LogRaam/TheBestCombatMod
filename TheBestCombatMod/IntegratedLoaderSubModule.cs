// Code written by Gabriel Mailhot, 01/08/2023.

#region

using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace TheBestCombatMod
{
   internal class IntegratedLoaderSubModule : MBSubModuleBase
   {
      protected override void OnGameStart(Game game, IGameStarter gameStarter)
      {
         var starter = (CampaignGameStarter) gameStarter;
         starter.AddBehavior(new ConfigurationBehavior());
      }

      protected override void OnSubModuleLoad()
      {
         base.OnSubModuleLoad();
         var harmony = new Harmony("mod.thebestcombatmod.patch");
         harmony.PatchAll(Assembly.GetExecutingAssembly());
      }
   }
}