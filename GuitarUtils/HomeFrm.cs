using System;
using System.Windows.Forms;

namespace GuitarUtils
{
	public partial class HomeFrm : Form
	{
		public HomeFrm()
		{
			InitializeComponent();
		}

		private void ScalesBtn_Click(object sender, EventArgs e)
		{
			var scalesForm = new ScalesFrm();
			scalesForm.Show(this);
		}
	}
}
