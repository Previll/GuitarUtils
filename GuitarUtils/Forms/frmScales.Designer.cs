namespace GuitarUtils.Forms
{
	partial class frmScales
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
			this.pnlScales = new System.Windows.Forms.Panel();
			this.ptbScales = new System.Windows.Forms.PictureBox();
			this.cmbPitch = new System.Windows.Forms.ComboBox();
			this.cmbScale = new System.Windows.Forms.ComboBox();
			this.lblPitch = new System.Windows.Forms.Label();
			this.lblScale = new System.Windows.Forms.Label();
			this.lblTuning = new System.Windows.Forms.Label();
			this.cmbTuning = new System.Windows.Forms.ComboBox();
			this.lblFretCount = new System.Windows.Forms.Label();
			this.btnExport = new System.Windows.Forms.Button();
			this.lblZoom = new System.Windows.Forms.Label();
			this.nudZoom = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.nudStart = new System.Windows.Forms.NumericUpDown();
			this.nudEnd = new System.Windows.Forms.NumericUpDown();
			this.lblEnd = new System.Windows.Forms.Label();
			this.nudFretCount = new System.Windows.Forms.NumericUpDown();
			this.cbxScaleRun = new System.Windows.Forms.CheckBox();
			this.nudScaleRun = new System.Windows.Forms.NumericUpDown();
			this.pnlScales.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ptbScales)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudZoom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudFretCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudScaleRun)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlScales
			// 
			this.pnlScales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlScales.AutoScroll = true;
			this.pnlScales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlScales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlScales.Controls.Add(this.ptbScales);
			this.pnlScales.Location = new System.Drawing.Point(13, 13);
			this.pnlScales.Name = "pnlScales";
			this.pnlScales.Size = new System.Drawing.Size(759, 360);
			this.pnlScales.TabIndex = 999;
			// 
			// ptbScales
			// 
			this.ptbScales.Location = new System.Drawing.Point(0, 0);
			this.ptbScales.Name = "ptbScales";
			this.ptbScales.Size = new System.Drawing.Size(2000, 340);
			this.ptbScales.TabIndex = 0;
			this.ptbScales.TabStop = false;
			// 
			// cmbPitch
			// 
			this.cmbPitch.FormattingEnabled = true;
			this.cmbPitch.Location = new System.Drawing.Point(50, 379);
			this.cmbPitch.Name = "cmbPitch";
			this.cmbPitch.Size = new System.Drawing.Size(140, 21);
			this.cmbPitch.TabIndex = 0;
			this.cmbPitch.SelectionChangeCommitted += new System.EventHandler(this.cmbPitch_SelectionChangeCommitted);
			// 
			// cmbScale
			// 
			this.cmbScale.FormattingEnabled = true;
			this.cmbScale.Location = new System.Drawing.Point(236, 379);
			this.cmbScale.Name = "cmbScale";
			this.cmbScale.Size = new System.Drawing.Size(140, 21);
			this.cmbScale.TabIndex = 1;
			this.cmbScale.SelectionChangeCommitted += new System.EventHandler(this.cmbScale_SelectionChangeCommitted);
			// 
			// lblPitch
			// 
			this.lblPitch.AutoSize = true;
			this.lblPitch.Location = new System.Drawing.Point(13, 382);
			this.lblPitch.Name = "lblPitch";
			this.lblPitch.Size = new System.Drawing.Size(31, 13);
			this.lblPitch.TabIndex = 999;
			this.lblPitch.Text = "Pitch";
			// 
			// lblScale
			// 
			this.lblScale.AutoSize = true;
			this.lblScale.Location = new System.Drawing.Point(196, 382);
			this.lblScale.Name = "lblScale";
			this.lblScale.Size = new System.Drawing.Size(34, 13);
			this.lblScale.TabIndex = 999;
			this.lblScale.Text = "Scale";
			// 
			// lblTuning
			// 
			this.lblTuning.AutoSize = true;
			this.lblTuning.Location = new System.Drawing.Point(382, 382);
			this.lblTuning.Name = "lblTuning";
			this.lblTuning.Size = new System.Drawing.Size(40, 13);
			this.lblTuning.TabIndex = 999;
			this.lblTuning.Text = "Tuning";
			// 
			// cmbTuning
			// 
			this.cmbTuning.FormattingEnabled = true;
			this.cmbTuning.Location = new System.Drawing.Point(428, 379);
			this.cmbTuning.Name = "cmbTuning";
			this.cmbTuning.Size = new System.Drawing.Size(140, 21);
			this.cmbTuning.TabIndex = 2;
			this.cmbTuning.SelectionChangeCommitted += new System.EventHandler(this.cmbTuning_SelectionChangeCommitted);
			// 
			// lblFretCount
			// 
			this.lblFretCount.AutoSize = true;
			this.lblFretCount.Location = new System.Drawing.Point(574, 382);
			this.lblFretCount.Name = "lblFretCount";
			this.lblFretCount.Size = new System.Drawing.Size(56, 13);
			this.lblFretCount.TabIndex = 999;
			this.lblFretCount.Text = "Fret Count";
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(697, 431);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 20);
			this.btnExport.TabIndex = 8;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// lblZoom
			// 
			this.lblZoom.AutoSize = true;
			this.lblZoom.Location = new System.Drawing.Point(10, 408);
			this.lblZoom.Name = "lblZoom";
			this.lblZoom.Size = new System.Drawing.Size(34, 13);
			this.lblZoom.TabIndex = 999;
			this.lblZoom.Text = "Zoom";
			// 
			// nudZoom
			// 
			this.nudZoom.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudZoom.Location = new System.Drawing.Point(50, 406);
			this.nudZoom.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.nudZoom.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.nudZoom.Name = "nudZoom";
			this.nudZoom.Size = new System.Drawing.Size(140, 20);
			this.nudZoom.TabIndex = 4;
			this.nudZoom.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.nudZoom.ValueChanged += new System.EventHandler(this.nudZoom_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(196, 408);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 999;
			this.label1.Text = "Start";
			// 
			// nudStart
			// 
			this.nudStart.Location = new System.Drawing.Point(236, 406);
			this.nudStart.Name = "nudStart";
			this.nudStart.Size = new System.Drawing.Size(140, 20);
			this.nudStart.TabIndex = 5;
			this.nudStart.ValueChanged += new System.EventHandler(this.nudStart_ValueChanged);
			// 
			// nudEnd
			// 
			this.nudEnd.Location = new System.Drawing.Point(428, 406);
			this.nudEnd.Name = "nudEnd";
			this.nudEnd.Size = new System.Drawing.Size(140, 20);
			this.nudEnd.TabIndex = 6;
			this.nudEnd.ValueChanged += new System.EventHandler(this.nudEnd_ValueChanged);
			// 
			// lblEnd
			// 
			this.lblEnd.AutoSize = true;
			this.lblEnd.Location = new System.Drawing.Point(388, 408);
			this.lblEnd.Name = "lblEnd";
			this.lblEnd.Size = new System.Drawing.Size(26, 13);
			this.lblEnd.TabIndex = 999;
			this.lblEnd.Text = "End";
			// 
			// nudFretCount
			// 
			this.nudFretCount.Location = new System.Drawing.Point(636, 379);
			this.nudFretCount.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.nudFretCount.Name = "nudFretCount";
			this.nudFretCount.Size = new System.Drawing.Size(136, 20);
			this.nudFretCount.TabIndex = 3;
			this.nudFretCount.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
			this.nudFretCount.ValueChanged += new System.EventHandler(this.nudFretCount_ValueChanged);
			// 
			// cbxScaleRun
			// 
			this.cbxScaleRun.AutoSize = true;
			this.cbxScaleRun.Location = new System.Drawing.Point(574, 407);
			this.cbxScaleRun.Name = "cbxScaleRun";
			this.cbxScaleRun.Size = new System.Drawing.Size(76, 17);
			this.cbxScaleRun.TabIndex = 7;
			this.cbxScaleRun.Text = "Scale Run";
			this.cbxScaleRun.UseVisualStyleBackColor = true;
			this.cbxScaleRun.CheckedChanged += new System.EventHandler(this.cbxScaleRun_CheckedChanged);
			// 
			// nudScaleRun
			// 
			this.nudScaleRun.Location = new System.Drawing.Point(656, 406);
			this.nudScaleRun.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudScaleRun.Name = "nudScaleRun";
			this.nudScaleRun.Size = new System.Drawing.Size(116, 20);
			this.nudScaleRun.TabIndex = 1000;
			this.nudScaleRun.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudScaleRun.ValueChanged += new System.EventHandler(this.nudScaleRun_ValueChanged);
			// 
			// frmScales
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.nudScaleRun);
			this.Controls.Add(this.cbxScaleRun);
			this.Controls.Add(this.nudFretCount);
			this.Controls.Add(this.nudEnd);
			this.Controls.Add(this.lblEnd);
			this.Controls.Add(this.nudStart);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nudZoom);
			this.Controls.Add(this.lblZoom);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.lblFretCount);
			this.Controls.Add(this.lblTuning);
			this.Controls.Add(this.cmbTuning);
			this.Controls.Add(this.lblScale);
			this.Controls.Add(this.lblPitch);
			this.Controls.Add(this.cmbScale);
			this.Controls.Add(this.cmbPitch);
			this.Controls.Add(this.pnlScales);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "frmScales";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Scales";
			this.Load += new System.EventHandler(this.frmScales_Load);
			this.pnlScales.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ptbScales)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudZoom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudFretCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudScaleRun)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlScales;
		private System.Windows.Forms.PictureBox ptbScales;
		private System.Windows.Forms.ComboBox cmbPitch;
		private System.Windows.Forms.ComboBox cmbScale;
		private System.Windows.Forms.Label lblPitch;
		private System.Windows.Forms.Label lblScale;
		private System.Windows.Forms.Label lblTuning;
		private System.Windows.Forms.ComboBox cmbTuning;
		private System.Windows.Forms.Label lblFretCount;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Label lblZoom;
		private System.Windows.Forms.NumericUpDown nudZoom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nudStart;
		private System.Windows.Forms.NumericUpDown nudEnd;
		private System.Windows.Forms.Label lblEnd;
		private System.Windows.Forms.NumericUpDown nudFretCount;
		private System.Windows.Forms.CheckBox cbxScaleRun;
		private System.Windows.Forms.NumericUpDown nudScaleRun;
	}
}