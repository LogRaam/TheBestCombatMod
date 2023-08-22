// Code written by Gabriel Mailhot, 09/08/2023.

#region

using TaleWorlds.CampaignSystem;

#endregion

namespace TheBestCombatMod
{
   internal class ConfigurationBehavior : CampaignBehaviorBase
   {
      public override void RegisterEvents()
      {
         CampaignEvents.BeforeMissionOpenedEvent.AddNonSerializedListener(this, OnBeforeMissionOpened);
      }

      public override void SyncData(IDataStore dataStore)
      {
         //
      }

      #region private

      private static void LoadConfigsIfNeeded()
      {
         if (Runtime.LoadedOptions.Reload()) UpdateValues();
      }

      private static void UpdateValues()
      {
         var loadedOptions = Runtime.LoadedOptions.GetContent();
         Runtime.Resistance.Update(loadedOptions);
         Runtime.StaggerStrength.Update(loadedOptions);
         Runtime.BodyPartUnseatStaggerValue.Update(loadedOptions);
         Runtime.ImpactUnseatChanceValue.Update(loadedOptions);
         Runtime.UnseatContextualAdditionalValue.Update(loadedOptions);
         Runtime.WeaponStaggerForceValue.Update(loadedOptions);
         Runtime.KnockDownStrenghtValue.Update(loadedOptions);
      }

      private void OnBeforeMissionOpened()
      {
         LoadConfigsIfNeeded();
      }

      #endregion
   }
}