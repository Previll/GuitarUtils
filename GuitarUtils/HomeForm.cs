using System;
using System.Windows.Forms;

namespace GuitarUtils
{
	public partial class HomeForm : Form
	{
		public HomeForm()
		{
			InitializeComponent();

			var img = new ChordBoxImage("D", "xx0232", "---132", "5");
			this.pictureBox1.Image = img.GetBitmap();
		}
	}
}
