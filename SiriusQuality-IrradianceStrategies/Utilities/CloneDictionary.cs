using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusQuality_IrradianceStrategies.Utilities
{
    static class CloneDictionary
    {


        public static Dictionary<int, Dictionary<int, double>> CloneDict(Dictionary<int, Dictionary<int, double>> toClone)
        {
            Dictionary<int, Dictionary<int, double>> cloned = new Dictionary<int, Dictionary<int, double>>();

            foreach (int timeStep in toClone.Keys)
            {
                cloned.Add(timeStep, new Dictionary<int, double>());
                foreach (int layerIndex in toClone[timeStep].Keys)
                {
                    cloned[timeStep].Add(layerIndex, toClone[timeStep][layerIndex]);
                }
            }
            return cloned;
        }


    }
}
