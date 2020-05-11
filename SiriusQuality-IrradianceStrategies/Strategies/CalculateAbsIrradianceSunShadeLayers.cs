

 //Author:Loic Manceau loic.manceau@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:03/01/2018
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
	///Class CalculateAbsIrradianceSunShadeLayers
    /// Calculate the absorbed irradiance for the shaded and sunlit leaves layer by layer.
    /// </summary>
	public class CalculateAbsIrradianceSunShadeLayers : IStrategySiriusQualityIrradiance
	{

	#region Constructor

			public CalculateAbsIrradianceSunShadeLayers()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous);
				pd1.PropertyName = "incidentDiffuseIrradiance";
				pd1.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Exogenous);
				pd2.PropertyName = "incidentDirectIrradiance";
				pd2.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd3.PropertyName = "layersGAI";
				pd3.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI);
				_inputs0_0.Add(pd3);
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd4.PropertyName = "k_dir";
				pd4.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir);
				_inputs0_0.Add(pd4);
				PropertyDescription pd5 = new PropertyDescription();
				pd5.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd5.PropertyName = "k1_dir";
				pd5.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir)).ValueType.TypeForCurrentValue;
				pd5.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir);
				_inputs0_0.Add(pd5);
				PropertyDescription pd6 = new PropertyDescription();
				pd6.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd6.PropertyName = "k_dif";
				pd6.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif)).ValueType.TypeForCurrentValue;
				pd6.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif);
				_inputs0_0.Add(pd6);
				PropertyDescription pd7 = new PropertyDescription();
				pd7.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd7.PropertyName = "rhoCanopyDiff";
				pd7.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff)).ValueType.TypeForCurrentValue;
				pd7.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff);
				_inputs0_0.Add(pd7);
				PropertyDescription pd8 = new PropertyDescription();
				pd8.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd8.PropertyName = "rhoLeaf";
				pd8.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf)).ValueType.TypeForCurrentValue;
				pd8.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf);
				_inputs0_0.Add(pd8);
				PropertyDescription pd9 = new PropertyDescription();
				pd9.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd9.PropertyName = "tauLeaf";
				pd9.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf)).ValueType.TypeForCurrentValue;
				pd9.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf);
				_inputs0_0.Add(pd9);
				PropertyDescription pd10 = new PropertyDescription();
				pd10.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd10.PropertyName = "rhoCanopyDir";
				pd10.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir)).ValueType.TypeForCurrentValue;
				pd10.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir);
				_inputs0_0.Add(pd10);
				PropertyDescription pd11 = new PropertyDescription();
				pd11.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd11.PropertyName = "absorbedDiffIrradiance";
				pd11.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance)).ValueType.TypeForCurrentValue;
				pd11.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance);
				_inputs0_0.Add(pd11);
				PropertyDescription pd12 = new PropertyDescription();
				pd12.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd12.PropertyName = "absorbedDirIrradiance";
				pd12.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance)).ValueType.TypeForCurrentValue;
				pd12.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance);
				_inputs0_0.Add(pd12);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd13 = new PropertyDescription();
				pd13.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd13.PropertyName = "absorbedShadedIrradiance";
				pd13.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedShadedIrradiance)).ValueType.TypeForCurrentValue;
				pd13.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedShadedIrradiance);
				_outputs0_0.Add(pd13);
				PropertyDescription pd14 = new PropertyDescription();
				pd14.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.Rates);
				pd14.PropertyName = "absorbedSunlitIrradiance";
				pd14.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedSunlitIrradiance)).ValueType.TypeForCurrentValue;
				pd14.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedSunlitIrradiance);
				_outputs0_0.Add(pd14);
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
				get { return "Calculate the absorbed irradiance for the shaded and sunlit leaves layer by layer."; }
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
				_pd.Add("Date", "03/01/2018");
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
					
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedShadedIrradiance.CurrentValue=rates.absorbedShadedIrradiance;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedSunlitIrradiance.CurrentValue=rates.absorbedSunlitIrradiance;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r13 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedShadedIrradiance);
					if(r13.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedShadedIrradiance.ValueType)){prc.AddCondition(r13);}
					RangeBasedCondition r14 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedSunlitIrradiance);
					if(r14.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedSunlitIrradiance.ValueType)){prc.AddCondition(r14);}

					

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
					
					INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance.CurrentValue=exogenous.incidentDiffuseIrradiance;
					INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance.CurrentValue=exogenous.incidentDirectIrradiance;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI.CurrentValue=states.layersGAI;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir.CurrentValue=states.k_dir;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir.CurrentValue=states.k1_dir;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif.CurrentValue=states.k_dif;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff.CurrentValue=states.rhoCanopyDiff;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf.CurrentValue=states.rhoLeaf;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf.CurrentValue=states.tauLeaf;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir.CurrentValue=states.rhoCanopyDir;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance.CurrentValue=rates.absorbedDiffIrradiance;
					INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance.CurrentValue=rates.absorbedDirIrradiance;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance);
					if(r1.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDiffuseIrradiance.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance);
					if(r2.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.ExogenousVarInfo.incidentDirectIrradiance.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI);
					if(r3.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.layersGAI.ValueType)){prc.AddCondition(r3);}
					RangeBasedCondition r4 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir);
					if(r4.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dir.ValueType)){prc.AddCondition(r4);}
					RangeBasedCondition r5 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir);
					if(r5.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k1_dir.ValueType)){prc.AddCondition(r5);}
					RangeBasedCondition r6 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif);
					if(r6.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.k_dif.ValueType)){prc.AddCondition(r6);}
					RangeBasedCondition r7 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff);
					if(r7.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDiff.ValueType)){prc.AddCondition(r7);}
					RangeBasedCondition r8 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf);
					if(r8.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoLeaf.ValueType)){prc.AddCondition(r8);}
					RangeBasedCondition r9 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf);
					if(r9.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.tauLeaf.ValueType)){prc.AddCondition(r9);}
					RangeBasedCondition r10 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir);
					if(r10.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.rhoCanopyDir.ValueType)){prc.AddCondition(r10);}
					RangeBasedCondition r11 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance);
					if(r11.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDiffIrradiance.ValueType)){prc.AddCondition(r11);}
					RangeBasedCondition r12 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance);
					if(r12.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.RatesVarInfo.absorbedDirIrradiance.ValueType)){prc.AddCondition(r12);}

					

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
                double[] I_dir_inc = exogenous.incidentDirectIrradiance;
                double[] I_dif_inc = exogenous.incidentDiffuseIrradiance;
                double rho = states.rhoLeaf;
                double tau = states.tauLeaf;
                Dictionary<int, double> k1_dirDict = states.k1_dir;
                Dictionary<int, double> k_dirDict = states.k_dir;
                double k_dif = states.k_dif;
                Dictionary<int, double> rho_dirDict = states.rhoCanopyDir;
                double rho_dif = states.rhoCanopyDiff;
                Dictionary<int, Dictionary<int, double>> Idiff = rates.absorbedDiffIrradiance;
                Dictionary<int, Dictionary<int, double>> Idir = rates.absorbedDirIrradiance;

            Dictionary<int, Tuple<double, double>> gaiDict = states.layersGAI;

                // Output
                Dictionary<int, Dictionary<int, double>> I_sun_absDict = new Dictionary<int, Dictionary<int, double>>();
                Dictionary<int, Dictionary<int, double>> I_shade_absDict = new Dictionary<int, Dictionary<int, double>>();

                // Auxiliary
                Tuple<Dictionary<int, double>, Dictionary<int, double>> absDicts;

                IEnumerable<int> layers;
                layers = gaiDict.Keys;

                double sigma = rho + tau;


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
                    double I_dir = I_dir_inc[hour];
                    double I_dif = I_dif_inc[hour];
                    double k1_dir = k1_dirDict[hour];
                    double k_dir = k_dirDict[hour];
                    double rho_dir = rho_dirDict[hour];
                Dictionary<int, double> Ig = new Dictionary<int, double>();


                foreach (int il in Idiff[hour].Keys)
                {
                    Ig.Add(il, Idiff[hour][il] + Idir[hour][il]);
                }

                absDicts = HourlyAbsorbedIrradiance(I_dir, I_dif, k1_dir, k_dir, rho_dir, gaiDict, sigma, rho_dif, k_dif, Ig);

                    I_sun_absDict[hour] = absDicts.Item1;
                    I_shade_absDict[hour] = absDicts.Item2;


                }

                rates.absorbedSunlitIrradiance = I_sun_absDict; // absorbedSunlitIrradiance;
                rates.absorbedShadedIrradiance = I_shade_absDict; // absorbedShadedIrradiance;
                        

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation

            private Tuple<Dictionary<int, double>, Dictionary<int, double>> HourlyAbsorbedIrradiance(
        double I_dir, double I_dif, double k1_dir, double k_dir, double rho_dir,
        Dictionary<int, Tuple<double, double>> gaiDict, double sigma, double rho_dif, double k_dif,
        Dictionary<int,double> Ig)
            {
                Dictionary<int, double> I_sun_absDict = new Dictionary<int, double>();
                Dictionary<int, double> I_shade_absDict = new Dictionary<int, double>();
                Dictionary<int, double> f_sunDict = new Dictionary<int, double>();
                Dictionary<int, double> f_shadeDict = new Dictionary<int, double>();

                    double upperCumGAI = new double();
                    double lowerCumGAI = 0.0;
                    double layerGAI = new double();

                    double I_cb_l = new double();
                    double I_cd_l = new double();
                    double I_cs_l = new double();
                    double I_sun = new double();
                    double I_shade = new double();

            for (int layerIndex = gaiDict.Count - 1; layerIndex >= 0; --layerIndex)
            {
                        layerGAI = Math.Max(0.000001, gaiDict[layerIndex].Item1 + gaiDict[layerIndex].Item2);

                        upperCumGAI = lowerCumGAI;
                        lowerCumGAI += layerGAI;

                // Absorbed irradiance per unit GROUND area
                I_cb_l = I_dir * (1.0 - sigma) *  (Math.Exp(-k1_dir * upperCumGAI) - Math.Exp(-k1_dir * lowerCumGAI)) ;
                I_cd_l = I_dif * (1 - rho_dif) * (k_dif / (k_dif + k1_dir)) * (Math.Exp(-(k_dif+ k1_dir) * upperCumGAI) - Math.Exp(-(k_dif + k1_dir) * lowerCumGAI)) ;
                I_cs_l = I_dir * ((1 - rho_dir) * (k_dir / (k_dir + k1_dir)) * (Math.Exp(-(k1_dir+ k_dir) * upperCumGAI) - Math.Exp(-(k1_dir + k_dir) * lowerCumGAI)) -
                                (1 - sigma) * 0.5 * (Math.Exp(-2.0*k1_dir * upperCumGAI) - Math.Exp(-2.0*k1_dir * lowerCumGAI))) ;
               
                // Absorbed irradiance per unit ground surface area
                I_sun = I_cb_l + I_cd_l + I_cs_l;

                I_shade = Ig[layerIndex] - I_sun;
                //***********************************
                I_sun_absDict.Add(layerIndex, I_sun);
                        I_shade_absDict.Add(layerIndex, I_shade);
            }


            return Tuple.Create(I_sun_absDict, I_shade_absDict);

            }


				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
