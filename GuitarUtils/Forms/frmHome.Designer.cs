namespace GuitarUtils.Forms
{
	partial class frmHome
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
			this.btnScales = new System.Windows.Forms.Button();
			this.btnChords = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnScales
			// 
			this.btnScales.Location = new System.Drawing.Point(339, 12);
			this.btnScales.Name = "btnScales";
			this.btnScales.Size = new System.Drawing.Size(185, 34);
			this.btnScales.TabIndex = 0;
			this.btnScales.Text = "Scales";
			this.btnScales.UseVisualStyleBackColor = true;
			this.btnScales.Click += new System.EventHandler(this.ScalesBtn_Click);
			// 
			// btnChords
			// 
			this.btnChords.Location = new System.Drawing.Point(339, 68);
			this.btnChords.Name = "btnChords";
			this.btnChords.Size = new System.Drawing.Size(185, 34);
			this.btnChords.TabIndex = 1;
			this.btnChords.Text = "Chords";
			this.btnChords.UseVisualStyleBackColor = true;
			this.btnChords.Click += new System.EventHandler(this.btnChords_Click);
			// 
			// frmHome
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 443);
			this.Controls.Add(this.btnChords);
			this.Controls.Add(this.btnScales);
			this.Name = "frmHome";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Guitar Utils";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnScales;
		private System.Windows.Forms.Button btnChords;
	}
}

