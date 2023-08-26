// Code written by Gabriel Mailhot, 17/08/2023.

#region

using TaleWorlds.Library;

#endregion

namespace TheBestCombatMod
{
   internal static class ScreenLogger
   {
      public static void LogMessage(string message, Color color)
      {
         InformationManager.DisplayMessage(new InformationMessage(message, color));
      }
   }
}