using System;
using System.IO;
using System.Windows.Forms;
using NewspaperSellerModels;
using System.Data;
using System.Collections.Generic;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           var cases =  Directory.GetFiles(SimulationSystem.path, "T*.txt");

            foreach (var i in cases)
                comboBox1.Items.Add(Path.GetFileName(i));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = comboBox1.SelectedItem.ToString();

            var simulationSystem = new SimulationSystem();
            simulationSystem.LoadCase(fileName);

            simulationSystem.BuildSimulationTable();
            BuildGridView(simulationSystem.SimulationTable);

            var measures = simulationSystem.CalculatePerformance();
            ShowMeasures(measures);

            string testingResults = TestingManager.Test(simulationSystem, Constants.FileNames.TestCase1);
            MessageBox.Show(testingResults);
        }

        private void BuildGridView(List<SimulationCase>simTable)
        {
            var table = new DataTable();

            table.Columns.Add("Day", typeof(int));
            table.Columns.Add("Random day number", typeof(int));
            table.Columns.Add("Day type", typeof(Enums.DayType));
            table.Columns.Add("Random demand number", typeof(int));
            table.Columns.Add("Demand", typeof(int));
            table.Columns.Add("Sales profit", typeof(decimal));
            table.Columns.Add("Lost profit", typeof(decimal));
            table.Columns.Add("Scrap", typeof(decimal));
            table.Columns.Add("Daily profit", typeof(decimal));

            foreach (var Case in simTable)
            {
                table.Rows.Add(Case.DayNo, Case.RandomNewsDayType, Case.NewsDayType, Case.RandomDemand, Case.Demand, Case.SalesProfit, Case.LostProfit, Case.ScrapProfit, Case.DailyNetProfit);
            }
            dataGridView1.DataSource = table;
        }
        private void ShowMeasures(PerformanceMeasures measures)
        {
            label_total_sp.Text = measures.TotalSalesProfit.ToString("C");
            label_TC.Text = measures.TotalCost.ToString("C");
            label_TLP.Text = measures.TotalLostProfit.ToString("C");
            label_TSP.Text = measures.TotalScrapProfit.ToString("C");
            label_TNP.Text = measures.TotalNetProfit.ToString("C");
            label_DMD.Text = measures.DaysWithMoreDemand.ToString();
            label_DUP.Text = measures.DaysWithUnsoldPapers.ToString();
        }
    }
}
