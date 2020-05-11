/*   
     ----------------------------------------------------------------
	 Code generated by CRA.ModelLayer.ACC - API Code Generator
     http://components.biomamodelling.org/components/acc/help/ 

     Loic Manceau
     loic.manceau@inra.fr
     INRA
     3/1/2018 12:41:53 PM
	 ----------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Text;
using CRA.AgroManagement;
using CRA.ModelLayer.Core;

namespace INRA.SiriusQualityIrradiance.Interfaces
{
    /// <summary>
    /// INRA.SiriusQualityIrradiance.Interfaces component API 
    /// </summary>
    public class SiriusQualityIrradianceAPI 
    {
        private string _resultPreConditions;
        private string _resultPostConditions;
        Preconditions p = new Preconditions();

        /// <summary>
        /// Calculate method for the component
        /// </summary>
        /// <param name=r>Rates Domain class contains the accessors to values</param>
        /// <param name=e>Exogenous Domain class contains the accessors to values</param>
        /// <param name=s>States Domain class contains the accessors to values</param>
        /// <param name=ae>AgroManagement objects of impact parameters</param>
        public void Estimate
		(IStrategySiriusQualityIrradiance st, Rates r, Exogenous e, States s, ActEvents ae)
        {
            st.Estimate
			( r, e, s, ae);
        }
              
        /// <summary>
        /// Calculate method for the component with test of preconditions
        /// </summary>
        /// <param name=r>Rates Domain class contains the accessors to values</param>
        /// <param name=e>Exogenous Domain class contains the accessors to values</param>
        /// <param name=s>States Domain class contains the accessors to values</param>
        /// <param name=ae>AgroManagement objects of impact parameters</param>
        /// <param name="saveLog">Save log via a writer or show on screen</param>
        /// <param name="callID">Context description for violations</param>
        public void Estimate
            (IStrategySiriusQualityIrradiance st, Rates r, Exogenous e, States s, ActEvents ae, bool saveLog, string callID)        
           {
            _resultPreConditions = String.Empty;
            _resultPostConditions = String.Empty;
            _resultPreConditions = st.TestPreConditions( r, e, s, callID);
            st.Estimate
			( r, e, s, ae);
            _resultPostConditions = st.TestPostConditions( r, e, s, callID);

            if (_resultPreConditions != String.Empty || _resultPostConditions != String.Empty)
            {
                p.TestsOut(_resultPreConditions + _resultPostConditions, saveLog, callID);
            }
        }

        /// <summary>
        /// Show the about form with access to the help and codedoc
        /// </summary>
        public void Info()
        {
            // The following assumes an about form called AboutBox
            //AboutBox a = new AboutBox();
            //a.ShowDialog();
        }
    }
}
 
