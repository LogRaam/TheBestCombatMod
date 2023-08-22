// Code written by Gabriel Mailhot, 10/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.GeneralOptions;

#endregion

namespace TheBestCombatMod.Features.Unseat.Values
{
   public class ImpactUnseatChanceValue
   {
      public ImpactUnseatChanceValue(in string[] loadedOptions)
      {
         Update(loadedOptions);
      }

      public int ABDOMEN_BLUNT_SWINGING_v2v6T { get; set; }
      public int ABDOMEN_BLUNT_THRUSTING_6gLsx { get; set; }
      public int ABDOMEN_CUT_SWINGING_tRqGA { get; set; }
      public int ABDOMEN_CUT_THRUSTING_eypTb { get; set; }
      public int ABDOMEN_PIERCE_SWINGING_VTO6S { get; set; }
      public int ABDOMEN_PIERCE_THRUSTING_suxMY { get; set; }
      public int ARMS_BLUNT_SWINGING_zwGj0 { get; set; }
      public int ARMS_BLUNT_THRUSTING_E9s8D { get; set; }
      public int ARMS_CUT_SWINGING_eMIfX { get; set; }
      public int ARMS_CUT_THRUSTING_uHDMI { get; set; }
      public int ARMS_PIERCE_SWINGING_ScPD3 { get; set; }
      public int ARMS_PIERCE_THRUSTING_7R3oW { get; set; }
      public int CHEST_BLUNT_SWINGING_Ip0TE { get; set; }
      public int CHEST_BLUNT_THRUSTING_ktCEu { get; set; }
      public int CHEST_CUT_SWINGING_sQmx7 { get; set; }
      public int CHEST_CUT_THRUSTING_dNomI { get; set; }
      public int CHEST_PIERCE_SWINGING_6ssat { get; set; }
      public int CHEST_PIERCE_THRUSTING_ybixm { get; set; }
      public int HEAD_BLUNT_SWINGING_8VPtS { get; set; }
      public int HEAD_BLUNT_THRUSTING_UzQhf { get; set; }
      public int HEAD_CUT_SWINGING_05zN2 { get; set; }
      public int HEAD_CUT_THRUSTING_IgazM { get; set; }
      public int HEAD_PIERCE_SWINGING_JMWpz { get; set; }
      public int HEAD_PIERCE_THRUSTING_pMa5J { get; set; }
      public int LEGS_BLUNT_SWINGING_JTLxV { get; set; }
      public int LEGS_BLUNT_THRUSTING_awuSL { get; set; }
      public int LEGS_CUT_SWINGING_xOKtK { get; set; }
      public int LEGS_CUT_THRUSTING_hEsET { get; set; }
      public int LEGS_PIERCE_SWINGING_6DD8t { get; set; }
      public int LEGS_PIERCE_THRUSTING_NblKm { get; set; }
      public int NECK_BLUNT_SWINGING_Z19yv { get; set; }
      public int NECK_BLUNT_THRUSTING_yZEV1 { get; set; }
      public int NECK_CUT_SWINGING_OJ42D { get; set; }
      public int NECK_CUT_THRUSTING_JDsUb { get; set; }
      public int NECK_PIERCE_SWINGING_16Tqb { get; set; }
      public int NECK_PIERCE_THRUSTING_PwjyT { get; set; }
      public int SHOULDERS_BLUNT_SWINGING_TplnH { get; set; }
      public int SHOULDERS_BLUNT_THRUSTING_gqk9L { get; set; }
      public int SHOULDERS_CUT_SWINGING_8yoXK { get; set; }
      public int SHOULDERS_CUT_THRUSTING_2Y1ez { get; set; }
      public int SHOULDERS_PIERCE_SWINGING_HoWbh { get; set; }
      public int SHOULDERS_PIERCE_THRUSTING_UhpJO { get; set; }


      public void Update(in string[] loadedOptions)
      {
         var loader = new ConfigLoader();
         var option = new UnseatByBlowOptions(new OptionBase(), new UnseatActivationRefTag(), new UnseatValueRefTag(), new ActivationRefTag(), new ValueRefTag());

         Runtime.StaggerStrength.Update(loadedOptions);

         HEAD_CUT_SWINGING_05zN2 = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.HEAD_CUT_SWINGING_05zN2_Value));
         HEAD_CUT_THRUSTING_IgazM = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.HEAD_CUT_THRUSTING_IgazM_Value));
         HEAD_BLUNT_SWINGING_8VPtS = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.HEAD_BLUNT_SWINGING_8VPtS_Value));
         HEAD_BLUNT_THRUSTING_UzQhf = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.HEAD_BLUNT_THRUSTING_UzQhf_Value));
         HEAD_PIERCE_SWINGING_JMWpz = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.HEAD_PIERCE_SWINGING_JMWpz_Value));
         HEAD_PIERCE_THRUSTING_pMa5J = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.HEAD_PIERCE_THRUSTING_pMa5J_Value));
         NECK_BLUNT_SWINGING_Z19yv = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.NECK_BLUNT_SWINGING_Z19yv_Value));
         NECK_BLUNT_THRUSTING_yZEV1 = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.NECK_BLUNT_THRUSTING_yZEV1_Value));
         NECK_CUT_SWINGING_OJ42D = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.NECK_CUT_SWINGING_OJ42D_Value));
         NECK_CUT_THRUSTING_JDsUb = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.NECK_CUT_THRUSTING_JDsUb_Value));
         NECK_PIERCE_SWINGING_16Tqb = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.NECK_PIERCE_SWINGING_16Tqb_Value));
         NECK_PIERCE_THRUSTING_PwjyT = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.NECK_PIERCE_THRUSTING_PwjyT_Value));
         CHEST_BLUNT_SWINGING_Ip0TE = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.CHEST_BLUNT_SWINGING_Ip0TE_Value));
         CHEST_BLUNT_THRUSTING_ktCEu = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.CHEST_BLUNT_THRUSTING_ktCEu_Value));
         CHEST_CUT_SWINGING_sQmx7 = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.CHEST_CUT_SWINGING_sQmx7_Value));
         CHEST_CUT_THRUSTING_dNomI = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.CHEST_CUT_THRUSTING_dNomI_Value));
         CHEST_PIERCE_SWINGING_6ssat = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.CHEST_PIERCE_SWINGING_6ssat_Value));
         CHEST_PIERCE_THRUSTING_ybixm = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.CHEST_PIERCE_THRUSTING_ybixm_Value));
         ABDOMEN_BLUNT_SWINGING_v2v6T = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ABDOMEN_BLUNT_SWINGING_v2v6T_Value));
         ABDOMEN_BLUNT_THRUSTING_6gLsx = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ABDOMEN_BLUNT_THRUSTING_6gLsx_Value));
         ABDOMEN_CUT_SWINGING_tRqGA = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ABDOMEN_CUT_SWINGING_tRqGA_Value));
         ABDOMEN_CUT_THRUSTING_eypTb = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ABDOMEN_CUT_THRUSTING_eypTb_Value));
         ABDOMEN_PIERCE_SWINGING_VTO6S = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ABDOMEN_PIERCE_SWINGING_VTO6S_Value));
         ABDOMEN_PIERCE_THRUSTING_suxMY = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ABDOMEN_PIERCE_THRUSTING_suxMY_Value));
         SHOULDERS_BLUNT_SWINGING_TplnH = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.SHOULDERS_BLUNT_SWINGING_TplnH_Value));
         SHOULDERS_BLUNT_THRUSTING_gqk9L = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.SHOULDERS_BLUNT_THRUSTING_gqk9L_Value));
         SHOULDERS_CUT_SWINGING_8yoXK = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.SHOULDERS_CUT_SWINGING_8yoXK_Value));
         SHOULDERS_CUT_THRUSTING_2Y1ez = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.SHOULDERS_CUT_THRUSTING_2Y1ez_Value));
         SHOULDERS_PIERCE_SWINGING_HoWbh = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.SHOULDERS_PIERCE_SWINGING_HoWbh_Value));
         SHOULDERS_PIERCE_THRUSTING_UhpJO = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.SHOULDERS_PIERCE_THRUSTING_UhpJO_Value));
         ARMS_BLUNT_SWINGING_zwGj0 = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ARMS_BLUNT_SWINGING_zwGj0_Value));
         ARMS_BLUNT_THRUSTING_E9s8D = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ARMS_BLUNT_THRUSTING_E9s8D_Value));
         ARMS_CUT_SWINGING_eMIfX = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ARMS_CUT_SWINGING_eMIfX_Value));
         ARMS_CUT_THRUSTING_uHDMI = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ARMS_CUT_THRUSTING_uHDMI_Value));
         ARMS_PIERCE_SWINGING_ScPD3 = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ARMS_PIERCE_SWINGING_ScPD3_Value));
         ARMS_PIERCE_THRUSTING_7R3oW = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.ARMS_PIERCE_THRUSTING_7R3oW_Value));
         LEGS_BLUNT_SWINGING_JTLxV = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.LEGS_BLUNT_SWINGING_JTLxV_Value));
         LEGS_BLUNT_THRUSTING_awuSL = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.LEGS_BLUNT_THRUSTING_awuSL_Value));
         LEGS_CUT_SWINGING_xOKtK = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.LEGS_CUT_SWINGING_xOKtK_Value));
         LEGS_CUT_THRUSTING_hEsET = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.LEGS_CUT_THRUSTING_hEsET_Value));
         LEGS_PIERCE_SWINGING_6DD8t = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.LEGS_PIERCE_SWINGING_6DD8t_Value));
         LEGS_PIERCE_THRUSTING_NblKm = Runtime.StaggerStrength.Convert(loader.RetrieveAlphaValueFrom(loadedOptions, option.UnseatValueTags.LEGS_PIERCE_THRUSTING_NblKm_Value));
      }
   }
}