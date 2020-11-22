using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class Total_performance : UserControl
    {
        public Total_performance()
        {
            InitializeComponent();
        }
        public Total_performance(SimulationSystem sys)
        {
            InitializeComponent();
            label4.Text = "System Performance as a all";
            label2.Text = "MaxQueueLength = "+sys.PerformanceMeasures.MaxQueueLength.ToString();
            label3.Text = "WaitingProbability = " + sys.PerformanceMeasures.WaitingProbability.ToString();
            label1.Text = "AverageWaitingTime = " + sys.PerformanceMeasures.AverageWaitingTime.ToString();
        }
    }
}
