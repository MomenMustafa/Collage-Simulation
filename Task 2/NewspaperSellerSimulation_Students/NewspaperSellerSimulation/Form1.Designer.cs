namespace NewspaperSellerSimulation
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_DMD = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_TNP = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_TSP = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_TLP = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_TC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_total_sp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_DUP = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(968, 429);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(884, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(859, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label_DMD
            // 
            this.label_DMD.AutoSize = true;
            this.label_DMD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DMD.Location = new System.Drawing.Point(552, 98);
            this.label_DMD.Name = "label_DMD";
            this.label_DMD.Size = new System.Drawing.Size(24, 18);
            this.label_DMD.TabIndex = 24;
            this.label_DMD.Text = "00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(379, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 18);
            this.label11.TabIndex = 23;
            this.label11.Text = "DaysWithMoreDemand:";
            // 
            // label_TNP
            // 
            this.label_TNP.AutoSize = true;
            this.label_TNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TNP.Location = new System.Drawing.Point(502, 52);
            this.label_TNP.Name = "label_TNP";
            this.label_TNP.Size = new System.Drawing.Size(24, 18);
            this.label_TNP.TabIndex = 22;
            this.label_TNP.Text = "00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(379, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "TotalNetProfit:";
            // 
            // label_TSP
            // 
            this.label_TSP.AutoSize = true;
            this.label_TSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TSP.Location = new System.Drawing.Point(502, 15);
            this.label_TSP.Name = "label_TSP";
            this.label_TSP.Size = new System.Drawing.Size(24, 18);
            this.label_TSP.TabIndex = 20;
            this.label_TSP.Text = "00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(379, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "TotalScrapProfit:";
            // 
            // label_TLP
            // 
            this.label_TLP.AutoSize = true;
            this.label_TLP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TLP.Location = new System.Drawing.Point(157, 98);
            this.label_TLP.Name = "label_TLP";
            this.label_TLP.Size = new System.Drawing.Size(24, 18);
            this.label_TLP.TabIndex = 18;
            this.label_TLP.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "TotalLostProfit:";
            // 
            // label_TC
            // 
            this.label_TC.AutoSize = true;
            this.label_TC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TC.Location = new System.Drawing.Point(157, 52);
            this.label_TC.Name = "label_TC";
            this.label_TC.Size = new System.Drawing.Size(24, 18);
            this.label_TC.TabIndex = 16;
            this.label_TC.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "TotalCost:";
            // 
            // label_total_sp
            // 
            this.label_total_sp.AutoSize = true;
            this.label_total_sp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_total_sp.Location = new System.Drawing.Point(157, 15);
            this.label_total_sp.Name = "label_total_sp";
            this.label_total_sp.Size = new System.Drawing.Size(24, 18);
            this.label_total_sp.TabIndex = 14;
            this.label_total_sp.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "TotalSalesProfit:";
            // 
            // label_DUP
            // 
            this.label_DUP.AutoSize = true;
            this.label_DUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DUP.Location = new System.Drawing.Point(773, 15);
            this.label_DUP.Name = "label_DUP";
            this.label_DUP.Size = new System.Drawing.Size(24, 18);
            this.label_DUP.TabIndex = 26;
            this.label_DUP.Text = "00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(597, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(170, 18);
            this.label13.TabIndex = 25;
            this.label13.Text = "DaysWithUnsoldPapers:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.label_DUP);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label_DMD);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_TNP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label_TSP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_TLP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_TC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_total_sp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_DMD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_TNP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_TSP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_TLP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_TC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_total_sp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_DUP;
        private System.Windows.Forms.Label label13;
    }
}