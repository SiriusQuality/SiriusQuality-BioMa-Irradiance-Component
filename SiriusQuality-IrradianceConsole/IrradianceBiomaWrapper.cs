using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INRA.SiriusQualityIrradiance.Interfaces;
using INRA.SiriusQualityIrradiance.Strategies;

namespace SiriusQuality_IrradianceConsole
{
    public class IrradianceBiomaWrapper
    {
        #region Paameters


            public bool IsSunShadeUsed {get; set;}
            public bool IsHourlyUsed { get; set; }
            public bool IsCanopyUsed { get; set; }
            public bool IsSphereDistUsed { get; set; }
            public bool IsDiffDirIrrUsed { get; set; }

            double Kl = 0.45;
            double tauLeafPAR = 0.143;
            double tauLeafNIR = 0.411;
            double rhoLeafPAR = 0.057;
            double rhoLeafNIR = 0.389;
            double alaJuv = 0.806;
            double alaMat = 1.216;
            double CI = 1.0;

        #endregion


        #region Properties

        public Dictionary<string, Dictionary<int, Dictionary<int, double>>> absPARIrradianceDictionary { get { return irradianceRate.absorbedIrradiancePAR; } }
        public Dictionary<string, Dictionary<int, Dictionary<int, double>>> absNIRIrradianceDictionary { get { return irradianceRate.absorbedIrradianceNIR; } }
        public Dictionary<string, Dictionary<int, Dictionary<int, double>>> absIrradianceDictionary { get { return irradianceRate.absorbedIrradiance; } }

        public Dictionary<int, Dictionary<int, double>> AbsorbedIrradiancePerSunlitLeaves { get { return irradianceRate.absorbedSunlitIrradiance; } } // [MJ m-2ground h-1]
        public Dictionary<int, Dictionary<int, double>> AbsorbedIrradiancePerShadedLeaves { get { return irradianceRate.absorbedShadedIrradiance; } } // [MJ m-2ground h-1]

        public Dictionary<int, Dictionary<int, double>> AbsorbedTotalIrradiancePAR { get { return irradianceRate.absorbedGlobalIrradiancePAR; } } // [MJ m-2ground d-1] or  [MJ m-2ground h-1]
        public Dictionary<int, Dictionary<int, double>> AbsorbedTotalIrradianceNIR { get { return irradianceRate.absorbedGlobalIrradianceNIR; } } // [MJ m-2ground d-1] or  [MJ m-2ground h-1]
        public Dictionary<int, Dictionary<int, double>> AbsorbedTotalIrradiance { get { return irradianceRate.absorbedGlobalIrradiance; } } // [MJ m-2ground d-1] or  [MJ m-2ground h-1]

        public Dictionary<string, Dictionary<int, Dictionary<int, double>>> leafFractionDictionary { get {return irradianceState.sunlitShadedFractionPAR;} }
        public Dictionary<int, Dictionary<int, double>> SunlitFraction { get { return irradianceState.sunlitFraction; } }
        public Dictionary<int, Dictionary<int, double>> ShadeFraction { get { return irradianceState.shadeFraction; } }

        public double diffuseExtinctionCoeffBlackLeaves { get { return irradianceState.k_difBlack; } }
        public Dictionary<int, double> extinctionCoeffBlackLeaves { get { return irradianceState.k1_dir; } }

        public double diffuseExtinctionCoefficientNIR { get { return irradianceState.k_difNIR; } }
        public double diffuseExtinctionCoefficientPAR { get { return irradianceState.k_difPAR; }  }

        public Dictionary<int, double> directExtinctionCoefficient { get { return irradianceState.k_dir; } }
        public Dictionary<int, double> directExtinctionCoefficientNIR { get { return irradianceState.k_dirNIR; } }
        public Dictionary<int, double> directExtinctionCoefficientPAR { get { return irradianceState.k_dirPAR; } }

        public Dictionary<int, double> directReflectanceCoefficient { get { return irradianceState.rhoCanopyDir; } }
        public Dictionary<int, double> directReflectanceCoefficientNIR { get { return irradianceState.rhoCanopyDirNIR; } }
        public Dictionary<int, double> directReflectanceCoefficientPAR { get { return irradianceState.rhoCanopyDirPAR; } }

        public Dictionary<double, double> FiPar { get { return irradianceState.fiPARb; } }

        public Dictionary<int, Dictionary<int, double>> absorbedDiffIrradiance { get { return irradianceRate.absorbedDiffIrradiance; } }
        public Dictionary<int, Dictionary<int, double>> absorbedDiffIrradianceNIR { get { return irradianceRate.absorbedDiffIrradianceNIR; } }
        public Dictionary<int, Dictionary<int, double>> absorbedDiffIrradiancePAR { get { return irradianceRate.absorbedDiffIrradiancePAR; } }

        public Dictionary<int, Dictionary<int, double>> absorbedDirIrradiance { get { return irradianceRate.absorbedDirIrradiance; } }
        public Dictionary<int, Dictionary<int, double>> absorbedDirIrradianceNIR { get { return irradianceRate.absorbedDirIrradianceNIR; } }
        public Dictionary<int, Dictionary<int, double>> absorbedDirIrradiancePAR { get { return irradianceRate.absorbedDirIrradiancePAR; } }



        #endregion Properties

        private INRA.SiriusQualityIrradiance.Interfaces.States irradianceState;
        private INRA.SiriusQualityIrradiance.Interfaces.Rates irradianceRate;
        private INRA.SiriusQualityIrradiance.Interfaces.Exogenous irradianceExogenous;

        private INRA.SiriusQualityIrradiance.Strategies.Irradiance absorbedIrradiance;

        #region Constructor
        public IrradianceBiomaWrapper()
        {
            irradianceState = new INRA.SiriusQualityIrradiance.Interfaces.States();
            irradianceRate = new INRA.SiriusQualityIrradiance.Interfaces.Rates();
            irradianceExogenous = new INRA.SiriusQualityIrradiance.Interfaces.Exogenous();

            absorbedIrradiance = new INRA.SiriusQualityIrradiance.Strategies.Irradiance();

            IsSunShadeUsed = true;
            IsHourlyUsed = true;
            IsCanopyUsed = true;
            IsSphereDistUsed = true;


            loadParameters();
        }

        public IrradianceBiomaWrapper(IrradianceBiomaWrapper toCopy)
        {
            irradianceState = (toCopy.irradianceState != null) ? new INRA.SiriusQualityIrradiance.Interfaces.States(toCopy.irradianceState) : null;
            irradianceRate = (toCopy.irradianceRate != null) ? new INRA.SiriusQualityIrradiance.Interfaces.Rates(toCopy.irradianceRate) : null;
            irradianceExogenous = (toCopy.irradianceExogenous != null) ? new INRA.SiriusQualityIrradiance.Interfaces.Exogenous(toCopy.irradianceExogenous) : null;

            absorbedIrradiance = (toCopy.absorbedIrradiance != null) ? new INRA.SiriusQualityIrradiance.Strategies.Irradiance(toCopy.absorbedIrradiance) : null;
        }
        #endregion Constructor

        public void Estimate(double[] solarElevation
            , double[] incidentDiffuseIrradiancePAR, double[] incidentDirectIrradiancePAR
            , double[] incidentDiffuseIrradianceNIR, double[] incidentDirectIrradianceNIR,
             Dictionary<int, Tuple<double, double>> layerGAI, double CumulTT, double CumulTTFlagLeaf, double CumulTTSpiklet,
             double Phyllochon, double haunStage, double FinalLeafNumber)
        {

            irradianceExogenous.solarElevation = solarElevation;
            irradianceExogenous.incidentDirectIrradiancePAR = incidentDirectIrradiancePAR;
            irradianceExogenous.incidentDiffuseIrradiancePAR = incidentDiffuseIrradiancePAR;
            irradianceExogenous.incidentDirectIrradianceNIR = incidentDirectIrradianceNIR;
            irradianceExogenous.incidentDiffuseIrradianceNIR = incidentDiffuseIrradianceNIR;
            irradianceState.layersGAI = layerGAI;
            irradianceState.Phyll = Phyllochon;
            irradianceState.HS = haunStage;
            irradianceState.FLN = FinalLeafNumber;
            irradianceState.cumulTT = CumulTT;
            irradianceState.flagLeafLiguleTT = CumulTTFlagLeaf;
            irradianceState.termSpikletTT = CumulTTSpiklet;

            absorbedIrradiance.Estimate(irradianceRate,irradianceExogenous,irradianceState,null);

           

        }

        public void Init()
        {
            absorbedIrradiance.useSunShade = IsSunShadeUsed ? 1 : 0;
            absorbedIrradiance.useHourly = IsHourlyUsed ? 1 : 0;
            absorbedIrradiance.useLayered = IsCanopyUsed ? 0 : 1;
            absorbedIrradiance.useSphericalLeafDistrib = IsSphereDistUsed ? 1 : 0;
            absorbedIrradiance.useDiffDirIrradiance = IsDiffDirIrrUsed ? 1 : 0;
        }

        public void loadParameters()
        {
            absorbedIrradiance.Kl = Kl;
            absorbedIrradiance.tauLeafPAR = tauLeafPAR;
            absorbedIrradiance.tauLeafNIR = tauLeafNIR;
            absorbedIrradiance.rhoLeafPAR = rhoLeafPAR;
            absorbedIrradiance.rhoLeafNIR = rhoLeafNIR;
            absorbedIrradiance.alaJuv = alaJuv;
            absorbedIrradiance.alaMat = alaMat;
            absorbedIrradiance.CI = CI;



        }

    }
}
