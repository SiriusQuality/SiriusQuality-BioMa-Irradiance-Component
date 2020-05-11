

 //Author:Loic Manceau loic.manceau@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:3/1/2018
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
//To make this project compile please add the reference to assembly: CRA.ModelLayer, Version=1.0.5212.29139, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: CRA.AgroManagement2014, Version=0.8.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;

namespace INRA.SiriusQualityIrradiance.Strategies
{

	/// <summary>
	///Class CalculateFractionSunShadeLayers
    /// Calculate the fraction of shaded and sunlit leaves layer by layer.
    /// </summary>
	public class CalculateFractionSunShadeLayers : IStrategySiriusQualityIrradiance
	{

	#region Constructor

			public CalculateFractionSunShadeLayers()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd1.PropertyName = "layersGAI";
				pd1.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd2.PropertyName = "k1_dir";
				pd2.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir);
				_inputs0_0.Add(pd2);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd3.PropertyName = "shadeFraction";
				pd3.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.shadeFraction)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.shadeFraction);
				_outputs0_0.Add(pd3);
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd4.PropertyName = "sunlitFraction";
				pd4.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.sunlitFraction)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.sunlitFraction);
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
				get { return "Calculate the fraction of shaded and sunlit leaves layer by layer."; }
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
				_pd.Add("Date", "3/1/2018");
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
                
       
			}

			//Parameters static VarInfo list 
								
			
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
					
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.shadeFraction.CurrentValue=states.shadeFraction;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.sunlitFraction.CurrentValue=states.sunlitFraction;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r3 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.shadeFraction);
					if(r3.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.shadeFraction.ValueType)){prc.AddCondition(r3);}
					RangeBasedCondition r4 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.sunlitFraction);
					if(r4.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.sunlitFraction.ValueType)){prc.AddCondition(r4);}

					

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
					
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI.CurrentValue=states.layersGAI;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir.CurrentValue=states.k1_dir;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI);
					if(r1.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir);
					if(r2.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir.ValueType)){prc.AddCondition(r2);}

					

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

                //Input

                Dictionary<int, double> k1_dirDict = states.k1_dir;

                Dictionary<int, Tuple<double, double>> gaiDict = states.layersGAI;

                // Output
                Dictionary<int, Dictionary<int, double>> I_sun_absDict = new Dictionary<int, Dictionary<int, double>>();
                Dictionary<int, Dictionary<int, double>> I_shade_absDict = new Dictionary<int, Dictionary<int, double>>();

                // Auxiliary
                Tuple<Dictionary<int, double>, Dictionary<int, double>> absDicts;

                IEnumerable<int> layers;
                layers = gaiDict.Keys;


                // initialization
                foreach (int hour in Enumerable.Range(0, 24))
                {
                    I_sun_absDict.Add(hour, new Dictionary<int, double>());
                    I_shade_absDict.Add(hour, new Dictionary<int, double>());

                    foreach (int layerIndex in layers)
                    {
                        I_sun_absDict[hour].Add(layerIndex, 0.0);
                        I_shade_absDict[hour].Add(layerIndex, 0.0);

                    }
                }


                // Hourly calculations
                foreach (int hour in Enumerable.Range(0, 24))
                {

                    double k1_dir = k1_dirDict[hour];


                    absDicts = HourlyAbsorbedIrradiance(k1_dir, gaiDict);

                    I_sun_absDict[hour] = absDicts.Item1;
                    I_shade_absDict[hour] = absDicts.Item2;


                }

                    states.sunlitFraction = I_sun_absDict; // absorbedSunlitIrradiance;
                    states.shadeFraction = I_shade_absDict; // absorbedShadedIrradiance;
                        

        

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation
            private Tuple<Dictionary<int, double>, Dictionary<int, double>> HourlyAbsorbedIrradiance( double k1_dir,Dictionary<int, Tuple<double, double>> gaiDict)
            {

                Dictionary<int, double> f_sunDict = new Dictionary<int, double>();
                Dictionary<int, double> f_shadeDict = new Dictionary<int, double>();

                    double upperCumGAI = new double();
                    double lowerCumGAI = 0.0;
                    double layerGAI = new double();

                    double f_sun = new double();
                    double f_shade = new double();

            for (int layerIndex = gaiDict.Count - 1; layerIndex >= 0; --layerIndex)
            {
                        layerGAI = Math.Max(0.000001, gaiDict[layerIndex].Item1 + gaiDict[layerIndex].Item2);

                        upperCumGAI = lowerCumGAI;
                        lowerCumGAI += layerGAI;

                // Sunlit and shade leaves fractions
               f_sun = (Math.Exp(-k1_dir * upperCumGAI) - Math.Exp(-k1_dir * (upperCumGAI + gaiDict[layerIndex].Item1))) / (k1_dir * layerGAI);
                f_shade = 1.0 - f_sun;
;

                        f_sunDict.Add(layerIndex, f_sun);
                        f_shadeDict.Add(layerIndex, f_shade);

                    }

                return Tuple.Create( f_sunDict, f_shadeDict);

            }




				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
