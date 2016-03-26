using GuitarUtils.Canvases;
using GuitarUtils.Music;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GuitarUtils
{
	public partial class ScalesFrm : Form
	{
		const float ScalesImageWidth = 2000.0f;
		const float ScalesImageHeight = 300.0f;
		const int FretCount = 24;
		const string FontName = "Arial";

		public ScalesFrm()
		{
			InitializeComponent();
		}

		void ScalesFrm_Load(object sender, EventArgs e)
		{
			var tuning = new[] { new Note(Pitch.E, 4), new Note(Pitch.B, 3), new Note(Pitch.G, 3), new Note(Pitch.D, 3), new Note(Pitch.A, 2), new Note(Pitch.E, 2) };
			var scaleModel = Program.Data.Scales[0];

			var scale = new Scale(scaleModel.Name ,Pitch.A, scaleModel.Intervals);

			this.ScalesPtb.Image = DrawScalesImage(tuning, scale);
		}

		Image DrawScalesImage(IList<Note> tuning, Scale scale)
		{
			//var cellSize = GetCellSize();    // left column for text, 2 padding and top row for text
			var bitmap = new Bitmap((int)ScalesImageWidth, (int)ScalesImageHeight);

			using (var graphics = Graphics.FromImage(bitmap))
			{
				graphics.SmoothingMode = SmoothingMode.HighQuality;

				graphics.FillRectangle(Brushes.White, 0.0f, 0.0f, ScalesImageWidth, ScalesImageHeight);

				var canvasSize = new SizeF(ScalesImageWidth - 30.0f, ScalesImageHeight - 30.0f);
				var fretboardCanvas = new FretboardCanvas(canvasSize, FretCount, tuning, FontName);
				fretboardCanvas.Draw(graphics);
				fretboardCanvas.DrawScale(graphics, scale);
			}
			return bitmap;
		}
	}
}
