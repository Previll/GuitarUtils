using GuitarUtils.Canvas;
using GuitarUtils.Music;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;

namespace GuitarUtils.Forms
{
	public partial class frmScales : Form
	{
		bool _disableDrawScalesImage;

		public frmScales()
		{
			_disableDrawScalesImage = false;
			InitializeComponent();
		}

		/* Events */

		void frmScales_Load(object sender, EventArgs e)
		{
			PopulatePitchComboBox();
			PopulateScaleComboBox();
			PopulateTuningComboBox();
			PopulateZoomNumericUpDown();
			PopulateStartNumericUpDown();
			PopulateEndNumericUpDown();
			PopulateScaleRunNumericUpDown();
			DrawScalesImage();
		}

		void cmbPitch_SelectionChangeCommitted(object sender, EventArgs e)
		{
			DrawScalesImage();
		}

		void cmbScale_SelectionChangeCommitted(object sender, EventArgs e)
		{
			DrawScalesImage();
		}

		void cmbTuning_SelectionChangeCommitted(object sender, EventArgs e)
		{
			DrawScalesImage();
		}

		void nudFretCount_ValueChanged(object sender, EventArgs e)
		{
			_disableDrawScalesImage = true;
			this.nudEnd.Maximum = this.nudFretCount.Value;
			this.nudScaleRun.Maximum = this.nudFretCount.Value;
			_disableDrawScalesImage = false;
			DrawScalesImage();
		}

		void nudZoom_ValueChanged(object sender, EventArgs e)
		{
			this.ptbScales.Width = (int)this.nudZoom.Value;
			DrawScalesImage();
		}

		void nudStart_ValueChanged(object sender, EventArgs e)
		{
			this.nudEnd.Minimum = this.nudStart.Value;
			DrawScalesImage();
		}

		void nudEnd_ValueChanged(object sender, EventArgs e)
		{
			this.nudStart.Maximum = this.nudEnd.Value;
			DrawScalesImage();
		}

		void cbxScaleRun_CheckedChanged(object sender, EventArgs e)
		{
			DrawScalesImage();
		}

		void nudScaleRun_ValueChanged(object sender, EventArgs e)
		{
			DrawScalesImage();
		}

		void btnExport_Click(object sender, EventArgs e)
		{

		}

		/* Private */

		void PopulatePitchComboBox()
		{
			var pitches = from Pitch pitch in Enum.GetValues(typeof(Pitch))
						  select new { Name = pitch.GetLongName(), Pitch = pitch };
			this.cmbPitch.DataSource = pitches.ToList();
			this.cmbPitch.DisplayMember = "Name";
			this.cmbPitch.ValueMember = "Pitch";
		}

		void PopulateScaleComboBox()
		{
			this.cmbScale.DataSource = Program.Data.Scales;
			this.cmbScale.DisplayMember = "Name";
			this.cmbScale.ValueMember = "Intervals";
		}

		void PopulateTuningComboBox()
		{
			this.cmbTuning.DataSource = Program.Data.Tunings;
			this.cmbTuning.DisplayMember = "Name";
			this.cmbTuning.ValueMember = "Strings";
		}

		void PopulateZoomNumericUpDown()
		{
			this.nudZoom.Value = this.ptbScales.Width;
		}

		void PopulateStartNumericUpDown()
		{
			this.nudStart.Minimum = 0m;
			this.nudStart.Maximum = this.nudFretCount.Value;
			this.nudStart.Value = 0m;
		}

		void PopulateEndNumericUpDown()
		{
			this.nudEnd.Minimum = 0m;
			this.nudEnd.Maximum = this.nudFretCount.Value;
			this.nudEnd.Value = this.nudFretCount.Value;
		}

		void PopulateScaleRunNumericUpDown()
		{
			this.nudScaleRun.Maximum = this.nudFretCount.Value;
		}

		void DrawScalesImage()
		{
			if (_disableDrawScalesImage)
				return;

			var tuning = new Tuning(this.cmbTuning.SelectedText, (IEnumerable<string>)this.cmbTuning.SelectedValue);
			var pitchedScale = new PitchedScale((Pitch)this.cmbPitch.SelectedValue, this.cmbScale.SelectedText, (IEnumerable<int>)this.cmbScale.SelectedValue);
			var instrument = new Instrument(tuning, (int)this.nudFretCount.Value);
			var noteLocations = this.cbxScaleRun.Checked
				? instrument.GetScaleRunNoteLocations(pitchedScale, (int)this.nudScaleRun.Value, (int)this.nudStart.Value, (int)this.nudEnd.Value)
				: instrument.GetNoteLocations(pitchedScale, (int)this.nudStart.Value, (int)this.nudEnd.Value);
			
			this.ptbScales.Image = GetScalesImage(instrument, pitchedScale.RootPitch, noteLocations, this.ptbScales.Width, this.ptbScales.Height);
		}
		
		Image GetScalesImage(Instrument instrument, Pitch scaleRoot, IEnumerable<NoteLocation> pitchLocations, int imageWidth, int imageHeight)
		{
			var bitmap = new Bitmap(imageWidth, imageHeight);
			var fretboardCanvas = new FretboardCanvas(new SizeF(imageWidth, imageHeight), instrument);

			using (var graphics = Graphics.FromImage(bitmap))
			{
				graphics.FillRectangle(Brushes.White, 0.0f, 0.0f, imageWidth, imageHeight);
				fretboardCanvas.DrawFrame(graphics);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				fretboardCanvas.DrawScale(graphics, scaleRoot, pitchLocations);
			}
			return bitmap;
		}
	}
}
