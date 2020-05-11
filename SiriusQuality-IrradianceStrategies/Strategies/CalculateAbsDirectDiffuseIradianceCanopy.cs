

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
	///Class CalculateAbsDirectDiffuseIradianceCanopy
    /// Calculate diffuse and direct irradiance absorbed by the canopy
    /// </summary>
	public class CalculateAbsDirectDiffuseIradianceCanopy : IStrategySiriusQualityIrradiance
	{

	#region Constructor

			public CalculateAbsDirectDiffuseIradianceCanopy()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd1.PropertyName = "rhoCanopyDiff";
				pd1.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd2.PropertyName = "rhoCanopyDir";
				pd2.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd3.PropertyName = "k_dir";
				pd3.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir);
				_inputs0_0.Add(pd3);
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd4.PropertyName = "layersGAI";
				pd4.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI);
				_inputs0_0.Add(pd4);
				PropertyDescription pd5 = new PropertyDescription();
				pd5.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd5.PropertyName = "k_dif";
				pd5.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif)).ValueType.TypeForCurrentValue;
				pd5.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif);
				_inputs0_0.Add(pd5);
				PropertyDescription pd6 = new PropertyDescription();
				pd6.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous);
				pd6.PropertyName = "incidentDiffuseIrradiance";
				pd6.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance)).ValueType.TypeForCurrentValue;
				pd6.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance);
				_inputs0_0.Add(pd6);
				PropertyDescription pd7 = new PropertyDescription();
				pd7.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous);
				pd7.PropertyName = "incidentDirectIrradiance";
				pd7.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance)).ValueType.TypeForCurrentValue;
				pd7.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance);
				_inputs0_0.Add(pd7);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd8 = new PropertyDescription();
				pd8.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd8.PropertyName = "absorbedDirIrradiance";
				pd8.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance)).ValueType.TypeForCurrentValue;
				pd8.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance);
				_outputs0_0.Add(pd8);
				PropertyDescription pd9 = new PropertyDescription();
				pd9.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd9.PropertyName = "absorbedDiffIrradiance";
				pd9.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance)).ValueType.TypeForCurrentValue;
				pd9.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance);
				_outputs0_0.Add(pd9);
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
				get { return "Calculate diffuse and direct irradiance absorbed by the canopy"; }
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
					
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance.CurrentValue=rates.absorbedDirIrradiance;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance.CurrentValue=rates.absorbedDiffIrradiance;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r8 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance);
					if(r8.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance.ValueType)){prc.AddCondition(r8);}
					RangeBasedCondition r9 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance);
					if(r9.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance.ValueType)){prc.AddCondition(r9);}

					

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
					
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff.CurrentValue=states.rhoCanopyDiff;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir.CurrentValue=states.rhoCanopyDir;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir.CurrentValue=states.k_dir;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI.CurrentValue=states.layersGAI;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif.CurrentValue=states.k_dif;
					INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance.CurrentValue=exogenous.incidentDiffuseIrradiance;
					INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance.CurrentValue=exogenous.incidentDirectIrradiance;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff);
					if(r1.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir);
					if(r2.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir);
					if(r3.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir.ValueType)){prc.AddCondition(r3);}
					RangeBasedCondition r4 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI);
					if(r4.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI.ValueType)){prc.AddCondition(r4);}
					RangeBasedCondition r5 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif);
					if(r5.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif.ValueType)){prc.AddCondition(r5);}
					RangeBasedCondition r6 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance);
					if(r6.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance.ValueType)){prc.AddCondition(r6);}
					RangeBasedCondition r7 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance);
					if(r7.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance.ValueType)){prc.AddCondition(r7);}

					

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

            double[] I_dir_inc = exogenous.incidentDirectIrradiance;
            double[] I_dif_inc = exogenous.incidentDiffuseIrradiance;
            double rhodiff = states.rhoCanopyDiff;
            Dictionary<int, double> rhodir = states.rhoCanopyDir;
            double kd = states.k_dif;
            Dictionary<int, double> kb = states.k_dir;
            Dictionary<int, Tuple<double, double>> gai = states.layersGAI;
            double gaiTotal = gai.Sum(x => x.Value.Item1 + x.Value.Item2);

            Dictionary<int, Dictionary<int, double>> IAbsDiff = new Dictionary<int, Dictionary<int, double>>();
            Dictionary<int, Dictionary<int, double>> IAbsDir = new Dictionary<int, Dictionary<int, double>>();


            

            for(int ih = 0; ih < 24; ih++)
            {
                IAbsDir.Add(ih,new Dictionary<int, double>());
                IAbsDiff.Add(ih, new Dictionary<int, double>());

                double Iabs_b = (1 - rhodir[ih]) * I_dir_inc[ih] * (1 - Math.Exp(-kb[ih] * gaiTotal));
                IAbsDir[ih].Add(99, Iabs_b);

                double Iabs_d = (1 - rhodiff) * I_dif_inc[ih] * (1 - Math.Exp(-kd * gaiTotal));
                IAbsDiff[ih].Add(99, Iabs_d);
            }


            //Outputs
            rates.absorbedDiffIrradiance = IAbsDiff;
            rates.absorbedDirIrradiance = IAbsDir;



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
