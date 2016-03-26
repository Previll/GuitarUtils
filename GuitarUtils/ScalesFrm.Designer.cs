namespace GuitarUtils
{
	partial class ScalesFrm
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
			this.ScalesPnl = new System.Windows.Forms.Panel();
			this.ScalesPtb = new System.Windows.Forms.PictureBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.ScalesPnl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ScalesPtb)).BeginInit();
			this.SuspendLayout();
			// 
			// ScalesPnl
			// 
			this.ScalesPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScalesPnl.AutoScroll = true;
			this.ScalesPnl.AutoScrollMargin = new System.Drawing.Size(20, 20);
			this.ScalesPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ScalesPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ScalesPnl.Controls.Add(this.ScalesPtb);
			this.ScalesPnl.Location = new System.Drawing.Point(13, 13);
			this.ScalesPnl.Name = "ScalesPnl";
			this.ScalesPnl.Size = new System.Drawing.Size(759, 360);
			this.ScalesPnl.TabIndex = 0;
			// 
			// ScalesPtb
			// 
			this.ScalesPtb.Location = new System.Drawing.Point(20, 20);
			this.ScalesPtb.Name = "ScalesPtb";
			this.ScalesPtb.Size = new System.Drawing.Size(3000, 300);
			this.ScalesPtb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ScalesPtb.TabIndex = 0;
			this.ScalesPtb.TabStop = false;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(13, 380);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// ScalesFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.ScalesPnl);
			this.Name = "ScalesFrm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Scales";
			this.Load += new System.EventHandler(this.ScalesFrm_Load);
			this.ScalesPnl.ResumeLayout(false);
			this.ScalesPnl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ScalesPtb)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel ScalesPnl;
		private System.Windows.Forms.PictureBox ScalesPtb;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}