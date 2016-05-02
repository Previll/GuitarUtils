using System;
using System.Windows.Forms;

namespace GuitarUtils.Forms
{
	public partial class frmHome : Form
	{
		public frmHome()
		{
			InitializeComponent();
		}

		void ScalesBtn_Click(object sender, EventArgs e)
		{
			var scalesForm = new frmScales();
			scalesForm.Show(this);
		}

		private void btnChords_Click(object sender, EventArgs e)
		{
			var chordsForm = new frmChords();
			chordsForm.Show(this);
		}
	}
}
