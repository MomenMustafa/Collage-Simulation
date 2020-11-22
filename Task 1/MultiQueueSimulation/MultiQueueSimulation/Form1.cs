using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        public SimulationSystem sys = new SimulationSystem();
        public int stopCri;
        public int selecMeth;

        public Form1()
        {
            InitializeComponent();
            //our Functions -------------(-_-).

            ///Read input from file .......................
            ///least utilization...........................
            ///GUI ............................................
            Read_input("TestCase2");
            Calc_Cummualtive();
            running();
            string testingR = TestingManager.Test(sys, Constants.FileNames.TestCase2);
            MessageBox.Show(testingR);
            //--------------------------------
        }
        public void Read_input(string FileName = "TestCase2")
        {
            FileName += ".txt";
            //string TestPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName+"\\MultiQueueSimulation\\MultiQueueSimulation\\TestCases";
            FileStream F = new FileStream(FileName, FileMode.Open);
            StreamReader R = new StreamReader(F);
            R.ReadLine();
            sys.NumberOfServers = int.Parse(R.ReadLine());
            R.ReadLine();
            R.ReadLine();
            sys.StoppingNumber = int.Parse(R.ReadLine());
            R.ReadLine();
            R.ReadLine();
            stopCri = int.Parse(R.ReadLine());
            if(stopCri==1)
            {
                sys.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
            }
            else
            {
                sys.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
            }
            R.ReadLine();
            R.ReadLine();
            selecMeth = int.Parse(R.ReadLine());
            if (selecMeth == 1)
            {
                sys.SelectionMethod = Enums.SelectionMethod.HighestPriority;
            }
            else if(selecMeth == 2)
            {
                sys.SelectionMethod = Enums.SelectionMethod.Random;
            }
            else
            {
                sys.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
            }
            R.ReadLine();
            R.ReadLine();
            string line;
            char[] spearator = { ',', ' ' };

            while ((line = R.ReadLine()) != "")
            {
                TimeDistribution temp = new TimeDistribution();
                string[] l = line.Split(spearator);
                temp.Time = int.Parse(l[0]);
                temp.Probability = decimal.Parse(l[2]);
                sys.InterarrivalDistribution.Add(temp);
            }
            R.ReadLine();
            for (int i = 1; i <= sys.NumberOfServers; i++)
            {
                Server serTemp = new Server();
                serTemp.ID = i;
                serTemp.FinishTime = 0;
                serTemp.Utilization = 0;
                while ((line = R.ReadLine()) != "" && (line != " "))
                {
                    if (line == null)
                        break;
                    TimeDistribution temp = new TimeDistribution();
                    string[] l = line.Split(spearator);
                    temp.Time = int.Parse(l[0]);
                    temp.Probability = decimal.Parse(l[2]);
                    serTemp.TimeDistribution.Add(temp);
                }
                sys.Servers.Add(serTemp);
                if (line == null)
                    break;
                R.ReadLine();
            }
        }

        public void Calc_Cummualtive()
        {
            sys.InterarrivalDistribution[0].CummProbability = sys.InterarrivalDistribution[0].Probability;

            sys.InterarrivalDistribution[0].MinRange = 1;
            sys.InterarrivalDistribution[0].MaxRange = Convert.ToInt32(sys.InterarrivalDistribution[0].CummProbability * 100);

            for (int i = 1; i < sys.InterarrivalDistribution.Count; i++)
            {
                sys.InterarrivalDistribution[i].CummProbability = sys.InterarrivalDistribution[i - 1].CummProbability
                    + sys.InterarrivalDistribution[i].Probability;

                sys.InterarrivalDistribution[i].MinRange = sys.InterarrivalDistribution[i - 1].MaxRange + 1;
                sys.InterarrivalDistribution[i].MaxRange = Convert.ToInt32(sys.InterarrivalDistribution[i].CummProbability * 100);

            }

            for (int i = 0; i < sys.Servers.Count; i++)
            {
                sys.Servers[i].TimeDistribution[0].CummProbability = sys.Servers[i].TimeDistribution[0].Probability;

                sys.Servers[i].TimeDistribution[0].MinRange = 1;
                sys.Servers[i].TimeDistribution[0].MaxRange = Convert.ToInt32(sys.Servers[i].TimeDistribution[0].CummProbability * 100);


                for (int j = 1; j < sys.Servers[i].TimeDistribution.Count; j++)
                {
                    sys.Servers[i].TimeDistribution[j].CummProbability = sys.Servers[i].TimeDistribution[j - 1].CummProbability
                        + sys.Servers[i].TimeDistribution[j].Probability;

                    sys.Servers[i].TimeDistribution[j].MinRange = sys.Servers[i].TimeDistribution[j - 1].MaxRange + 1;
                    sys.Servers[i].TimeDistribution[j].MaxRange = Convert.ToInt32(sys.Servers[i].TimeDistribution[j].CummProbability * 100);

                }
            }
        }

        public int get_Random_server_id(int ArrivalTime)
        {
            bool found = false;
            List<int> l = new List<int>();
            int MinFinishT = 100000000, ID = -1;
            for (int i = 0; i < sys.Servers.Count; i++)
            {
                if (sys.Servers[i].FinishTime <= ArrivalTime)
                {
                    l.Add(sys.Servers[i].ID);
                    found = true;
                }
                if (sys.Servers[i].FinishTime < MinFinishT)
                {
                    MinFinishT = sys.Servers[i].FinishTime;
                    ID = sys.Servers[i].ID;
                }
            }
            if (found)
            {
                Random rmd = new Random();
                int Rval = rmd.Next(l.Count);
                return l[Rval];
            }
            return ID;
        }
        public int get_hieghst_periority_id(int ArrivalTime)
        {
            List<int> l = new List<int>();
            bool found = false;
            int MinFinishT = 100000000, ID = -1;
            for (int i = 0; i < sys.Servers.Count; i++)
            {
                if (sys.Servers[i].FinishTime <= ArrivalTime)
                {
                    l.Add(sys.Servers[i].ID);
                    found = true;
                }
                if (sys.Servers[i].FinishTime < MinFinishT)
                {
                    MinFinishT = sys.Servers[i].FinishTime;
                    ID = sys.Servers[i].ID;
                }
            }
            if (found)
            {
                int serID = 100000000;
                for (int i = 0; i < l.Count; i++)
                {
                    serID = Math.Min(serID, l[i]);
                }
                return serID;
            }
            return ID;
        }

        public int get_least_utilize_id(int ArrivalTime)
        {
            decimal min_utilize = 100000;
            int ID = -1;
            for (int i = 0; i < sys.Servers.Count; i++)
            {
                if (sys.Servers[i].FinishTime <= ArrivalTime)
                {
                    if (min_utilize > sys.Servers[i].Utilization)
                    {
                        min_utilize = sys.Servers[i].Utilization;
                        ID = sys.Servers[i].ID;
                    }
                }
            }
            if (ID == -1)
            {
                Dictionary<int, decimal> hold_fininshT = new Dictionary<int, decimal>();
                Dictionary<int, int> hold_id = new Dictionary<int, int>();
                for (int i = 0; i < sys.Servers.Count; i++)
                {
                    if (hold_fininshT.ContainsKey(sys.Servers[i].FinishTime))
                    {
                        if (sys.Servers[i].Utilization < hold_fininshT[sys.Servers[i].FinishTime])
                        {
                            hold_fininshT[sys.Servers[i].FinishTime] = sys.Servers[i].Utilization;
                            hold_id[sys.Servers[i].FinishTime] = sys.Servers[i].ID;
                        }
                    }
                    else
                    {
                        hold_fininshT.Add(sys.Servers[i].FinishTime, sys.Servers[i].Utilization);
                        hold_id.Add(sys.Servers[i].FinishTime, sys.Servers[i].ID);
                    }
                }
                int min_time = 100000;
                foreach (KeyValuePair<int, decimal> pair in hold_fininshT)
                {
                    min_time = Math.Min(min_time, pair.Key);
                }
                return hold_id[min_time];
            }
            return ID;
        }
        public void Update_Servers_Utilization(decimal curr_endTime)
        {
            for (int i = 0; i < sys.Servers.Count; i++)
            {
                sys.Servers[i].Utilization = (decimal)(sys.Servers[i].TotalWorkingTime / curr_endTime);
            }
            return;
        }
        public int get_service_index(int serverID)
        {
            int index;
            for (index = 0; index < sys.Servers.Count; index++)
                if (sys.Servers[index].ID == serverID)
                    return index;
            return 0;
        }
        public int get_service_time(int serverID, int RandomSer)
        {
            int index;
            for (index = 0; index < sys.Servers.Count; index++)
                if (sys.Servers[index].ID == serverID)
                    break;
            int serviceTime = -1;
            for (int i = 0; i < sys.Servers[index].TimeDistribution.Count; i++)
            {
                if (sys.Servers[index].TimeDistribution[i].MinRange <= RandomSer)
                    serviceTime = sys.Servers[index].TimeDistribution[i].Time;
            }
            if (serviceTime == -1 && RandomSer > sys.Servers[index].TimeDistribution[sys.Servers[index].TimeDistribution.Count - 1].MinRange)
                serviceTime = sys.Servers[index].TimeDistribution[sys.Servers[index].TimeDistribution.Count - 1].MinRange;

            return serviceTime;
        }

        public int get_interArrival(int val)
        {
            int arrivalT = -1;
            for (int i = 0; i < sys.InterarrivalDistribution.Count; i++)
            {
                if (sys.InterarrivalDistribution[i].MinRange <= val)
                {
                    arrivalT = sys.InterarrivalDistribution[i].Time;
                }
            }
            if (arrivalT == -1 && val > sys.InterarrivalDistribution[sys.InterarrivalDistribution.Count - 1].MinRange)
            {
                arrivalT = sys.InterarrivalDistribution[sys.InterarrivalDistribution.Count - 1].Time;
            }
            return arrivalT;
        }
        public void running()
        {

            SimulationCase TempCase0 = new SimulationCase();
            TempCase0.CustomerNumber = 1;
            TempCase0.ArrivalTime = 0;
            TempCase0.InterArrival = -1;
            Random rmd = new Random();
            TempCase0.RandomService = rmd.Next(1, 100);
            TempCase0.RandomInterArrival = rmd.Next(1, 100);
            int assignedServerID = -1;
            if (sys.SelectionMethod == Enums.SelectionMethod.HighestPriority)
                assignedServerID = get_hieghst_periority_id(TempCase0.ArrivalTime);
            else if (sys.SelectionMethod == Enums.SelectionMethod.Random)
            assignedServerID = get_Random_server_id(TempCase0.ArrivalTime);
            else if (sys.SelectionMethod == Enums.SelectionMethod.LeastUtilization)
                assignedServerID = get_least_utilize_id(TempCase0.ArrivalTime);

            // TempCase0.AssignedServer.ID = assignedServerID;
            TempCase0.ServiceTime = get_service_time(assignedServerID, TempCase0.RandomService);
            int service_index = get_service_index(assignedServerID);
            int finishTime = sys.Servers[service_index].FinishTime;


            TempCase0.StartTime = Math.Max(finishTime, TempCase0.ArrivalTime);
            TempCase0.EndTime = TempCase0.StartTime + TempCase0.ServiceTime;
            TempCase0.TimeInQueue = TempCase0.StartTime - TempCase0.ArrivalTime;


            sys.Servers[service_index].number_of_served_customer++;
            sys.Servers[service_index].FinishTime = TempCase0.EndTime;
            sys.Servers[service_index].TotalWorkingTime += TempCase0.ServiceTime;

            Server Temp_ser0 = new Server();
            //Temp_ser0.ID = sys.Servers[service_index].ID;
            //Temp_ser0.FinishTime = sys.Servers[service_index].FinishTime;
            //Temp_ser0.AverageServiceTime = sys.Servers[service_index].AverageServiceTime;
            //Temp_ser0.IdleProbability = sys.Servers[service_index].IdleProbability;
            //Temp_ser0.number_of_served_customer = sys.Servers[service_index].number_of_served_customer;
            //Temp_ser0.TotalWorkingTime = sys.Servers[service_index].TotalWorkingTime;
            //Temp_ser0.Utilization = sys.Servers[service_index].Utilization;
            //Temp_ser0.TimeDistribution = sys.Servers[service_index].TimeDistribution;
            Temp_ser0 = sys.Servers[service_index];
            TempCase0.AssignedServer = Temp_ser0;

            sys.SimulationTable.Add(TempCase0);

            decimal curr_End_Time = TempCase0.EndTime;




            Update_Servers_Utilization(curr_End_Time);



            // GUI--------------------------------------------------------------------------------------------------------------------
           /* string[] row = { sys.SimulationTable[0].CustomerNumber.ToString() , sys.SimulationTable[0].RandomInterArrival.ToString() ,
                    sys.SimulationTable[0].InterArrival.ToString(),sys.SimulationTable[0].ArrivalTime.ToString(),
                    sys.SimulationTable[0].RandomService.ToString(),sys.SimulationTable[0].StartTime.ToString(),
                    sys.SimulationTable[0].ServiceTime.ToString(),sys.SimulationTable[0].EndTime.ToString(),
                    sys.SimulationTable[0].TimeInQueue.ToString(),sys.SimulationTable[0].AssignedServer.ID.ToString(),
                    sys.Servers[service_index].Utilization.ToString()};
            dataGridView1.Rows.Add(row);*/
            // GUI--------------------------------------------------------------------------------------------------------------------
            decimal customer_wait_count = 0;
            decimal wait_time_customer_summation = 0;
            int i = 1;
            while (true)
            {
                SimulationCase TempCase = new SimulationCase();
                if (sys.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers && sys.StoppingNumber < i + 1)
                    break;
                TempCase.CustomerNumber = i + 1;
                TempCase.RandomInterArrival = rmd.Next(1, 100);
                TempCase.RandomService = rmd.Next(1, 100);
                TempCase.InterArrival = get_interArrival(TempCase.RandomInterArrival);
                TempCase.ArrivalTime = sys.SimulationTable[i - 1].ArrivalTime + TempCase.InterArrival;

                if (sys.SelectionMethod == Enums.SelectionMethod.HighestPriority)
                    assignedServerID = get_hieghst_periority_id(TempCase.ArrivalTime);
                else if (sys.SelectionMethod == Enums.SelectionMethod.Random)
                    assignedServerID = get_Random_server_id(TempCase.ArrivalTime);
                else if (sys.SelectionMethod == Enums.SelectionMethod.LeastUtilization)
                    assignedServerID = get_least_utilize_id(TempCase.ArrivalTime);

                TempCase.AssignedServer.ID = assignedServerID;
                TempCase.ServiceTime = get_service_time(assignedServerID, TempCase.RandomService);
                service_index = get_service_index(assignedServerID);
                finishTime = sys.Servers[service_index].FinishTime;
                TempCase.StartTime = Math.Max(finishTime, TempCase.ArrivalTime);
                TempCase.EndTime = TempCase.StartTime + TempCase.ServiceTime;
                TempCase.TimeInQueue = TempCase.StartTime - TempCase.ArrivalTime;

                if (sys.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime && TempCase.EndTime > sys.StoppingNumber)
                    break;

                if (TempCase.TimeInQueue > 0)
                    customer_wait_count++;
                wait_time_customer_summation += TempCase.TimeInQueue;




                sys.Servers[service_index].TotalWorkingTime += TempCase.ServiceTime;
                sys.Servers[service_index].number_of_served_customer++;
                sys.Servers[service_index].FinishTime = TempCase.EndTime;


                Server Temp_ser = new Server();
                //Temp_ser.ID = sys.Servers[service_index].ID;
                //Temp_ser.FinishTime = sys.Servers[service_index].FinishTime;
                //Temp_ser.AverageServiceTime = sys.Servers[service_index].AverageServiceTime;
                //Temp_ser.IdleProbability = sys.Servers[service_index].IdleProbability;
                //Temp_ser.number_of_served_customer = sys.Servers[service_index].number_of_served_customer;
                //Temp_ser.TotalWorkingTime = sys.Servers[service_index].TotalWorkingTime;
                //Temp_ser.Utilization = sys.Servers[service_index].Utilization;
                //Temp_ser.TimeDistribution = sys.Servers[service_index].TimeDistribution;
                Temp_ser = sys.Servers[service_index];
                TempCase.AssignedServer = Temp_ser;


                sys.SimulationTable.Add(TempCase);
                curr_End_Time = Math.Max(curr_End_Time, TempCase.EndTime);





                Update_Servers_Utilization(curr_End_Time);



                // GUI----------------------------------------------------------------------------------------------------------------------
                /*string[] row1 = { sys.SimulationTable[i].CustomerNumber.ToString() , sys.SimulationTable[i].RandomInterArrival.ToString() ,
                    sys.SimulationTable[i].InterArrival.ToString(),sys.SimulationTable[i].ArrivalTime.ToString(),
                    sys.SimulationTable[i].RandomService.ToString(),sys.SimulationTable[i].StartTime.ToString(),
                    sys.SimulationTable[i].ServiceTime.ToString(),sys.SimulationTable[i].EndTime.ToString(),
                    sys.SimulationTable[i].TimeInQueue.ToString(),sys.SimulationTable[i].AssignedServer.ID.ToString(),
                    sys.Servers[service_index].Utilization.ToString()};
                dataGridView1.Rows.Add(row1);*/
                // GUI----------------------------------------------------------------------------------------------------------------------
                i++;
            }
            int max_queue_length = -1, cnt = 1;
            bool inqeue = false;
            for (int j = 0; j < sys.SimulationTable.Count; j++)
            {
                int k = j + 1;
                while (k < sys.SimulationTable.Count && sys.SimulationTable[k].ArrivalTime < sys.SimulationTable[j].StartTime)
                {
                    inqeue = true;
                    cnt++;
                    k++;
                }
                max_queue_length = Math.Max(max_queue_length, cnt);
                cnt = 1;
            }

            //sys.StoppingNumbe
            sys.PerformanceMeasures.AverageWaitingTime = (decimal)(wait_time_customer_summation / i);
            sys.PerformanceMeasures.WaitingProbability = (decimal)(customer_wait_count / i);
            if (inqeue)
                sys.PerformanceMeasures.MaxQueueLength = max_queue_length;
            else sys.PerformanceMeasures.MaxQueueLength = 0;

            //dinamic
            decimal end_of_sim_time = -1;
            for (int j = 0; j < sys.Servers.Count; j++)
            {
                end_of_sim_time = Math.Max(sys.Servers[j].FinishTime, end_of_sim_time);
            }

            for (int j = 0; j < sys.Servers.Count; j++)
            {
                decimal idl = /*end_of_sim_time*/curr_End_Time - sys.Servers[j].TotalWorkingTime;
                sys.Servers[j].IdleProbability = (idl / curr_End_Time /*end_of_sim_time*/);
                if (sys.Servers[j].number_of_served_customer == 0)
                {
                    sys.Servers[j].AverageServiceTime = 0;
                }
                else
                    sys.Servers[j].AverageServiceTime = (decimal)(sys.Servers[j].TotalWorkingTime / sys.Servers[j].number_of_served_customer);
                sys.Servers[j].Utilization = (decimal)(sys.Servers[j].TotalWorkingTime / curr_End_Time /*end_of_sim_time*/);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Simulation_Table_uc us = new Simulation_Table_uc(sys);
            panel1.Controls.Add(us);
            us.BringToFront();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Performance us = new Performance(sys);
            panel1.Controls.Add(us);
            us.BringToFront();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}