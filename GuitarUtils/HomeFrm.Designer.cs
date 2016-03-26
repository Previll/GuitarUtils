namespace GuitarUtils
{
	partial class HomeFrm
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
			this.ScalesBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ScalesBtn
			// 
			this.ScalesBtn.Location = new System.Drawing.Point(339, 12);
			this.ScalesBtn.Name = "ScalesBtn";
			this.ScalesBtn.Size = new System.Drawing.Size(185, 34);
			this.ScalesBtn.TabIndex = 0;
			this.ScalesBtn.Text = "Scales";
			this.ScalesBtn.UseVisualStyleBackColor = true;
			this.ScalesBtn.Click += new System.EventHandler(this.ScalesBtn_Click);
			// 
			// HomeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 443);
			this.Controls.Add(this.ScalesBtn);
			this.Name = "HomeForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Guitar Utils";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ScalesBtn;
	}
}

