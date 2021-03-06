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
/// This class was created from file C:\Users\mancealo\Documents\Sirius Quality\branches\RamiAprilCPModuleIrr\Code\SiriusQuality-IrradianceDomainClass\XML\INRA.SiriusQualityIrradiance.Interfaces_Exogenous.xml
/// The tool used was: DCC - Domain Class Coder, http://components.biomamodelling.org/, DCC
/// 
/// Loic Manceau
/// loic.manceau@inra.fr
/// INRA
/// 
/// 
/// 3/2/2018 2:46:30 PM
/// 
namespace INRA.SiriusQualityIrradiance.Interfaces
{
    using System;
    using CRA.ModelLayer.Core;
    
    
    /// <summary>ExogenousVarInfoClasses contain the attributes for each variable in the domain class RainData. Attributes are valorized via the static constructor. The data-type VarInfo causes  a dependency to the assembly CRA.Core.Preconditions.dll</summary>
    public class ExogenousVarInfo : IVarInfoClass
    {
        
        #region Private fields
        static VarInfo _incidentDirectIrradiance = new VarInfo();
        
        static VarInfo _incidentDiffuseIrradiance = new VarInfo();
        
        static VarInfo _solarElevation = new VarInfo();
        
        static VarInfo _incidentDirectIrradianceNIR = new VarInfo();
        
        static VarInfo _incidentDirectIrradiancePAR = new VarInfo();
        
        static VarInfo _incidentDiffuseIrradianceNIR = new VarInfo();
        
        static VarInfo _incidentDiffuseIrradiancePAR = new VarInfo();
        #endregion
        
        /// <summary>Constructor</summary>
        static ExogenousVarInfo()
        {
            ExogenousVarInfo.DescribeVariables();
        }
        
        #region IVarInfoClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "Domain class for Irradiance exogenous states";
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
                return "Exogenous";
            }
        }
        #endregion
        
        #region Public properties
        /// <summary>Incident beam irradiance</summary>
        public static  VarInfo incidentDirectIrradiance
        {
            get
            {
                return  _incidentDirectIrradiance;
            }
        }
        
        /// <summary>Incident diffuse irradiance</summary>
        public static  VarInfo incidentDiffuseIrradiance
        {
            get
            {
                return  _incidentDiffuseIrradiance;
            }
        }
        
        /// <summary>Solar elevation angle</summary>
        public static  VarInfo solarElevation
        {
            get
            {
                return  _solarElevation;
            }
        }
        
        /// <summary>Incident beam irradiance for Near Infrared Radiations</summary>
        public static  VarInfo incidentDirectIrradianceNIR
        {
            get
            {
                return  _incidentDirectIrradianceNIR;
            }
        }
        
        /// <summary>Incident beam irradiance for Photosynthetically Active Radiations</summary>
        public static  VarInfo incidentDirectIrradiancePAR
        {
            get
            {
                return  _incidentDirectIrradiancePAR;
            }
        }
        
        /// <summary>Incident diffuse irradiance for Near Infrared Radiations</summary>
        public static  VarInfo incidentDiffuseIrradianceNIR
        {
            get
            {
                return  _incidentDiffuseIrradianceNIR;
            }
        }
        
        /// <summary>Incident diffuse irradiance for Photosynthetically Active Radiations</summary>
        public static  VarInfo incidentDiffuseIrradiancePAR
        {
            get
            {
                return  _incidentDiffuseIrradiancePAR;
            }
        }
        #endregion
        
        #region VarInfo values
        /// <summary>Set VarInfo values</summary>
        static void DescribeVariables()
        {
            //   
            _incidentDirectIrradiance.Name = "incidentDirectIrradiance";
            _incidentDirectIrradiance.Description = "Incident beam irradiance";
            _incidentDirectIrradiance.MaxValue = 1D;
            _incidentDirectIrradiance.MinValue = 0D;
            _incidentDirectIrradiance.DefaultValue = 1D;
            _incidentDirectIrradiance.Units = "MJ m-2 h-1";
            _incidentDirectIrradiance.URL = "http://";
            _incidentDirectIrradiance.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _incidentDiffuseIrradiance.Name = "incidentDiffuseIrradiance";
            _incidentDiffuseIrradiance.Description = "Incident diffuse irradiance";
            _incidentDiffuseIrradiance.MaxValue = 1D;
            _incidentDiffuseIrradiance.MinValue = 0D;
            _incidentDiffuseIrradiance.DefaultValue = 1D;
            _incidentDiffuseIrradiance.Units = "MJ m-2 h-1";
            _incidentDiffuseIrradiance.URL = "http://";
            _incidentDiffuseIrradiance.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _solarElevation.Name = "solarElevation";
            _solarElevation.Description = "Solar elevation angle";
            _solarElevation.MaxValue = 1.5708D;
            _solarElevation.MinValue = 0D;
            _solarElevation.DefaultValue = 1.5708D;
            _solarElevation.Units = "radians";
            _solarElevation.URL = "http://";
            _solarElevation.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _incidentDirectIrradianceNIR.Name = "incidentDirectIrradianceNIR";
            _incidentDirectIrradianceNIR.Description = "Incident beam irradiance for Near Infrared Radiations";
            _incidentDirectIrradianceNIR.MaxValue = 1D;
            _incidentDirectIrradianceNIR.MinValue = 0D;
            _incidentDirectIrradianceNIR.DefaultValue = 1D;
            _incidentDirectIrradianceNIR.Units = "MJ m-2 h-1";
            _incidentDirectIrradianceNIR.URL = "http://";
            _incidentDirectIrradianceNIR.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _incidentDirectIrradiancePAR.Name = "incidentDirectIrradiancePAR";
            _incidentDirectIrradiancePAR.Description = "Incident beam irradiance for Photosynthetically Active Radiations";
            _incidentDirectIrradiancePAR.MaxValue = 1D;
            _incidentDirectIrradiancePAR.MinValue = 0D;
            _incidentDirectIrradiancePAR.DefaultValue = 1D;
            _incidentDirectIrradiancePAR.Units = "MJ m-2 h-1";
            _incidentDirectIrradiancePAR.URL = "http://";
            _incidentDirectIrradiancePAR.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _incidentDiffuseIrradianceNIR.Name = "incidentDiffuseIrradianceNIR";
            _incidentDiffuseIrradianceNIR.Description = "Incident diffuse irradiance for Near Infrared Radiations";
            _incidentDiffuseIrradianceNIR.MaxValue = 1D;
            _incidentDiffuseIrradianceNIR.MinValue = 0D;
            _incidentDiffuseIrradianceNIR.DefaultValue = 1D;
            _incidentDiffuseIrradianceNIR.Units = "MJ m-2 h-1";
            _incidentDiffuseIrradianceNIR.URL = "http://";
            _incidentDiffuseIrradianceNIR.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            //   
            _incidentDiffuseIrradiancePAR.Name = "incidentDiffuseIrradiancePAR";
            _incidentDiffuseIrradiancePAR.Description = "Incident diffuse irradiance for Photosynthetically Active Radiations";
            _incidentDiffuseIrradiancePAR.MaxValue = 1D;
            _incidentDiffuseIrradiancePAR.MinValue = 0D;
            _incidentDiffuseIrradiancePAR.DefaultValue = 1D;
            _incidentDiffuseIrradiancePAR.Units = "MJ m-2 h-1";
            _incidentDiffuseIrradiancePAR.URL = "http://";
            _incidentDiffuseIrradiancePAR.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
        }
        #endregion
    }
}
