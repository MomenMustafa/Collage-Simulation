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
    public partial class server_chart_performance : UserControl
    {
        public server_chart_performance()
        {
            InitializeComponent();
        }
        public server_chart_performance(int  index_of_server , SimulationSystem sys)
        {
            InitializeComponent();
            label1.Text = "Server " + sys.Servers[index_of_server].ID.ToString();
            label2.Text = "probablity of server idle:";
            label5.Text = sys.Servers[index_of_server].IdleProbability.ToString();
            label3.Text = "average service time =  ";
            label6.Text = sys.Servers[index_of_server].AverageServiceTime.ToString();
            label4.Text = "Utilization =  ";
            label7.Text = sys.Servers[index_of_server].Utilization.ToString();
            int start = 0;
            for (int i=0;i< sys.SimulationTable.Count; i++)
            {
                if(sys.Servers[index_of_server].ID == sys.SimulationTable[i].AssignedServer.ID)
                {
                    if (sys.SimulationTable[i].StartTime >= 20)
                        break;
                    if (start != sys.SimulationTable[i].StartTime)
                    {
                        for (int j = start+1; j < sys.SimulationTable[i].StartTime; j++)
                        {
                            this.chart1.Series["graph"].Points.AddXY(j, 0);
                        }
                        for (int j = sys.SimulationTable[i].StartTime; j <= sys.SimulationTable[i].EndTime; j++)
                        {
                            this.chart1.Series["graph"].Points.AddXY(j, 1);
                        }
                    }
                    else
                    {
                        for (int j = sys.SimulationTable[i].StartTime+1; j <= sys.SimulationTable[i].EndTime; j++)
                        {
                            this.chart1.Series["graph"].Points.AddXY(j, 1);
                        }
                    }
                    start = sys.SimulationTable[i].EndTime;
                }
            }

        }
    }
}
