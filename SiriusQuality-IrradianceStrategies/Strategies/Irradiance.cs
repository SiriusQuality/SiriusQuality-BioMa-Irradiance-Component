

 //Author:Loic Manceau loic.manceau@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:27/04/2020
 //Date of revision:

using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;


using INRA.SiriusQualityIrradiance.Interfaces;
using CRA.AgroManagement;


//To make this project compile please add the reference to assembly: SiriusQuality-IrradianceDomainClass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: CRA.ModelLayer, Version=1.0.5212.29139, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.AgroManagement2014, Version=0.8.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;

namespace INRA.SiriusQualityIrradiance.Strategies
{

	/// <summary>
	///Class Irradiance
    /// Composite class: merge NIR and PAR
    /// </summary>
	public class Irradiance : IStrategySiriusQualityIrradiance
	{

	#region Constructor

			public Irradiance()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 0.057;
				 v1.Description = "Reflectance coefficient at leaf level for PAR";
				 v1.Id = 0;
				 v1.MaxValue = 10;
				 v1.MinValue = 0;
				 v1.Name = "rhoLeafPAR";
				 v1.Size = 1;
				 v1.Units = "-";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v1);
				VarInfo v2 = new VarInfo();
				 v2.DefaultValue = 0.389;
				 v2.Description = "Reflectance coefficient at leaf level for NIR";
				 v2.Id = 0;
				 v2.MaxValue = 10;
				 v2.MinValue = 0;
				 v2.Name = "rhoLeafNIR";
				 v2.Size = 1;
				 v2.Units = "-";
				 v2.URL = "";
				 v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v2);
				VarInfo v3 = new VarInfo();
				 v3.DefaultValue = 0.143;
				 v3.Description = "Transmitance coefficient at leaf level for PAR ";
				 v3.Id = 0;
				 v3.MaxValue = 10;
				 v3.MinValue = 0;
				 v3.Name = "tauLeafPAR";
				 v3.Size = 1;
				 v3.Units = "-";
				 v3.URL = "";
				 v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v3);
				VarInfo v4 = new VarInfo();
				 v4.DefaultValue = 0.411;
				 v4.Description = "Transmitance coefficient at leaf level for NIR";
				 v4.Id = 0;
				 v4.MaxValue = 10;
				 v4.MinValue = 0;
				 v4.Name = "tauLeafNIR";
				 v4.Size = 1;
				 v4.Units = "-";
				 v4.URL = "";
				 v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v4);
				VarInfo v5 = new VarInfo();
				 v5.DefaultValue = 1;
				 v5.Description = "0: Global Irradiance, 1: direct/Diffuse";
				 v5.Id = 0;
				 v5.MaxValue = 1;
				 v5.MinValue = 0;
				 v5.Name = "useSunShade";
				 v5.Size = 1;
				 v5.Units = "-";
				 v5.URL = "";
				 v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v5.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
				 _parameters0_0.Add(v5);
				VarInfo v6 = new VarInfo();
				 v6.DefaultValue = 0;
				 v6.Description = "0: Daily, 1: Hourly";
				 v6.Id = 0;
				 v6.MaxValue = 1;
				 v6.MinValue = 0;
				 v6.Name = "useHourly";
				 v6.Size = 1;
				 v6.Units = "-";
				 v6.URL = "";
				 v6.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v6.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
				 _parameters0_0.Add(v6);
				VarInfo v7 = new VarInfo();
				 v7.DefaultValue = 0;
				 v7.Description = "0:Big leaf, 1: Layered";
				 v7.Id = 0;
				 v7.MaxValue = 1;
				 v7.MinValue = 0;
				 v7.Name = "useLayered";
				 v7.Size = 1;
				 v7.Units = "-";
				 v7.URL = "";
				 v7.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v7.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
				 _parameters0_0.Add(v7);
				VarInfo v8 = new VarInfo();
				 v8.DefaultValue = 0;
				 v8.Description = "1: Diect Diffuse Output Irradiance, 0: Other option";
				 v8.Id = 0;
				 v8.MaxValue = 1;
				 v8.MinValue = 0;
				 v8.Name = "useDiffDirIrradiance";
				 v8.Size = 1;
				 v8.Units = "-";
				 v8.URL = "";
				 v8.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v8.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
				 _parameters0_0.Add(v8);
				VarInfo v9 = new CompositeStrategyVarInfo(_calculatediffreflectancecoef,"useSphericalLeafDistrib");
				 _parameters0_0.Add(v9);
				VarInfo v10 = new CompositeStrategyVarInfo(_calculatediffreflectancecoef,"CI");
				 _parameters0_0.Add(v10);
				VarInfo v11 = new CompositeStrategyVarInfo(_calculatediffusionextinctioncoef,"useSphericalLeafDistrib");
				 _parameters0_0.Add(v11);
				VarInfo v12 = new CompositeStrategyVarInfo(_calculatediffusionextinctioncoef,"CI");
				 _parameters0_0.Add(v12);
				VarInfo v13 = new CompositeStrategyVarInfo(_calculatedirectextinctioncoefblakleavesellipse,"CI");
				 _parameters0_0.Add(v13);
				VarInfo v14 = new CompositeStrategyVarInfo(_calculatedirectextinctioncoefblakleavessphere,"CI");
				 _parameters0_0.Add(v14);
				VarInfo v15 = new CompositeStrategyVarInfo(_calculateglobalabsorbedradiationdaily,"Kl");
				 _parameters0_0.Add(v15);
				VarInfo v16 = new CompositeStrategyVarInfo(_calculateglobalabsorbedradiationdailylayers,"Kl");
				 _parameters0_0.Add(v16);
				VarInfo v17 = new CompositeStrategyVarInfo(_calculateglobalabsorbedradiationhourly,"Kl");
				 _parameters0_0.Add(v17);
				VarInfo v18 = new CompositeStrategyVarInfo(_calculateglobalabsorbedradiationhourlylayers,"Kl");
				 _parameters0_0.Add(v18);
				VarInfo v19 = new CompositeStrategyVarInfo(_calculateintdirectirradiancecanopy,"useSphericalLeafDistrib");
				 _parameters0_0.Add(v19);
				VarInfo v20 = new CompositeStrategyVarInfo(_calculateintdirectirradiancecanopy,"CI");
				 _parameters0_0.Add(v20);
				VarInfo v21 = new CompositeStrategyVarInfo(_calculatemeanangle,"alaJuv");
				 _parameters0_0.Add(v21);
				VarInfo v22 = new CompositeStrategyVarInfo(_calculatemeanangle,"alaMat");
				 _parameters0_0.Add(v22);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous);
				pd1.PropertyName = "incidentDiffuseIrradianceNIR";
				pd1.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradianceNIR)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradianceNIR);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous);
				pd2.PropertyName = "incidentDiffuseIrradiancePAR";
				pd2.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiancePAR)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiancePAR);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous);
				pd3.PropertyName = "incidentDirectIrradianceNIR";
				pd3.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradianceNIR)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradianceNIR);
				_inputs0_0.Add(pd3);
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous);
				pd4.PropertyName = "incidentDirectIrradiancePAR";
				pd4.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiancePAR)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiancePAR);
				_inputs0_0.Add(pd4);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd5 = new PropertyDescription();
				pd5.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd5.PropertyName = "k_difNIR";
				pd5.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difNIR)).ValueType.TypeForCurrentValue;
				pd5.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difNIR);
				_outputs0_0.Add(pd5);
				PropertyDescription pd6 = new PropertyDescription();
				pd6.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd6.PropertyName = "k_difPAR";
				pd6.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difPAR)).ValueType.TypeForCurrentValue;
				pd6.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difPAR);
				_outputs0_0.Add(pd6);
				PropertyDescription pd7 = new PropertyDescription();
				pd7.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd7.PropertyName = "k_dirNIR";
				pd7.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirNIR)).ValueType.TypeForCurrentValue;
				pd7.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirNIR);
				_outputs0_0.Add(pd7);
				PropertyDescription pd8 = new PropertyDescription();
				pd8.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd8.PropertyName = "k_dirPAR";
				pd8.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirPAR)).ValueType.TypeForCurrentValue;
				pd8.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirPAR);
				_outputs0_0.Add(pd8);
				PropertyDescription pd9 = new PropertyDescription();
				pd9.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd9.PropertyName = "absorbedDiffIrradianceNIR";
				pd9.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradianceNIR)).ValueType.TypeForCurrentValue;
				pd9.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradianceNIR);
				_outputs0_0.Add(pd9);
				PropertyDescription pd10 = new PropertyDescription();
				pd10.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd10.PropertyName = "absorbedDiffIrradiancePAR";
				pd10.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiancePAR)).ValueType.TypeForCurrentValue;
				pd10.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiancePAR);
				_outputs0_0.Add(pd10);
				PropertyDescription pd11 = new PropertyDescription();
				pd11.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd11.PropertyName = "absorbedDirIrradianceNIR";
				pd11.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradianceNIR)).ValueType.TypeForCurrentValue;
				pd11.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradianceNIR);
				_outputs0_0.Add(pd11);
				PropertyDescription pd12 = new PropertyDescription();
				pd12.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd12.PropertyName = "absorbedDirIrradiancePAR";
				pd12.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiancePAR)).ValueType.TypeForCurrentValue;
				pd12.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiancePAR);
				_outputs0_0.Add(pd12);
				PropertyDescription pd13 = new PropertyDescription();
				pd13.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd13.PropertyName = "absorbedGlobalIrradianceNIR";
				pd13.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradianceNIR)).ValueType.TypeForCurrentValue;
				pd13.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradianceNIR);
				_outputs0_0.Add(pd13);
				PropertyDescription pd14 = new PropertyDescription();
				pd14.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd14.PropertyName = "absorbedGlobalIrradiancePAR";
				pd14.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradiancePAR)).ValueType.TypeForCurrentValue;
				pd14.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradiancePAR);
				_outputs0_0.Add(pd14);
				PropertyDescription pd15 = new PropertyDescription();
				pd15.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd15.PropertyName = "absorbedIrradiance";
				pd15.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiance)).ValueType.TypeForCurrentValue;
				pd15.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiance);
				_outputs0_0.Add(pd15);
				PropertyDescription pd16 = new PropertyDescription();
				pd16.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd16.PropertyName = "absorbedIrradianceNIR";
				pd16.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradianceNIR)).ValueType.TypeForCurrentValue;
				pd16.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradianceNIR);
				_outputs0_0.Add(pd16);
				PropertyDescription pd17 = new PropertyDescription();
				pd17.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd17.PropertyName = "absorbedIrradiancePAR";
				pd17.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiancePAR)).ValueType.TypeForCurrentValue;
				pd17.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiancePAR);
				_outputs0_0.Add(pd17);
				PropertyDescription pd18 = new PropertyDescription();
				pd18.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd18.PropertyName = "rhoCanopyDirNIR";
				pd18.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirNIR)).ValueType.TypeForCurrentValue;
				pd18.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirNIR);
				_outputs0_0.Add(pd18);
				PropertyDescription pd19 = new PropertyDescription();
				pd19.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd19.PropertyName = "rhoCanopyDirPAR";
				pd19.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirPAR)).ValueType.TypeForCurrentValue;
				pd19.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirPAR);
				_outputs0_0.Add(pd19);
				PropertyDescription pd20 = new PropertyDescription();
				pd20.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd20.PropertyName = "rhoCanopyDiffNIR";
				pd20.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffNIR)).ValueType.TypeForCurrentValue;
				pd20.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffNIR);
				_outputs0_0.Add(pd20);
				PropertyDescription pd21 = new PropertyDescription();
				pd21.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd21.PropertyName = "rhoCanopyDiffPAR";
				pd21.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffPAR)).ValueType.TypeForCurrentValue;
				pd21.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffPAR);
				_outputs0_0.Add(pd21);
				mo0_0.Outputs=_outputs0_0;
				//Associated strategies
				List<string> lAssStrat0_0 = new List<string>();
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceCanopy).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceLayers).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeCanopy).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeLayers).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateDiffReflectanceCoef).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateDiffusionExtinctionCoef).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoef).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesEllipse).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesSphere).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateDirectReflectanceCoef).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeCanopy).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeLayers).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDaily).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDailyLayers).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourly).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourlyLayers).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateIntDirectIrradianceCanopy).FullName);
				lAssStrat0_0.Add(typeof(INRA.SiriusQualityIrradiance.Strategies.CalculateMeanAngle).FullName);
				mo0_0.AssociatedStrategies = lAssStrat0_0;
				//Adding the modeling options to the modeling options manager

				//Creating the modeling options manager of the strategy
				_modellingOptionsManager = new ModellingOptionsManager(mo0_0);
			
				SetStaticParametersVarInfoDefinitions();
				SetPublisherData();
					
			}

	#endregion

	#region Implementation of IAnnotatable

			/// <summary>
			/// Description of the model
			/// </summary>
			public string Description
			{
				get { return "Composite class: merge NIR and PAR"; }
			}
			
			/// <summary>
			/// URL to access the description of the model
			/// </summary>
			public string URL
			{
				get { return "http://biomamodelling.org"; }
			}
		

	#endregion
	
	#region Implementation of IStrategy

			/// <summary>
			/// Domain of the model.
			/// </summary>
			public string Domain
			{
				get {  return "Crop"; }
			}

			/// <summary>
			/// Type of the model.
			/// </summary>
			public string ModelType
			{
				get { return "LightInterception"; }
			}

			/// <summary>
			/// Declare if the strategy is a ContextStrategy, that is, it contains logic to select a strategy at run time. 
			/// </summary>
			public bool IsContext
			{
					get { return  false; }
			}

			/// <summary>
			/// Timestep to be used with this strategy
			/// </summary>
			public IList<int> TimeStep
			{
				get
				{
					IList<int> ts = new List<int>();
					
					return ts;
				}
			}
	
	
	#region Publisher Data

			private PublisherData _pd;
			private  void SetPublisherData()
			{
					// Set publishers' data
					
				_pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
				_pd.Add("Creator", "loic.manceau@inra.fr");
				_pd.Add("Date", "27/04/2020");
				_pd.Add("Publisher", "INRA");
			}

			public PublisherData PublisherData
			{
				get { return _pd; }
			}

	#endregion

	#region ModellingOptionsManager

			private ModellingOptionsManager _modellingOptionsManager;
			
			public ModellingOptionsManager ModellingOptionsManager
			{
				get { return _modellingOptionsManager; }            
			}

	#endregion

			/// <summary>
			/// Return the types of the domain classes used by the strategy
			/// </summary>
			/// <returns></returns>
			public IEnumerable<Type> GetStrategyDomainClassesTypes()
			{
				return new List<Type>() {  typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates),typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous),typeof(INRA.SiriusQualityIrradiance.Interfaces.States),typeof(CRA.AgroManagement.ActEvents) };
			}

	#endregion

    #region Instances of the parameters
			
			// Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

			
			public Double rhoLeafPAR
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("rhoLeafPAR");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'rhoLeafPAR' not found (or found null) in strategy 'Irradiance'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("rhoLeafPAR");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'rhoLeafPAR' not found in strategy 'Irradiance'");
				}
			}
			public Double rhoLeafNIR
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("rhoLeafNIR");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'rhoLeafNIR' not found (or found null) in strategy 'Irradiance'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("rhoLeafNIR");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'rhoLeafNIR' not found in strategy 'Irradiance'");
				}
			}
			public Double tauLeafPAR
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("tauLeafPAR");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'tauLeafPAR' not found (or found null) in strategy 'Irradiance'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("tauLeafPAR");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'tauLeafPAR' not found in strategy 'Irradiance'");
				}
			}
			public Double tauLeafNIR
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("tauLeafNIR");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'tauLeafNIR' not found (or found null) in strategy 'Irradiance'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("tauLeafNIR");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'tauLeafNIR' not found in strategy 'Irradiance'");
				}
			}
			public Int32 useSunShade
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("useSunShade");
						if (vi != null && vi.CurrentValue!=null) return (Int32)vi.CurrentValue ;
						else throw new Exception("Parameter 'useSunShade' not found (or found null) in strategy 'Irradiance'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("useSunShade");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'useSunShade' not found in strategy 'Irradiance'");
				}
			}
			public Int32 useHourly
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("useHourly");
						if (vi != null && vi.CurrentValue!=null) return (Int32)vi.CurrentValue ;
						else throw new Exception("Parameter 'useHourly' not found (or found null) in strategy 'Irradiance'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("useHourly");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'useHourly' not found in strategy 'Irradiance'");
				}
			}
			public Int32 useLayered
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("useLayered");
						if (vi != null && vi.CurrentValue!=null) return (Int32)vi.CurrentValue ;
						else throw new Exception("Parameter 'useLayered' not found (or found null) in strategy 'Irradiance'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("useLayered");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'useLayered' not found in strategy 'Irradiance'");
				}
			}
			public Int32 useDiffDirIrradiance
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("useDiffDirIrradiance");
						if (vi != null && vi.CurrentValue!=null) return (Int32)vi.CurrentValue ;
						else throw new Exception("Parameter 'useDiffDirIrradiance' not found (or found null) in strategy 'Irradiance'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("useDiffDirIrradiance");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'useDiffDirIrradiance' not found in strategy 'Irradiance'");
				}
			}

			// Getter and setters for the value of the parameters of a composite strategy
			
			public Int32 useSphericalLeafDistrib
			{ 
				get {
						return _calculatediffreflectancecoef.useSphericalLeafDistrib ;
				}
				set {
						_calculatediffreflectancecoef.useSphericalLeafDistrib=value;
						_calculatediffusionextinctioncoef.useSphericalLeafDistrib=value;
						_calculateintdirectirradiancecanopy.useSphericalLeafDistrib=value;
				}
			}
			public Double CI
			{ 
				get {
						return _calculatediffreflectancecoef.CI ;
				}
				set {
						_calculatediffreflectancecoef.CI=value;
						_calculatediffusionextinctioncoef.CI=value;
						_calculatedirectextinctioncoefblakleavesellipse.CI=value;
						_calculatedirectextinctioncoefblakleavessphere.CI=value;
						_calculateintdirectirradiancecanopy.CI=value;
				}
			}
			public Double Kl
			{ 
				get {
						return _calculateglobalabsorbedradiationdaily.Kl ;
				}
				set {
						_calculateglobalabsorbedradiationdaily.Kl=value;
						_calculateglobalabsorbedradiationdailylayers.Kl=value;
						_calculateglobalabsorbedradiationhourly.Kl=value;
						_calculateglobalabsorbedradiationhourlylayers.Kl=value;
				}
			}
			public Double alaJuv
			{ 
				get {
						return _calculatemeanangle.alaJuv ;
				}
				set {
						_calculatemeanangle.alaJuv=value;
				}
			}
			public Double alaMat
			{ 
				get {
						return _calculatemeanangle.alaMat ;
				}
				set {
						_calculatemeanangle.alaMat=value;
				}
			}

	#endregion		

	
	#region Parameters initialization method
			
            /// <summary>
            /// Set parameter(s) current values to the default value
            /// </summary>
            public void SetParametersDefaultValue()
            {
				_modellingOptionsManager.SetParametersDefaultValue();
				
					_calculateabsdirectdiffuseiradiancecanopy.SetParametersDefaultValue();
					_calculateabsdirectdiffuseiradiancelayers.SetParametersDefaultValue();
					_calculateabsirradiancesunshadecanopy.SetParametersDefaultValue();
					_calculateabsirradiancesunshadelayers.SetParametersDefaultValue();
					_calculatediffreflectancecoef.SetParametersDefaultValue();
					_calculatediffusionextinctioncoef.SetParametersDefaultValue();
					_calculatedirectextinctioncoef.SetParametersDefaultValue();
					_calculatedirectextinctioncoefblakleavesellipse.SetParametersDefaultValue();
					_calculatedirectextinctioncoefblakleavessphere.SetParametersDefaultValue();
					_calculatedirectreflectancecoef.SetParametersDefaultValue();
					_calculatefractionsunshadecanopy.SetParametersDefaultValue();
					_calculatefractionsunshadelayers.SetParametersDefaultValue();
					_calculateglobalabsorbedradiationdaily.SetParametersDefaultValue();
					_calculateglobalabsorbedradiationdailylayers.SetParametersDefaultValue();
					_calculateglobalabsorbedradiationhourly.SetParametersDefaultValue();
					_calculateglobalabsorbedradiationhourlylayers.SetParametersDefaultValue();
					_calculateintdirectirradiancecanopy.SetParametersDefaultValue();
					_calculatemeanangle.SetParametersDefaultValue(); 

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section5
            //Code written below will not be overwritten by a future code generation

            //Custom initialization of the parameter. E.g. initialization of the array dimensions of array parameters

            //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
            //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section5 
            }

	#endregion		

	#region Static parameters VarInfo definition

			// Define the properties of the static VarInfo of the parameters
			private static void SetStaticParametersVarInfoDefinitions()
			{                                
                rhoLeafPARVarInfo.Name = "rhoLeafPAR";
				rhoLeafPARVarInfo.Description =" Reflectance coefficient at leaf level for PAR";
				rhoLeafPARVarInfo.MaxValue = 10;
				rhoLeafPARVarInfo.MinValue = 0;
				rhoLeafPARVarInfo.DefaultValue = 0.057;
				rhoLeafPARVarInfo.Units = "-";
				rhoLeafPARVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				rhoLeafNIRVarInfo.Name = "rhoLeafNIR";
				rhoLeafNIRVarInfo.Description =" Reflectance coefficient at leaf level for NIR";
				rhoLeafNIRVarInfo.MaxValue = 10;
				rhoLeafNIRVarInfo.MinValue = 0;
				rhoLeafNIRVarInfo.DefaultValue = 0.389;
				rhoLeafNIRVarInfo.Units = "-";
				rhoLeafNIRVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				tauLeafPARVarInfo.Name = "tauLeafPAR";
				tauLeafPARVarInfo.Description =" Transmitance coefficient at leaf level for PAR ";
				tauLeafPARVarInfo.MaxValue = 10;
				tauLeafPARVarInfo.MinValue = 0;
				tauLeafPARVarInfo.DefaultValue = 0.143;
				tauLeafPARVarInfo.Units = "-";
				tauLeafPARVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				tauLeafNIRVarInfo.Name = "tauLeafNIR";
				tauLeafNIRVarInfo.Description =" Transmitance coefficient at leaf level for NIR";
				tauLeafNIRVarInfo.MaxValue = 10;
				tauLeafNIRVarInfo.MinValue = 0;
				tauLeafNIRVarInfo.DefaultValue = 0.411;
				tauLeafNIRVarInfo.Units = "-";
				tauLeafNIRVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				useSunShadeVarInfo.Name = "useSunShade";
				useSunShadeVarInfo.Description =" 0: Global Irradiance, 1: direct/Diffuse";
				useSunShadeVarInfo.MaxValue = 1;
				useSunShadeVarInfo.MinValue = 0;
				useSunShadeVarInfo.DefaultValue = 1;
				useSunShadeVarInfo.Units = "-";
				useSunShadeVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Integer");

				useHourlyVarInfo.Name = "useHourly";
				useHourlyVarInfo.Description =" 0: Daily, 1: Hourly";
				useHourlyVarInfo.MaxValue = 1;
				useHourlyVarInfo.MinValue = 0;
				useHourlyVarInfo.DefaultValue = 0;
				useHourlyVarInfo.Units = "-";
				useHourlyVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Integer");

				useLayeredVarInfo.Name = "useLayered";
				useLayeredVarInfo.Description =" 0:Big leaf, 1: Layered";
				useLayeredVarInfo.MaxValue = 1;
				useLayeredVarInfo.MinValue = 0;
				useLayeredVarInfo.DefaultValue = 0;
				useLayeredVarInfo.Units = "-";
				useLayeredVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Integer");

				useDiffDirIrradianceVarInfo.Name = "useDiffDirIrradiance";
				useDiffDirIrradianceVarInfo.Description =" 1: Diect Diffuse Output Irradiance, 0: Other option";
				useDiffDirIrradianceVarInfo.MaxValue = 1;
				useDiffDirIrradianceVarInfo.MinValue = 0;
				useDiffDirIrradianceVarInfo.DefaultValue = 0;
				useDiffDirIrradianceVarInfo.Units = "-";
				useDiffDirIrradianceVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Integer");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _rhoLeafPARVarInfo= new VarInfo();
				/// <summary> 
				///rhoLeafPAR VarInfo definition
				/// </summary>
				public static VarInfo rhoLeafPARVarInfo
				{
					get { return _rhoLeafPARVarInfo; }
				}
				private static VarInfo _rhoLeafNIRVarInfo= new VarInfo();
				/// <summary> 
				///rhoLeafNIR VarInfo definition
				/// </summary>
				public static VarInfo rhoLeafNIRVarInfo
				{
					get { return _rhoLeafNIRVarInfo; }
				}
				private static VarInfo _tauLeafPARVarInfo= new VarInfo();
				/// <summary> 
				///tauLeafPAR VarInfo definition
				/// </summary>
				public static VarInfo tauLeafPARVarInfo
				{
					get { return _tauLeafPARVarInfo; }
				}
				private static VarInfo _tauLeafNIRVarInfo= new VarInfo();
				/// <summary> 
				///tauLeafNIR VarInfo definition
				/// </summary>
				public static VarInfo tauLeafNIRVarInfo
				{
					get { return _tauLeafNIRVarInfo; }
				}
				private static VarInfo _useSunShadeVarInfo= new VarInfo();
				/// <summary> 
				///useSunShade VarInfo definition
				/// </summary>
				public static VarInfo useSunShadeVarInfo
				{
					get { return _useSunShadeVarInfo; }
				}
				private static VarInfo _useHourlyVarInfo= new VarInfo();
				/// <summary> 
				///useHourly VarInfo definition
				/// </summary>
				public static VarInfo useHourlyVarInfo
				{
					get { return _useHourlyVarInfo; }
				}
				private static VarInfo _useLayeredVarInfo= new VarInfo();
				/// <summary> 
				///useLayered VarInfo definition
				/// </summary>
				public static VarInfo useLayeredVarInfo
				{
					get { return _useLayeredVarInfo; }
				}
				private static VarInfo _useDiffDirIrradianceVarInfo= new VarInfo();
				/// <summary> 
				///useDiffDirIrradiance VarInfo definition
				/// </summary>
				public static VarInfo useDiffDirIrradianceVarInfo
				{
					get { return _useDiffDirIrradianceVarInfo; }
				}					
			
			//Parameters static VarInfo list of the composite class
			
				/// <summary> 
				///useSphericalLeafDistrib VarInfo definition
				/// </summary>
				public static VarInfo useSphericalLeafDistribVarInfo
				{
					get { return INRA.SiriusQualityIrradiance.Strategies.CalculateDiffReflectanceCoef.useSphericalLeafDistribVarInfo; }
				}
				/// <summary> 
				///CI VarInfo definition
				/// </summary>
				public static VarInfo CIVarInfo
				{
					get { return INRA.SiriusQualityIrradiance.Strategies.CalculateDiffReflectanceCoef.CIVarInfo; }
				}
				/// <summary> 
				///Kl VarInfo definition
				/// </summary>
				public static VarInfo KlVarInfo
				{
					get { return INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDaily.KlVarInfo; }
				}
				/// <summary> 
				///alaJuv VarInfo definition
				/// </summary>
				public static VarInfo alaJuvVarInfo
				{
					get { return INRA.SiriusQualityIrradiance.Strategies.CalculateMeanAngle.alaJuvVarInfo; }
				}
				/// <summary> 
				///alaMat VarInfo definition
				/// </summary>
				public static VarInfo alaMatVarInfo
				{
					get { return INRA.SiriusQualityIrradiance.Strategies.CalculateMeanAngle.alaMatVarInfo; }
				}			

	#endregion
	
	#region pre/post conditions management		

		    /// <summary>
			/// Test to verify the postconditions
			/// </summary>
			public string TestPostConditions(INRA.SiriusQualityIrradiance.Interfaces.Rates rates,INRA.SiriusQualityIrradiance.Interfaces.Exogenous exogenous,INRA.SiriusQualityIrradiance.Interfaces.States states, string callID)
			{
				try
				{
					//Set current values of the outputs to the static VarInfo representing the output properties of the domain classes				
					
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difNIR.CurrentValue=states.k_difNIR;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difPAR.CurrentValue=states.k_difPAR;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirNIR.CurrentValue=states.k_dirNIR;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirPAR.CurrentValue=states.k_dirPAR;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradianceNIR.CurrentValue=rates.absorbedDiffIrradianceNIR;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiancePAR.CurrentValue=rates.absorbedDiffIrradiancePAR;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradianceNIR.CurrentValue=rates.absorbedDirIrradianceNIR;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiancePAR.CurrentValue=rates.absorbedDirIrradiancePAR;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradianceNIR.CurrentValue=rates.absorbedGlobalIrradianceNIR;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradiancePAR.CurrentValue=rates.absorbedGlobalIrradiancePAR;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiance.CurrentValue=rates.absorbedIrradiance;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradianceNIR.CurrentValue=rates.absorbedIrradianceNIR;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiancePAR.CurrentValue=rates.absorbedIrradiancePAR;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirNIR.CurrentValue=states.rhoCanopyDirNIR;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirPAR.CurrentValue=states.rhoCanopyDirPAR;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffNIR.CurrentValue=states.rhoCanopyDiffNIR;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffPAR.CurrentValue=states.rhoCanopyDiffPAR;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r5 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difNIR);
					if(r5.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difNIR.ValueType)){prc.AddCondition(r5);}
					RangeBasedCondition r6 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difPAR);
					if(r6.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_difPAR.ValueType)){prc.AddCondition(r6);}
					RangeBasedCondition r7 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirNIR);
					if(r7.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirNIR.ValueType)){prc.AddCondition(r7);}
					RangeBasedCondition r8 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirPAR);
					if(r8.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dirPAR.ValueType)){prc.AddCondition(r8);}
					RangeBasedCondition r9 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradianceNIR);
					if(r9.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradianceNIR.ValueType)){prc.AddCondition(r9);}
					RangeBasedCondition r10 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiancePAR);
					if(r10.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiancePAR.ValueType)){prc.AddCondition(r10);}
					RangeBasedCondition r11 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradianceNIR);
					if(r11.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradianceNIR.ValueType)){prc.AddCondition(r11);}
					RangeBasedCondition r12 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiancePAR);
					if(r12.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiancePAR.ValueType)){prc.AddCondition(r12);}
					RangeBasedCondition r13 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradianceNIR);
					if(r13.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradianceNIR.ValueType)){prc.AddCondition(r13);}
					RangeBasedCondition r14 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradiancePAR);
					if(r14.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedGlobalIrradiancePAR.ValueType)){prc.AddCondition(r14);}
					RangeBasedCondition r15 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiance);
					if(r15.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiance.ValueType)){prc.AddCondition(r15);}
					RangeBasedCondition r16 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradianceNIR);
					if(r16.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradianceNIR.ValueType)){prc.AddCondition(r16);}
					RangeBasedCondition r17 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiancePAR);
					if(r17.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedIrradiancePAR.ValueType)){prc.AddCondition(r17);}
					RangeBasedCondition r18 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirNIR);
					if(r18.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirNIR.ValueType)){prc.AddCondition(r18);}
					RangeBasedCondition r19 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirPAR);
					if(r19.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDirPAR.ValueType)){prc.AddCondition(r19);}
					RangeBasedCondition r20 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffNIR);
					if(r20.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffNIR.ValueType)){prc.AddCondition(r20);}
					RangeBasedCondition r21 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffPAR);
					if(r21.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiffPAR.ValueType)){prc.AddCondition(r21);}

					
					string ret = "";
					 ret += _calculateabsdirectdiffuseiradiancecanopy.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceCanopy");
					 ret += _calculateabsdirectdiffuseiradiancelayers.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceLayers");
					 ret += _calculateabsirradiancesunshadecanopy.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeCanopy");
					 ret += _calculateabsirradiancesunshadelayers.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeLayers");
					 ret += _calculatediffreflectancecoef.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDiffReflectanceCoef");
					 ret += _calculatediffusionextinctioncoef.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDiffusionExtinctionCoef");
					 ret += _calculatedirectextinctioncoef.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoef");
					 ret += _calculatedirectextinctioncoefblakleavesellipse.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesEllipse");
					 ret += _calculatedirectextinctioncoefblakleavessphere.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesSphere");
					 ret += _calculatedirectreflectancecoef.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDirectReflectanceCoef");
					 ret += _calculatefractionsunshadecanopy.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeCanopy");
					 ret += _calculatefractionsunshadelayers.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeLayers");
					 ret += _calculateglobalabsorbedradiationdaily.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDaily");
					 ret += _calculateglobalabsorbedradiationdailylayers.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDailyLayers");
					 ret += _calculateglobalabsorbedradiationhourly.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourly");
					 ret += _calculateglobalabsorbedradiationhourlylayers.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourlyLayers");
					 ret += _calculateintdirectirradiancecanopy.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateIntDirectIrradianceCanopy");
					 ret += _calculatemeanangle.TestPostConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateMeanAngle");
					if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section4
                //Code written below will not be overwritten by a future code generation



                //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
                //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section4 

					//Get the evaluation of postconditions
					string postConditionsResult =pre.VerifyPostconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in component INRA.SiriusQualityIrradiance.Strategies, strategy " + this.GetType().Name ); }
					return postConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1001,	"Strategy: " + this.GetType().Name + " - Unhandled exception running post-conditions");

					string msg = "Component INRA.SiriusQualityIrradiance.Strategies, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
					throw new Exception(msg, exception);
				}
			}

			/// <summary>
			/// Test to verify the preconditions
			/// </summary>
			public string TestPreConditions(INRA.SiriusQualityIrradiance.Interfaces.Rates rates,INRA.SiriusQualityIrradiance.Interfaces.Exogenous exogenous,INRA.SiriusQualityIrradiance.Interfaces.States states, string callID)
			{
				try
				{
					//Set current values of the inputs to the static VarInfo representing the input properties of the domain classes				
					
					INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradianceNIR.CurrentValue=exogenous.incidentDiffuseIrradianceNIR;
					INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiancePAR.CurrentValue=exogenous.incidentDiffuseIrradiancePAR;
					INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradianceNIR.CurrentValue=exogenous.incidentDirectIrradianceNIR;
					INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiancePAR.CurrentValue=exogenous.incidentDirectIrradiancePAR;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradianceNIR);
					if(r1.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradianceNIR.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiancePAR);
					if(r2.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiancePAR.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradianceNIR);
					if(r3.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradianceNIR.ValueType)){prc.AddCondition(r3);}
					RangeBasedCondition r4 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiancePAR);
					if(r4.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiancePAR.ValueType)){prc.AddCondition(r4);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("rhoLeafPAR")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("rhoLeafNIR")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("tauLeafPAR")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("tauLeafNIR")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("useSunShade")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("useHourly")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("useLayered")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("useDiffDirIrradiance")));

					
					string ret = "";
					 ret += _calculateabsdirectdiffuseiradiancecanopy.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceCanopy");
					 ret += _calculateabsdirectdiffuseiradiancelayers.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceLayers");
					 ret += _calculateabsirradiancesunshadecanopy.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeCanopy");
					 ret += _calculateabsirradiancesunshadelayers.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeLayers");
					 ret += _calculatediffreflectancecoef.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDiffReflectanceCoef");
					 ret += _calculatediffusionextinctioncoef.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDiffusionExtinctionCoef");
					 ret += _calculatedirectextinctioncoef.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoef");
					 ret += _calculatedirectextinctioncoefblakleavesellipse.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesEllipse");
					 ret += _calculatedirectextinctioncoefblakleavessphere.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesSphere");
					 ret += _calculatedirectreflectancecoef.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateDirectReflectanceCoef");
					 ret += _calculatefractionsunshadecanopy.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeCanopy");
					 ret += _calculatefractionsunshadelayers.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeLayers");
					 ret += _calculateglobalabsorbedradiationdaily.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDaily");
					 ret += _calculateglobalabsorbedradiationdailylayers.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDailyLayers");
					 ret += _calculateglobalabsorbedradiationhourly.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourly");
					 ret += _calculateglobalabsorbedradiationhourlylayers.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourlyLayers");
					 ret += _calculateintdirectirradiancecanopy.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateIntDirectIrradianceCanopy");
					 ret += _calculatemeanangle.TestPreConditions(rates,exogenous,states, "strategy INRA.SiriusQualityIrradiance.Strategies.CalculateMeanAngle");
					if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section3
                //Code written below will not be overwritten by a future code generation



                //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
                //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section3 
								
					//Get the evaluation of preconditions;					
					string preConditionsResult =pre.VerifyPreconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component INRA.SiriusQualityIrradiance.Strategies, strategy " + this.GetType().Name ); }
					return preConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//	TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1002,"Strategy: " + this.GetType().Name + " - Unhandled exception running pre-conditions");

					string msg = "Component INRA.SiriusQualityIrradiance.Strategies, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
					throw new Exception(msg, exception);
				}
			}

		
	#endregion
		


	#region Model

		 	/// <summary>
			/// Run the strategy to calculate the outputs. In case of error during the execution, the preconditions tests are executed.
			/// </summary>
			public void Estimate(INRA.SiriusQualityIrradiance.Interfaces.Rates rates,INRA.SiriusQualityIrradiance.Interfaces.Exogenous exogenous,INRA.SiriusQualityIrradiance.Interfaces.States states,CRA.AgroManagement.ActEvents actevents)
			{
				//try
				//{
					CalculateModel(rates,exogenous,states,actevents);

					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1005,"Strategy: " + this.GetType().Name + " - Model executed");
				//}
				//catch (Exception exception)
				//{
				//	//Uncomment the next line to use the trace
				//	//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1003,		"Strategy: " + this.GetType().Name + " - Unhandled exception running model");

				//	string msg = "Error in component INRA.SiriusQualityIrradiance.Strategies, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;				
				//	throw new Exception(msg, exception);
				//}
			}

		

			private void CalculateModel(INRA.SiriusQualityIrradiance.Interfaces.Rates rates,INRA.SiriusQualityIrradiance.Interfaces.Exogenous exogenous,INRA.SiriusQualityIrradiance.Interfaces.States states,CRA.AgroManagement.ActEvents actevents)
			{				
				
					EstimateOfAssociatedClasses(rates,exogenous,states,actevents);

				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
            //Code written below will not be overwritten by a future code generation



            //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
            //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				
			#region Composite class: associations

			//Declaration of the associated strategies
			INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceCanopy _calculateabsdirectdiffuseiradiancecanopy = new INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceCanopy();
			INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceLayers _calculateabsdirectdiffuseiradiancelayers = new INRA.SiriusQualityIrradiance.Strategies.CalculateAbsDirectDiffuseIradianceLayers();
			INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeCanopy _calculateabsirradiancesunshadecanopy = new INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeCanopy();
			INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeLayers _calculateabsirradiancesunshadelayers = new INRA.SiriusQualityIrradiance.Strategies.CalculateAbsIrradianceSunShadeLayers();
			INRA.SiriusQualityIrradiance.Strategies.CalculateDiffReflectanceCoef _calculatediffreflectancecoef = new INRA.SiriusQualityIrradiance.Strategies.CalculateDiffReflectanceCoef();
			INRA.SiriusQualityIrradiance.Strategies.CalculateDiffusionExtinctionCoef _calculatediffusionextinctioncoef = new INRA.SiriusQualityIrradiance.Strategies.CalculateDiffusionExtinctionCoef();
			INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoef _calculatedirectextinctioncoef = new INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoef();
			INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesEllipse _calculatedirectextinctioncoefblakleavesellipse = new INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesEllipse();
			INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesSphere _calculatedirectextinctioncoefblakleavessphere = new INRA.SiriusQualityIrradiance.Strategies.CalculateDirectExtinctionCoefBlakLeavesSphere();
			INRA.SiriusQualityIrradiance.Strategies.CalculateDirectReflectanceCoef _calculatedirectreflectancecoef = new INRA.SiriusQualityIrradiance.Strategies.CalculateDirectReflectanceCoef();
			INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeCanopy _calculatefractionsunshadecanopy = new INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeCanopy();
			INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeLayers _calculatefractionsunshadelayers = new INRA.SiriusQualityIrradiance.Strategies.CalculateFractionSunShadeLayers();
			INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDaily _calculateglobalabsorbedradiationdaily = new INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDaily();
			INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDailyLayers _calculateglobalabsorbedradiationdailylayers = new INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationDailyLayers();
			INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourly _calculateglobalabsorbedradiationhourly = new INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourly();
			INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourlyLayers _calculateglobalabsorbedradiationhourlylayers = new INRA.SiriusQualityIrradiance.Strategies.CalculateGlobalAbsorbedRadiationHourlyLayers();
			INRA.SiriusQualityIrradiance.Strategies.CalculateIntDirectIrradianceCanopy _calculateintdirectirradiancecanopy = new INRA.SiriusQualityIrradiance.Strategies.CalculateIntDirectIrradianceCanopy();
			INRA.SiriusQualityIrradiance.Strategies.CalculateMeanAngle _calculatemeanangle = new INRA.SiriusQualityIrradiance.Strategies.CalculateMeanAngle();

			//Call of the associated strategies
			private void EstimateOfAssociatedClasses(INRA.SiriusQualityIrradiance.Interfaces.Rates rates,INRA.SiriusQualityIrradiance.Interfaces.Exogenous exogenous,INRA.SiriusQualityIrradiance.Interfaces.States states,CRA.AgroManagement.ActEvents actevents){
            /*_calculateabsdirectdiffuseiradiancecanopy.Estimate(rates,exogenous,states,actevents);
            _calculateabsdirectdiffuseiradiancelayers.Estimate(rates,exogenous,states,actevents);
            _calculateabsirradiancesunshadecanopy.Estimate(rates,exogenous,states,actevents);
            _calculateabsirradiancesunshadelayers.Estimate(rates,exogenous,states,actevents);
            _calculatediffreflectancecoef.Estimate(rates,exogenous,states,actevents);
            _calculatediffusionextinctioncoef.Estimate(rates,exogenous,states,actevents);
            _calculatedirectextinctioncoef.Estimate(rates,exogenous,states,actevents);
            _calculatedirectextinctioncoefblakleavesellipse.Estimate(rates,exogenous,states,actevents);
            _calculatedirectextinctioncoefblakleavessphere.Estimate(rates,exogenous,states,actevents);
            _calculatedirectreflectancecoef.Estimate(rates,exogenous,states,actevents);
            _calculatefractionsunshadecanopy.Estimate(rates,exogenous,states,actevents);
            _calculatefractionsunshadelayers.Estimate(rates,exogenous,states,actevents);
            _calculateglobalabsorbedradiationdaily.Estimate(rates,exogenous,states,actevents);
            _calculateglobalabsorbedradiationdailylayers.Estimate(rates,exogenous,states,actevents);
            _calculateglobalabsorbedradiationhourly.Estimate(rates,exogenous,states,actevents);
            _calculateglobalabsorbedradiationhourlylayers.Estimate(rates,exogenous,states,actevents);
            _calculateintdirectirradiancecanopy.Estimate(rates,exogenous,states,actevents);
            _calculatemeanangle.Estimate(rates,exogenous,states,actevents);*/

            #region init

            double[] HourlyDirIrradiancePAR = exogenous.incidentDirectIrradiancePAR;
            double[] HourlyDirIrradianceNIR = exogenous.incidentDirectIrradianceNIR;

            double[] HourlyDiffIrradiancePAR = exogenous.incidentDiffuseIrradiancePAR;
            double[] HourlyDiffIrradianceNIR = exogenous.incidentDiffuseIrradianceNIR;


            // Leaf reflectance
            List<double> rhoList = new List<double>();
            rhoList.Add(rhoLeafPAR);
            rhoList.Add(rhoLeafNIR);

            // Leaf transmittance
            List<double> tauList = new List<double>();
            tauList.Add(tauLeafPAR);
            tauList.Add(tauLeafNIR);

            // Hourly direct irradiance
            List<double[]> dirIrrList = new List<double[]>();
            dirIrrList.Add(HourlyDirIrradiancePAR);
            dirIrrList.Add(HourlyDirIrradianceNIR);

            // Hourly diffuse irradiance
            List<double[]> diffIrrList = new List<double[]>();
            diffIrrList.Add(HourlyDiffIrradiancePAR);
            diffIrrList.Add(HourlyDiffIrradianceNIR);

            List<Dictionary<int, Dictionary<int, double>>> resultIabsSun = new List<Dictionary<int, Dictionary<int, double>>>();
            List<Dictionary<int, Dictionary<int, double>>> resultIabsShade = new List<Dictionary<int, Dictionary<int, double>>>();

            List<Dictionary<int, Dictionary<int, double>>> resultIabsDir = new List<Dictionary<int, Dictionary<int, double>>>();
            List<Dictionary<int, Dictionary<int, double>>> resultIabsDiff = new List<Dictionary<int, Dictionary<int, double>>>();

            List<Dictionary<int, Dictionary<int, double>>> resultFracSun = new List<Dictionary<int, Dictionary<int, double>>>();
            List<Dictionary<int, Dictionary<int, double>>> resultFracShade = new List<Dictionary<int, Dictionary<int, double>>>();

            List<Dictionary<int, Dictionary<int, double>>> resultTotAbsIrr = new List<Dictionary<int, Dictionary<int, double>>>();


            List<double> resultKdiff = new List<double>();
            List<Dictionary<int, double>> resultKdir = new List<Dictionary<int, double>>();
            List<Dictionary<int, double>> resultRhoCanopy = new List<Dictionary<int, double>>();
            List<double> resultRhoDiffCanopy = new List<double>();

            List<double> resultKdiffBlack = new List<double>();
            List<Dictionary<int, double>> resultKdirBlack = new List<Dictionary<int, double>>();

            #endregion

            #region Call Twice


            for (int i = 0; i < 2; i++)
            {

                states.tauLeaf = tauList[i];
                states.rhoLeaf = rhoList[i];
                exogenous.incidentDirectIrradiance = dirIrrList[i];
                exogenous.incidentDiffuseIrradiance = diffIrrList[i];

                _calculatemeanangle.Estimate(rates, exogenous, states, actevents);

                _calculatediffusionextinctioncoef.Estimate(rates, exogenous, states, actevents);
                resultKdiff.Add(states.k_dif);

                _calculatediffreflectancecoef.Estimate(rates, exogenous, states, actevents);
                resultRhoDiffCanopy.Add(states.rhoCanopyDiff);

                if (useSphericalLeafDistrib == 1)
                {
                    _calculatedirectextinctioncoefblakleavessphere.Estimate(rates, exogenous, states, actevents);
                }
                else
                {
                     _calculatedirectextinctioncoefblakleavesellipse.Estimate(rates, exogenous, states, actevents);
                }

                _calculatedirectextinctioncoef.Estimate(rates, exogenous, states, actevents);

                _calculatedirectreflectancecoef.Estimate(rates, exogenous, states, actevents);

                resultKdir.Add(states.k_dir);
                resultRhoCanopy.Add(states.rhoCanopyDir);

                resultKdiffBlack.Add(states.k_difBlack);
                resultKdirBlack.Add(states.k1_dir);

                if (useSunShade == 1)
                {
                    if (useLayered == 1)
                    {
                        _calculateabsdirectdiffuseiradiancelayers.Estimate(rates, exogenous, states, actevents);
                        _calculateabsirradiancesunshadelayers.Estimate(rates, exogenous, states, actevents);
                        _calculatefractionsunshadelayers.Estimate(rates, exogenous, states, actevents);
                    }
                    else
                    {
                        _calculateabsdirectdiffuseiradiancecanopy.Estimate(rates, exogenous, states, actevents);
                        _calculateabsirradiancesunshadecanopy.Estimate(rates, exogenous, states, actevents);
                        _calculatefractionsunshadecanopy.Estimate(rates, exogenous, states, actevents);

                    }

                    resultIabsSun.Add(rates.absorbedSunlitIrradiance);
                    resultIabsShade.Add(rates.absorbedShadedIrradiance);



                    resultFracSun.Add(states.sunlitFraction);
                    resultFracShade.Add(states.shadeFraction);


                }
                else if (useDiffDirIrradiance == 1)
                {
                    if (useLayered == 1)
                    {
                        _calculateabsdirectdiffuseiradiancelayers.Estimate(rates, exogenous, states, actevents);

                    }
                    else
                    {
                        _calculateabsdirectdiffuseiradiancecanopy.Estimate(rates, exogenous, states, actevents);
                    }

                    resultIabsDir.Add(rates.absorbedDirIrradiance);
                    resultIabsDiff.Add(rates.absorbedDiffIrradiance);

                }

               _calculateglobalabsorbedradiationhourlylayers.Estimate(rates, exogenous, states, actevents);

                if (useHourly == 1 && useLayered == 0)
                {
                    _calculateglobalabsorbedradiationhourly.Estimate(rates, exogenous, states, actevents);
                }
                if (useHourly == 0 && useLayered == 0)
                {
                    _calculateglobalabsorbedradiationdaily.Estimate(rates, exogenous, states, actevents);
                }
                else if (useHourly == 0 && useLayered == 1)
                {
                    _calculateglobalabsorbedradiationdailylayers.Estimate(rates, exogenous, states, actevents);
                }

                resultTotAbsIrr.Add(rates.absorbedGlobalIrradiance);

                if (useHourly == 1 && i == 0) _calculateintdirectirradiancecanopy.Estimate(rates, exogenous, states, actevents);

            }

            #endregion

            #region Merge PAR/NIR

            rates.absorbedIrradiancePAR = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            rates.absorbedIrradianceNIR = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            rates.absorbedIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();


            if (useSunShade == 1)
            {
                #region Absorbed Diff/Dir


                rates.absorbedIrradiance.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());
                rates.absorbedIrradiance.Add("shaded", new Dictionary<int, Dictionary<int, double>>());

                rates.absorbedIrradiancePAR.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());
                rates.absorbedIrradianceNIR.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());

                rates.absorbedIrradiancePAR.Add("shaded", new Dictionary<int, Dictionary<int, double>>());
                rates.absorbedIrradianceNIR.Add("shaded", new Dictionary<int, Dictionary<int, double>>());

                if (states.layersGAI.Count != 0 && states.layersGAI.Sum(x => x.Value.Item1 + x.Value.Item2) > 0.0)
                {

                    rates.absorbedIrradiancePAR["sunlit"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultIabsSun[0]);
                    rates.absorbedIrradianceNIR["sunlit"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultIabsSun[1]);

                    rates.absorbedIrradiancePAR["shaded"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultIabsShade[0]);
                    rates.absorbedIrradianceNIR["shaded"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultIabsShade[1]);


                    foreach (int hour in rates.absorbedSunlitIrradiance.Keys)
                    {
                        rates.absorbedIrradiance["sunlit"].Add(hour, new Dictionary<int, double>());
                        rates.absorbedIrradiance["shaded"].Add(hour, new Dictionary<int, double>());

                        foreach (int layer in rates.absorbedSunlitIrradiance[hour].Keys)
                        {

                            rates.absorbedIrradiance["sunlit"][hour].Add(layer, resultIabsSun[0][hour][layer] + resultIabsSun[1][hour][layer]);
                            rates.absorbedIrradiance["shaded"][hour].Add(layer, resultIabsShade[0][hour][layer] + resultIabsShade[1][hour][layer]);

                        }
                    }
                }
                else
                {
                    foreach (int hour in rates.absorbedSunlitIrradiance.Keys)
                    {
                        rates.absorbedIrradiance["sunlit"].Add(hour, new Dictionary<int, double>());
                        rates.absorbedIrradiance["shaded"].Add(hour, new Dictionary<int, double>());
                        rates.absorbedIrradiancePAR["sunlit"].Add(hour, new Dictionary<int, double>());
                        rates.absorbedIrradiancePAR["shaded"].Add(hour, new Dictionary<int, double>());
                        rates.absorbedIrradianceNIR["sunlit"].Add(hour, new Dictionary<int, double>());
                        rates.absorbedIrradianceNIR["shaded"].Add(hour, new Dictionary<int, double>());

                        foreach (int layer in rates.absorbedSunlitIrradiance[hour].Keys)
                        {

                            rates.absorbedIrradiance["sunlit"][hour].Add(layer, 0.0);
                            rates.absorbedIrradiance["shaded"][hour].Add(layer, 0.0);
                            rates.absorbedIrradiancePAR["sunlit"][hour].Add(layer, 0.0);
                            rates.absorbedIrradiancePAR["shaded"][hour].Add(layer, 0.0);
                            rates.absorbedIrradianceNIR["sunlit"][hour].Add(layer, 0.0);
                            rates.absorbedIrradianceNIR["shaded"][hour].Add(layer, 0.0);

                        }
                    }
                }
                #endregion

                #region sunlit/shaded Fraction

                states.sunlitShadedFractionPAR = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
                states.sunlitShadedFractionNIR = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
                states.sunlitShadedFraction = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();

                states.sunlitShadedFraction.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());
                states.sunlitShadedFraction.Add("shaded", new Dictionary<int, Dictionary<int, double>>());

                states.sunlitShadedFractionPAR.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());
                states.sunlitShadedFractionNIR.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());

                states.sunlitShadedFractionPAR.Add("shaded", new Dictionary<int, Dictionary<int, double>>());
                states.sunlitShadedFractionNIR.Add("shaded", new Dictionary<int, Dictionary<int, double>>());


                if (states.layersGAI.Count != 0 && states.layersGAI.Sum(x => x.Value.Item1 + x.Value.Item2) > 0.0)
                {


                    states.sunlitShadedFractionPAR["sunlit"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultFracSun[0]);
                    states.sunlitShadedFractionNIR["sunlit"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultFracSun[1]);

                    states.sunlitShadedFractionPAR["shaded"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultFracShade[0]);
                    states.sunlitShadedFractionNIR["shaded"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultFracShade[1]);


                    states.sunlitShadedFraction["sunlit"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultFracSun[0]);
                    states.sunlitShadedFraction["shaded"] = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultFracShade[0]);
                }
                else
                {
                    foreach (int hour in rates.absorbedSunlitIrradiance.Keys)
                    {
                        states.sunlitShadedFractionPAR["sunlit"].Add(hour, new Dictionary<int, double>());
                        states.sunlitShadedFractionPAR["shaded"].Add(hour, new Dictionary<int, double>());
                        states.sunlitShadedFractionNIR["sunlit"].Add(hour, new Dictionary<int, double>());
                        states.sunlitShadedFractionNIR["shaded"].Add(hour, new Dictionary<int, double>());
                        states.sunlitShadedFraction["sunlit"].Add(hour, new Dictionary<int, double>());
                        states.sunlitShadedFraction["shaded"].Add(hour, new Dictionary<int, double>());

                        foreach (int layer in rates.absorbedSunlitIrradiance[hour].Keys)
                        {

                            states.sunlitShadedFractionPAR["sunlit"][hour].Add(layer, 0.0);
                            states.sunlitShadedFractionPAR["shaded"][hour].Add(layer, 0.0);
                            states.sunlitShadedFractionNIR["sunlit"][hour].Add(layer, 0.0);
                            states.sunlitShadedFractionNIR["shaded"][hour].Add(layer, 0.0);
                            states.sunlitShadedFraction["sunlit"][hour].Add(layer, 0.0);
                            states.sunlitShadedFraction["shaded"][hour].Add(layer, 0.0);

                        }
                    }
                }


                states.sunlitFraction = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultFracSun[0]);
                states.shadeFraction = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultFracShade[0]);

                #endregion
            }
            else
            {

                #region Global Absorbed

                rates.absorbedIrradiancePAR.Add("global", SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultTotAbsIrr[0]));
                rates.absorbedIrradianceNIR.Add("global", SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultTotAbsIrr[1]));

                rates.absorbedIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());

                if (useDiffDirIrradiance == 0)
                {

                    if (states.layersGAI.Count != 0 && states.layersGAI.Sum(x => x.Value.Item1 + x.Value.Item2) > 0.0)
                    {

                        foreach (int hour in rates.absorbedGlobalIrradiance.Keys)
                        {
                            rates.absorbedIrradiance["global"].Add(hour, new Dictionary<int, double>());

                            foreach (int layer in rates.absorbedGlobalIrradiance[hour].Keys)
                            {

                                rates.absorbedIrradiance["global"][hour].Add(layer, resultTotAbsIrr[0][hour][layer] + resultTotAbsIrr[1][hour][layer]);

                            }
                        }
                    }
                    else
                    {
                        foreach (int hour in rates.absorbedGlobalIrradiance.Keys)
                        {
                            rates.absorbedIrradiance["global"].Add(hour, new Dictionary<int, double>());

                            foreach (int layer in rates.absorbedGlobalIrradiance[hour].Keys)
                            {

                                rates.absorbedIrradiance["global"][hour].Add(layer, 0.0);
                                //rates.absorbedIrradiance["global"][hour].Add(layer, resultTotAbsIrr[0][hour][layer]);

                            }
                        }
                    }

                }
                else
                {
                    #region Absorbed Direct and Diffuse Irradiance

                    rates.absorbedDiffIrradianceNIR = resultIabsDiff[1];
                    rates.absorbedDirIrradianceNIR = resultIabsDir[1];

                    rates.absorbedDiffIrradiancePAR = resultIabsDiff[0];
                    rates.absorbedDirIrradiancePAR = resultIabsDir[0];

                    rates.absorbedDiffIrradiance = new Dictionary<int, Dictionary<int, double>>();
                    rates.absorbedDirIrradiance = new Dictionary<int, Dictionary<int, double>>();

                    foreach (int ih in rates.absorbedDiffIrradianceNIR.Keys)
                    {
                        rates.absorbedDiffIrradiance.Add(ih, new Dictionary<int, double>());
                        rates.absorbedDirIrradiance.Add(ih, new Dictionary<int, double>());

                        foreach (int il in rates.absorbedDiffIrradianceNIR[ih].Keys)
                        {
                            rates.absorbedDiffIrradiance[ih].Add(il, resultIabsDiff[0][ih][il] + resultIabsDiff[1][ih][il]);
                            rates.absorbedDirIrradiance[ih].Add(il, resultIabsDir[0][ih][il] + resultIabsDir[1][ih][il]);
                        }
                    }


                    if (states.layersGAI.Count != 0 && states.layersGAI.Sum(x => x.Value.Item1 + x.Value.Item2) > 0.0)
                    {

                        foreach (int hour in rates.absorbedGlobalIrradiance.Keys)
                        {
                            rates.absorbedIrradiance["global"].Add(hour, new Dictionary<int, double>());

                            foreach (int layer in rates.absorbedGlobalIrradiance[hour].Keys)
                            {

                                rates.absorbedIrradiance["global"][hour].Add(layer, resultIabsDiff[0][hour][layer] + resultIabsDir[0][hour][layer] + resultIabsDir[1][hour][layer]);

                            }
                        }
                    }
                    else
                    {
                        foreach (int hour in rates.absorbedGlobalIrradiance.Keys)
                        {
                            rates.absorbedIrradiance["global"].Add(hour, new Dictionary<int, double>());

                            foreach (int layer in rates.absorbedGlobalIrradiance[hour].Keys)
                            {

                                rates.absorbedIrradiance["global"][hour].Add(layer, 0.0);
                                //rates.absorbedIrradiance["global"][hour].Add(layer, resultTotAbsIrr[0][hour][layer]);

                            }
                        }
                    }
                }

                states.sunlitShadedFractionPAR = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
                states.sunlitShadedFractionNIR = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
                states.sunlitShadedFraction = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();

                states.sunlitShadedFraction.Add("global", new Dictionary<int, Dictionary<int, double>>());
                states.sunlitShadedFractionPAR.Add("global", new Dictionary<int, Dictionary<int, double>>());
                states.sunlitShadedFractionNIR.Add("global", new Dictionary<int, Dictionary<int, double>>());


                foreach (int ihour in rates.absorbedGlobalIrradiance.Keys)
                {
                    states.sunlitShadedFraction["global"].Add(ihour, new Dictionary<int, double>());
                    states.sunlitShadedFractionPAR["global"].Add(ihour, new Dictionary<int, double>());
                    states.sunlitShadedFractionNIR["global"].Add(ihour, new Dictionary<int, double>());
                    foreach (int ilayer in rates.absorbedGlobalIrradiance[ihour].Keys)
                    {
                        states.sunlitShadedFraction["global"][ihour].Add(ilayer, 1.0);
                        states.sunlitShadedFractionPAR["global"][ihour].Add(ilayer, 1.0);
                        states.sunlitShadedFractionNIR["global"][ihour].Add(ilayer, 1.0);
                    }

                }

                #endregion

                #endregion
            }

            #region Global Irradiance

            rates.absorbedGlobalIrradiancePAR = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultTotAbsIrr[0]);
            rates.absorbedGlobalIrradianceNIR = SiriusQuality_IrradianceStrategies.Utilities.CloneDictionary.CloneDict(resultTotAbsIrr[1]);


            foreach (int hour in resultTotAbsIrr[0].Keys)
            {
                foreach (int layer in resultTotAbsIrr[0][hour].Keys)
                {
                    rates.absorbedGlobalIrradiance[hour][layer] = resultTotAbsIrr[0][hour][layer] + resultTotAbsIrr[1][hour][layer];
                }
            }

            #endregion

            #region kdir/kfdiff/rhoCanopy

            states.k_dirPAR = resultKdir[0];
            states.k_dirNIR = resultKdir[1];

            states.k_difPAR = resultKdiff[0];
            states.k_difNIR = resultKdiff[1];

            states.k_dir = resultKdir[0];
            states.k_dif = resultKdiff[0];

            states.k1_dir = resultKdirBlack[0];
            states.k_difBlack = resultKdiffBlack[0];

            states.rhoCanopyDirPAR = resultRhoCanopy[0];
            states.rhoCanopyDirNIR = resultRhoCanopy[1];
            states.rhoCanopyDir = resultRhoCanopy[0];

            states.rhoCanopyDiffPAR = resultRhoDiffCanopy[0];
            states.rhoCanopyDiffNIR = resultRhoDiffCanopy[1];
            states.rhoCanopyDiff = resultRhoDiffCanopy[0];

            #endregion


            #endregion
        }

        #endregion


        #endregion


        //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
        //Code written below will not be overwritten by a future code generation

        public Irradiance(Irradiance tocopy)
            : this()
        {
            Kl = tocopy.Kl;
            useSunShade = tocopy.useSunShade;
            useHourly = tocopy.useHourly;
            useDiffDirIrradiance = tocopy.useDiffDirIrradiance;
            useLayered = tocopy.useLayered;
            tauLeafPAR = tocopy.tauLeafPAR;
            tauLeafNIR = tocopy.tauLeafNIR;
            rhoLeafPAR = tocopy.rhoLeafPAR;
            rhoLeafNIR = tocopy.rhoLeafNIR;
            useSphericalLeafDistrib = tocopy.useSphericalLeafDistrib;
            alaJuv = tocopy.alaJuv;
            alaMat = tocopy.alaMat;
            CI = tocopy.CI;
        }

        //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
        //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
