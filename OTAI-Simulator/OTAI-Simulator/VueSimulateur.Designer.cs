namespace OTAI_Simulator
{
    partial class VueSimulateur
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
            this.pnlSimulation = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnOpenNewScenario = new System.Windows.Forms.Button();
            this.pnlSimulation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSimulation
            // 
            this.pnlSimulation.Controls.Add(this.lblClock);
            this.pnlSimulation.Location = new System.Drawing.Point(12, 409);
            this.pnlSimulation.Name = "pnlSimulation";
            this.pnlSimulation.Size = new System.Drawing.Size(1850, 963);
            this.pnlSimulation.TabIndex = 0;
            // 
            // lblClock
            // 
            this.lblClock.BackColor = System.Drawing.Color.Black;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClock.Location = new System.Drawing.Point(1567, 853);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(280, 107);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "00:00";
            this.lblClock.UseCompatibleTextRendering = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnOpenNewScenario);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1854, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(1376, 31);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(472, 43);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnOpenNewScenario
            // 
            this.btnOpenNewScenario.Location = new System.Drawing.Point(6, 31);
            this.btnOpenNewScenario.Name = "btnOpenNewScenario";
            this.btnOpenNewScenario.Size = new System.Drawing.Size(1337, 43);
            this.btnOpenNewScenario.TabIndex = 0;
            this.btnOpenNewScenario.Text = "Ouvrir un scenario";
            this.btnOpenNewScenario.UseVisualStyleBackColor = true;
            this.btnOpenNewScenario.Click += new System.EventHandler(this.BtnOpenNewScenario_Click);
            // 
            // VueSimulateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1878, 1384);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlSimulation);
            this.Name = "VueSimulateur";
            this.Text = "VueSimulateur";
            this.pnlSimulation.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSimulation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnOpenNewScenario;
    }
}