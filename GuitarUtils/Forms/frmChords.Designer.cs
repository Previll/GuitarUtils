namespace GuitarUtils.Forms
{
	partial class frmChords
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
			this.flpChords = new System.Windows.Forms.FlowLayoutPanel();
			this.lblPitch = new System.Windows.Forms.Label();
			this.cmbPitch = new System.Windows.Forms.ComboBox();
			this.lblTuning = new System.Windows.Forms.Label();
			this.cmbTuning = new System.Windows.Forms.ComboBox();
			this.lblChord = new System.Windows.Forms.Label();
			this.cmbChord = new System.Windows.Forms.ComboBox();
			this.lblBase = new System.Windows.Forms.Label();
			this.cmbBase = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// flpChords
			// 
			this.flpChords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpChords.AutoScroll = true;
			this.flpChords.AutoScrollMargin = new System.Drawing.Size(20, 20);
			this.flpChords.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flpChords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpChords.Location = new System.Drawing.Point(12, 12);
			this.flpChords.Name = "flpChords";
			this.flpChords.Size = new System.Drawing.Size(759, 360);
			this.flpChords.TabIndex = 1;
			this.flpChords.MouseUp += new System.Windows.Forms.MouseEventHandler(this.flpChords_MouseUp);
			// 
			// lblPitch
			// 
			this.lblPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblPitch.AutoSize = true;
			this.lblPitch.Location = new System.Drawing.Point(13, 382);
			this.lblPitch.Name = "lblPitch";
			this.lblPitch.Size = new System.Drawing.Size(31, 13);
			this.lblPitch.TabIndex = 5;
			this.lblPitch.Text = "Pitch";
			// 
			// cmbPitch
			// 
			this.cmbPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbPitch.FormattingEnabled = true;
			this.cmbPitch.Location = new System.Drawing.Point(50, 379);
			this.cmbPitch.Name = "cmbPitch";
			this.cmbPitch.Size = new System.Drawing.Size(140, 21);
			this.cmbPitch.TabIndex = 4;
			this.cmbPitch.SelectionChangeCommitted += new System.EventHandler(this.cmbPitch_SelectionChangeCommitted);
			// 
			// lblTuning
			// 
			this.lblTuning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTuning.AutoSize = true;
			this.lblTuning.Location = new System.Drawing.Point(586, 382);
			this.lblTuning.Name = "lblTuning";
			this.lblTuning.Size = new System.Drawing.Size(40, 13);
			this.lblTuning.TabIndex = 10;
			this.lblTuning.Text = "Tuning";
			// 
			// cmbTuning
			// 
			this.cmbTuning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbTuning.FormattingEnabled = true;
			this.cmbTuning.Location = new System.Drawing.Point(632, 379);
			this.cmbTuning.Name = "cmbTuning";
			this.cmbTuning.Size = new System.Drawing.Size(140, 21);
			this.cmbTuning.TabIndex = 9;
			this.cmbTuning.SelectionChangeCommitted += new System.EventHandler(this.cmbTuning_SelectionChangeCommitted);
			// 
			// lblChord
			// 
			this.lblChord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblChord.AutoSize = true;
			this.lblChord.Location = new System.Drawing.Point(391, 382);
			this.lblChord.Name = "lblChord";
			this.lblChord.Size = new System.Drawing.Size(35, 13);
			this.lblChord.TabIndex = 8;
			this.lblChord.Text = "Chord";
			// 
			// cmbChord
			// 
			this.cmbChord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbChord.FormattingEnabled = true;
			this.cmbChord.Location = new System.Drawing.Point(431, 379);
			this.cmbChord.Name = "cmbChord";
			this.cmbChord.Size = new System.Drawing.Size(140, 21);
			this.cmbChord.TabIndex = 7;
			this.cmbChord.SelectionChangeCommitted += new System.EventHandler(this.cmbChord_SelectionChangeCommitted);
			// 
			// lblBase
			// 
			this.lblBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblBase.AutoSize = true;
			this.lblBase.Location = new System.Drawing.Point(202, 382);
			this.lblBase.Name = "lblBase";
			this.lblBase.Size = new System.Drawing.Size(31, 13);
			this.lblBase.TabIndex = 12;
			this.lblBase.Text = "Base";
			// 
			// cmbBase
			// 
			this.cmbBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbBase.FormattingEnabled = true;
			this.cmbBase.Location = new System.Drawing.Point(239, 379);
			this.cmbBase.Name = "cmbBase";
			this.cmbBase.Size = new System.Drawing.Size(140, 21);
			this.cmbBase.TabIndex = 11;
			this.cmbBase.SelectionChangeCommitted += new System.EventHandler(this.cmbBase_SelectionChangeCommitted);
			// 
			// frmChords
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.lblBase);
			this.Controls.Add(this.cmbBase);
			this.Controls.Add(this.lblTuning);
			this.Controls.Add(this.cmbTuning);
			this.Controls.Add(this.lblChord);
			this.Controls.Add(this.cmbChord);
			this.Controls.Add(this.lblPitch);
			this.Controls.Add(this.cmbPitch);
			this.Controls.Add(this.flpChords);
			this.Name = "frmChords";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chords";
			this.Load += new System.EventHandler(this.frmChords_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel flpChords;
		private System.Windows.Forms.Label lblPitch;
		private System.Windows.Forms.ComboBox cmbPitch;
		private System.Windows.Forms.Label lblTuning;
		private System.Windows.Forms.ComboBox cmbTuning;
		private System.Windows.Forms.Label lblChord;
		private System.Windows.Forms.ComboBox cmbChord;
		private System.Windows.Forms.Label lblBase;
		private System.Windows.Forms.ComboBox cmbBase;
	}
}