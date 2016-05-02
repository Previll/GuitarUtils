using GuitarUtils.Forms;
using GuitarUtils.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace GuitarUtils
{
	static class Program
	{
		public static Data Data;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Data = DataSerializer.ReadFromJson(Path.Combine(Environment.CurrentDirectory, "Data.json"));
			Application.Run(new frmHome());
		}
	}
}
