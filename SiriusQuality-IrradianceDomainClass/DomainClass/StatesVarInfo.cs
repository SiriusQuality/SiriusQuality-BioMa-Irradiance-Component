//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

/// 
/// This class was created from file C:\Users\loicm\GitSiriusCode\SiriusQuality\SiriusCode\Code\SiriusQuality-IrradianceDomainClass\XML\INRA.SiriusQualityIrradiance.Interfaces_States.xml
/// The tool used was: DCC - Domain Class Coder, http://components.biomamodelling.org/, DCC
/// 
/// Loic Manceau
/// loic.manceau@inrae.fr
/// INRAE
/// 
/// 
/// 27/04/2020 10:15:37
/// 
namespace INRA.SiriusQualityIrradiance.Interfaces
{
    using System;
    using CRA.ModelLayer.Core;
    
    
    /// <summary>StatesVarInfoClasses contain the attributes for each variable in the domain class RainData. Attributes are valorized via the static constructor. The data-type VarInfo causes  a dependency to the assembly CRA.Core.Preconditions.dll</summary>
    public class StatesVarInfo : IVarInfoClass
    {
        
        #region Private fields
        static VarInfo _rhoLeaf = new VarInfo();
        
        static VarInfo _tauLeaf = new VarInfo();
        
        static VarInfo _rhoCanopyDiff = new VarInfo();
        
        static VarInfo _rhoCanopyDir = new VarInfo();
        
        static VarInfo _k1_dir = new VarInfo();
        
        static VarInfo _k_dir = new VarInfo();
        
        static VarInfo _k_dif = new VarInfo();
        
        static VarInfo _layersGAI = new VarInfo();
        
        static VarInfo _sunlitFraction = new VarInfo();
        
        static VarInfo _shadeFraction = new VarInfo();
        
        static VarInfo _sunlitShadedFraction = new VarInfo();
        
        static VarInfo _sunlitShadedFractionNIR = new VarInfo();
        
        static VarInfo _sunlitShadedFractionPAR = new VarInfo();
        
        static VarInfo _k_dirNIR = new VarInfo();
        
        static VarInfo _k_dirPAR = new VarInfo();
        
        static VarInfo _k_difNIR = new VarInfo();
        
        static VarInfo _k_difPAR = new VarInfo();
        
        static VarInfo _rhoCanopyDirNIR = new VarInfo();
        
        static VarInfo _rhoCanopyDirPAR = new VarInfo();
        
        static VarInfo _k_difBlack = new VarInfo();
        
        static VarInfo _ala = new VarInfo();
        
        static VarInfo _cumulTT = new VarInfo();
        
        static VarInfo _termSpikletTT = new VarInfo();
        
        static VarInfo _flagLeafLiguleTT = new VarInfo();
        
        static VarInfo _fiPARb = new VarInfo();
        
        static VarInfo _FLN = new VarInfo();
        
        static VarInfo _HS = new VarInfo();
        
        static VarInfo _Phyll = new VarInfo();
        
        static VarInfo _rhoCanopyDiffNIR = new VarInfo();
        
        static VarInfo _rhoCanopyDiffPAR = new VarInfo();
        #endregion
        
        /// <summary>Constructor</summary>
        static StatesVarInfo()
        {
            StatesVarInfo.DescribeVariables();
        }
        
        #region IVarInfoClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "State variables of Irradiance component";
            }
        }
        
        /// <summary>Reference to the ontology</summary>
        public  string URL
        {
            get
            {
                return "http://";
            }
        }
        
        /// <summary>Value domain class of reference</summary>
        public  string DomainClassOfReference
        {
            get
            {
                return "States";
            }
        }
        #endregion
        
        #region Public properties
        /// <summary>Leaf reflectance coefficient</summary>
        public static  VarInfo rhoLeaf
        {
            get
            {
                return  _rhoLeaf;
            }
        }
        
        /// <summary>Leaf transmittance coefficient</summary>
        public static  VarInfo tauLeaf
        {
            get
            {
                return  _tauLeaf;
            }
        }
        
        /// <summary>Reflectance coefficient of a canopy having non horizontal leaves</summary>
        public static  VarInfo rhoCanopyDiff
        {
            get
            {
                return  _rhoCanopyDiff;
            }
        }
        
        /// <summary>Canopy reflectance coefficient to diffuse irradiance</summary>
        public static  VarInfo rhoCanopyDir
        {
            get
            {
                return  _rhoCanopyDir;
            }
        }
        
        /// <summary>Coefficient of extinction of beam irradiance</summary>
        public static  VarInfo k1_dir
        {
            get
            {
                return  _k1_dir;
            }
        }
        
        /// <summary>Coefficient of extinction of beam and scatter irradiances</summary>
        public static  VarInfo k_dir
        {
            get
            {
                return  _k_dir;
            }
        }
        
        /// <summary>Extinction coefficient of diffuse and scatter irradiance from the entire sky</summary>
        public static  VarInfo k_dif
        {
            get
            {
                return  _k_dif;
            }
        }
        
        /// <summary>Leaf area index per layer</summary>
        public static  VarInfo layersGAI
        {
            get
            {
                return  _layersGAI;
            }
        }
        
        /// <summary>Sunlit leaves surface fraction (generic variable)</summary>
        public static  VarInfo sunlitFraction
        {
            get
            {
                return  _sunlitFraction;
            }
        }
        
        /// <summary>Shade leaves surface fraction (generic variable)</summary>
        public static  VarInfo shadeFraction
        {
            get
            {
                return  _shadeFraction;
            }
        }
        
        /// <summary>Summary of fraction of shaded and sunlit leaves</summary>
        public static  VarInfo sunlitShadedFraction
        {
            get
            {
                return  _sunlitShadedFraction;
            }
        }
        
        /// <summary>Summary of fraction of shaded and sunlit leaves for Near Infrared Radiations</summary>
        public static  VarInfo sunlitShadedFractionNIR
        {
            get
            {
                return  _sunlitShadedFractionNIR;
            }
        }
        
        /// <summary>Summary of fraction of shaded and sunlit leaves for Photosynthetically Active radiations</summary>
        public static  VarInfo sunlitShadedFractionPAR
        {
            get
            {
                return  _sunlitShadedFractionPAR;
            }
        }
        
        /// <summary>Coefficient of extinction of beam and scatter irradiances for Near Infrared Radiation</summary>
        public static  VarInfo k_dirNIR
        {
            get
            {
                return  _k_dirNIR;
            }
        }
        
        /// <summary>Coefficient of extinction of beam and scatter irradiances for Photosynthetically Active Radiaitions</summary>
        public static  VarInfo k_dirPAR
        {
            get
            {
                return  _k_dirPAR;
            }
        }
        
        /// <summary>Extinction coefficient of diffuse and scatter irradiance from the entire sky for Near Infrared Radaiations</summary>
        public static  VarInfo k_difNIR
        {
            get
            {
                return  _k_difNIR;
            }
        }
        
        /// <summary>Extinction coefficient of diffuse and scatter irradiance from the entire sky for Photosynthetically Active Radiations</summary>
        public static  VarInfo k_difPAR
        {
            get
            {
                return  _k_difPAR;
            }
        }
        
        /// <summary>Canopy reflectance coefficient to diffuse irradiance for Near Infrared Radiaitions</summary>
        public static  VarInfo rhoCanopyDirNIR
        {
            get
            {
                return  _rhoCanopyDirNIR;
            }
        }
        
        /// <summary>Canopy reflectance coefficient to diffuse irradiance for Photosyntheti cally Active Radiaitions</summary>
        public static  VarInfo rhoCanopyDirPAR
        {
            get
            {
                return  _rhoCanopyDirPAR;
            }
        }
        
        /// <summary>Extinction coefficient of diffuse and scatter irradiance from the entire sky for black leaves</summary>
        public static  VarInfo k_difBlack
        {
            get
            {
                return  _k_difBlack;
            }
        }
        
        /// <summary>Average leaf angle</summary>
        public static  VarInfo ala
        {
            get
            {
                return  _ala;
            }
        }
        
        /// <summary>Cumulative physiological Thermal Time</summary>
        public static  VarInfo cumulTT
        {
            get
            {
                return  _cumulTT;
            }
        }
        
        /// <summary>Cumulative physiological Thermal Time at terrminal spiklet growth stage </summary>
        public static  VarInfo termSpikletTT
        {
            get
            {
                return  _termSpikletTT;
            }
        }
        
        /// <summary>Cumulative physiological Thermal Time at  Flag Leaf Ligulation</summary>
        public static  VarInfo flagLeafLiguleTT
        {
            get
            {
                return  _flagLeafLiguleTT;
            }
        }
        
        /// <summary>Fraction of direct intercepted light</summary>
        public static  VarInfo fiPARb
        {
            get
            {
                return  _fiPARb;
            }
        }
        
        /// <summary>Final Leaf Number</summary>
        public static  VarInfo FLN
        {
            get
            {
                return  _FLN;
            }
        }
        
        /// <summary>Haun Stage</summary>
        public static  VarInfo HS
        {
            get
            {
                return  _HS;
            }
        }
        
        /// <summary>Phyllochron</summary>
        public static  VarInfo Phyll
        {
            get
            {
                return  _Phyll;
            }
        }
        
        /// <summary>eflectance coefficeintfo diffuse NIR</summary>
        public static  VarInfo rhoCanopyDiffNIR
        {
            get
            {
                return  _rhoCanopyDiffNIR;
            }
        }
        
        /// <summary>Reflectance Coefficient for Diffuse PAR</summary>
        public static  VarInfo rhoCanopyDiffPAR
        {
            get
            {
                return  _rhoCanopyDiffPAR;
            }
        }
        #endregion
        
        #region VarInfo values
        /// <summary>Set VarInfo values</summary>
        static void DescribeVariables()
        {
            //   
            _rhoLeaf.Name = "rhoLeaf";
            _rhoLeaf.Description = "Leaf reflectance coefficient";
            _rhoLeaf.MaxValue = 1D;
            _rhoLeaf.MinValue = 0D;
            _rhoLeaf.DefaultValue = 0.07D;
            _rhoLeaf.Units = "-";
            _rhoLeaf.URL = "http://";
            _rhoLeaf.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _tauLeaf.Name = "tauLeaf";
            _tauLeaf.Description = "Leaf transmittance coefficient";
            _tauLeaf.MaxValue = 1D;
            _tauLeaf.MinValue = 0D;
            _tauLeaf.DefaultValue = 0.07D;
            _tauLeaf.Units = "-";
            _tauLeaf.URL = "http://";
            _tauLeaf.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _rhoCanopyDiff.Name = "rhoCanopyDiff";
            _rhoCanopyDiff.Description = "Reflectance coefficient of a canopy having non horizontal leaves";
            _rhoCanopyDiff.MaxValue = 1D;
            _rhoCanopyDiff.MinValue = 0D;
            _rhoCanopyDiff.DefaultValue = 0.5D;
            _rhoCanopyDiff.Units = "-";
            _rhoCanopyDiff.URL = "http://";
            _rhoCanopyDiff.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _rhoCanopyDir.Name = "rhoCanopyDir";
            _rhoCanopyDir.Description = "Canopy reflectance coefficient to diffuse irradiance";
            _rhoCanopyDir.MaxValue = 1D;
            _rhoCanopyDir.MinValue = 0D;
            _rhoCanopyDir.DefaultValue = 0.5D;
            _rhoCanopyDir.Units = "-";
            _rhoCanopyDir.URL = "http://";
            _rhoCanopyDir.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _k1_dir.Name = "k1_dir";
            _k1_dir.Description = "Coefficient of extinction of beam irradiance";
            _k1_dir.MaxValue = 10D;
            _k1_dir.MinValue = 0D;
            _k1_dir.DefaultValue = 1D;
            _k1_dir.Units = "-";
            _k1_dir.URL = "http://";
            _k1_dir.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _k_dir.Name = "k_dir";
            _k_dir.Description = "Coefficient of extinction of beam and scatter irradiances";
            _k_dir.MaxValue = 10D;
            _k_dir.MinValue = 0D;
            _k_dir.DefaultValue = 1D;
            _k_dir.Units = "-";
            _k_dir.URL = "http://";
            _k_dir.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _k_dif.Name = "k_dif";
            _k_dif.Description = "Extinction coefficient of diffuse and scatter irradiance from the entire sky";
            _k_dif.MaxValue = 10D;
            _k_dif.MinValue = 0D;
            _k_dif.DefaultValue = 0.5D;
            _k_dif.Units = "-";
            _k_dif.URL = "http://";
            _k_dif.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _layersGAI.Name = "layersGAI";
            _layersGAI.Description = "Leaf area index per layer";
            _layersGAI.MaxValue = 10D;
            _layersGAI.MinValue = 0D;
            _layersGAI.DefaultValue = 5D;
            _layersGAI.Units = "m²leaf/m²ground";
            _layersGAI.URL = "http://";
            _layersGAI.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _sunlitFraction.Name = "sunlitFraction";
            _sunlitFraction.Description = "Sunlit leaves surface fraction (generic variable)";
            _sunlitFraction.MaxValue = 1D;
            _sunlitFraction.MinValue = 0D;
            _sunlitFraction.DefaultValue = 1D;
            _sunlitFraction.Units = "-";
            _sunlitFraction.URL = "http://";
            _sunlitFraction.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _shadeFraction.Name = "shadeFraction";
            _shadeFraction.Description = "Shade leaves surface fraction (generic variable)";
            _shadeFraction.MaxValue = 1D;
            _shadeFraction.MinValue = 0D;
            _shadeFraction.DefaultValue = 0D;
            _shadeFraction.Units = "-";
            _shadeFraction.URL = "http://";
            _shadeFraction.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _sunlitShadedFraction.Name = "sunlitShadedFraction";
            _sunlitShadedFraction.Description = "Summary of fraction of shaded and sunlit leaves";
            _sunlitShadedFraction.MaxValue = 1D;
            _sunlitShadedFraction.MinValue = 0D;
            _sunlitShadedFraction.DefaultValue = 1D;
            _sunlitShadedFraction.Units = "-";
            _sunlitShadedFraction.URL = "http://";
            _sunlitShadedFraction.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _sunlitShadedFractionNIR.Name = "sunlitShadedFractionNIR";
            _sunlitShadedFractionNIR.Description = "Summary of fraction of shaded and sunlit leaves for Near Infrared Radiations";
            _sunlitShadedFractionNIR.MaxValue = 1D;
            _sunlitShadedFractionNIR.MinValue = 0D;
            _sunlitShadedFractionNIR.DefaultValue = 1D;
            _sunlitShadedFractionNIR.Units = "-";
            _sunlitShadedFractionNIR.URL = "http://";
            _sunlitShadedFractionNIR.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _sunlitShadedFractionPAR.Name = "sunlitShadedFractionPAR";
            _sunlitShadedFractionPAR.Description = "Summary of fraction of shaded and sunlit leaves for Photosynthetically Active rad" +
                "iations";
            _sunlitShadedFractionPAR.MaxValue = 1D;
            _sunlitShadedFractionPAR.MinValue = 0D;
            _sunlitShadedFractionPAR.DefaultValue = 1D;
            _sunlitShadedFractionPAR.Units = "-";
            _sunlitShadedFractionPAR.URL = "http://";
            _sunlitShadedFractionPAR.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _k_dirNIR.Name = "k_dirNIR";
            _k_dirNIR.Description = "Coefficient of extinction of beam and scatter irradiances for Near Infrared Radia" +
                "tion";
            _k_dirNIR.MaxValue = 10D;
            _k_dirNIR.MinValue = 0D;
            _k_dirNIR.DefaultValue = 1D;
            _k_dirNIR.Units = "-";
            _k_dirNIR.URL = "http://";
            _k_dirNIR.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _k_dirPAR.Name = "k_dirPAR";
            _k_dirPAR.Description = "Coefficient of extinction of beam and scatter irradiances for Photosynthetically " +
                "Active Radiaitions";
            _k_dirPAR.MaxValue = 10D;
            _k_dirPAR.MinValue = 0D;
            _k_dirPAR.DefaultValue = 1D;
            _k_dirPAR.Units = "-";
            _k_dirPAR.URL = "http://";
            _k_dirPAR.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _k_difNIR.Name = "k_difNIR";
            _k_difNIR.Description = "Extinction coefficient of diffuse and scatter irradiance from the entire sky for " +
                "Near Infrared Radaiations";
            _k_difNIR.MaxValue = 10D;
            _k_difNIR.MinValue = 0D;
            _k_difNIR.DefaultValue = 0.5D;
            _k_difNIR.Units = "-";
            _k_difNIR.URL = "http://";
            _k_difNIR.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _k_difPAR.Name = "k_difPAR";
            _k_difPAR.Description = "Extinction coefficient of diffuse and scatter irradiance from the entire sky for " +
                "Photosynthetically Active Radiations";
            _k_difPAR.MaxValue = 10D;
            _k_difPAR.MinValue = 0D;
            _k_difPAR.DefaultValue = 0.5D;
            _k_difPAR.Units = "-";
            _k_difPAR.URL = "http://";
            _k_difPAR.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _rhoCanopyDirNIR.Name = "rhoCanopyDirNIR";
            _rhoCanopyDirNIR.Description = "Canopy reflectance coefficient to diffuse irradiance for Near Infrared Radiaition" +
                "s";
            _rhoCanopyDirNIR.MaxValue = 1D;
            _rhoCanopyDirNIR.MinValue = 0D;
            _rhoCanopyDirNIR.DefaultValue = 0.5D;
            _rhoCanopyDirNIR.Units = "-";
            _rhoCanopyDirNIR.URL = "http://";
            _rhoCanopyDirNIR.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _rhoCanopyDirPAR.Name = "rhoCanopyDirPAR";
            _rhoCanopyDirPAR.Description = "Canopy reflectance coefficient to diffuse irradiance for Photosyntheti cally Acti" +
                "ve Radiaitions";
            _rhoCanopyDirPAR.MaxValue = 1D;
            _rhoCanopyDirPAR.MinValue = 0D;
            _rhoCanopyDirPAR.DefaultValue = 0.5D;
            _rhoCanopyDirPAR.Units = "-";
            _rhoCanopyDirPAR.URL = "http://";
            _rhoCanopyDirPAR.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryIntDouble");
            //   
            _k_difBlack.Name = "k_difBlack";
            _k_difBlack.Description = "Extinction coefficient of diffuse and scatter irradiance from the entire sky for " +
                "black leaves";
            _k_difBlack.MaxValue = 10D;
            _k_difBlack.MinValue = 0D;
            _k_difBlack.DefaultValue = 0.5D;
            _k_difBlack.Units = "-";
            _k_difBlack.URL = "http://";
            _k_difBlack.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _ala.Name = "ala";
            _ala.Description = "Average leaf angle";
            _ala.MaxValue = 0.78D;
            _ala.MinValue = 0D;
            _ala.DefaultValue = 3.141592D;
            _ala.Units = "radians";
            _ala.URL = "http://";
            _ala.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _cumulTT.Name = "cumulTT";
            _cumulTT.Description = "Cumulative physiological Thermal Time";
            _cumulTT.MaxValue = 20000D;
            _cumulTT.MinValue = 0D;
            _cumulTT.DefaultValue = 0D;
            _cumulTT.Units = "°Cd";
            _cumulTT.URL = "http://";
            _cumulTT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _termSpikletTT.Name = "termSpikletTT";
            _termSpikletTT.Description = "Cumulative physiological Thermal Time at terrminal spiklet growth stage ";
            _termSpikletTT.MaxValue = 20000D;
            _termSpikletTT.MinValue = 0D;
            _termSpikletTT.DefaultValue = 0D;
            _termSpikletTT.Units = "°Cd";
            _termSpikletTT.URL = "http://";
            _termSpikletTT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _flagLeafLiguleTT.Name = "flagLeafLiguleTT";
            _flagLeafLiguleTT.Description = "Cumulative physiological Thermal Time at  Flag Leaf Ligulation";
            _flagLeafLiguleTT.MaxValue = 20000D;
            _flagLeafLiguleTT.MinValue = 0D;
            _flagLeafLiguleTT.DefaultValue = 0D;
            _flagLeafLiguleTT.Units = "°Cd";
            _flagLeafLiguleTT.URL = "http://";
            _flagLeafLiguleTT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _fiPARb.Name = "fiPARb";
            _fiPARb.Description = "Fraction of direct intercepted light";
            _fiPARb.MaxValue = 1D;
            _fiPARb.MinValue = 0D;
            _fiPARb.DefaultValue = 0D;
            _fiPARb.Units = "-";
            _fiPARb.URL = "http://";
            _fiPARb.ValueType = VarInfoValueTypes.GetInstanceForName("DictionaryDoubleDouble");
            //   
            _FLN.Name = "FLN";
            _FLN.Description = "Final Leaf Number";
            _FLN.MaxValue = 100D;
            _FLN.MinValue = 0D;
            _FLN.DefaultValue = 15D;
            _FLN.Units = "leaf";
            _FLN.URL = "http://";
            _FLN.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _HS.Name = "HS";
            _HS.Description = "Haun Stage";
            _HS.MaxValue = 100D;
            _HS.MinValue = 0D;
            _HS.DefaultValue = 5D;
            _HS.Units = "leaf";
            _HS.URL = "http://";
            _HS.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _Phyll.Name = "Phyll";
            _Phyll.Description = "Phyllochron";
            _Phyll.MaxValue = 1000D;
            _Phyll.MinValue = 0D;
            _Phyll.DefaultValue = 120D;
            _Phyll.Units = "°Cd/leaf";
            _Phyll.URL = "http://";
            _Phyll.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _rhoCanopyDiffNIR.Name = "rhoCanopyDiffNIR";
            _rhoCanopyDiffNIR.Description = "eflectance coefficeintfo diffuse NIR";
            _rhoCanopyDiffNIR.MaxValue = 1D;
            _rhoCanopyDiffNIR.MinValue = 0D;
            _rhoCanopyDiffNIR.DefaultValue = 1D;
            _rhoCanopyDiffNIR.Units = "-";
            _rhoCanopyDiffNIR.URL = "http://";
            _rhoCanopyDiffNIR.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _rhoCanopyDiffPAR.Name = "rhoCanopyDiffPAR";
            _rhoCanopyDiffPAR.Description = "Reflectance Coefficient for Diffuse PAR";
            _rhoCanopyDiffPAR.MaxValue = 1D;
            _rhoCanopyDiffPAR.MinValue = 0D;
            _rhoCanopyDiffPAR.DefaultValue = 1D;
            _rhoCanopyDiffPAR.Units = "-";
            _rhoCanopyDiffPAR.URL = "http://";
            _rhoCanopyDiffPAR.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }
        #endregion
    }
}