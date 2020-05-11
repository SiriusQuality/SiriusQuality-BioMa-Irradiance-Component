using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INRA.SiriusQualityIrradiance.Strategies;
using INRA.SiriusQualityIrradiance.Interfaces;
using System.Collections.Generic;

namespace TestIrradianceComponent
{



    [TestClass]
    public class TestCalculateAbsorbedIrradiance
    {
        double Kl = 0.45;
        double tauLeafPAR = 0.143;
        double tauLeafNIR = 0.411;
        double rhoLeafPAR = 0.057;
        double rhoLeafNIR = 0.389;
        double alaJuv = 0.806;
        double alaMat = 1.216;
        double CI = 1.0;


        

        [TestMethod]
        public void TestUseHourly1UseLayers1UseSunShade0Sphere()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.82933876596111, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.234, 0.0));
            gAI.Add(2, Tuple.Create(0.117, 0.0));
            gAI.Add(1, Tuple.Create(0.0670471664864663, 0.0));
            gAI.Add(0, Tuple.Create(0.0369136395866261, 0.00777766556238132));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.83691040793521;
            state.FLN = 9.13338362106057;
            state.cumulTT = 519.553112372622;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 499.542396312717;

            #endregion

            #region Parameters

            strategy.useSunShade = 0;
            strategy.useHourly = 1;
            strategy.useLayered = 1;
            strategy.useSphericalLeafDistrib = 1;
            strategy.useDiffDirIrradiance = 0;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["global"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["global"][0].Add(5, 0);
            AbsIrradiance["global"][0].Add(4, 0);
            AbsIrradiance["global"][0].Add(3, 0);
            AbsIrradiance["global"][0].Add(2, 0);
            AbsIrradiance["global"][0].Add(1, 0);
            AbsIrradiance["global"][0].Add(0, 0);
            AbsIrradiance["global"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["global"][1].Add(5, 0);
            AbsIrradiance["global"][1].Add(4, 0);
            AbsIrradiance["global"][1].Add(3, 0);
            AbsIrradiance["global"][1].Add(2, 0);
            AbsIrradiance["global"][1].Add(1, 0);
            AbsIrradiance["global"][1].Add(0, 0);
            AbsIrradiance["global"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["global"][2].Add(5, 0);
            AbsIrradiance["global"][2].Add(4, 0);
            AbsIrradiance["global"][2].Add(3, 0);
            AbsIrradiance["global"][2].Add(2, 0);
            AbsIrradiance["global"][2].Add(1, 0);
            AbsIrradiance["global"][2].Add(0, 0);
            AbsIrradiance["global"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["global"][3].Add(5, 0);
            AbsIrradiance["global"][3].Add(4, 0);
            AbsIrradiance["global"][3].Add(3, 0);
            AbsIrradiance["global"][3].Add(2, 0);
            AbsIrradiance["global"][3].Add(1, 0);
            AbsIrradiance["global"][3].Add(0, 0);
            AbsIrradiance["global"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["global"][4].Add(5, 0);
            AbsIrradiance["global"][4].Add(4, 0);
            AbsIrradiance["global"][4].Add(3, 0);
            AbsIrradiance["global"][4].Add(2, 0);
            AbsIrradiance["global"][4].Add(1, 0);
            AbsIrradiance["global"][4].Add(0, 0);
            AbsIrradiance["global"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["global"][5].Add(5, 0);
            AbsIrradiance["global"][5].Add(4, 0);
            AbsIrradiance["global"][5].Add(3, 0);
            AbsIrradiance["global"][5].Add(2, 0);
            AbsIrradiance["global"][5].Add(1, 0);
            AbsIrradiance["global"][5].Add(0, 0);
            AbsIrradiance["global"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["global"][6].Add(5, 0);
            AbsIrradiance["global"][6].Add(4, 0);
            AbsIrradiance["global"][6].Add(3, 0);
            AbsIrradiance["global"][6].Add(2, 0);
            AbsIrradiance["global"][6].Add(1, 0);
            AbsIrradiance["global"][6].Add(0, 0);
            AbsIrradiance["global"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["global"][7].Add(5, 0.127190007089021);
            AbsIrradiance["global"][7].Add(4, 0.0410793700333555);
            AbsIrradiance["global"][7].Add(3, 0.0239948352764983);
            AbsIrradiance["global"][7].Add(2, 0.0110825296942875);
            AbsIrradiance["global"][7].Add(1, 0.00609277839154773);
            AbsIrradiance["global"][7].Add(0, 0.00327681317275262);
            AbsIrradiance["global"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["global"][8].Add(5, 0.404079702877882);
            AbsIrradiance["global"][8].Add(4, 0.130508205930604);
            AbsIrradiance["global"][8].Add(3, 0.0762310352128921);
            AbsIrradiance["global"][8].Add(2, 0.0352089398255059);
            AbsIrradiance["global"][8].Add(1, 0.0193566156532584);
            AbsIrradiance["global"][8].Add(0, 0.0104103594577636);
            AbsIrradiance["global"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["global"][9].Add(5, 0.702485522706763);
            AbsIrradiance["global"][9].Add(4, 0.22688624201545);
            AbsIrradiance["global"][9].Add(3, 0.132526326456417);
            AbsIrradiance["global"][9].Add(2, 0.0612101284006991);
            AbsIrradiance["global"][9].Add(1, 0.0336511390405634);
            AbsIrradiance["global"][9].Add(0, 0.0180982285256295);
            AbsIrradiance["global"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["global"][10].Add(5, 0.897342211822075);
            AbsIrradiance["global"][10].Add(4, 0.289820353105168);
            AbsIrradiance["global"][10].Add(3, 0.16928671561634);
            AbsIrradiance["global"][10].Add(2, 0.0781887031541351);
            AbsIrradiance["global"][10].Add(1, 0.0429853520975638);
            AbsIrradiance["global"][10].Add(0, 0.0231183474823422);
            AbsIrradiance["global"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["global"][11].Add(5, 0.908278894193369);
            AbsIrradiance["global"][11].Add(4, 0.293352643356187);
            AbsIrradiance["global"][11].Add(3, 0.17134995861771);
            AbsIrradiance["global"][11].Add(2, 0.0791416562194811);
            AbsIrradiance["global"][11].Add(1, 0.0435092516047036);
            AbsIrradiance["global"][11].Add(0, 0.0234001106937821);
            AbsIrradiance["global"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["global"][12].Add(5, 0.730805461313393);
            AbsIrradiance["global"][12].Add(4, 0.236032913707428);
            AbsIrradiance["global"][12].Add(3, 0.137868980942088);
            AbsIrradiance["global"][12].Add(2, 0.0636777480489054);
            AbsIrradiance["global"][12].Add(1, 0.0350077480536572);
            AbsIrradiance["global"][12].Add(0, 0.0188278388936264);
            AbsIrradiance["global"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["global"][13].Add(5, 0.438053289345);
            AbsIrradiance["global"][13].Add(4, 0.141480872429994);
            AbsIrradiance["global"][13].Add(3, 0.0826402699451444);
            AbsIrradiance["global"][13].Add(2, 0.0381691824535274);
            AbsIrradiance["global"][13].Add(1, 0.0209840511589846);
            AbsIrradiance["global"][13].Add(0, 0.0112856255121415);
            AbsIrradiance["global"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["global"][14].Add(5, 0.152403285883145);
            AbsIrradiance["global"][14].Add(4, 0.0492226639370432);
            AbsIrradiance["global"][14].Add(3, 0.0287514076306614);
            AbsIrradiance["global"][14].Add(2, 0.0132794547304711);
            AbsIrradiance["global"][14].Add(1, 0.00730056918999775);
            AbsIrradiance["global"][14].Add(0, 0.0039263862482777);
            AbsIrradiance["global"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["global"][15].Add(5, 0);
            AbsIrradiance["global"][15].Add(4, 0);
            AbsIrradiance["global"][15].Add(3, 0);
            AbsIrradiance["global"][15].Add(2, 0);
            AbsIrradiance["global"][15].Add(1, 0);
            AbsIrradiance["global"][15].Add(0, 0);
            AbsIrradiance["global"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["global"][16].Add(5, 0);
            AbsIrradiance["global"][16].Add(4, 0);
            AbsIrradiance["global"][16].Add(3, 0);
            AbsIrradiance["global"][16].Add(2, 0);
            AbsIrradiance["global"][16].Add(1, 0);
            AbsIrradiance["global"][16].Add(0, 0);
            AbsIrradiance["global"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["global"][17].Add(5, 9.57631812986251E-18);
            AbsIrradiance["global"][17].Add(4, 3.09292471175365E-18);
            AbsIrradiance["global"][17].Add(3, 1.80660557649446E-18);
            AbsIrradiance["global"][17].Add(2, 8.34419562237027E-19);
            AbsIrradiance["global"][17].Add(1, 4.58734027205269E-19);
            AbsIrradiance["global"][17].Add(0, 2.46715965448767E-19);
            AbsIrradiance["global"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["global"][18].Add(5, 0);
            AbsIrradiance["global"][18].Add(4, 0);
            AbsIrradiance["global"][18].Add(3, 0);
            AbsIrradiance["global"][18].Add(2, 0);
            AbsIrradiance["global"][18].Add(1, 0);
            AbsIrradiance["global"][18].Add(0, 0);
            AbsIrradiance["global"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["global"][19].Add(5, 0);
            AbsIrradiance["global"][19].Add(4, 0);
            AbsIrradiance["global"][19].Add(3, 0);
            AbsIrradiance["global"][19].Add(2, 0);
            AbsIrradiance["global"][19].Add(1, 0);
            AbsIrradiance["global"][19].Add(0, 0);
            AbsIrradiance["global"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["global"][20].Add(5, 0);
            AbsIrradiance["global"][20].Add(4, 0);
            AbsIrradiance["global"][20].Add(3, 0);
            AbsIrradiance["global"][20].Add(2, 0);
            AbsIrradiance["global"][20].Add(1, 0);
            AbsIrradiance["global"][20].Add(0, 0);
            AbsIrradiance["global"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["global"][21].Add(5, 0);
            AbsIrradiance["global"][21].Add(4, 0);
            AbsIrradiance["global"][21].Add(3, 0);
            AbsIrradiance["global"][21].Add(2, 0);
            AbsIrradiance["global"][21].Add(1, 0);
            AbsIrradiance["global"][21].Add(0, 0);
            AbsIrradiance["global"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["global"][22].Add(5, 0);
            AbsIrradiance["global"][22].Add(4, 0);
            AbsIrradiance["global"][22].Add(3, 0);
            AbsIrradiance["global"][22].Add(2, 0);
            AbsIrradiance["global"][22].Add(1, 0);
            AbsIrradiance["global"][22].Add(0, 0);
            AbsIrradiance["global"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["global"][23].Add(5, 0);
            AbsIrradiance["global"][23].Add(4, 0);
            AbsIrradiance["global"][23].Add(3, 0);
            AbsIrradiance["global"][23].Add(2, 0);
            AbsIrradiance["global"][23].Add(1, 0);
            AbsIrradiance["global"][23].Add(0, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


           foreach(string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l],rate.absorbedIrradiance[iss][h][l], 0.00001);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TesttUseHourly1UseLayers1UseSunShade0Ellipse()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0,0,0,0,0,0,0,0.0983712488665375,0.385671109550484,0.838207199302679,1.12478372198615,1.13899883376011,0.890560332771681,0.429117464255033,0.119045365378662,0,0,7.37883450714624E-18,0,0,0,0,0,0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(1.03431535983786, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.234, 0.0));
            gAI.Add(2, Tuple.Create(0.117, 0.0));
            gAI.Add(1, Tuple.Create(0.0728823982290582, 0.0));
            gAI.Add(0, Tuple.Create(0.0373659451398467, 0.00788754233459126));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.81617959243677;
            state.FLN = 9.13338362106057;
            state.cumulTT = 516.419799997853;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 496.57212684863;

            #endregion

            #region Parameters

            strategy.useSunShade = 0;
            strategy.useHourly = 1;
            strategy.useLayered = 1;
            strategy.useSphericalLeafDistrib = 0;
            strategy.useDiffDirIrradiance = 0;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["global"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["global"][0].Add(5, 0);
            AbsIrradiance["global"][0].Add(4, 0);
            AbsIrradiance["global"][0].Add(3, 0);
            AbsIrradiance["global"][0].Add(2, 0);
            AbsIrradiance["global"][0].Add(1, 0);
            AbsIrradiance["global"][0].Add(0, 0);
            AbsIrradiance["global"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["global"][1].Add(5, 0);
            AbsIrradiance["global"][1].Add(4, 0);
            AbsIrradiance["global"][1].Add(3, 0);
            AbsIrradiance["global"][1].Add(2, 0);
            AbsIrradiance["global"][1].Add(1, 0);
            AbsIrradiance["global"][1].Add(0, 0);
            AbsIrradiance["global"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["global"][2].Add(5, 0);
            AbsIrradiance["global"][2].Add(4, 0);
            AbsIrradiance["global"][2].Add(3, 0);
            AbsIrradiance["global"][2].Add(2, 0);
            AbsIrradiance["global"][2].Add(1, 0);
            AbsIrradiance["global"][2].Add(0, 0);
            AbsIrradiance["global"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["global"][3].Add(5, 0);
            AbsIrradiance["global"][3].Add(4, 0);
            AbsIrradiance["global"][3].Add(3, 0);
            AbsIrradiance["global"][3].Add(2, 0);
            AbsIrradiance["global"][3].Add(1, 0);
            AbsIrradiance["global"][3].Add(0, 0);
            AbsIrradiance["global"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["global"][4].Add(5, 0);
            AbsIrradiance["global"][4].Add(4, 0);
            AbsIrradiance["global"][4].Add(3, 0);
            AbsIrradiance["global"][4].Add(2, 0);
            AbsIrradiance["global"][4].Add(1, 0);
            AbsIrradiance["global"][4].Add(0, 0);
            AbsIrradiance["global"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["global"][5].Add(5, 0);
            AbsIrradiance["global"][5].Add(4, 0);
            AbsIrradiance["global"][5].Add(3, 0);
            AbsIrradiance["global"][5].Add(2, 0);
            AbsIrradiance["global"][5].Add(1, 0);
            AbsIrradiance["global"][5].Add(0, 0);
            AbsIrradiance["global"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["global"][6].Add(5, 0);
            AbsIrradiance["global"][6].Add(4, 0);
            AbsIrradiance["global"][6].Add(3, 0);
            AbsIrradiance["global"][6].Add(2, 0);
            AbsIrradiance["global"][6].Add(1, 0);
            AbsIrradiance["global"][6].Add(0, 0);
            AbsIrradiance["global"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["global"][7].Add(5, 0.151963793053641);
            AbsIrradiance["global"][7].Add(4, 0.0374597334941892);
            AbsIrradiance["global"][7].Add(3, 0.0218805725103563);
            AbsIrradiance["global"][7].Add(2, 0.0101060120555003);
            AbsIrradiance["global"][7].Add(1, 0.0060315830441937);
            AbsIrradiance["global"][7].Add(0, 0.00301645759834761);
            AbsIrradiance["global"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["global"][8].Add(5, 0.482785446362412);
            AbsIrradiance["global"][8].Add(4, 0.119008704588108);
            AbsIrradiance["global"][8].Add(3, 0.0695140714364024);
            AbsIrradiance["global"][8].Add(2, 0.0321065659333496);
            AbsIrradiance["global"][8].Add(1, 0.0191621994538866);
            AbsIrradiance["global"][8].Add(0, 0.00958321583574507);
            AbsIrradiance["global"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["global"][9].Add(5, 0.839314086373728);
            AbsIrradiance["global"][9].Add(4, 0.206894559300588);
            AbsIrradiance["global"][9].Add(3, 0.120849001968392);
            AbsIrradiance["global"][9].Add(2, 0.0558167054454217);
            AbsIrradiance["global"][9].Add(1, 0.033313149865493);
            AbsIrradiance["global"][9].Add(0, 0.016660253751027);
            AbsIrradiance["global"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["global"][10].Add(5, 1.07212452689137);
            AbsIrradiance["global"][10].Add(4, 0.264283341728368);
            AbsIrradiance["global"][10].Add(3, 0.154370314003004);
            AbsIrradiance["global"][10].Add(2, 0.0712992429054278);
            AbsIrradiance["global"][10].Add(1, 0.0425536108813733);
            AbsIrradiance["global"][10].Add(0, 0.0212815046961532);
            AbsIrradiance["global"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["global"][11].Add(5, 1.08519143186765);
            AbsIrradiance["global"][11].Add(4, 0.267504390427992);
            AbsIrradiance["global"][11].Add(3, 0.156251757971164);
            AbsIrradiance["global"][11].Add(2, 0.0721682281851765);
            AbsIrradiance["global"][11].Add(1, 0.0430722483864744);
            AbsIrradiance["global"][11].Add(0, 0.0215408807225773);
            AbsIrradiance["global"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["global"][12].Add(5, 0.873150119472599);
            AbsIrradiance["global"][12].Add(4, 0.215235288081534);
            AbsIrradiance["global"][12].Add(3, 0.125720897837833);
            AbsIrradiance["global"][12].Add(2, 0.0580668951224245);
            AbsIrradiance["global"][12].Add(1, 0.0346561332131769);
            AbsIrradiance["global"][12].Add(0, 0.0173318937324205);
            AbsIrradiance["global"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["global"][13].Add(5, 0.523376332245181);
            AbsIrradiance["global"][13].Add(4, 0.129014533851167);
            AbsIrradiance["global"][13].Add(3, 0.0753585677073269);
            AbsIrradiance["global"][13].Add(2, 0.0348059719815384);
            AbsIrradiance["global"][13].Add(1, 0.0207732891359722);
            AbsIrradiance["global"][13].Add(0, 0.0103889385917013);
            AbsIrradiance["global"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["global"][14].Add(5, 0.18208805806915);
            AbsIrradiance["global"][14].Add(4, 0.0448854953583391);
            AbsIrradiance["global"][14].Add(3, 0.0262180278459201);
            AbsIrradiance["global"][14].Add(2, 0.0121093589007739);
            AbsIrradiance["global"][14].Add(1, 0.00722724289470957);
            AbsIrradiance["global"][14].Add(0, 0.0036144195620148);
            AbsIrradiance["global"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["global"][15].Add(5, 0);
            AbsIrradiance["global"][15].Add(4, 0);
            AbsIrradiance["global"][15].Add(3, 0);
            AbsIrradiance["global"][15].Add(2, 0);
            AbsIrradiance["global"][15].Add(1, 0);
            AbsIrradiance["global"][15].Add(0, 0);
            AbsIrradiance["global"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["global"][16].Add(5, 0);
            AbsIrradiance["global"][16].Add(4, 0);
            AbsIrradiance["global"][16].Add(3, 0);
            AbsIrradiance["global"][16].Add(2, 0);
            AbsIrradiance["global"][16].Add(1, 0);
            AbsIrradiance["global"][16].Add(0, 0);
            AbsIrradiance["global"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["global"][17].Add(5, 1.14415720213281E-17);
            AbsIrradiance["global"][17].Add(4, 2.82039708315409E-18);
            AbsIrradiance["global"][17].Add(3, 1.64741969922245E-18);
            AbsIrradiance["global"][17].Add(2, 7.60896148075225E-19);
            AbsIrradiance["global"][17].Add(1, 4.54126541698019E-19);
            AbsIrradiance["global"][17].Add(0, 2.27113420685636E-19);
            AbsIrradiance["global"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["global"][18].Add(5, 0);
            AbsIrradiance["global"][18].Add(4, 0);
            AbsIrradiance["global"][18].Add(3, 0);
            AbsIrradiance["global"][18].Add(2, 0);
            AbsIrradiance["global"][18].Add(1, 0);
            AbsIrradiance["global"][18].Add(0, 0);
            AbsIrradiance["global"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["global"][19].Add(5, 0);
            AbsIrradiance["global"][19].Add(4, 0);
            AbsIrradiance["global"][19].Add(3, 0);
            AbsIrradiance["global"][19].Add(2, 0);
            AbsIrradiance["global"][19].Add(1, 0);
            AbsIrradiance["global"][19].Add(0, 0);
            AbsIrradiance["global"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["global"][20].Add(5, 0);
            AbsIrradiance["global"][20].Add(4, 0);
            AbsIrradiance["global"][20].Add(3, 0);
            AbsIrradiance["global"][20].Add(2, 0);
            AbsIrradiance["global"][20].Add(1, 0);
            AbsIrradiance["global"][20].Add(0, 0);
            AbsIrradiance["global"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["global"][21].Add(5, 0);
            AbsIrradiance["global"][21].Add(4, 0);
            AbsIrradiance["global"][21].Add(3, 0);
            AbsIrradiance["global"][21].Add(2, 0);
            AbsIrradiance["global"][21].Add(1, 0);
            AbsIrradiance["global"][21].Add(0, 0);
            AbsIrradiance["global"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["global"][22].Add(5, 0);
            AbsIrradiance["global"][22].Add(4, 0);
            AbsIrradiance["global"][22].Add(3, 0);
            AbsIrradiance["global"][22].Add(2, 0);
            AbsIrradiance["global"][22].Add(1, 0);
            AbsIrradiance["global"][22].Add(0, 0);
            AbsIrradiance["global"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["global"][23].Add(5, 0);
            AbsIrradiance["global"][23].Add(4, 0);
            AbsIrradiance["global"][23].Add(3, 0);
            AbsIrradiance["global"][23].Add(2, 0);
            AbsIrradiance["global"][23].Add(1, 0);
            AbsIrradiance["global"][23].Add(0, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], 0.00001);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers0UseSunShade0Sphere()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.986258287350056, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.230696932136567, 0.0));
            gAI.Add(2, Tuple.Create(0.0989330685579592, 0.0));
            gAI.Add(1, Tuple.Create(0.0551429067144052, 0.0));
            gAI.Add(0, Tuple.Create(0.0252626226369163, 0.00538950005363393));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.99103109180387;
            state.FLN = 9.20561851236093;
            state.cumulTT = 533.90078117312;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 505.882750255413;

            #endregion

            #region Parameters

            strategy.useSunShade = 0;
            strategy.useHourly = 1;
            strategy.useLayered = 0;
            strategy.useSphericalLeafDistrib = 1;
            strategy.useDiffDirIrradiance = 0;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["global"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["global"][0].Add(99, 0);
            AbsIrradiance["global"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["global"][1].Add(99, 0);
            AbsIrradiance["global"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["global"][2].Add(99, 0);
            AbsIrradiance["global"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["global"][3].Add(99, 0);
            AbsIrradiance["global"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["global"][4].Add(99, 0);
            AbsIrradiance["global"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["global"][5].Add(99, 0);
            AbsIrradiance["global"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["global"][6].Add(99, 0);
            AbsIrradiance["global"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["global"][7].Add(99, 0.22278196243389);
            AbsIrradiance["global"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["global"][8].Add(99, 0.707773128150165);
            AbsIrradiance["global"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["global"][9].Add(99, 1.23045125094202);
            AbsIrradiance["global"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["global"][10].Add(99, 1.57175601684314);
            AbsIrradiance["global"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["global"][11].Add(99, 1.59091236109499);
            AbsIrradiance["global"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["global"][12].Add(99, 1.28005555275149);
            AbsIrradiance["global"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["global"][13].Add(99, 0.767280179350852);
            AbsIrradiance["global"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["global"][14].Add(99, 0.266944737935715);
            AbsIrradiance["global"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["global"][15].Add(99, 0);
            AbsIrradiance["global"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["global"][16].Add(99, 0);
            AbsIrradiance["global"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["global"][17].Add(99, 1.67735736060524E-17);
            AbsIrradiance["global"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["global"][18].Add(99, 0);
            AbsIrradiance["global"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["global"][19].Add(99, 0);
            AbsIrradiance["global"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["global"][20].Add(99, 0);
            AbsIrradiance["global"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["global"][21].Add(99, 0);
            AbsIrradiance["global"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["global"][22].Add(99, 0);
            AbsIrradiance["global"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["global"][23].Add(99, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], 0.00001);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers0UseSunShade0Ellipse()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.976092493432532, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.234, 0.0));
            gAI.Add(2, Tuple.Create(0.0990458376606824, 0.0));
            gAI.Add(1, Tuple.Create(0.056346772165243, 0.0));
            gAI.Add(0, Tuple.Create(0.0258179242216226, 0.0055186248448702));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.98946046328449;
            state.FLN = 9.18183344560221;
            state.cumulTT = 530.576778581676;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 495.051070735623;

            #endregion

            #region Parameters

            strategy.useSunShade = 0;
            strategy.useHourly = 1;
            strategy.useLayered = 0;
            strategy.useSphericalLeafDistrib = 0;
            strategy.useDiffDirIrradiance = 0;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["global"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["global"][0].Add(99, 0);
            AbsIrradiance["global"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["global"][1].Add(99, 0);
            AbsIrradiance["global"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["global"][2].Add(99, 0);
            AbsIrradiance["global"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["global"][3].Add(99, 0);
            AbsIrradiance["global"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["global"][4].Add(99, 0);
            AbsIrradiance["global"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["global"][5].Add(99, 0);
            AbsIrradiance["global"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["global"][6].Add(99, 0);
            AbsIrradiance["global"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["global"][7].Add(99, 0.222375544982684);
            AbsIrradiance["global"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["global"][8].Add(99, 0.706481949332846);
            AbsIrradiance["global"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["global"][9].Add(99, 1.22820655906581);
            AbsIrradiance["global"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["global"][10].Add(99, 1.56888868832468);
            AbsIrradiance["global"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["global"][11].Add(99, 1.5880100859744);
            AbsIrradiance["global"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["global"][12].Add(99, 1.27772036856751);
            AbsIrradiance["global"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["global"][13].Add(99, 0.765880442803753);
            AbsIrradiance["global"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["global"][14].Add(99, 0.266457755063226);
            AbsIrradiance["global"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["global"][15].Add(99, 0);
            AbsIrradiance["global"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["global"][16].Add(99, 0);
            AbsIrradiance["global"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["global"][17].Add(99, 1.67429738530108E-17);
            AbsIrradiance["global"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["global"][18].Add(99, 0);
            AbsIrradiance["global"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["global"][19].Add(99, 0);
            AbsIrradiance["global"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["global"][20].Add(99, 0);
            AbsIrradiance["global"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["global"][21].Add(99, 0);
            AbsIrradiance["global"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["global"][22].Add(99, 0);
            AbsIrradiance["global"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["global"][23].Add(99, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], 0.00001);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers1UseSunShade1Sphere()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.339216815744189, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.234, 0.0));
            gAI.Add(2, Tuple.Create(0.117, 0.0));
            gAI.Add(1, Tuple.Create(0.104490866099216, 0.0));
            gAI.Add(0, Tuple.Create(0.0762524062216429, 0.0155046559317341));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.33141437795716;
            state.FLN = 9.03326815053531;
            state.cumulTT = 465.208919191313;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = -999;

            #endregion

            #region Parameters

            strategy.useSunShade = 1;
            strategy.useHourly = 1;
            strategy.useLayered = 1;
            strategy.useSphericalLeafDistrib = 1;
            strategy.useDiffDirIrradiance = 0;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance.Add("shaded", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["sunlit"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][0].Add(5, 0);
            AbsIrradiance["shaded"][0].Add(5, 0);
            AbsIrradiance["sunlit"][0].Add(4, 0);
            AbsIrradiance["shaded"][0].Add(4, 0);
            AbsIrradiance["sunlit"][0].Add(3, 0);
            AbsIrradiance["shaded"][0].Add(3, 0);
            AbsIrradiance["sunlit"][0].Add(2, 0);
            AbsIrradiance["shaded"][0].Add(2, 0);
            AbsIrradiance["sunlit"][0].Add(1, 0);
            AbsIrradiance["shaded"][0].Add(1, 0);
            AbsIrradiance["sunlit"][0].Add(0, 0);
            AbsIrradiance["shaded"][0].Add(0, 0);
            AbsIrradiance["sunlit"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][1].Add(5, 0);
            AbsIrradiance["shaded"][1].Add(5, 0);
            AbsIrradiance["sunlit"][1].Add(4, 0);
            AbsIrradiance["shaded"][1].Add(4, 0);
            AbsIrradiance["sunlit"][1].Add(3, 0);
            AbsIrradiance["shaded"][1].Add(3, 0);
            AbsIrradiance["sunlit"][1].Add(2, 0);
            AbsIrradiance["shaded"][1].Add(2, 0);
            AbsIrradiance["sunlit"][1].Add(1, 0);
            AbsIrradiance["shaded"][1].Add(1, 0);
            AbsIrradiance["sunlit"][1].Add(0, 0);
            AbsIrradiance["shaded"][1].Add(0, 0);
            AbsIrradiance["sunlit"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][2].Add(5, 0);
            AbsIrradiance["shaded"][2].Add(5, 0);
            AbsIrradiance["sunlit"][2].Add(4, 0);
            AbsIrradiance["shaded"][2].Add(4, 0);
            AbsIrradiance["sunlit"][2].Add(3, 0);
            AbsIrradiance["shaded"][2].Add(3, 0);
            AbsIrradiance["sunlit"][2].Add(2, 0);
            AbsIrradiance["shaded"][2].Add(2, 0);
            AbsIrradiance["sunlit"][2].Add(1, 0);
            AbsIrradiance["shaded"][2].Add(1, 0);
            AbsIrradiance["sunlit"][2].Add(0, 0);
            AbsIrradiance["shaded"][2].Add(0, 0);
            AbsIrradiance["sunlit"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][3].Add(5, 0);
            AbsIrradiance["shaded"][3].Add(5, 0);
            AbsIrradiance["sunlit"][3].Add(4, 0);
            AbsIrradiance["shaded"][3].Add(4, 0);
            AbsIrradiance["sunlit"][3].Add(3, 0);
            AbsIrradiance["shaded"][3].Add(3, 0);
            AbsIrradiance["sunlit"][3].Add(2, 0);
            AbsIrradiance["shaded"][3].Add(2, 0);
            AbsIrradiance["sunlit"][3].Add(1, 0);
            AbsIrradiance["shaded"][3].Add(1, 0);
            AbsIrradiance["sunlit"][3].Add(0, 0);
            AbsIrradiance["shaded"][3].Add(0, 0);
            AbsIrradiance["sunlit"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][4].Add(5, 0);
            AbsIrradiance["shaded"][4].Add(5, 0);
            AbsIrradiance["sunlit"][4].Add(4, 0);
            AbsIrradiance["shaded"][4].Add(4, 0);
            AbsIrradiance["sunlit"][4].Add(3, 0);
            AbsIrradiance["shaded"][4].Add(3, 0);
            AbsIrradiance["sunlit"][4].Add(2, 0);
            AbsIrradiance["shaded"][4].Add(2, 0);
            AbsIrradiance["sunlit"][4].Add(1, 0);
            AbsIrradiance["shaded"][4].Add(1, 0);
            AbsIrradiance["sunlit"][4].Add(0, 0);
            AbsIrradiance["shaded"][4].Add(0, 0);
            AbsIrradiance["sunlit"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][5].Add(5, 0);
            AbsIrradiance["shaded"][5].Add(5, 0);
            AbsIrradiance["sunlit"][5].Add(4, 0);
            AbsIrradiance["shaded"][5].Add(4, 0);
            AbsIrradiance["sunlit"][5].Add(3, 0);
            AbsIrradiance["shaded"][5].Add(3, 0);
            AbsIrradiance["sunlit"][5].Add(2, 0);
            AbsIrradiance["shaded"][5].Add(2, 0);
            AbsIrradiance["sunlit"][5].Add(1, 0);
            AbsIrradiance["shaded"][5].Add(1, 0);
            AbsIrradiance["sunlit"][5].Add(0, 0);
            AbsIrradiance["shaded"][5].Add(0, 0);
            AbsIrradiance["sunlit"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][6].Add(5, 0);
            AbsIrradiance["shaded"][6].Add(5, 0);
            AbsIrradiance["sunlit"][6].Add(4, 0);
            AbsIrradiance["shaded"][6].Add(4, 0);
            AbsIrradiance["sunlit"][6].Add(3, 0);
            AbsIrradiance["shaded"][6].Add(3, 0);
            AbsIrradiance["sunlit"][6].Add(2, 0);
            AbsIrradiance["shaded"][6].Add(2, 0);
            AbsIrradiance["sunlit"][6].Add(1, 0);
            AbsIrradiance["shaded"][6].Add(1, 0);
            AbsIrradiance["sunlit"][6].Add(0, 0);
            AbsIrradiance["shaded"][6].Add(0, 0);
            AbsIrradiance["sunlit"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][7].Add(5, 0.0694889920586821);
            AbsIrradiance["shaded"][7].Add(5, 0.00814814071074006);
            AbsIrradiance["sunlit"][7].Add(4, 0.0397579396359103);
            AbsIrradiance["shaded"][7].Add(4, 0.0182019151011157);
            AbsIrradiance["sunlit"][7].Add(3, 0.0157845294725133);
            AbsIrradiance["shaded"][7].Add(3, 0.0138327000266907);
            AbsIrradiance["sunlit"][7].Add(2, 0.00577989849991538);
            AbsIrradiance["shaded"][7].Add(2, 0.00692146713346217);
            AbsIrradiance["sunlit"][7].Add(1, 0.00425459045328946);
            AbsIrradiance["shaded"][7].Add(1, 0.00607327260370812);
            AbsIrradiance["sunlit"][7].Add(0, 0.00314900657739342);
            AbsIrradiance["shaded"][7].Add(0, 0.00520858956459603);
            AbsIrradiance["sunlit"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][8].Add(5, 0.191231844748603);
            AbsIrradiance["shaded"][8].Add(5, 0.0139911705706587);
            AbsIrradiance["sunlit"][8].Add(4, 0.133035176269409);
            AbsIrradiance["shaded"][8].Add(4, 0.0338251820658193);
            AbsIrradiance["sunlit"][8].Add(3, 0.0630678534656693);
            AbsIrradiance["shaded"][8].Add(3, 0.0278149443086072);
            AbsIrradiance["sunlit"][8].Add(2, 0.0257131354791402);
            AbsIrradiance["shaded"][8].Add(2, 0.0146091912955051);
            AbsIrradiance["sunlit"][8].Add(1, 0.0202220990717753);
            AbsIrradiance["shaded"][8].Add(1, 0.0132117197418376);
            AbsIrradiance["sunlit"][8].Add(0, 0.0158696730159712);
            AbsIrradiance["shaded"][8].Add(0, 0.0116320468231591);
            AbsIrradiance["sunlit"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][9].Add(5, 0.300791576361172);
            AbsIrradiance["shaded"][9].Add(5, 0.0141475622034834);
            AbsIrradiance["sunlit"][9].Add(4, 0.229160874452252);
            AbsIrradiance["shaded"][9].Add(4, 0.036159253176139);
            AbsIrradiance["sunlit"][9].Add(3, 0.117508112750104);
            AbsIrradiance["shaded"][9].Add(3, 0.0312795194587761);
            AbsIrradiance["sunlit"][9].Add(2, 0.0501986814481245);
            AbsIrradiance["shaded"][9].Add(2, 0.0169386198550116);
            AbsIrradiance["sunlit"][9].Add(1, 0.0406293519866262);
            AbsIrradiance["shaded"][9].Add(1, 0.0156144372726161);
            AbsIrradiance["sunlit"][9].Add(0, 0.032701688935559);
            AbsIrradiance["shaded"][9].Add(0, 0.0139798122651175);
            AbsIrradiance["sunlit"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][10].Add(5, 0.360019850445082);
            AbsIrradiance["shaded"][10].Add(5, 0.0145457898597165);
            AbsIrradiance["sunlit"][10].Add(4, 0.282949838459532);
            AbsIrradiance["shaded"][10].Add(4, 0.037860195475267);
            AbsIrradiance["sunlit"][10].Add(3, 0.149089890762769);
            AbsIrradiance["shaded"][10].Add(3, 0.0333307081617841);
            AbsIrradiance["sunlit"][10].Add(2, 0.0647406558325994);
            AbsIrradiance["shaded"][10].Add(2, 0.01824935978788);
            AbsIrradiance["sunlit"][10].Add(1, 0.0529343729906871);
            AbsIrradiance["shaded"][10].Add(1, 0.0169422740530756);
            AbsIrradiance["sunlit"][10].Add(0, 0.0429903741204701);
            AbsIrradiance["shaded"][10].Add(0, 0.0152643847002778);
            AbsIrradiance["sunlit"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][11].Add(5, 0.363176839911477);
            AbsIrradiance["shaded"][11].Add(5, 0.0146172536133976);
            AbsIrradiance["sunlit"][11].Add(4, 0.28576383521597);
            AbsIrradiance["shaded"][11].Add(4, 0.0380592678252778);
            AbsIrradiance["sunlit"][11].Add(3, 0.15073267705769);
            AbsIrradiance["shaded"][11].Add(3, 0.0335202860837721);
            AbsIrradiance["sunlit"][11].Add(2, 0.0654969437289702);
            AbsIrradiance["shaded"][11].Add(2, 0.0183587537713171);
            AbsIrradiance["sunlit"][11].Add(1, 0.0535748808125947);
            AbsIrradiance["shaded"][11].Add(1, 0.0170473884818929);
            AbsIrradiance["sunlit"][11].Add(0, 0.0435266053211577);
            AbsIrradiance["shaded"][11].Add(0, 0.0153620393515787);
            AbsIrradiance["sunlit"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][12].Add(5, 0.309991430933754);
            AbsIrradiance["shaded"][12].Add(5, 0.0139004735603021);
            AbsIrradiance["sunlit"][12].Add(4, 0.237868736033675);
            AbsIrradiance["shaded"][12].Add(4, 0.0357516976548044);
            AbsIrradiance["sunlit"][12].Add(3, 0.122704476438913);
            AbsIrradiance["shaded"][12].Add(3, 0.0310950256869869);
            AbsIrradiance["sunlit"][12].Add(2, 0.0526016672508298);
            AbsIrradiance["shaded"][12].Add(2, 0.0168921351272792);
            AbsIrradiance["sunlit"][12].Add(1, 0.0426649771664329);
            AbsIrradiance["shaded"][12].Add(1, 0.0156020791280243);
            AbsIrradiance["sunlit"][12].Add(0, 0.034404143460254);
            AbsIrradiance["shaded"][12].Add(0, 0.0139924618965956);
            AbsIrradiance["sunlit"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][13].Add(5, 0.204813544077457);
            AbsIrradiance["shaded"][13].Add(5, 0.0142695601817714);
            AbsIrradiance["sunlit"][13].Add(4, 0.144321554083002);
            AbsIrradiance["shaded"][13].Add(4, 0.0347166297825934);
            AbsIrradiance["sunlit"][13].Add(3, 0.0691963111642293);
            AbsIrradiance["shaded"][13].Add(3, 0.0287191799571413);
            AbsIrradiance["sunlit"][13].Add(2, 0.0284041455962726);
            AbsIrradiance["shaded"][13].Add(2, 0.015139590944474);
            AbsIrradiance["sunlit"][13].Add(1, 0.0224323916487247);
            AbsIrradiance["shaded"][13].Add(1, 0.0137231014261509);
            AbsIrradiance["sunlit"][13].Add(0, 0.0176696480460903);
            AbsIrradiance["shaded"][13].Add(0, 0.0121068690717766);
            AbsIrradiance["sunlit"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][14].Add(5, 0.0813478511411054);
            AbsIrradiance["shaded"][14].Add(5, 0.00909002530944089);
            AbsIrradiance["sunlit"][14].Add(4, 0.048068455355944);
            AbsIrradiance["shaded"][14].Add(4, 0.0205412459524547);
            AbsIrradiance["sunlit"][14].Add(3, 0.0196616433271236);
            AbsIrradiance["shaded"][14].Add(3, 0.0158019097822726);
            AbsIrradiance["sunlit"][14].Add(2, 0.00733117843140913);
            AbsIrradiance["shaded"][14].Add(2, 0.00796629172304415);
            AbsIrradiance["sunlit"][14].Add(1, 0.00545677579727709);
            AbsIrradiance["shaded"][14].Add(1, 0.0070223329688243);
            AbsIrradiance["sunlit"][14].Add(0, 0.00407869529444773);
            AbsIrradiance["shaded"][14].Add(0, 0.00604644596296277);
            AbsIrradiance["sunlit"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][15].Add(5, 0);
            AbsIrradiance["shaded"][15].Add(5, 0);
            AbsIrradiance["sunlit"][15].Add(4, 0);
            AbsIrradiance["shaded"][15].Add(4, 0);
            AbsIrradiance["sunlit"][15].Add(3, 0);
            AbsIrradiance["shaded"][15].Add(3, 0);
            AbsIrradiance["sunlit"][15].Add(2, 0);
            AbsIrradiance["shaded"][15].Add(2, 0);
            AbsIrradiance["sunlit"][15].Add(1, 0);
            AbsIrradiance["shaded"][15].Add(1, 0);
            AbsIrradiance["sunlit"][15].Add(0, 0);
            AbsIrradiance["shaded"][15].Add(0, 0);
            AbsIrradiance["sunlit"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][16].Add(5, 0);
            AbsIrradiance["shaded"][16].Add(5, 0);
            AbsIrradiance["sunlit"][16].Add(4, 0);
            AbsIrradiance["shaded"][16].Add(4, 0);
            AbsIrradiance["sunlit"][16].Add(3, 0);
            AbsIrradiance["shaded"][16].Add(3, 0);
            AbsIrradiance["sunlit"][16].Add(2, 0);
            AbsIrradiance["shaded"][16].Add(2, 0);
            AbsIrradiance["sunlit"][16].Add(1, 0);
            AbsIrradiance["shaded"][16].Add(1, 0);
            AbsIrradiance["sunlit"][16].Add(0, 0);
            AbsIrradiance["shaded"][16].Add(0, 0);
            AbsIrradiance["sunlit"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][17].Add(5, 7.96067214318395E-18);
            AbsIrradiance["shaded"][17].Add(5, 4.52232249705186E-18);
            AbsIrradiance["sunlit"][17].Add(4, 4.64190264772042E-60);
            AbsIrradiance["shaded"][17].Add(4, 1.84643025973736E-18);
            AbsIrradiance["sunlit"][17].Add(3, 9.91695220137849E-104);
            AbsIrradiance["shaded"][17].Add(3, 1.03208083332417E-18);
            AbsIrradiance["sunlit"][17].Add(2, 7.63587716599457E-133);
            AbsIrradiance["shaded"][17].Add(2, 4.64761539116191E-19);
            AbsIrradiance["sunlit"][17].Add(1, 2.11887788689245E-147);
            AbsIrradiance["shaded"][17].Add(1, 3.88845977352545E-19);
            AbsIrradiance["sunlit"][17].Add(0, 2.11690499301716E-160);
            AbsIrradiance["shaded"][17].Add(0, 3.2235952655878E-19);
            AbsIrradiance["sunlit"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][18].Add(5, 0);
            AbsIrradiance["shaded"][18].Add(5, 0);
            AbsIrradiance["sunlit"][18].Add(4, 0);
            AbsIrradiance["shaded"][18].Add(4, 0);
            AbsIrradiance["sunlit"][18].Add(3, 0);
            AbsIrradiance["shaded"][18].Add(3, 0);
            AbsIrradiance["sunlit"][18].Add(2, 0);
            AbsIrradiance["shaded"][18].Add(2, 0);
            AbsIrradiance["sunlit"][18].Add(1, 0);
            AbsIrradiance["shaded"][18].Add(1, 0);
            AbsIrradiance["sunlit"][18].Add(0, 0);
            AbsIrradiance["shaded"][18].Add(0, 0);
            AbsIrradiance["sunlit"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][19].Add(5, 0);
            AbsIrradiance["shaded"][19].Add(5, 0);
            AbsIrradiance["sunlit"][19].Add(4, 0);
            AbsIrradiance["shaded"][19].Add(4, 0);
            AbsIrradiance["sunlit"][19].Add(3, 0);
            AbsIrradiance["shaded"][19].Add(3, 0);
            AbsIrradiance["sunlit"][19].Add(2, 0);
            AbsIrradiance["shaded"][19].Add(2, 0);
            AbsIrradiance["sunlit"][19].Add(1, 0);
            AbsIrradiance["shaded"][19].Add(1, 0);
            AbsIrradiance["sunlit"][19].Add(0, 0);
            AbsIrradiance["shaded"][19].Add(0, 0);
            AbsIrradiance["sunlit"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][20].Add(5, 0);
            AbsIrradiance["shaded"][20].Add(5, 0);
            AbsIrradiance["sunlit"][20].Add(4, 0);
            AbsIrradiance["shaded"][20].Add(4, 0);
            AbsIrradiance["sunlit"][20].Add(3, 0);
            AbsIrradiance["shaded"][20].Add(3, 0);
            AbsIrradiance["sunlit"][20].Add(2, 0);
            AbsIrradiance["shaded"][20].Add(2, 0);
            AbsIrradiance["sunlit"][20].Add(1, 0);
            AbsIrradiance["shaded"][20].Add(1, 0);
            AbsIrradiance["sunlit"][20].Add(0, 0);
            AbsIrradiance["shaded"][20].Add(0, 0);
            AbsIrradiance["sunlit"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][21].Add(5, 0);
            AbsIrradiance["shaded"][21].Add(5, 0);
            AbsIrradiance["sunlit"][21].Add(4, 0);
            AbsIrradiance["shaded"][21].Add(4, 0);
            AbsIrradiance["sunlit"][21].Add(3, 0);
            AbsIrradiance["shaded"][21].Add(3, 0);
            AbsIrradiance["sunlit"][21].Add(2, 0);
            AbsIrradiance["shaded"][21].Add(2, 0);
            AbsIrradiance["sunlit"][21].Add(1, 0);
            AbsIrradiance["shaded"][21].Add(1, 0);
            AbsIrradiance["sunlit"][21].Add(0, 0);
            AbsIrradiance["shaded"][21].Add(0, 0);
            AbsIrradiance["sunlit"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][22].Add(5, 0);
            AbsIrradiance["shaded"][22].Add(5, 0);
            AbsIrradiance["sunlit"][22].Add(4, 0);
            AbsIrradiance["shaded"][22].Add(4, 0);
            AbsIrradiance["sunlit"][22].Add(3, 0);
            AbsIrradiance["shaded"][22].Add(3, 0);
            AbsIrradiance["sunlit"][22].Add(2, 0);
            AbsIrradiance["shaded"][22].Add(2, 0);
            AbsIrradiance["sunlit"][22].Add(1, 0);
            AbsIrradiance["shaded"][22].Add(1, 0);
            AbsIrradiance["sunlit"][22].Add(0, 0);
            AbsIrradiance["shaded"][22].Add(0, 0);
            AbsIrradiance["sunlit"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][23].Add(5, 0);
            AbsIrradiance["shaded"][23].Add(5, 0);
            AbsIrradiance["sunlit"][23].Add(4, 0);
            AbsIrradiance["shaded"][23].Add(4, 0);
            AbsIrradiance["sunlit"][23].Add(3, 0);
            AbsIrradiance["shaded"][23].Add(3, 0);
            AbsIrradiance["sunlit"][23].Add(2, 0);
            AbsIrradiance["shaded"][23].Add(2, 0);
            AbsIrradiance["sunlit"][23].Add(1, 0);
            AbsIrradiance["shaded"][23].Add(1, 0);
            AbsIrradiance["sunlit"][23].Add(0, 0);
            AbsIrradiance["shaded"][23].Add(0, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], 2* AbsIrradiance[iss][h][l]/100);
                       
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers1UseSunShade1Ellipse()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.439671187185625, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.234, 0.0));
            gAI.Add(2, Tuple.Create(0.117, 0.0));
            gAI.Add(1, Tuple.Create(0.0918898298749683, 0.0));
            gAI.Add(0, Tuple.Create(0.0672201728719751, 0.0116242740125777));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.47296172140673;
            state.FLN = 9.05867274356201;
            state.cumulTT = 479.822397156231;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = -999;

            #endregion

            #region Parameters

            strategy.useSunShade = 1;
            strategy.useHourly = 1;
            strategy.useLayered = 1;
            strategy.useSphericalLeafDistrib = 0;
            strategy.useDiffDirIrradiance = 0;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance.Add("shaded", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["sunlit"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][0].Add(5, 0);
            AbsIrradiance["shaded"][0].Add(5, 0);
            AbsIrradiance["sunlit"][0].Add(4, 0);
            AbsIrradiance["shaded"][0].Add(4, 0);
            AbsIrradiance["sunlit"][0].Add(3, 0);
            AbsIrradiance["shaded"][0].Add(3, 0);
            AbsIrradiance["sunlit"][0].Add(2, 0);
            AbsIrradiance["shaded"][0].Add(2, 0);
            AbsIrradiance["sunlit"][0].Add(1, 0);
            AbsIrradiance["shaded"][0].Add(1, 0);
            AbsIrradiance["sunlit"][0].Add(0, 0);
            AbsIrradiance["shaded"][0].Add(0, 0);
            AbsIrradiance["sunlit"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][1].Add(5, 0);
            AbsIrradiance["shaded"][1].Add(5, 0);
            AbsIrradiance["sunlit"][1].Add(4, 0);
            AbsIrradiance["shaded"][1].Add(4, 0);
            AbsIrradiance["sunlit"][1].Add(3, 0);
            AbsIrradiance["shaded"][1].Add(3, 0);
            AbsIrradiance["sunlit"][1].Add(2, 0);
            AbsIrradiance["shaded"][1].Add(2, 0);
            AbsIrradiance["sunlit"][1].Add(1, 0);
            AbsIrradiance["shaded"][1].Add(1, 0);
            AbsIrradiance["sunlit"][1].Add(0, 0);
            AbsIrradiance["shaded"][1].Add(0, 0);
            AbsIrradiance["sunlit"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][2].Add(5, 0);
            AbsIrradiance["shaded"][2].Add(5, 0);
            AbsIrradiance["sunlit"][2].Add(4, 0);
            AbsIrradiance["shaded"][2].Add(4, 0);
            AbsIrradiance["sunlit"][2].Add(3, 0);
            AbsIrradiance["shaded"][2].Add(3, 0);
            AbsIrradiance["sunlit"][2].Add(2, 0);
            AbsIrradiance["shaded"][2].Add(2, 0);
            AbsIrradiance["sunlit"][2].Add(1, 0);
            AbsIrradiance["shaded"][2].Add(1, 0);
            AbsIrradiance["sunlit"][2].Add(0, 0);
            AbsIrradiance["shaded"][2].Add(0, 0);
            AbsIrradiance["sunlit"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][3].Add(5, 0);
            AbsIrradiance["shaded"][3].Add(5, 0);
            AbsIrradiance["sunlit"][3].Add(4, 0);
            AbsIrradiance["shaded"][3].Add(4, 0);
            AbsIrradiance["sunlit"][3].Add(3, 0);
            AbsIrradiance["shaded"][3].Add(3, 0);
            AbsIrradiance["sunlit"][3].Add(2, 0);
            AbsIrradiance["shaded"][3].Add(2, 0);
            AbsIrradiance["sunlit"][3].Add(1, 0);
            AbsIrradiance["shaded"][3].Add(1, 0);
            AbsIrradiance["sunlit"][3].Add(0, 0);
            AbsIrradiance["shaded"][3].Add(0, 0);
            AbsIrradiance["sunlit"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][4].Add(5, 0);
            AbsIrradiance["shaded"][4].Add(5, 0);
            AbsIrradiance["sunlit"][4].Add(4, 0);
            AbsIrradiance["shaded"][4].Add(4, 0);
            AbsIrradiance["sunlit"][4].Add(3, 0);
            AbsIrradiance["shaded"][4].Add(3, 0);
            AbsIrradiance["sunlit"][4].Add(2, 0);
            AbsIrradiance["shaded"][4].Add(2, 0);
            AbsIrradiance["sunlit"][4].Add(1, 0);
            AbsIrradiance["shaded"][4].Add(1, 0);
            AbsIrradiance["sunlit"][4].Add(0, 0);
            AbsIrradiance["shaded"][4].Add(0, 0);
            AbsIrradiance["sunlit"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][5].Add(5, 0);
            AbsIrradiance["shaded"][5].Add(5, 0);
            AbsIrradiance["sunlit"][5].Add(4, 0);
            AbsIrradiance["shaded"][5].Add(4, 0);
            AbsIrradiance["sunlit"][5].Add(3, 0);
            AbsIrradiance["shaded"][5].Add(3, 0);
            AbsIrradiance["sunlit"][5].Add(2, 0);
            AbsIrradiance["shaded"][5].Add(2, 0);
            AbsIrradiance["sunlit"][5].Add(1, 0);
            AbsIrradiance["shaded"][5].Add(1, 0);
            AbsIrradiance["sunlit"][5].Add(0, 0);
            AbsIrradiance["shaded"][5].Add(0, 0);
            AbsIrradiance["sunlit"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][6].Add(5, 0);
            AbsIrradiance["shaded"][6].Add(5, 0);
            AbsIrradiance["sunlit"][6].Add(4, 0);
            AbsIrradiance["shaded"][6].Add(4, 0);
            AbsIrradiance["sunlit"][6].Add(3, 0);
            AbsIrradiance["shaded"][6].Add(3, 0);
            AbsIrradiance["sunlit"][6].Add(2, 0);
            AbsIrradiance["shaded"][6].Add(2, 0);
            AbsIrradiance["sunlit"][6].Add(1, 0);
            AbsIrradiance["shaded"][6].Add(1, 0);
            AbsIrradiance["sunlit"][6].Add(0, 0);
            AbsIrradiance["shaded"][6].Add(0, 0);
            AbsIrradiance["sunlit"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][7].Add(5, 0.0816526827135202);
            AbsIrradiance["shaded"][7].Add(5, 0.0118750855890748);
            AbsIrradiance["sunlit"][7].Add(4, 0.0344079875106149);
            AbsIrradiance["shaded"][7].Add(4, 0.0183027201069106);
            AbsIrradiance["sunlit"][7].Add(3, 0.01424348941558);
            AbsIrradiance["shaded"][7].Add(3, 0.0131833295684821);
            AbsIrradiance["sunlit"][7].Add(2, 0.00535548868120433);
            AbsIrradiance["shaded"][7].Add(2, 0.00651249423770445);
            AbsIrradiance["sunlit"][7].Add(1, 0.003559229483231);
            AbsIrradiance["shaded"][7].Add(1, 0.00501093548195281);
            AbsIrradiance["sunlit"][7].Add(0, 0.00266587120353474);
            AbsIrradiance["shaded"][7].Add(0, 0.00420557296635894);
            AbsIrradiance["sunlit"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][8].Add(5, 0.235077329758028);
            AbsIrradiance["shaded"][8].Add(5, 0.0222100938900431);
            AbsIrradiance["sunlit"][8].Add(4, 0.119002468540204);
            AbsIrradiance["shaded"][8].Add(4, 0.0368626424259266);
            AbsIrradiance["sunlit"][8].Add(3, 0.0566948908396591);
            AbsIrradiance["shaded"][8].Add(3, 0.0283262335207958);
            AbsIrradiance["sunlit"][8].Add(2, 0.0232004650844688);
            AbsIrradiance["shaded"][8].Add(2, 0.01455098000851);
            AbsIrradiance["sunlit"][8].Add(1, 0.0161980801491242);
            AbsIrradiance["shaded"][8].Add(1, 0.0114556877884309);
            AbsIrradiance["sunlit"][8].Add(0, 0.0126288735410942);
            AbsIrradiance["shaded"][8].Add(0, 0.00979363905204717);
            AbsIrradiance["sunlit"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][9].Add(5, 0.385240516241602);
            AbsIrradiance["shaded"][9].Add(5, 0.0243054549114844);
            AbsIrradiance["sunlit"][9].Add(4, 0.212863012413823);
            AbsIrradiance["shaded"][9].Add(4, 0.0427264965553431);
            AbsIrradiance["sunlit"][9].Add(3, 0.108028463819989);
            AbsIrradiance["shaded"][9].Add(3, 0.0343725524436106);
            AbsIrradiance["sunlit"][9].Add(2, 0.0458755157064806);
            AbsIrradiance["shaded"][9].Add(2, 0.0181379544299689);
            AbsIrradiance["sunlit"][9].Add(1, 0.0327213678680624);
            AbsIrradiance["shaded"][9].Add(1, 0.0145050990806403);
            AbsIrradiance["sunlit"][9].Add(0, 0.0259554272986693);
            AbsIrradiance["shaded"][9].Add(0, 0.0125576696828882);
            AbsIrradiance["sunlit"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][10].Add(5, 0.473860058427926);
            AbsIrradiance["shaded"][10].Add(5, 0.0262223980818228);
            AbsIrradiance["sunlit"][10].Add(4, 0.269252963512339);
            AbsIrradiance["shaded"][10].Add(4, 0.0469967354592998);
            AbsIrradiance["sunlit"][10].Add(3, 0.139477087305902);
            AbsIrradiance["shaded"][10].Add(3, 0.0384158848815353);
            AbsIrradiance["sunlit"][10].Add(2, 0.0599537889599732);
            AbsIrradiance["shaded"][10].Add(2, 0.0204664063943797);
            AbsIrradiance["sunlit"][10].Add(1, 0.0430657496939681);
            AbsIrradiance["shaded"][10].Add(1, 0.016460030168847);
            AbsIrradiance["sunlit"][10].Add(0, 0.0343567954863074);
            AbsIrradiance["shaded"][10].Add(0, 0.0143155651518952);
            AbsIrradiance["sunlit"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][11].Add(5, 0.478694731901356);
            AbsIrradiance["shaded"][11].Add(5, 0.0264169234963154);
            AbsIrradiance["sunlit"][11].Add(4, 0.272258311633355);
            AbsIrradiance["shaded"][11].Add(4, 0.0473614482816798);
            AbsIrradiance["sunlit"][11].Add(3, 0.141138355189074);
            AbsIrradiance["shaded"][11].Add(3, 0.0387277784562418);
            AbsIrradiance["sunlit"][11].Add(2, 0.0606953564970492);
            AbsIrradiance["shaded"][11].Add(2, 0.0206375207440494);
            AbsIrradiance["sunlit"][11].Add(1, 0.043610117600164);
            AbsIrradiance["shaded"][11].Add(1, 0.0166001448802994);
            AbsIrradiance["sunlit"][11].Add(0, 0.034798715641135);
            AbsIrradiance["shaded"][11].Add(0, 0.0144392422267077);
            AbsIrradiance["sunlit"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][12].Add(5, 0.398714467157161);
            AbsIrradiance["shaded"][12].Add(5, 0.0240655533115821);
            AbsIrradiance["sunlit"][12].Add(4, 0.221868406440726);
            AbsIrradiance["shaded"][12].Add(4, 0.0425946872223835);
            AbsIrradiance["sunlit"][12].Add(3, 0.113149340597486);
            AbsIrradiance["shaded"][12].Add(3, 0.0344433232670026);
            AbsIrradiance["sunlit"][12].Add(2, 0.0481844595096105);
            AbsIrradiance["shaded"][12].Add(2, 0.0182283863005984);
            AbsIrradiance["sunlit"][12].Add(1, 0.0344230071577763);
            AbsIrradiance["shaded"][12].Add(1, 0.0146017965373247);
            AbsIrradiance["sunlit"][12].Add(0, 0.0273400580195261);
            AbsIrradiance["shaded"][12].Add(0, 0.0126581837897048);
            AbsIrradiance["sunlit"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][13].Add(5, 0.252916982058523);
            AbsIrradiance["shaded"][13].Add(5, 0.0228613471593426);
            AbsIrradiance["sunlit"][13].Add(4, 0.129599676116385);
            AbsIrradiance["shaded"][13].Add(4, 0.0381797505314464);
            AbsIrradiance["sunlit"][13].Add(3, 0.0623029210055788);
            AbsIrradiance["shaded"][13].Add(3, 0.0294901961181522);
            AbsIrradiance["sunlit"][13].Add(2, 0.025632421992693);
            AbsIrradiance["shaded"][13].Add(2, 0.0151958253997195);
            AbsIrradiance["sunlit"][13].Add(1, 0.0179518209163855);
            AbsIrradiance["shaded"][13].Add(1, 0.0119851559732137);
            AbsIrradiance["sunlit"][13].Add(0, 0.01403155949884);
            AbsIrradiance["shaded"][13].Add(0, 0.0102613687239434);
            AbsIrradiance["sunlit"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][14].Add(5, 0.0961739211604031);
            AbsIrradiance["shaded"][14].Add(5, 0.0133729180068897);
            AbsIrradiance["sunlit"][14].Add(4, 0.0417646441075075);
            AbsIrradiance["shaded"][14].Add(4, 0.0208299894773047);
            AbsIrradiance["sunlit"][14].Add(3, 0.017700344379343);
            AbsIrradiance["shaded"][14].Add(3, 0.0151503005371919);
            AbsIrradiance["sunlit"][14].Add(2, 0.00675082964621863);
            AbsIrradiance["shaded"][14].Add(2, 0.00752853704674355);
            AbsIrradiance["sunlit"][14].Add(1, 0.00452395940968004);
            AbsIrradiance["shaded"][14].Add(1, 0.00581270958972126);
            AbsIrradiance["sunlit"][14].Add(0, 0.00341143769783551);
            AbsIrradiance["shaded"][14].Add(0, 0.00489196719726631);
            AbsIrradiance["sunlit"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][15].Add(5, 0);
            AbsIrradiance["shaded"][15].Add(5, 0);
            AbsIrradiance["sunlit"][15].Add(4, 0);
            AbsIrradiance["shaded"][15].Add(4, 0);
            AbsIrradiance["sunlit"][15].Add(3, 0);
            AbsIrradiance["shaded"][15].Add(3, 0);
            AbsIrradiance["sunlit"][15].Add(2, 0);
            AbsIrradiance["shaded"][15].Add(2, 0);
            AbsIrradiance["sunlit"][15].Add(1, 0);
            AbsIrradiance["shaded"][15].Add(1, 0);
            AbsIrradiance["sunlit"][15].Add(0, 0);
            AbsIrradiance["shaded"][15].Add(0, 0);
            AbsIrradiance["sunlit"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][16].Add(5, 0);
            AbsIrradiance["shaded"][16].Add(5, 0);
            AbsIrradiance["sunlit"][16].Add(4, 0);
            AbsIrradiance["shaded"][16].Add(4, 0);
            AbsIrradiance["sunlit"][16].Add(3, 0);
            AbsIrradiance["shaded"][16].Add(3, 0);
            AbsIrradiance["sunlit"][16].Add(2, 0);
            AbsIrradiance["shaded"][16].Add(2, 0);
            AbsIrradiance["sunlit"][16].Add(1, 0);
            AbsIrradiance["shaded"][16].Add(1, 0);
            AbsIrradiance["sunlit"][16].Add(0, 0);
            AbsIrradiance["shaded"][16].Add(0, 0);
            AbsIrradiance["sunlit"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][17].Add(5, 7.94012645948283E-18);
            AbsIrradiance["shaded"][17].Add(5, 5.22511059233436E-18);
            AbsIrradiance["sunlit"][17].Add(4, 1.30043002607303E-208);
            AbsIrradiance["shaded"][17].Add(4, 1.78776038006744E-18);
            AbsIrradiance["sunlit"][17].Add(3, 0);
            AbsIrradiance["shaded"][17].Add(3, 9.89319512824421E-19);
            AbsIrradiance["sunlit"][17].Add(2, 0);
            AbsIrradiance["shaded"][17].Add(2, 4.42925518460687E-19);
            AbsIrradiance["sunlit"][17].Add(1, 0);
            AbsIrradiance["shaded"][17].Add(1, 3.25990519160237E-19);
            AbsIrradiance["sunlit"][17].Add(0, 0);
            AbsIrradiance["shaded"][17].Add(0, 2.65325627707305E-19);
            AbsIrradiance["sunlit"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][18].Add(5, 0);
            AbsIrradiance["shaded"][18].Add(5, 0);
            AbsIrradiance["sunlit"][18].Add(4, 0);
            AbsIrradiance["shaded"][18].Add(4, 0);
            AbsIrradiance["sunlit"][18].Add(3, 0);
            AbsIrradiance["shaded"][18].Add(3, 0);
            AbsIrradiance["sunlit"][18].Add(2, 0);
            AbsIrradiance["shaded"][18].Add(2, 0);
            AbsIrradiance["sunlit"][18].Add(1, 0);
            AbsIrradiance["shaded"][18].Add(1, 0);
            AbsIrradiance["sunlit"][18].Add(0, 0);
            AbsIrradiance["shaded"][18].Add(0, 0);
            AbsIrradiance["sunlit"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][19].Add(5, 0);
            AbsIrradiance["shaded"][19].Add(5, 0);
            AbsIrradiance["sunlit"][19].Add(4, 0);
            AbsIrradiance["shaded"][19].Add(4, 0);
            AbsIrradiance["sunlit"][19].Add(3, 0);
            AbsIrradiance["shaded"][19].Add(3, 0);
            AbsIrradiance["sunlit"][19].Add(2, 0);
            AbsIrradiance["shaded"][19].Add(2, 0);
            AbsIrradiance["sunlit"][19].Add(1, 0);
            AbsIrradiance["shaded"][19].Add(1, 0);
            AbsIrradiance["sunlit"][19].Add(0, 0);
            AbsIrradiance["shaded"][19].Add(0, 0);
            AbsIrradiance["sunlit"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][20].Add(5, 0);
            AbsIrradiance["shaded"][20].Add(5, 0);
            AbsIrradiance["sunlit"][20].Add(4, 0);
            AbsIrradiance["shaded"][20].Add(4, 0);
            AbsIrradiance["sunlit"][20].Add(3, 0);
            AbsIrradiance["shaded"][20].Add(3, 0);
            AbsIrradiance["sunlit"][20].Add(2, 0);
            AbsIrradiance["shaded"][20].Add(2, 0);
            AbsIrradiance["sunlit"][20].Add(1, 0);
            AbsIrradiance["shaded"][20].Add(1, 0);
            AbsIrradiance["sunlit"][20].Add(0, 0);
            AbsIrradiance["shaded"][20].Add(0, 0);
            AbsIrradiance["sunlit"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][21].Add(5, 0);
            AbsIrradiance["shaded"][21].Add(5, 0);
            AbsIrradiance["sunlit"][21].Add(4, 0);
            AbsIrradiance["shaded"][21].Add(4, 0);
            AbsIrradiance["sunlit"][21].Add(3, 0);
            AbsIrradiance["shaded"][21].Add(3, 0);
            AbsIrradiance["sunlit"][21].Add(2, 0);
            AbsIrradiance["shaded"][21].Add(2, 0);
            AbsIrradiance["sunlit"][21].Add(1, 0);
            AbsIrradiance["shaded"][21].Add(1, 0);
            AbsIrradiance["sunlit"][21].Add(0, 0);
            AbsIrradiance["shaded"][21].Add(0, 0);
            AbsIrradiance["sunlit"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][22].Add(5, 0);
            AbsIrradiance["shaded"][22].Add(5, 0);
            AbsIrradiance["sunlit"][22].Add(4, 0);
            AbsIrradiance["shaded"][22].Add(4, 0);
            AbsIrradiance["sunlit"][22].Add(3, 0);
            AbsIrradiance["shaded"][22].Add(3, 0);
            AbsIrradiance["sunlit"][22].Add(2, 0);
            AbsIrradiance["shaded"][22].Add(2, 0);
            AbsIrradiance["sunlit"][22].Add(1, 0);
            AbsIrradiance["shaded"][22].Add(1, 0);
            AbsIrradiance["sunlit"][22].Add(0, 0);
            AbsIrradiance["shaded"][22].Add(0, 0);
            AbsIrradiance["sunlit"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][23].Add(5, 0);
            AbsIrradiance["shaded"][23].Add(5, 0);
            AbsIrradiance["sunlit"][23].Add(4, 0);
            AbsIrradiance["shaded"][23].Add(4, 0);
            AbsIrradiance["sunlit"][23].Add(3, 0);
            AbsIrradiance["shaded"][23].Add(3, 0);
            AbsIrradiance["sunlit"][23].Add(2, 0);
            AbsIrradiance["shaded"][23].Add(2, 0);
            AbsIrradiance["sunlit"][23].Add(1, 0);
            AbsIrradiance["shaded"][23].Add(1, 0);
            AbsIrradiance["sunlit"][23].Add(0, 0);
            AbsIrradiance["shaded"][23].Add(0, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], 2 * AbsIrradiance[iss][h][l] / 100);

                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers0UseSunShade1Sphere()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.778694107139603, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.234, 0.0));
            gAI.Add(2, Tuple.Create(0.117, 0.0));
            gAI.Add(1, Tuple.Create(0.0748428856539245, 0.0));
            gAI.Add(0, Tuple.Create(0.0489981381006313, 0.00962797818167481));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.78320434691151;
            state.FLN = 9.13338362106057;
            state.cumulTT = 513.336413037851;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 501.035317789094;

            #endregion

            #region Parameters

            strategy.useSunShade = 1;
            strategy.useHourly = 1;
            strategy.useLayered = 0;
            strategy.useSphericalLeafDistrib = 1;
            strategy.useDiffDirIrradiance = 0;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance.Add("shaded", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["sunlit"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][0].Add(99, 0);
            AbsIrradiance["shaded"][0].Add(99, 0);
            AbsIrradiance["sunlit"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][1].Add(99, 0);
            AbsIrradiance["shaded"][1].Add(99, 0);
            AbsIrradiance["sunlit"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][2].Add(99, 0);
            AbsIrradiance["shaded"][2].Add(99, 0);
            AbsIrradiance["sunlit"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][3].Add(99, 0);
            AbsIrradiance["shaded"][3].Add(99, 0);
            AbsIrradiance["sunlit"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][4].Add(99, 0);
            AbsIrradiance["shaded"][4].Add(99, 0);
            AbsIrradiance["sunlit"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][5].Add(99, 0);
            AbsIrradiance["shaded"][5].Add(99, 0);
            AbsIrradiance["sunlit"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][6].Add(99, 0);
            AbsIrradiance["shaded"][6].Add(99, 0);
            AbsIrradiance["sunlit"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][7].Add(99, 0.146189432635875);
            AbsIrradiance["shaded"][7].Add(99, 0.0774716015492858);
            AbsIrradiance["sunlit"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][8].Add(99, 0.497085281276539);
            AbsIrradiance["shaded"][8].Add(99, 0.160664209677922);
            AbsIrradiance["sunlit"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][9].Add(99, 0.878021515549566);
            AbsIrradiance["shaded"][9].Add(99, 0.185520270834871);
            AbsIrradiance["sunlit"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][10].Add(99, 1.0969904693384);
            AbsIrradiance["shaded"][10].Add(99, 0.19995713221885);
            AbsIrradiance["sunlit"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][11].Add(99, 1.10846601503226);
            AbsIrradiance["shaded"][11].Add(99, 0.201169289827957);
            AbsIrradiance["sunlit"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][12].Add(99, 0.913532525671277);
            AbsIrradiance["shaded"][12].Add(99, 0.184965659201402);
            AbsIrradiance["sunlit"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][13].Add(99, 0.540834759201174);
            AbsIrradiance["shaded"][13].Add(99, 0.166378109168511);
            AbsIrradiance["sunlit"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][14].Add(99, 0.176575512271819);
            AbsIrradiance["shaded"][14].Add(99, 0.0888368471943129);
            AbsIrradiance["sunlit"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][15].Add(99, 0);
            AbsIrradiance["shaded"][15].Add(99, 0);
            AbsIrradiance["sunlit"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][16].Add(99, 0);
            AbsIrradiance["shaded"][16].Add(99, 0);
            AbsIrradiance["sunlit"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][17].Add(99, 7.96005464979314E-18);
            AbsIrradiance["shaded"][17].Add(99, 9.62576779190321E-18);
            AbsIrradiance["sunlit"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][18].Add(99, 0);
            AbsIrradiance["shaded"][18].Add(99, 0);
            AbsIrradiance["sunlit"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][19].Add(99, 0);
            AbsIrradiance["shaded"][19].Add(99, 0);
            AbsIrradiance["sunlit"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][20].Add(99, 0);
            AbsIrradiance["shaded"][20].Add(99, 0);
            AbsIrradiance["sunlit"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][21].Add(99, 0);
            AbsIrradiance["shaded"][21].Add(99, 0);
            AbsIrradiance["sunlit"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][22].Add(99, 0);
            AbsIrradiance["shaded"][22].Add(99, 0);
            AbsIrradiance["sunlit"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][23].Add(99, 0);
            AbsIrradiance["shaded"][23].Add(99, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                       if(AbsIrradiance[iss][h][l]>1E-5) Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], AbsIrradiance[iss][h][l]/100.0);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers0UseSunShade1Ellipse()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.073050603096574, 0.0));
            gAI.Add(4, Tuple.Create(0.141110560409713, 0.0));
            gAI.Add(3, Tuple.Create(2.5E-05, 0.0));
            gAI.Add(2, Tuple.Create(2.5E-05, 0.0));
            gAI.Add(1, Tuple.Create(2.5E-05, 0.0));
            gAI.Add(0, Tuple.Create(2.5E-05, 0.0));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.66718293646358;
            state.FLN = 9.13338362106057;
            state.cumulTT = 499.68821035808;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 499.68821035808;

            #endregion

            #region Parameters

            strategy.useSunShade = 1;
            strategy.useHourly = 1;
            strategy.useLayered = 0;
            strategy.useSphericalLeafDistrib = 0;
            strategy.useDiffDirIrradiance = 0;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("sunlit", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance.Add("shaded", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["sunlit"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][0].Add(99, 0);
            AbsIrradiance["shaded"][0].Add(99, 0);
            AbsIrradiance["sunlit"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][1].Add(99, 0);
            AbsIrradiance["shaded"][1].Add(99, 0);
            AbsIrradiance["sunlit"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][2].Add(99, 0);
            AbsIrradiance["shaded"][2].Add(99, 0);
            AbsIrradiance["sunlit"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][3].Add(99, 0);
            AbsIrradiance["shaded"][3].Add(99, 0);
            AbsIrradiance["sunlit"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][4].Add(99, 0);
            AbsIrradiance["shaded"][4].Add(99, 0);
            AbsIrradiance["sunlit"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][5].Add(99, 0);
            AbsIrradiance["shaded"][5].Add(99, 0);
            AbsIrradiance["sunlit"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][6].Add(99, 0);
            AbsIrradiance["shaded"][6].Add(99, 0);
            AbsIrradiance["sunlit"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][7].Add(99, 0.0483098466591087);
            AbsIrradiance["shaded"][7].Add(99, 0.00351760937453978);
            AbsIrradiance["sunlit"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][8].Add(99, 0.132959271537345);
            AbsIrradiance["shaded"][8].Add(99, 0.00637079759912672);
            AbsIrradiance["sunlit"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][9].Add(99, 0.211080342529756);
            AbsIrradiance["shaded"][9].Add(99, 0.00672947934506355);
            AbsIrradiance["sunlit"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][10].Add(99, 0.257177633356993);
            AbsIrradiance["shaded"][10].Add(99, 0.00717409643324671);
            AbsIrradiance["sunlit"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][11].Add(99, 0.259742908610651);
            AbsIrradiance["shaded"][11].Add(99, 0.00722645006349973);
            AbsIrradiance["sunlit"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][12].Add(99, 0.217796603782157);
            AbsIrradiance["shaded"][12].Add(99, 0.00663132392896375);
            AbsIrradiance["sunlit"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][13].Add(99, 0.142503558521561);
            AbsIrradiance["shaded"][13].Add(99, 0.00653560804741667);
            AbsIrradiance["sunlit"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][14].Add(99, 0.0565585259116466);
            AbsIrradiance["shaded"][14].Add(99, 0.00394713773245224);
            AbsIrradiance["sunlit"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][15].Add(99, 0);
            AbsIrradiance["shaded"][15].Add(99, 0);
            AbsIrradiance["sunlit"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][16].Add(99, 0);
            AbsIrradiance["shaded"][16].Add(99, 0);
            AbsIrradiance["sunlit"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][17].Add(99, 7.94080893595015E-18);
            AbsIrradiance["shaded"][17].Add(99, 3.97106559746798E-18);
            AbsIrradiance["sunlit"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][18].Add(99, 0);
            AbsIrradiance["shaded"][18].Add(99, 0);
            AbsIrradiance["sunlit"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][19].Add(99, 0);
            AbsIrradiance["shaded"][19].Add(99, 0);
            AbsIrradiance["sunlit"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][20].Add(99, 0);
            AbsIrradiance["shaded"][20].Add(99, 0);
            AbsIrradiance["sunlit"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][21].Add(99, 0);
            AbsIrradiance["shaded"][21].Add(99, 0);
            AbsIrradiance["sunlit"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][22].Add(99, 0);
            AbsIrradiance["shaded"][22].Add(99, 0);
            AbsIrradiance["sunlit"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["shaded"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["sunlit"][23].Add(99, 0);
            AbsIrradiance["shaded"][23].Add(99, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        if (AbsIrradiance[iss][h][l] > 1E-5) Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], AbsIrradiance[iss][h][l] / 100.0);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers0UseDirDiff1Sphere()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(6, Tuple.Create(0.146859435555601, 0.0));
            gAI.Add(5, Tuple.Create(0.96433712591557, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.232341591110455, 0.0));
            gAI.Add(2, Tuple.Create(0.0991766421707466, 0.0));
            gAI.Add(1, Tuple.Create(0.0564805972791465, 0.0));
            gAI.Add(0, Tuple.Create(0.0267174874659243, 0.00412278727317234));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 6.00057815935169;
            state.FLN = 9.20561851236093;
            state.cumulTT = 533.331597474178;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 498.3798889621;

            #endregion

            #region Parameters

            strategy.useSunShade = 0;
            strategy.useHourly = 1;
            strategy.useLayered = 0;
            strategy.useSphericalLeafDistrib = 1;
            strategy.useDiffDirIrradiance = 1;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["global"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["global"][0].Add(99, 0);
            AbsIrradiance["global"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["global"][1].Add(99, 0);
            AbsIrradiance["global"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["global"][2].Add(99, 0);
            AbsIrradiance["global"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["global"][3].Add(99, 0);
            AbsIrradiance["global"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["global"][4].Add(99, 0);
            AbsIrradiance["global"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["global"][5].Add(99, 0);
            AbsIrradiance["global"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["global"][6].Add(99, 0);
            AbsIrradiance["global"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["global"][7].Add(99, 0.200776462542629);
            AbsIrradiance["global"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["global"][8].Add(99, 0.619840267356524);
            AbsIrradiance["global"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["global"][9].Add(99, 1.06625379699245);
            AbsIrradiance["global"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["global"][10].Add(99, 1.32190067731253);
            AbsIrradiance["global"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["global"][11].Add(99, 1.33507402281006);
            AbsIrradiance["global"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["global"][12].Add(99, 1.10871528495039);
            AbsIrradiance["global"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["global"][13].Add(99, 0.670775278481583);
            AbsIrradiance["global"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["global"][14].Add(99, 0.238879442348854);
            AbsIrradiance["global"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["global"][15].Add(99, 0);
            AbsIrradiance["global"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["global"][16].Add(99, 0);
            AbsIrradiance["global"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["global"][17].Add(99, 1.5351206484136E-17);
            AbsIrradiance["global"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["global"][18].Add(99, 0);
            AbsIrradiance["global"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["global"][19].Add(99, 0);
            AbsIrradiance["global"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["global"][20].Add(99, 0);
            AbsIrradiance["global"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["global"][21].Add(99, 0);
            AbsIrradiance["global"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["global"][22].Add(99, 0);
            AbsIrradiance["global"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["global"][23].Add(99, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], AbsIrradiance[iss][h][l]/100.0);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers0UseDirDiff1Ellipse()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.958863004152806, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.23022311296544, 0.0));
            gAI.Add(2, Tuple.Create(0.0991726164073892, 0.0));
            gAI.Add(1, Tuple.Create(0.056380122964859, 0.0));
            gAI.Add(0, Tuple.Create(0.0269607322301787, 0.00416430062932502));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.95967283350744;
            state.FLN = 9.20561851236093;
            state.cumulTT = 530.413029384819;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 503.033895565173;

            #endregion

            #region Parameters

            strategy.useSunShade = 0;
            strategy.useHourly = 1;
            strategy.useLayered = 0;
            strategy.useSphericalLeafDistrib = 0;
            strategy.useDiffDirIrradiance = 1;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["global"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["global"][0].Add(99, 0);
            AbsIrradiance["global"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["global"][1].Add(99, 0);
            AbsIrradiance["global"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["global"][2].Add(99, 0);
            AbsIrradiance["global"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["global"][3].Add(99, 0);
            AbsIrradiance["global"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["global"][4].Add(99, 0);
            AbsIrradiance["global"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["global"][5].Add(99, 0);
            AbsIrradiance["global"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["global"][6].Add(99, 0);
            AbsIrradiance["global"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["global"][7].Add(99, 0.194690180940446);
            AbsIrradiance["global"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["global"][8].Add(99, 0.594723613809497);
            AbsIrradiance["global"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["global"][9].Add(99, 1.00772654167726);
            AbsIrradiance["global"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["global"][10].Add(99, 1.23359876462628);
            AbsIrradiance["global"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["global"][11].Add(99, 1.24497234763692);
            AbsIrradiance["global"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["global"][12].Add(99, 1.04604614771524);
            AbsIrradiance["global"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["global"][13].Add(99, 0.642652611516827);
            AbsIrradiance["global"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["global"][14].Add(99, 0.231381976415873);
            AbsIrradiance["global"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["global"][15].Add(99, 0);
            AbsIrradiance["global"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["global"][16].Add(99, 0);
            AbsIrradiance["global"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["global"][17].Add(99, 1.50398969232301E-17);
            AbsIrradiance["global"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["global"][18].Add(99, 0);
            AbsIrradiance["global"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["global"][19].Add(99, 0);
            AbsIrradiance["global"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["global"][20].Add(99, 0);
            AbsIrradiance["global"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["global"][21].Add(99, 0);
            AbsIrradiance["global"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["global"][22].Add(99, 0);
            AbsIrradiance["global"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["global"][23].Add(99, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], AbsIrradiance[iss][h][l] / 100.0);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers1UseDirDiff1Sphere()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.811922306727478, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.234, 0.0));
            gAI.Add(2, Tuple.Create(0.109765866665926, 0.0));
            gAI.Add(1, Tuple.Create(0.0682477522396878, 0.0));
            gAI.Add(0, Tuple.Create(0.0383809734658297, 0.00794559895410965));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.83729579323919;
            state.FLN = 9.15775145560249;
            state.cumulTT = 521.52135602669;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 501.799129779787;

            #endregion

            #region Parameters

            strategy.useSunShade = 0;
            strategy.useHourly = 1;
            strategy.useLayered = 1;
            strategy.useSphericalLeafDistrib = 1;
            strategy.useDiffDirIrradiance = 1;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["global"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["global"][0].Add(5, 0);
            AbsIrradiance["global"][0].Add(4, 0);
            AbsIrradiance["global"][0].Add(3, 0);
            AbsIrradiance["global"][0].Add(2, 0);
            AbsIrradiance["global"][0].Add(1, 0);
            AbsIrradiance["global"][0].Add(0, 0);
            AbsIrradiance["global"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["global"][1].Add(5, 0);
            AbsIrradiance["global"][1].Add(4, 0);
            AbsIrradiance["global"][1].Add(3, 0);
            AbsIrradiance["global"][1].Add(2, 0);
            AbsIrradiance["global"][1].Add(1, 0);
            AbsIrradiance["global"][1].Add(0, 0);
            AbsIrradiance["global"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["global"][2].Add(5, 0);
            AbsIrradiance["global"][2].Add(4, 0);
            AbsIrradiance["global"][2].Add(3, 0);
            AbsIrradiance["global"][2].Add(2, 0);
            AbsIrradiance["global"][2].Add(1, 0);
            AbsIrradiance["global"][2].Add(0, 0);
            AbsIrradiance["global"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["global"][3].Add(5, 0);
            AbsIrradiance["global"][3].Add(4, 0);
            AbsIrradiance["global"][3].Add(3, 0);
            AbsIrradiance["global"][3].Add(2, 0);
            AbsIrradiance["global"][3].Add(1, 0);
            AbsIrradiance["global"][3].Add(0, 0);
            AbsIrradiance["global"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["global"][4].Add(5, 0);
            AbsIrradiance["global"][4].Add(4, 0);
            AbsIrradiance["global"][4].Add(3, 0);
            AbsIrradiance["global"][4].Add(2, 0);
            AbsIrradiance["global"][4].Add(1, 0);
            AbsIrradiance["global"][4].Add(0, 0);
            AbsIrradiance["global"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["global"][5].Add(5, 0);
            AbsIrradiance["global"][5].Add(4, 0);
            AbsIrradiance["global"][5].Add(3, 0);
            AbsIrradiance["global"][5].Add(2, 0);
            AbsIrradiance["global"][5].Add(1, 0);
            AbsIrradiance["global"][5].Add(0, 0);
            AbsIrradiance["global"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["global"][6].Add(5, 0);
            AbsIrradiance["global"][6].Add(4, 0);
            AbsIrradiance["global"][6].Add(3, 0);
            AbsIrradiance["global"][6].Add(2, 0);
            AbsIrradiance["global"][6].Add(1, 0);
            AbsIrradiance["global"][6].Add(0, 0);
            AbsIrradiance["global"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["global"][7].Add(5, 0.130844581362076);
            AbsIrradiance["global"][7].Add(4, 0.0310712402977214);
            AbsIrradiance["global"][7].Add(3, 0.0157070286542096);
            AbsIrradiance["global"][7].Add(2, 0.00628906908768922);
            AbsIrradiance["global"][7].Add(1, 0.00360884567346427);
            AbsIrradiance["global"][7].Add(0, 0.00232756806706825);
            AbsIrradiance["global"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["global"][8].Add(5, 0.370378408789363);
            AbsIrradiance["global"][8].Add(4, 0.103789239754782);
            AbsIrradiance["global"][8].Add(3, 0.0561435546922425);
            AbsIrradiance["global"][8].Add(2, 0.0233239215284959);
            AbsIrradiance["global"][8].Add(1, 0.013627759720029);
            AbsIrradiance["global"][8].Add(0, 0.00888944250619047);
            AbsIrradiance["global"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["global"][9].Add(5, 0.607833346585138);
            AbsIrradiance["global"][9].Add(4, 0.183601526925073);
            AbsIrradiance["global"][9].Add(3, 0.102880088424499);
            AbsIrradiance["global"][9].Add(2, 0.0436212037774901);
            AbsIrradiance["global"][9].Add(1, 0.0257531417289436);
            AbsIrradiance["global"][9].Add(0, 0.0169107519598987);
            AbsIrradiance["global"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["global"][10].Add(5, 0.737831952526408);
            AbsIrradiance["global"][10].Add(4, 0.230113567583072);
            AbsIrradiance["global"][10].Add(3, 0.130924435447381);
            AbsIrradiance["global"][10].Add(2, 0.056006066561336);
            AbsIrradiance["global"][10].Add(1, 0.0332146969932332);
            AbsIrradiance["global"][10].Add(0, 0.0218735182492559);
            AbsIrradiance["global"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["global"][11].Add(5, 0.74447830840643);
            AbsIrradiance["global"][11].Add(4, 0.232517505707232);
            AbsIrradiance["global"][11].Add(3, 0.132382319489434);
            AbsIrradiance["global"][11].Add(2, 0.0566521368817157);
            AbsIrradiance["global"][11].Add(1, 0.0336046415530944);
            AbsIrradiance["global"][11].Add(0, 0.0221331773639406);
            AbsIrradiance["global"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["global"][12].Add(5, 0.629609524548385);
            AbsIrradiance["global"][12].Add(4, 0.191289179665807);
            AbsIrradiance["global"][12].Add(3, 0.107486962035314);
            AbsIrradiance["global"][12].Add(2, 0.0456485891538846);
            AbsIrradiance["global"][12].Add(1, 0.0269724359308866);
            AbsIrradiance["global"][12].Add(0, 0.0177208091641758);
            AbsIrradiance["global"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["global"][13].Add(5, 0.39826720016072);
            AbsIrradiance["global"][13].Add(4, 0.112799156189079);
            AbsIrradiance["global"][13].Add(3, 0.0613157290057941);
            AbsIrradiance["global"][13].Add(2, 0.0255439684307497);
            AbsIrradiance["global"][13].Add(1, 0.0149460178417172);
            AbsIrradiance["global"][13].Add(0, 0.00975813946460336);
            AbsIrradiance["global"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["global"][14].Add(5, 0.153555477789402);
            AbsIrradiance["global"][14].Add(4, 0.0375410777869651);
            AbsIrradiance["global"][14].Add(3, 0.0191839960478287);
            AbsIrradiance["global"][14].Add(2, 0.00772433508485463);
            AbsIrradiance["global"][14].Add(1, 0.00444420966487773);
            AbsIrradiance["global"][14].Add(0, 0.00287103108376979);
            AbsIrradiance["global"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["global"][15].Add(5, 0);
            AbsIrradiance["global"][15].Add(4, 0);
            AbsIrradiance["global"][15].Add(3, 0);
            AbsIrradiance["global"][15].Add(2, 0);
            AbsIrradiance["global"][15].Add(1, 0);
            AbsIrradiance["global"][15].Add(0, 0);
            AbsIrradiance["global"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["global"][16].Add(5, 0);
            AbsIrradiance["global"][16].Add(4, 0);
            AbsIrradiance["global"][16].Add(3, 0);
            AbsIrradiance["global"][16].Add(2, 0);
            AbsIrradiance["global"][16].Add(1, 0);
            AbsIrradiance["global"][16].Add(0, 0);
            AbsIrradiance["global"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["global"][17].Add(5, 1.33035412660585E-17);
            AbsIrradiance["global"][17].Add(4, 8.61489388015937E-19);
            AbsIrradiance["global"][17].Add(3, 4.6781642261462E-19);
            AbsIrradiance["global"][17].Add(2, 1.94516574061334E-19);
            AbsIrradiance["global"][17].Add(1, 1.1365479439576E-19);
            AbsIrradiance["global"][17].Add(0, 7.41272469979652E-20);
            AbsIrradiance["global"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["global"][18].Add(5, 0);
            AbsIrradiance["global"][18].Add(4, 0);
            AbsIrradiance["global"][18].Add(3, 0);
            AbsIrradiance["global"][18].Add(2, 0);
            AbsIrradiance["global"][18].Add(1, 0);
            AbsIrradiance["global"][18].Add(0, 0);
            AbsIrradiance["global"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["global"][19].Add(5, 0);
            AbsIrradiance["global"][19].Add(4, 0);
            AbsIrradiance["global"][19].Add(3, 0);
            AbsIrradiance["global"][19].Add(2, 0);
            AbsIrradiance["global"][19].Add(1, 0);
            AbsIrradiance["global"][19].Add(0, 0);
            AbsIrradiance["global"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["global"][20].Add(5, 0);
            AbsIrradiance["global"][20].Add(4, 0);
            AbsIrradiance["global"][20].Add(3, 0);
            AbsIrradiance["global"][20].Add(2, 0);
            AbsIrradiance["global"][20].Add(1, 0);
            AbsIrradiance["global"][20].Add(0, 0);
            AbsIrradiance["global"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["global"][21].Add(5, 0);
            AbsIrradiance["global"][21].Add(4, 0);
            AbsIrradiance["global"][21].Add(3, 0);
            AbsIrradiance["global"][21].Add(2, 0);
            AbsIrradiance["global"][21].Add(1, 0);
            AbsIrradiance["global"][21].Add(0, 0);
            AbsIrradiance["global"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["global"][22].Add(5, 0);
            AbsIrradiance["global"][22].Add(4, 0);
            AbsIrradiance["global"][22].Add(3, 0);
            AbsIrradiance["global"][22].Add(2, 0);
            AbsIrradiance["global"][22].Add(1, 0);
            AbsIrradiance["global"][22].Add(0, 0);
            AbsIrradiance["global"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["global"][23].Add(5, 0);
            AbsIrradiance["global"][23].Add(4, 0);
            AbsIrradiance["global"][23].Add(3, 0);
            AbsIrradiance["global"][23].Add(2, 0);
            AbsIrradiance["global"][23].Add(1, 0);
            AbsIrradiance["global"][23].Add(0, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], AbsIrradiance[iss][h][l] / 100.0);
                    }
                }
            }

            #endregion

            #endregion

        }

        [TestMethod]
        public void TestUseHourly1UseLayers1UseDirDiff1Ellipse()
        {
            #region body

            #region DomainClass
            States state = new States();
            Rates rate = new Rates();
            Exogenous exo = new Exogenous();
            #endregion

            #region Strategy
            Irradiance strategy = new Irradiance();
            #endregion

            #region Input


            exo.incidentDirectIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0983712488665375, 0.385671109550484, 0.838207199302679, 1.12478372198615, 1.13899883376011, 0.890560332771681, 0.429117464255033, 0.119045365378662, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradiancePAR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.0976360266950389, 0.237039459333994, 0.244364274498965, 0.258073360980604, 0.260712319462172, 0.235653830714472, 0.245948397917657, 0.115817054525755, 0, 0, 7.37883450714624E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDirectIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.106568852938749, 0.417810368679691, 0.908057799244569, 1.21851569881833, 1.23391540324012, 0.964773693835987, 0.464877252942953, 0.128965812493551, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.incidentDiffuseIrradianceNIR = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0.105772362252959, 0.256792747611827, 0.264727964040546, 0.279579474395654, 0.28243834608402, 0.255291649940678, 0.266444097744129, 0.125468475736235, 0, 0, 7.99373738274176E-18, 0, 0, 0, 0, 0, 0 };
            exo.solarElevation = new double[24] { 0, 0, 0, 0, 0, 0, 0.103140385060359, 0.324696088747995, 0.523518264039217, 0.682643078120759, 0.776839241860709, 0.782030882727239, 0.696610657622821, 0.543231293529088, 0.347769562777655, 0.128108447988189, 0, -6.93889390390723E-17, 0, 0, 0, 0, 0, 0 };

            System.Collections.Generic.Dictionary<int, System.Tuple<double, double>> gAI = new System.Collections.Generic.Dictionary<int, System.Tuple<double, double>>();
            gAI.Add(5, Tuple.Create(0.806016180580947, 0.0));
            gAI.Add(4, Tuple.Create(0.351, 0.0));
            gAI.Add(3, Tuple.Create(0.234, 0.0));
            gAI.Add(2, Tuple.Create(0.10978845355401, 0.0));
            gAI.Add(1, Tuple.Create(0.0685000872336766, 0.0));
            gAI.Add(0, Tuple.Create(0.0386006177629926, 0.00802853975588673));
            state.layersGAI = gAI;

            state.Phyll = 89.2359;
            state.HS = 5.79744052929482;
            state.FLN = 9.15775145560249;
            state.cumulTT = 518.649287562846;
            state.flagLeafLiguleTT = -999;
            state.termSpikletTT = 506.62568386034;

            #endregion

            #region Parameters

            strategy.useSunShade = 0;
            strategy.useHourly = 1;
            strategy.useLayered = 1;
            strategy.useSphericalLeafDistrib = 0;
            strategy.useDiffDirIrradiance = 1;

            strategy.Kl = Kl;
            strategy.tauLeafPAR = tauLeafPAR;
            strategy.tauLeafNIR = tauLeafNIR;
            strategy.rhoLeafPAR = rhoLeafPAR;
            strategy.rhoLeafNIR = rhoLeafNIR;
            strategy.alaJuv = alaJuv;
            strategy.alaMat = alaMat;
            strategy.CI = CI;

            #endregion

            #region Output

            Dictionary<string, Dictionary<int, Dictionary<int, double>>> AbsIrradiance = new Dictionary<string, Dictionary<int, Dictionary<int, double>>>();
            AbsIrradiance.Add("global", new Dictionary<int, Dictionary<int, double>>());
            AbsIrradiance["global"].Add(0, new Dictionary<int, double>());
            AbsIrradiance["global"][0].Add(5, 0);
            AbsIrradiance["global"][0].Add(4, 0);
            AbsIrradiance["global"][0].Add(3, 0);
            AbsIrradiance["global"][0].Add(2, 0);
            AbsIrradiance["global"][0].Add(1, 0);
            AbsIrradiance["global"][0].Add(0, 0);
            AbsIrradiance["global"].Add(1, new Dictionary<int, double>());
            AbsIrradiance["global"][1].Add(5, 0);
            AbsIrradiance["global"][1].Add(4, 0);
            AbsIrradiance["global"][1].Add(3, 0);
            AbsIrradiance["global"][1].Add(2, 0);
            AbsIrradiance["global"][1].Add(1, 0);
            AbsIrradiance["global"][1].Add(0, 0);
            AbsIrradiance["global"].Add(2, new Dictionary<int, double>());
            AbsIrradiance["global"][2].Add(5, 0);
            AbsIrradiance["global"][2].Add(4, 0);
            AbsIrradiance["global"][2].Add(3, 0);
            AbsIrradiance["global"][2].Add(2, 0);
            AbsIrradiance["global"][2].Add(1, 0);
            AbsIrradiance["global"][2].Add(0, 0);
            AbsIrradiance["global"].Add(3, new Dictionary<int, double>());
            AbsIrradiance["global"][3].Add(5, 0);
            AbsIrradiance["global"][3].Add(4, 0);
            AbsIrradiance["global"][3].Add(3, 0);
            AbsIrradiance["global"][3].Add(2, 0);
            AbsIrradiance["global"][3].Add(1, 0);
            AbsIrradiance["global"][3].Add(0, 0);
            AbsIrradiance["global"].Add(4, new Dictionary<int, double>());
            AbsIrradiance["global"][4].Add(5, 0);
            AbsIrradiance["global"][4].Add(4, 0);
            AbsIrradiance["global"][4].Add(3, 0);
            AbsIrradiance["global"][4].Add(2, 0);
            AbsIrradiance["global"][4].Add(1, 0);
            AbsIrradiance["global"][4].Add(0, 0);
            AbsIrradiance["global"].Add(5, new Dictionary<int, double>());
            AbsIrradiance["global"][5].Add(5, 0);
            AbsIrradiance["global"][5].Add(4, 0);
            AbsIrradiance["global"][5].Add(3, 0);
            AbsIrradiance["global"][5].Add(2, 0);
            AbsIrradiance["global"][5].Add(1, 0);
            AbsIrradiance["global"][5].Add(0, 0);
            AbsIrradiance["global"].Add(6, new Dictionary<int, double>());
            AbsIrradiance["global"][6].Add(5, 0);
            AbsIrradiance["global"][6].Add(4, 0);
            AbsIrradiance["global"][6].Add(3, 0);
            AbsIrradiance["global"][6].Add(2, 0);
            AbsIrradiance["global"][6].Add(1, 0);
            AbsIrradiance["global"][6].Add(0, 0);
            AbsIrradiance["global"].Add(7, new Dictionary<int, double>());
            AbsIrradiance["global"][7].Add(5, 0.131254128415474);
            AbsIrradiance["global"][7].Add(4, 0.030934633462873);
            AbsIrradiance["global"][7].Add(3, 0.0155550891483559);
            AbsIrradiance["global"][7].Add(2, 0.00621551493383609);
            AbsIrradiance["global"][7].Add(1, 0.0035754294961906);
            AbsIrradiance["global"][7].Add(0, 0.0023108044075578);
            AbsIrradiance["global"].Add(8, new Dictionary<int, double>());
            AbsIrradiance["global"][8].Add(5, 0.368671610331705);
            AbsIrradiance["global"][8].Add(4, 0.104146238203496);
            AbsIrradiance["global"][8].Add(3, 0.0563093624910682);
            AbsIrradiance["global"][8].Add(2, 0.0233925358498741);
            AbsIrradiance["global"][8].Add(1, 0.0137130667791447);
            AbsIrradiance["global"][8].Add(0, 0.00896818037385778);
            AbsIrradiance["global"].Add(9, new Dictionary<int, double>());
            AbsIrradiance["global"][9].Add(5, 0.597064822435368);
            AbsIrradiance["global"][9].Add(4, 0.183197128814081);
            AbsIrradiance["global"][9].Add(3, 0.102958987081792);
            AbsIrradiance["global"][9].Add(2, 0.0437374356053168);
            AbsIrradiance["global"][9].Add(1, 0.0259320326197421);
            AbsIrradiance["global"][9].Add(0, 0.0170828894590077);
            AbsIrradiance["global"].Add(10, new Dictionary<int, double>());
            AbsIrradiance["global"][10].Add(5, 0.7158462067671);
            AbsIrradiance["global"][10].Add(4, 0.227779602554622);
            AbsIrradiance["global"][10].Add(3, 0.130265300602214);
            AbsIrradiance["global"][10].Add(2, 0.0559000683894206);
            AbsIrradiance["global"][10].Add(1, 0.0333150109865499);
            AbsIrradiance["global"][10].Add(0, 0.0220193862995678);
            AbsIrradiance["global"].Add(11, new Dictionary<int, double>());
            AbsIrradiance["global"][11].Add(5, 0.7217569541928);
            AbsIrradiance["global"][11].Add(4, 0.230042068735089);
            AbsIrradiance["global"][11].Add(3, 0.131664370455506);
            AbsIrradiance["global"][11].Add(2, 0.0565266999345334);
            AbsIrradiance["global"][11].Add(1, 0.0336964703187024);
            AbsIrradiance["global"][11].Add(0, 0.0222749068903181);
            AbsIrradiance["global"].Add(12, new Dictionary<int, double>());
            AbsIrradiance["global"][12].Add(5, 0.617495513012127);
            AbsIrradiance["global"][12].Add(4, 0.190683163183139);
            AbsIrradiance["global"][12].Add(3, 0.107496467549407);
            AbsIrradiance["global"][12].Add(2, 0.045746820874461);
            AbsIrradiance["global"][12].Add(1, 0.0271482450065426);
            AbsIrradiance["global"][12].Add(0, 0.0178945958881654);
            AbsIrradiance["global"].Add(13, new Dictionary<int, double>());
            AbsIrradiance["global"][13].Add(5, 0.395937806083253);
            AbsIrradiance["global"][13].Add(4, 0.113168494886354);
            AbsIrradiance["global"][13].Add(3, 0.061514399240214);
            AbsIrradiance["global"][13].Add(2, 0.0256325121889933);
            AbsIrradiance["global"][13].Add(1, 0.0150491813043899);
            AbsIrradiance["global"][13].Add(0, 0.0098515939894261);
            AbsIrradiance["global"].Add(14, new Dictionary<int, double>());
            AbsIrradiance["global"][14].Add(5, 0.153935040458402);
            AbsIrradiance["global"][14].Add(4, 0.0374478443778956);
            AbsIrradiance["global"][14].Add(3, 0.0190465464800917);
            AbsIrradiance["global"][14].Add(2, 0.00765474083120903);
            AbsIrradiance["global"][14].Add(1, 0.00441524649294735);
            AbsIrradiance["global"][14].Add(0, 0.00285830727162473);
            AbsIrradiance["global"].Add(15, new Dictionary<int, double>());
            AbsIrradiance["global"][15].Add(5, 0);
            AbsIrradiance["global"][15].Add(4, 0);
            AbsIrradiance["global"][15].Add(3, 0);
            AbsIrradiance["global"][15].Add(2, 0);
            AbsIrradiance["global"][15].Add(1, 0);
            AbsIrradiance["global"][15].Add(0, 0);
            AbsIrradiance["global"].Add(16, new Dictionary<int, double>());
            AbsIrradiance["global"][16].Add(5, 0);
            AbsIrradiance["global"][16].Add(4, 0);
            AbsIrradiance["global"][16].Add(3, 0);
            AbsIrradiance["global"][16].Add(2, 0);
            AbsIrradiance["global"][16].Add(1, 0);
            AbsIrradiance["global"][16].Add(0, 0);
            AbsIrradiance["global"].Add(17, new Dictionary<int, double>());
            AbsIrradiance["global"][17].Add(5, 1.31893193877947E-17);
            AbsIrradiance["global"][17].Add(4, 8.54023665811758E-19);
            AbsIrradiance["global"][17].Add(3, 4.67666504872645E-19);
            AbsIrradiance["global"][17].Add(2, 1.9545409289144E-19);
            AbsIrradiance["global"][17].Add(1, 1.14880998984199E-19);
            AbsIrradiance["global"][17].Add(0, 7.5246765701994E-20);
            AbsIrradiance["global"].Add(18, new Dictionary<int, double>());
            AbsIrradiance["global"][18].Add(5, 0);
            AbsIrradiance["global"][18].Add(4, 0);
            AbsIrradiance["global"][18].Add(3, 0);
            AbsIrradiance["global"][18].Add(2, 0);
            AbsIrradiance["global"][18].Add(1, 0);
            AbsIrradiance["global"][18].Add(0, 0);
            AbsIrradiance["global"].Add(19, new Dictionary<int, double>());
            AbsIrradiance["global"][19].Add(5, 0);
            AbsIrradiance["global"][19].Add(4, 0);
            AbsIrradiance["global"][19].Add(3, 0);
            AbsIrradiance["global"][19].Add(2, 0);
            AbsIrradiance["global"][19].Add(1, 0);
            AbsIrradiance["global"][19].Add(0, 0);
            AbsIrradiance["global"].Add(20, new Dictionary<int, double>());
            AbsIrradiance["global"][20].Add(5, 0);
            AbsIrradiance["global"][20].Add(4, 0);
            AbsIrradiance["global"][20].Add(3, 0);
            AbsIrradiance["global"][20].Add(2, 0);
            AbsIrradiance["global"][20].Add(1, 0);
            AbsIrradiance["global"][20].Add(0, 0);
            AbsIrradiance["global"].Add(21, new Dictionary<int, double>());
            AbsIrradiance["global"][21].Add(5, 0);
            AbsIrradiance["global"][21].Add(4, 0);
            AbsIrradiance["global"][21].Add(3, 0);
            AbsIrradiance["global"][21].Add(2, 0);
            AbsIrradiance["global"][21].Add(1, 0);
            AbsIrradiance["global"][21].Add(0, 0);
            AbsIrradiance["global"].Add(22, new Dictionary<int, double>());
            AbsIrradiance["global"][22].Add(5, 0);
            AbsIrradiance["global"][22].Add(4, 0);
            AbsIrradiance["global"][22].Add(3, 0);
            AbsIrradiance["global"][22].Add(2, 0);
            AbsIrradiance["global"][22].Add(1, 0);
            AbsIrradiance["global"][22].Add(0, 0);
            AbsIrradiance["global"].Add(23, new Dictionary<int, double>());
            AbsIrradiance["global"][23].Add(5, 0);
            AbsIrradiance["global"][23].Add(4, 0);
            AbsIrradiance["global"][23].Add(3, 0);
            AbsIrradiance["global"][23].Add(2, 0);
            AbsIrradiance["global"][23].Add(1, 0);
            AbsIrradiance["global"][23].Add(0, 0);

            #endregion

            #region Call strategy
            strategy.Estimate(rate, exo, state, null);
            #endregion

            #region Test


            foreach (string iss in AbsIrradiance.Keys)
            {
                foreach (int h in AbsIrradiance[iss].Keys)
                {
                    foreach (int l in AbsIrradiance[iss][h].Keys)
                    {
                        Assert.AreEqual(AbsIrradiance[iss][h][l], rate.absorbedIrradiance[iss][h][l], AbsIrradiance[iss][h][l] / 100.0);
                    }
                }
            }

            #endregion

            #endregion

        }
    }
}