

 //Author:Loic Manceau loic.manceau@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:24/04/2020
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

using MathNet.Numerics.Integration;
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
	///Class CalculateDiffReflectanceCoef
    /// Calculate the reflectance coeficient for diffuse Irradiance
    /// </summary>
	public class CalculateDiffReflectanceCoef : IStrategySiriusQualityIrradiance
	{

	#region Constructor

			public CalculateDiffReflectanceCoef()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 1;
				 v1.Description = "1:Spherical leaf angle Distribution; 0 Ellipsoidal";
				 v1.Id = 0;
				 v1.MaxValue = 1;
				 v1.MinValue = 0;
				 v1.Name = "useSphericalLeafDistrib";
				 v1.Size = 1;
				 v1.Units = "-";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
				 _parameters0_0.Add(v1);
				VarInfo v2 = new VarInfo();
				 v2.DefaultValue = 1;
				 v2.Description = "Clumping Index";
				 v2.Id = 0;
				 v2.MaxValue = 1;
				 v2.MinValue = 0;
				 v2.Name = "CI";
				 v2.Size = 1;
				 v2.Units = "-";
				 v2.URL = "";
				 v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v2);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd1.PropertyName = "rhoLeaf";
				pd1.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd2.PropertyName = "tauLeaf";
				pd2.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd3.PropertyName = "ala";
				pd3.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala);
				_inputs0_0.Add(pd3);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd4.PropertyName = "rhoCanopyDiff";
				pd4.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff);
				_outputs0_0.Add(pd4);
				mo0_0.Outputs=_outputs0_0;
				//Associated strategies
				List<string> lAssStrat0_0 = new List<string>();
				mo0_0.AssociatedStrategies = lAssStrat0_0;
				//Adding the modeling options to the modeling options manager
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
				get { return "Calculate the reflectance coeficient for diffuse Irradiance"; }
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
				_pd.Add("Date", "24/04/2020");
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

			
			public Int32 useSphericalLeafDistrib
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("useSphericalLeafDistrib");
						if (vi != null && vi.CurrentValue!=null) return (Int32)vi.CurrentValue ;
						else throw new Exception("Parameter 'useSphericalLeafDistrib' not found (or found null) in strategy 'CalculateDiffReflectanceCoef'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("useSphericalLeafDistrib");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'useSphericalLeafDistrib' not found in strategy 'CalculateDiffReflectanceCoef'");
				}
			}
			public Double CI
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("CI");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'CI' not found (or found null) in strategy 'CalculateDiffReflectanceCoef'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("CI");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'CI' not found in strategy 'CalculateDiffReflectanceCoef'");
				}
			}

			// Getter and setters for the value of the parameters of a composite strategy
			

	#endregion		

	
	#region Parameters initialization method
			
            /// <summary>
            /// Set parameter(s) current values to the default value
            /// </summary>
            public void SetParametersDefaultValue()
            {
				_modellingOptionsManager.SetParametersDefaultValue();
				 

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
                useSphericalLeafDistribVarInfo.Name = "useSphericalLeafDistrib";
				useSphericalLeafDistribVarInfo.Description =" 1:Spherical leaf angle Distribution; 0 Ellipsoidal";
				useSphericalLeafDistribVarInfo.MaxValue = 1;
				useSphericalLeafDistribVarInfo.MinValue = 0;
				useSphericalLeafDistribVarInfo.DefaultValue = 1;
				useSphericalLeafDistribVarInfo.Units = "-";
				useSphericalLeafDistribVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Integer");

				CIVarInfo.Name = "CI";
				CIVarInfo.Description =" Clumping Index";
				CIVarInfo.MaxValue = 1;
				CIVarInfo.MinValue = 0;
				CIVarInfo.DefaultValue = 1;
				CIVarInfo.Units = "-";
				CIVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _useSphericalLeafDistribVarInfo= new VarInfo();
				/// <summary> 
				///useSphericalLeafDistrib VarInfo definition
				/// </summary>
				public static VarInfo useSphericalLeafDistribVarInfo
				{
					get { return _useSphericalLeafDistribVarInfo; }
				}
				private static VarInfo _CIVarInfo= new VarInfo();
				/// <summary> 
				///CI VarInfo definition
				/// </summary>
				public static VarInfo CIVarInfo
				{
					get { return _CIVarInfo; }
				}					
			
			//Parameters static VarInfo list of the composite class
						

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
					
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff.CurrentValue=states.rhoCanopyDiff;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r4 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff);
					if(r4.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff.ValueType)){prc.AddCondition(r4);}

					

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
					
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf.CurrentValue=states.rhoLeaf;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf.CurrentValue=states.tauLeaf;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala.CurrentValue=states.ala;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf);
					if(r1.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf);
					if(r2.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala);
					if(r3.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala.ValueType)){prc.AddCondition(r3);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("useSphericalLeafDistrib")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("CI")));

					

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
				try
				{
					CalculateModel(rates,exogenous,states,actevents);

					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1005,"Strategy: " + this.GetType().Name + " - Model executed");
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1003,		"Strategy: " + this.GetType().Name + " - Unhandled exception running model");

					string msg = "Error in component INRA.SiriusQualityIrradiance.Strategies, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;				
					throw new Exception(msg, exception);
				}
			}

		

			private void CalculateModel(INRA.SiriusQualityIrradiance.Interfaces.Rates rates,INRA.SiriusQualityIrradiance.Interfaces.Exogenous exogenous,INRA.SiriusQualityIrradiance.Interfaces.States states,CRA.AgroManagement.ActEvents actevents)
			{				
				

				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
            //Code written below will not be overwritten by a future code generation

            //Inputs
            double rho = states.rhoLeaf;
            double tau = states.tauLeaf;
            double alphaMean = states.ala;
            double sigma = rho + tau;

            Func<double, double> f = null;

            double rhoh = (1 - Math.Sqrt(1 - sigma)) / (1 + Math.Sqrt(1 - sigma));

            if (useSphericalLeafDistrib == 1)
            {
                f = x => (1 - Math.Exp(-((2.0*rhoh* CI * 0.5 / Math.Sin(Math.Max(0.00174533, x))) /(1+ CI * 0.5 / Math.Sin(Math.Max(0.00174533, x)))))) * Math.Cos(x) * Math.Sin(x);

            }
            else
            {
                double Chi = Math.Pow(alphaMean / 9.65, -0.6061) - 3;
                
                f = x => (1 - Math.Exp(-((2.0 * rhoh * (CI * (Math.Sqrt(Math.Pow(Chi, 2) + (1 / Math.Pow(Math.Tan(x), 2)))) / (Chi + 1.774 * Math.Pow(Chi + 1.182, -0.733)))) /(1+ (CI * (Math.Sqrt(Math.Pow(Chi, 2) + (1 / Math.Pow(Math.Tan(x), 2)))) / (Chi + 1.774 * Math.Pow(Chi + 1.182, -0.733))))))) * Math.Cos(x) * Math.Sin(x);


            }


            states.rhoCanopyDiff = 2.0 * GaussLegendreRule.Integrate(f, 0.0, Math.PI / 2.0, 30);


            //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
            //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
