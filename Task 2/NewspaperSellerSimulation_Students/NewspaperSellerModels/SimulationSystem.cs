using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NewspaperSellerModels
{

    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
            DemandDistributions = new List<DemandDistribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }
        ///////////// INPUTS /////////////
        public static string path = @"E:\college\4th year\1st term\Tasks&GP\simulation\Task 2\NewspaperSellerSimulation_Students\NewspaperSellerSimulation\TestCases\";
        public int NumOfNewspapers { get; set; }
        public int NumOfRecords { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal ScrapPrice { get; set; }
        public decimal UnitProfit { get; set; }
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
        public List<DemandDistribution> DemandDistributions { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        public void LoadCase(string fileName)
        {
            var lines = File.ReadAllLines(path+fileName);

            NumOfNewspapers = int.Parse(lines[1]);
            NumOfRecords = int.Parse(lines[4]);
            PurchasePrice = decimal.Parse(lines[7]);
            ScrapPrice = decimal.Parse(lines[10]);
            SellingPrice = decimal.Parse(lines[13]);
            UnitProfit = SellingPrice - PurchasePrice;

            #region
            // day type distribution
            var DayTypes = lines[16].Split(',');
            var cummProb = 0.0m;
            foreach (var day in DayTypes)
            {
                var dayTypeDistribution = new DayTypeDistribution
                {
                    Probability = decimal.Parse(day),
                    MinRange = (int)(cummProb * 100) + 1
                };
                cummProb += dayTypeDistribution.Probability;
                dayTypeDistribution.CummProbability = cummProb;
                dayTypeDistribution.MaxRange = (int)(cummProb * 100);

                DayTypeDistributions.Add(dayTypeDistribution);
            }
            DayTypeDistributions[0].DayType = Enums.DayType.Good;
            DayTypeDistributions[1].DayType = Enums.DayType.Fair;
            DayTypeDistributions[2].DayType = Enums.DayType.Poor;
            #endregion

            #region
            // Demand distribution
            decimal goodCumm = 0.0m, fairCumm = 0.0m, poorCum = 0.0m;
            for (int i = 19; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');                       // demand, good, fair, poor

                var goodDay = new DayTypeDistribution
                {
                    DayType = Enums.DayType.Good,
                    Probability = decimal.Parse(values[1]),
                    MinRange = (int)(goodCumm * 100) + 1,
                    MaxRange = (int)((goodCumm + decimal.Parse(values[1])) * 100)
                };
                goodCumm += goodDay.Probability;
                goodDay.CummProbability = goodCumm;

                var fairDay = new DayTypeDistribution
                {
                    DayType = Enums.DayType.Fair,
                    Probability = decimal.Parse(values[2]),
                    MinRange = (int)(fairCumm * 100) + 1,
                    MaxRange = (int)((fairCumm + decimal.Parse(values[2])) * 100)

                };
                fairCumm += fairDay.Probability;
                fairDay.CummProbability = fairCumm;

                var poorDay = new DayTypeDistribution
                {
                    DayType = Enums.DayType.Poor,
                    Probability = decimal.Parse(values[3]),
                    MinRange = (int)(poorCum * 100) + 1,
                    MaxRange = (int)((poorCum + decimal.Parse(values[3])) * 100)

                };
                poorCum += poorDay.Probability;
                fairDay.CummProbability = poorCum;

                var demandDistribution = new DemandDistribution
                {
                    Demand = int.Parse(values[0])
                };
                if(goodDay.Probability>0)
                    demandDistribution.DayTypeDistributions.Add(goodDay);
                if (fairDay.Probability > 0)
                    demandDistribution.DayTypeDistributions.Add(fairDay);
                if (poorDay.Probability > 0)
                    demandDistribution.DayTypeDistributions.Add(poorDay);

                DemandDistributions.Add(demandDistribution);
            }
            #endregion
        }
        public void BuildSimulationTable()
        {
            var rand = new Random();
            
            for (int i = 0; i < NumOfRecords; i++)
            {
                var simulationCase = new SimulationCase
                {
                    DayNo = i + 1,
                    RandomNewsDayType = rand.Next(1, 101),
                    RandomDemand = rand.Next(1, 101)
                };

                simulationCase.NewsDayType = GetDayType(simulationCase.RandomNewsDayType);
                simulationCase.Demand = GetDemand(simulationCase.RandomDemand, simulationCase.NewsDayType);
                simulationCase.DailyCost = NumOfNewspapers * PurchasePrice;
                simulationCase.SalesProfit = Math.Min(NumOfNewspapers, simulationCase.Demand) * SellingPrice;
                var diffrence = simulationCase.Demand - NumOfNewspapers;
                simulationCase.LostProfit = ((diffrence > 0) ? diffrence * UnitProfit : 0);
                simulationCase.ScrapProfit = ((diffrence < 0) ? Math.Abs(diffrence) * ScrapPrice : 0);
                simulationCase.DailyNetProfit = simulationCase.SalesProfit - simulationCase.DailyCost - simulationCase.LostProfit + simulationCase.ScrapProfit;

                SimulationTable.Add(simulationCase);
            }
        }
        public PerformanceMeasures CalculatePerformance()
        {
            var performanceMeasures = new PerformanceMeasures
            {
                TotalCost = NumOfRecords * NumOfNewspapers * PurchasePrice,
                TotalLostProfit = SimulationTable.Sum(itm => itm.LostProfit),
                TotalSalesProfit = SimulationTable.Sum(itm => itm.SalesProfit),
                TotalScrapProfit = SimulationTable.Sum(itm => itm.ScrapProfit),
                TotalNetProfit = SimulationTable.Sum(itm => itm.DailyNetProfit),
                DaysWithMoreDemand = SimulationTable.Count(itm => itm.LostProfit != 0),
                DaysWithUnsoldPapers = SimulationTable.Count(itm => itm.ScrapProfit != 0)
            };
            return PerformanceMeasures = performanceMeasures;
        }
        private Enums.DayType GetDayType(int rand)
        {
            foreach (var type in DayTypeDistributions)
            {
                if (rand >= type.MinRange && rand <= type.MaxRange)
                    return type.DayType;
            }
            return Enums.DayType.Good;
        }
        private int GetDemand(int rand,Enums.DayType dayType)
        {
            for (int i = 0; i < DemandDistributions.Count; i++)
            {
                var temp= DemandDistributions[i].DayTypeDistributions.Find(x => x.DayType == dayType);
                if (rand >= temp.MinRange && rand <= temp.MaxRange)
                    return DemandDistributions[i].Demand;
            }
            return rand;
        }
    }
}
