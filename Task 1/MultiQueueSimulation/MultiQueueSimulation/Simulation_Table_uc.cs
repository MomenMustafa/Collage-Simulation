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
    public partial class Simulation_Table_uc : UserControl
    {
        public Simulation_Table_uc()
        {
            InitializeComponent();
        }
        public Simulation_Table_uc(SimulationSystem sys)
        {
            InitializeComponent();
            for (int i = 0; i < sys.SimulationTable.Count; i++)
            {
                string[] row1 = { sys.SimulationTable[i].CustomerNumber.ToString() , sys.SimulationTable[i].RandomInterArrival.ToString() ,
                    sys.SimulationTable[i].InterArrival.ToString(),sys.SimulationTable[i].ArrivalTime.ToString(),
                    sys.SimulationTable[i].RandomService.ToString(),sys.SimulationTable[i].StartTime.ToString(),
                    sys.SimulationTable[i].ServiceTime.ToString(),sys.SimulationTable[i].EndTime.ToString(),
                    sys.SimulationTable[i].TimeInQueue.ToString(),sys.SimulationTable[i].AssignedServer.ID.ToString()};
                dataGridView1.Rows.Add(row1);
            }
        }
    }
}
