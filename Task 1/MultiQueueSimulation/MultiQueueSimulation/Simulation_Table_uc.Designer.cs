namespace MultiQueueSimulation
{
    partial class Simulation_Table_uc
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.C_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomArr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interArrT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomSer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Waiting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_num,
            this.RandomArr,
            this.interArrT,
            this.ArrT,
            this.RandomSer,
            this.StartTime,
            this.ServiceTime,
            this.EndTime,
            this.Waiting,
            this.ServerID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1054, 355);
            this.dataGridView1.TabIndex = 1;
            // 
            // C_num
            // 
            this.C_num.HeaderText = "Customer Number";
            this.C_num.Name = "C_num";
            this.C_num.ReadOnly = true;
            // 
            // RandomArr
            // 
            this.RandomArr.HeaderText = "RandomInterArrival";
            this.RandomArr.Name = "RandomArr";
            this.RandomArr.ReadOnly = true;
            // 
            // interArrT
            // 
            this.interArrT.HeaderText = "InterArrival time";
            this.interArrT.Name = "interArrT";
            this.interArrT.ReadOnly = true;
            // 
            // ArrT
            // 
            this.ArrT.HeaderText = "InterArrival time Clock";
            this.ArrT.Name = "ArrT";
            this.ArrT.ReadOnly = true;
            // 
            // RandomSer
            // 
            this.RandomSer.HeaderText = "RandomService";
            this.RandomSer.Name = "RandomSer";
            this.RandomSer.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Service Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // ServiceTime
            // 
            this.ServiceTime.HeaderText = "ServiceTime";
            this.ServiceTime.Name = "ServiceTime";
            this.ServiceTime.ReadOnly = true;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End Service Time";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            // 
            // Waiting
            // 
            this.Waiting.HeaderText = "Waiting Queue";
            this.Waiting.Name = "Waiting";
            this.Waiting.ReadOnly = true;
            // 
            // ServerID
            // 
            this.ServerID.HeaderText = "ServerID";
            this.ServerID.Name = "ServerID";
            this.ServerID.ReadOnly = true;
            // 
            // Simulation_Table_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "Simulation_Table_uc";
            this.Size = new System.Drawing.Size(1054, 355);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn RandomArr;
        private System.Windows.Forms.DataGridViewTextBoxColumn interArrT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RandomSer;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Waiting;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerID;
    }
}
