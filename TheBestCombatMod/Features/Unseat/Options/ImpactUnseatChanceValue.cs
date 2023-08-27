// Code written by Gabriel Mailhot, 24/08/2023.

#region

using LogRaamConfiguration;
using TheBestCombatMod.Concept;

#endregion

namespace TheBestCombatMod.Features.Unseat.Options
{
   public class ImpactUnseatChanceValue : ImpactChanceOptions
   {
      private readonly ConfigurationLoader _configLoader;
      private readonly string[] _loadedOptions;
      private readonly UnseatOptionReader _optionsReader;
      private readonly StaggerStrengthOptions _staggerStrengthOptions;

      public ImpactUnseatChanceValue(in ImpactUnseatChanceValueConstructorParams parameters)
      {
         _loadedOptions = parameters.LoadedOptions;
         _configLoader = parameters.ConfigLoader;
         _optionsReader = parameters.OptionsReader;
         _staggerStrengthOptions = parameters.StaggerStrengthOptions;
         Update();
      }

      #region private properties

      private int ABDOMEN_BLUNT_SWINGING_v2v6T { get; set; }
      private int ABDOMEN_BLUNT_THRUSTING_6gLsx { get; set; }
      private int ABDOMEN_CUT_SWINGING_tRqGA { get; set; }
      private int ABDOMEN_CUT_THRUSTING_eypTb { get; set; }
      private int ABDOMEN_PIERCE_SWINGING_VTO6S { get; set; }
      private int ABDOMEN_PIERCE_THRUSTING_suxMY { get; set; }
      private int ARMS_BLUNT_SWINGING_zwGj0 { get; set; }
      private int ARMS_BLUNT_THRUSTING_E9s8D { get; set; }
      private int ARMS_CUT_SWINGING_eMIfX { get; set; }
      private int ARMS_CUT_THRUSTING_uHDMI { get; set; }
      private int ARMS_PIERCE_SWINGING_ScPD3 { get; set; }
      private int ARMS_PIERCE_THRUSTING_7R3oW { get; set; }
      private int CHEST_BLUNT_SWINGING_Ip0TE { get; set; }
      private int CHEST_BLUNT_THRUSTING_ktCEu { get; set; }
      private int CHEST_CUT_SWINGING_sQmx7 { get; set; }
      private int CHEST_CUT_THRUSTING_dNomI { get; set; }
      private int CHEST_PIERCE_SWINGING_6ssat { get; set; }
      private int CHEST_PIERCE_THRUSTING_ybixm { get; set; }
      private int HEAD_BLUNT_SWINGING_8VPtS { get; set; }
      private int HEAD_BLUNT_THRUSTING_UzQhf { get; set; }
      private int HEAD_CUT_SWINGING_05zN2 { get; set; }
      private int HEAD_CUT_THRUSTING_IgazM { get; set; }
      private int HEAD_PIERCE_SWINGING_JMWpz { get; set; }
      private int HEAD_PIERCE_THRUSTING_pMa5J { get; set; }
      private int LEGS_BLUNT_SWINGING_JTLxV { get; set; }
      private int LEGS_BLUNT_THRUSTING_awuSL { get; set; }
      private int LEGS_CUT_SWINGING_xOKtK { get; set; }
      private int LEGS_CUT_THRUSTING_hEsET { get; set; }
      private int LEGS_PIERCE_SWINGING_6DD8t { get; set; }
      private int LEGS_PIERCE_THRUSTING_NblKm { get; set; }
      private int NECK_BLUNT_SWINGING_Z19yv { get; set; }
      private int NECK_BLUNT_THRUSTING_yZEV1 { get; set; }
      private int NECK_CUT_SWINGING_OJ42D { get; set; }
      private int NECK_CUT_THRUSTING_JDsUb { get; set; }
      private int NECK_PIERCE_SWINGING_16Tqb { get; set; }
      private int NECK_PIERCE_THRUSTING_PwjyT { get; set; }
      private int SHOULDERS_BLUNT_SWINGING_TplnH { get; set; }
      private int SHOULDERS_BLUNT_THRUSTING_gqk9L { get; set; }
      private int SHOULDERS_CUT_SWINGING_8yoXK { get; set; }
      private int SHOULDERS_CUT_THRUSTING_2Y1ez { get; set; }
      private int SHOULDERS_PIERCE_SWINGING_HoWbh { get; set; }
      private int SHOULDERS_PIERCE_THRUSTING_UhpJO { get; set; }

      #endregion

      public int ABDOMEN_BLUNT_SWINGING() => ABDOMEN_BLUNT_SWINGING_v2v6T;
      public int ABDOMEN_BLUNT_THRUSTING() => ABDOMEN_BLUNT_THRUSTING_6gLsx;
      public int ABDOMEN_CUT_SWINGING() => ABDOMEN_CUT_SWINGING_tRqGA;
      public int ABDOMEN_CUT_THRUSTING() => ABDOMEN_CUT_THRUSTING_eypTb;
      public int ABDOMEN_PIERCE_SWINGING() => ABDOMEN_PIERCE_SWINGING_VTO6S;
      public int ABDOMEN_PIERCE_THRUSTING() => ABDOMEN_PIERCE_THRUSTING_suxMY;
      public int ARMS_BLUNT_SWINGING() => ARMS_BLUNT_SWINGING_zwGj0;
      public int ARMS_BLUNT_THRUSTING() => ARMS_BLUNT_THRUSTING_E9s8D;
      public int ARMS_CUT_SWINGING() => ARMS_CUT_SWINGING_eMIfX;
      public int ARMS_CUT_THRUSTING() => ARMS_CUT_THRUSTING_uHDMI;
      public int ARMS_PIERCE_SWINGING() => ARMS_PIERCE_SWINGING_ScPD3;
      public int ARMS_PIERCE_THRUSTING() => ARMS_PIERCE_THRUSTING_7R3oW;
      public int CHEST_BLUNT_SWINGING() => CHEST_BLUNT_SWINGING_Ip0TE;
      public int CHEST_BLUNT_THRUSTING() => CHEST_BLUNT_THRUSTING_ktCEu;
      public int CHEST_CUT_SWINGING() => CHEST_CUT_SWINGING_sQmx7;
      public int CHEST_CUT_THRUSTING() => CHEST_CUT_THRUSTING_dNomI;
      public int CHEST_PIERCE_SWINGING() => CHEST_PIERCE_SWINGING_6ssat;
      public int CHEST_PIERCE_THRUSTING() => CHEST_PIERCE_THRUSTING_ybixm;
      public int HEAD_BLUNT_SWINGING() => HEAD_BLUNT_SWINGING_8VPtS;
      public int HEAD_BLUNT_THRUSTING() => HEAD_BLUNT_THRUSTING_UzQhf;
      public int HEAD_CUT_SWINGING() => HEAD_CUT_SWINGING_05zN2;
      public int HEAD_CUT_THRUSTING() => HEAD_CUT_THRUSTING_IgazM;
      public int HEAD_PIERCE_SWINGING() => HEAD_PIERCE_SWINGING_JMWpz;
      public int HEAD_PIERCE_THRUSTING() => HEAD_PIERCE_THRUSTING_pMa5J;
      public int LEGS_BLUNT_SWINGING() => LEGS_BLUNT_SWINGING_JTLxV;
      public int LEGS_BLUNT_THRUSTING() => LEGS_BLUNT_THRUSTING_awuSL;
      public int LEGS_CUT_SWINGING() => LEGS_CUT_SWINGING_xOKtK;
      public int LEGS_CUT_THRUSTING() => LEGS_CUT_THRUSTING_hEsET;
      public int LEGS_PIERCE_SWINGING() => LEGS_PIERCE_SWINGING_6DD8t;
      public int LEGS_PIERCE_THRUSTING() => LEGS_PIERCE_THRUSTING_NblKm;
      public int NECK_BLUNT_SWINGING() => NECK_BLUNT_SWINGING_Z19yv;
      public int NECK_BLUNT_THRUSTING() => NECK_BLUNT_THRUSTING_yZEV1;
      public int NECK_CUT_SWINGING() => NECK_CUT_SWINGING_OJ42D;
      public int NECK_CUT_THRUSTING() => NECK_CUT_THRUSTING_JDsUb;
      public int NECK_PIERCE_SWINGING() => NECK_PIERCE_SWINGING_16Tqb;
      public int NECK_PIERCE_THRUSTING() => NECK_PIERCE_THRUSTING_PwjyT;
      public int SHOULDERS_BLUNT_SWINGING() => SHOULDERS_BLUNT_SWINGING_TplnH;
      public int SHOULDERS_BLUNT_THRUSTING() => SHOULDERS_BLUNT_THRUSTING_gqk9L;
      public int SHOULDERS_CUT_SWINGING() => SHOULDERS_CUT_SWINGING_8yoXK;
      public int SHOULDERS_CUT_THRUSTING() => SHOULDERS_CUT_THRUSTING_2Y1ez;
      public int SHOULDERS_PIERCE_SWINGING() => SHOULDERS_PIERCE_SWINGING_HoWbh;
      public int SHOULDERS_PIERCE_THRUSTING() => SHOULDERS_PIERCE_THRUSTING_UhpJO;


      public void Update()
      {
         if (_loadedOptions.Length == 0) return;

         _staggerStrengthOptions.Update();

         LoadValues();
      }

      #region private

      private void LoadValues()
      {
         HEAD_CUT_SWINGING_05zN2 = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.HEAD_CUT_SWINGING_05zN2_Value));
         HEAD_CUT_THRUSTING_IgazM = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.HEAD_CUT_THRUSTING_IgazM_Value));
         HEAD_BLUNT_SWINGING_8VPtS = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.HEAD_BLUNT_SWINGING_8VPtS_Value));
         HEAD_BLUNT_THRUSTING_UzQhf = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.HEAD_BLUNT_THRUSTING_UzQhf_Value));
         HEAD_PIERCE_SWINGING_JMWpz = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.HEAD_PIERCE_SWINGING_JMWpz_Value));
         HEAD_PIERCE_THRUSTING_pMa5J = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.HEAD_PIERCE_THRUSTING_pMa5J_Value));
         NECK_BLUNT_SWINGING_Z19yv = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.NECK_BLUNT_SWINGING_Z19yv_Value));
         NECK_BLUNT_THRUSTING_yZEV1 = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.NECK_BLUNT_THRUSTING_yZEV1_Value));
         NECK_CUT_SWINGING_OJ42D = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.NECK_CUT_SWINGING_OJ42D_Value));
         NECK_CUT_THRUSTING_JDsUb = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.NECK_CUT_THRUSTING_JDsUb_Value));
         NECK_PIERCE_SWINGING_16Tqb = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.NECK_PIERCE_SWINGING_16Tqb_Value));
         NECK_PIERCE_THRUSTING_PwjyT = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.NECK_PIERCE_THRUSTING_PwjyT_Value));
         CHEST_BLUNT_SWINGING_Ip0TE = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.CHEST_BLUNT_SWINGING_Ip0TE_Value));
         CHEST_BLUNT_THRUSTING_ktCEu = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.CHEST_BLUNT_THRUSTING_ktCEu_Value));
         CHEST_CUT_SWINGING_sQmx7 = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.CHEST_CUT_SWINGING_sQmx7_Value));
         CHEST_CUT_THRUSTING_dNomI = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.CHEST_CUT_THRUSTING_dNomI_Value));
         CHEST_PIERCE_SWINGING_6ssat = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.CHEST_PIERCE_SWINGING_6ssat_Value));
         CHEST_PIERCE_THRUSTING_ybixm = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.CHEST_PIERCE_THRUSTING_ybixm_Value));
         ABDOMEN_BLUNT_SWINGING_v2v6T = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ABDOMEN_BLUNT_SWINGING_v2v6T_Value));
         ABDOMEN_BLUNT_THRUSTING_6gLsx = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ABDOMEN_BLUNT_THRUSTING_6gLsx_Value));
         ABDOMEN_CUT_SWINGING_tRqGA = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ABDOMEN_CUT_SWINGING_tRqGA_Value));
         ABDOMEN_CUT_THRUSTING_eypTb = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ABDOMEN_CUT_THRUSTING_eypTb_Value));
         ABDOMEN_PIERCE_SWINGING_VTO6S = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ABDOMEN_PIERCE_SWINGING_VTO6S_Value));
         ABDOMEN_PIERCE_THRUSTING_suxMY = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ABDOMEN_PIERCE_THRUSTING_suxMY_Value));
         SHOULDERS_BLUNT_SWINGING_TplnH = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.SHOULDERS_BLUNT_SWINGING_TplnH_Value));
         SHOULDERS_BLUNT_THRUSTING_gqk9L = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.SHOULDERS_BLUNT_THRUSTING_gqk9L_Value));
         SHOULDERS_CUT_SWINGING_8yoXK = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.SHOULDERS_CUT_SWINGING_8yoXK_Value));
         SHOULDERS_CUT_THRUSTING_2Y1ez = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.SHOULDERS_CUT_THRUSTING_2Y1ez_Value));
         SHOULDERS_PIERCE_SWINGING_HoWbh = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.SHOULDERS_PIERCE_SWINGING_HoWbh_Value));
         SHOULDERS_PIERCE_THRUSTING_UhpJO = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.SHOULDERS_PIERCE_THRUSTING_UhpJO_Value));
         ARMS_BLUNT_SWINGING_zwGj0 = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ARMS_BLUNT_SWINGING_zwGj0_Value));
         ARMS_BLUNT_THRUSTING_E9s8D = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ARMS_BLUNT_THRUSTING_E9s8D_Value));
         ARMS_CUT_SWINGING_eMIfX = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ARMS_CUT_SWINGING_eMIfX_Value));
         ARMS_CUT_THRUSTING_uHDMI = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ARMS_CUT_THRUSTING_uHDMI_Value));
         ARMS_PIERCE_SWINGING_ScPD3 = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ARMS_PIERCE_SWINGING_ScPD3_Value));
         ARMS_PIERCE_THRUSTING_7R3oW = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.ARMS_PIERCE_THRUSTING_7R3oW_Value));
         LEGS_BLUNT_SWINGING_JTLxV = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.LEGS_BLUNT_SWINGING_JTLxV_Value));
         LEGS_BLUNT_THRUSTING_awuSL = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.LEGS_BLUNT_THRUSTING_awuSL_Value));
         LEGS_CUT_SWINGING_xOKtK = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.LEGS_CUT_SWINGING_xOKtK_Value));
         LEGS_CUT_THRUSTING_hEsET = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.LEGS_CUT_THRUSTING_hEsET_Value));
         LEGS_PIERCE_SWINGING_6DD8t = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.LEGS_PIERCE_SWINGING_6DD8t_Value));
         LEGS_PIERCE_THRUSTING_NblKm = Runtime.StaggerStrength.Convert(_configLoader.RetrieveAlphaValueFrom(_loadedOptions, _optionsReader.UnseatValues.LEGS_PIERCE_THRUSTING_NblKm_Value));
      }

      #endregion
   }


   public class ImpactUnseatChanceValueParams : ImpactUnseatChanceValueConstructorParams
   {
      public ImpactUnseatChanceValueParams(in string[] loadedOptions,
                                           in ConfigurationLoader configLoader,
                                           in UnseatOptionReader optionsReader,
                                           in StaggerStrengthOptions staggerStrengthOptions)
      {
         LoadedOptions = loadedOptions;
         ConfigLoader = configLoader;
         OptionsReader = optionsReader;
         StaggerStrengthOptions = staggerStrengthOptions;
      }

      public ConfigurationLoader ConfigLoader { get; set; }
      public string[] LoadedOptions { get; set; }
      public UnseatOptionReader OptionsReader { get; set; }
      public StaggerStrengthOptions StaggerStrengthOptions { get; set; }
   }

   public interface ImpactUnseatChanceValueConstructorParams
   {
      ConfigurationLoader ConfigLoader { get; set; }
      string[] LoadedOptions { get; set; }
      UnseatOptionReader OptionsReader { get; set; }
      StaggerStrengthOptions StaggerStrengthOptions { get; set; }
   }
}