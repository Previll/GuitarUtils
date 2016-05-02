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
	public partial class frmChords : Form
	{
		const float ImageWidth = 200.0f;
		const float ImageHeight = 300.0f;
		const int FretCount = 4;
		const int InstrumentFretCount = 24;

		bool _disableDrawChordsImage;

		public frmChords()
		{
			_disableDrawChordsImage = false;
			InitializeComponent();
		}

		/* Events */

		void frmChords_Load(object sender, EventArgs e)
		{
			PopulatePitchComboBox();
			PopulateBaseComboBox();
			PopulateChordComboBox();
			PopulateTuningComboBox();
			DrawChordsImages();
		}

		void cmbPitch_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_disableDrawChordsImage = true;
			this.cmbBase.SelectedValue = (Pitch)this.cmbPitch.SelectedValue;
			_disableDrawChordsImage = false;
			DrawChordsImages();
		}

		void cmbBase_SelectionChangeCommitted(object sender, EventArgs e)
		{
			DrawChordsImages();
		}

		void cmbChord_SelectionChangeCommitted(object sender, EventArgs e)
		{
			DrawChordsImages();
		}

		void cmbTuning_SelectionChangeCommitted(object sender, EventArgs e)
		{
			DrawChordsImages();
		}

		void flpChords_MouseUp(object sender, MouseEventArgs e)
		{
			this.flpChords.Focus();
		}

		void ptbChord_MouseUp(object sender, MouseEventArgs e)
		{
			this.flpChords.Focus();
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

		void PopulateBaseComboBox()
		{
			var pitches = from Pitch pitch in Enum.GetValues(typeof(Pitch))
						  select new { Name = pitch.GetLongName(), Pitch = pitch };
			this.cmbBase.DataSource = pitches.ToList();
			this.cmbBase.DisplayMember = "Name";
			this.cmbBase.ValueMember = "Pitch";
		}

		void PopulateChordComboBox()
		{
			this.cmbChord.DataSource = Program.Data.Chords;
			this.cmbChord.DisplayMember = "Name";
			this.cmbChord.ValueMember = "Intervals";
		}

		void PopulateTuningComboBox()
		{
			this.cmbTuning.DataSource = Program.Data.Tunings;
			this.cmbTuning.DisplayMember = "Name";
			this.cmbTuning.ValueMember = "Strings";
		}

		void DrawChordsImages()
		{
			if (_disableDrawChordsImage)
				return;

			var tuning = new Tuning(this.cmbTuning.SelectedText, (IEnumerable<string>)this.cmbTuning.SelectedValue);
			var pitchedChord = new PitchedChord((Pitch)this.cmbPitch.SelectedValue, (Pitch)this.cmbBase.SelectedValue, this.cmbChord.SelectedText, (IEnumerable<int>)this.cmbChord.SelectedValue);
			var instrument = new Instrument(tuning, InstrumentFretCount);
			var chordFinderOptions = new ChordFinderOptions { Instrument = instrument, MinFret = 0, MaxFret = FretCount, AllowRootlessChords = false, AllowMutedStrings = true, AllowOpenStrings = true };
			var chordFinder = new ChordFinder();
			var chordFingerings = chordFinder.FindChordFingerings(pitchedChord, chordFinderOptions);

			this.flpChords.Controls.Clear();
			foreach (var chordFingering in chordFingerings)
			{
				var ptbChord = new PictureBox
				{
					BorderStyle = BorderStyle.FixedSingle,
					Size = new Size(200, 300),
					Image = GetChordImage(instrument, pitchedChord.RootPitch, chordFingering, 200, 300)
				};
				ptbChord.MouseUp += this.ptbChord_MouseUp;
				this.flpChords.Controls.Add(ptbChord);
			}
		}

		Image GetChordImage(Instrument instrument, Pitch root, IEnumerable<NoteLocation> pitchLocations, float imageWidth, float imageHeight)
		{
			var bitmap = new Bitmap((int)imageWidth, (int)imageHeight);
			var chordBoxCanvas = new ChordBoxCanvas(new SizeF(imageWidth, imageHeight), instrument, FretCount);
			using (var graphics = Graphics.FromImage(bitmap))
			{
				graphics.FillRectangle(Brushes.White, 0.0f, 0.0f, imageWidth, imageHeight);
				chordBoxCanvas.DrawFrame(graphics);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				chordBoxCanvas.DrawChord(graphics, root, pitchLocations);
			}
			return bitmap;
		}
	}
}
