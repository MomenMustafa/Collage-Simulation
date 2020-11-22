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
    public partial class Performance : UserControl
    {
        SimulationSystem s = new SimulationSystem();
        int x = 0, y = 24;
        public Performance()
        {
            InitializeComponent();
        }
        public Performance(SimulationSystem sys)
        {
            InitializeComponent();
            s = sys;
            loadbut(sys);
        }

        public void loadbut(SimulationSystem sys)
        {
            for(int i=0;i<sys.Servers.Count;i++)
            {
                Button bt = new Button();
                bt.Text = "Server "+ sys.Servers[i].ID.ToString();
                bt.Name = sys.Servers[i].ID.ToString();
                bt.Size = new Size(77,24);
                bt.Location = new Point(x,y);
                y += 24;
                bt.Click += new EventHandler(this.button_click); 
                this.Controls.Add(bt);

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        { 
            Total_performance us = new Total_performance(s);
            panel1.Controls.Add(us);
            us.BringToFront();
        }

        void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string button_name = btn.Name.ToString();
            int server_id = Convert.ToInt32(button_name);
            for (int i = 0; i < s.Servers.Count; i++)
            {
                if(s.Servers[i].ID == server_id)
                {
                    server_chart_performance us = new server_chart_performance(i,s);
                    panel1.Controls.Add(us);
                    us.BringToFront();
                    break;
                }
            }
        }
    }
}
