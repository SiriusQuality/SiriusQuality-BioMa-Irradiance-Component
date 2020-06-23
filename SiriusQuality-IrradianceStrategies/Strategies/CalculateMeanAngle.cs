

 //Author:Loic Manceau loic.manceau@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:21/04/2020
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
	///Class CalculateMeanAngle
    /// Calcalates mean orietation angle for ellipsoidal dsitribution as a function of cumulated physiological thermal time
    /// </summary>
	public class CalculateMeanAngle : IStrategySiriusQualityIrradiance
	{

	#region Constructor

			public CalculateMeanAngle()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 0.806;
				 v1.Description = "Mean leaf angle for a ellipsoidal distribution during at terminal spikelet (GS30)";
				 v1.Id = 0;
				 v1.MaxValue = 7;
				 v1.MinValue = 0;
				 v1.Name = "alaJuv";
				 v1.Size = 1;
				 v1.Units = "rd";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v1);
				VarInfo v2 = new VarInfo();
				 v2.DefaultValue = 1.216;
				 v2.Description = "Mean leaf angle for a ellipsoidal distribution at flag leaf ligule (GS39)";
				 v2.Id = 0;
				 v2.MaxValue = 7;
				 v2.MinValue = 0;
				 v2.Name = "alaMat";
				 v2.Size = 1;
				 v2.Units = "rd";
				 v2.URL = "";
				 v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v2);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd1.PropertyName = "cumulTT";
				pd1.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.cumulTT)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.cumulTT);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd2.PropertyName = "flagLeafLiguleTT";
				pd2.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.flagLeafLiguleTT)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.flagLeafLiguleTT);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd3.PropertyName = "FLN";
				pd3.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.FLN)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.FLN);
				_inputs0_0.Add(pd3);
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd4.PropertyName = "HS";
				pd4.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.HS)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.HS);
				_inputs0_0.Add(pd4);
				PropertyDescription pd5 = new PropertyDescription();
				pd5.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd5.PropertyName = "Phyll";
				pd5.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.Phyll)).ValueType.TypeForCurrentValue;
				pd5.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.Phyll);
				_inputs0_0.Add(pd5);
				PropertyDescription pd6 = new PropertyDescription();
				pd6.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd6.PropertyName = "termSpikletTT";
				pd6.PropertyType = (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.termSpikletTT)).ValueType.TypeForCurrentValue;
				pd6.PropertyVarInfo =( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.termSpikletTT);
				_inputs0_0.Add(pd6);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd7 = new PropertyDescription();
				pd7.DomainClassType = typeof(INRA.SiriusQualityIrradiance.Interfaces.States);
				pd7.PropertyName = "ala";
				pd7.PropertyType =  (( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala)).ValueType.TypeForCurrentValue;
				pd7.PropertyVarInfo =(  INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala);
				_outputs0_0.Add(pd7);
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
				get { return "Calcalates mean orietation angle for ellipsoidal dsitribution as a function of cumulated physiological thermal time"; }
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
				_pd.Add("Date", "21/04/2020");
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

			
			public Double alaJuv
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("alaJuv");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'alaJuv' not found (or found null) in strategy 'CalculateMeanAngle'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("alaJuv");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'alaJuv' not found in strategy 'CalculateMeanAngle'");
				}
			}
			public Double alaMat
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("alaMat");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'alaMat' not found (or found null) in strategy 'CalculateMeanAngle'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("alaMat");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'alaMat' not found in strategy 'CalculateMeanAngle'");
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
                alaJuvVarInfo.Name = "alaJuv";
				alaJuvVarInfo.Description =" Mean leaf angle for a ellipsoidal distribution during at terminal spikelet (GS30)";
				alaJuvVarInfo.MaxValue = 7;
				alaJuvVarInfo.MinValue = 0;
				alaJuvVarInfo.DefaultValue = 0.806;
				alaJuvVarInfo.Units = "rd";
				alaJuvVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				alaMatVarInfo.Name = "alaMat";
				alaMatVarInfo.Description =" Mean leaf angle for a ellipsoidal distribution at flag leaf ligule (GS39)";
				alaMatVarInfo.MaxValue = 7;
				alaMatVarInfo.MinValue = 0;
				alaMatVarInfo.DefaultValue = 1.216;
				alaMatVarInfo.Units = "rd";
				alaMatVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _alaJuvVarInfo= new VarInfo();
				/// <summary> 
				///alaJuv VarInfo definition
				/// </summary>
				public static VarInfo alaJuvVarInfo
				{
					get { return _alaJuvVarInfo; }
				}
				private static VarInfo _alaMatVarInfo= new VarInfo();
				/// <summary> 
				///alaMat VarInfo definition
				/// </summary>
				public static VarInfo alaMatVarInfo
				{
					get { return _alaMatVarInfo; }
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
					
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala.CurrentValue=states.ala;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r7 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala);
					if(r7.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.ala.ValueType)){prc.AddCondition(r7);}

					

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
					
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.cumulTT.CurrentValue=states.cumulTT;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.flagLeafLiguleTT.CurrentValue=states.flagLeafLiguleTT;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.FLN.CurrentValue=states.FLN;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.HS.CurrentValue=states.HS;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.Phyll.CurrentValue=states.Phyll;
					INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.termSpikletTT.CurrentValue=states.termSpikletTT;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.cumulTT);
					if(r1.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.cumulTT.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.flagLeafLiguleTT);
					if(r2.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.flagLeafLiguleTT.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.FLN);
					if(r3.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.FLN.ValueType)){prc.AddCondition(r3);}
					RangeBasedCondition r4 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.HS);
					if(r4.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.HS.ValueType)){prc.AddCondition(r4);}
					RangeBasedCondition r5 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.Phyll);
					if(r5.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.Phyll.ValueType)){prc.AddCondition(r5);}
					RangeBasedCondition r6 = new RangeBasedCondition(INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.termSpikletTT);
					if(r6.ApplicableVarInfoValueTypes.Contains( INRA.SiriusQualityIrradiance.Interfaces.StatesVarInfo.termSpikletTT.ValueType)){prc.AddCondition(r6);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("alaJuv")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("alaMat")));

					

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

        double hs30 = 0.0;
        double tt30 = 0.0;

        private void CalculateModel(INRA.SiriusQualityIrradiance.Interfaces.Rates rates,INRA.SiriusQualityIrradiance.Interfaces.Exogenous exogenous,INRA.SiriusQualityIrradiance.Interfaces.States states,CRA.AgroManagement.ActEvents actevents)
			{				
				

				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
                //Code written below will not be overwritten by a future code generation

                #region Inputs

                double TT = states.cumulTT;
                double TTGS30 = states.termSpikletTT;
                double TTGS39 = states.flagLeafLiguleTT;
                double hs = states.HS;
                double fln = states.FLN;
                double P = states.Phyll;

                #endregion

                double a = 0.0;


                if (TT <= TTGS30 || TTGS30 == -999) { 

                    a = alaJuv;
                    hs30 = hs;
                    tt30 = TT;
                }
                else if ((TT > TTGS30 && TTGS39 == -999) || (TT > TTGS30 && TT < TTGS39))
                {

                    a = alaJuv + (TT- tt30) * ((alaMat- alaJuv) /(P*(fln-hs30)));
                    a = Math.Min(alaMat, Math.Max(alaJuv, a));
                
                }
                else if (TT >= TTGS39)
                {
                    a = alaMat;
                }




                #region Output

                states.ala = Math.Min(80.0 * (Math.PI / 180),a);

            #endregion



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
