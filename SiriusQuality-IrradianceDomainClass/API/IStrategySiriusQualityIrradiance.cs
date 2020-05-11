/*
     -----------------------------------------------------------

     Code generated by CRA.ModelLayer.ACC - API Code Generator
     http://components.biomamodelling.org/components/acc/help/ 

     Loic Manceau
     loic.manceau@inra.fr
     INRA
     3/1/2018 12:41:53 PM

     -----------------------------------------------------------
*/

using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;


namespace INRA.SiriusQualityIrradiance.Interfaces
{
    /// <summary>
    /// INRA.SiriusQualityIrradiance.Interfaces component model interface   
    /// </summary>
    public interface IStrategySiriusQualityIrradiance : IStrategy
    {
        /// <summary>
        /// Calculate method for models
        /// </summary>
        /// <param name=r>Rates Domain class contains the accessors to values</param>
        /// <param name=e>Exogenous Domain class contains the accessors to values</param>
        /// <param name=s>States Domain class contains the accessors to values</param>
        /// <param name=ae>AgroManagement objects of impact parameters</param>
        void Estimate
        ( Rates r, Exogenous e, States s, ActEvents ae);
        
        /// <summary>
        /// Test of pre conditions
        /// </summary>
        /// <param name=r>Rates Domain class contains the accessors to values</param>
        /// <param name=e>Exogenous Domain class contains the accessors to values</param>
        /// <param name=s>States Domain class contains the accessors to values</param>
        /// <param name=callID>Preconditions test context</param>
        /// <returns>List of violations</returns>
        string TestPreConditions( Rates r, Exogenous e, States s, string callID);
        
        /// <summary>
        /// Test of post-conditions
        /// </summary>
        /// <param name=r>Rates Domain class contains the accessors to values</param>
        /// <param name=e>Exogenous Domain class contains the accessors to values</param>
        /// <param name=s>States Domain class contains the accessors to values</param>
        /// <param name=callID>Postconditions test context</param>
        /// <returns>List of violations</returns>
        string TestPostConditions( Rates r, Exogenous e, States s, string callID);
    
        /// <summary>
        /// Set parameters to the default value
        /// </summary>
        void SetParametersDefaultValue();
    }
}
