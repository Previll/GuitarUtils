using GuitarUtils.Drawing;
using GuitarUtils.Music;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GuitarUtils.Canvas
{
	class FretboardCanvas : CanvasBase
	{
		readonly Instrument _instrument;

		/* Constructors */

		public FretboardCanvas(SizeF canvasSize, Instrument instrument)
			: base(canvasSize, instrument.FretCount, instrument.StringCount)
		{
			_instrument = instrument;
			NoteCircleColour = Color.FromArgb(255, 255, 128, 128);
			NoteCircleOutlineColour = Color.FromArgb(255, 128, 0, 0);
			NoteRootCircleColour = Color.FromArgb(255, 255, 0, 0);
			NoteRootCircleOutlineColour = Color.FromArgb(255, 128, 0, 0);
		}

		/* Public Methods */

		public override void DrawFrame(Graphics graphics)
		{
			DrawGrid(graphics);
			DrawNut(graphics);
			DrawFretLabels(graphics);
			DrawStrings(graphics);
			DrawStringLabels(graphics);
		}

		public void DrawScale(Graphics graphics, Pitch scaleRoot, IEnumerable<NoteLocation> pitchLocations)
		{
			foreach (var pitchLocation in pitchLocations)
			{
				var posX = GridOffset.X + (pitchLocation.FretIndex * CellSize.Width) - (pitchLocation.FretIndex > 0 ? CellSize.Width / 2 : 0); // Remove last bit to have points on end of cell
				var posY = GridOffset.Y + ((_instrument.StringCount - pitchLocation.StringIndex - 1) * CellSize.Height);		// Again cuz we draw upside down
				var point = new PointF(posX, posY);

				DrawNoteCircle(graphics, point, pitchLocation.Note.Pitch == scaleRoot);
				DrawNoteLabel(graphics, point, pitchLocation.Note.Pitch.GetShortName());
			}
		}

		/* Private Methods */

		void DrawGrid(Graphics graphics)
		{
			DrawGridColumns(graphics);
			DrawGridRows(graphics);
		}

		void DrawGridColumns(Graphics graphics)
		{
			using (var pen = new Pen(Color.Black, 2.0f))
			{
				for (int columnIndex = 0; columnIndex <= _instrument.FretCount; columnIndex++)
				{
					var posX = GridOffset.X + (CellSize.Width * columnIndex);
					var startPosY = GridOffset.Y;
					var endPosY = startPosY + (CellSize.Height * _instrument.StringCount);
					var line = new LineF(posX, startPosY, posX, endPosY);

					graphics.DrawLine(pen, line.StartPoint, line.EndPoint);
				}
			}
		}

		void DrawGridRows(Graphics graphics)
		{
			for (int rowIndex = 0; rowIndex <= _instrument.StringCount; rowIndex++)
			{
				var posY = GridOffset.Y + (CellSize.Height * rowIndex);
				var startPosX = GridOffset.X;
				var endPosX = startPosX + (CellSize.Width * _instrument.FretCount);
				var line = new LineF(startPosX, posY, endPosX, posY);

				graphics.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
			}
		}

		void DrawNut(Graphics graphics)
		{
			var nutOffset = new OffsetF(5.0f, 0f);

			var posX = GridOffset.X + nutOffset.X;
			var startPosY = GridOffset.Y + nutOffset.Y;
			var endPosY = startPosY + (CellSize.Height * _instrument.StringCount);
			var line = new LineF(posX, startPosY, posX, endPosY);

			graphics.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
		}

		void DrawFretLabels(Graphics graphics)
		{
			for (int fretIndex = 1; fretIndex <= _instrument.FretCount; fretIndex++)
			{
				var text = fretIndex.ToString();
				var textSize = graphics.MeasureString(text, FretboardFont);
				var textOffset = new OffsetF(-(textSize.Width / 2), 0f);

				var posX = GridOffset.X + textOffset.X + (CellSize.Width * fretIndex);
				var posY = textOffset.Y;
				var point = new PointF(posX, posY);

				graphics.DrawString(text, FretboardFont, Brushes.Black, point);
			}
		}

		void DrawStrings(Graphics graphics)
		{
			var stringOffset = new OffsetF(0f, CellSize.Height / 2);

			using (var stringPen = new Pen(Color.Gray, 2.0f))
			{
				stringPen.DashStyle = DashStyle.Dash;

				for (int rowIndex = 0; rowIndex < _instrument.StringCount; rowIndex++)
				{
					var posY = GridOffset.Y + stringOffset.Y + (CellSize.Height * rowIndex);
					var startPosX = GridOffset.X + stringOffset.X;
					var endPosX = startPosX + (CellSize.Width * _instrument.FretCount);
					var line = new LineF(startPosX, posY, endPosX, posY);

					graphics.DrawLine(stringPen, line.StartPoint, line.EndPoint);
				}
			}
		}

		void DrawStringLabels(Graphics graphics)
		{
			for (int rowIndex = 0; rowIndex < _instrument.StringCount; rowIndex++)
			{
				var text = _instrument.Strings[_instrument.StringCount - 1 - rowIndex].RootNote.ToString(); // we draw the instrument upside down
				var textSize = graphics.MeasureString(text, FretboardFont);
				var textOffset = new OffsetF((CellSize.Width - textSize.Width) / 2, (CellSize.Height - textSize.Height) / 2);

				var posX = textOffset.X;
				var posY = GridOffset.Y + textOffset.Y + (CellSize.Height * rowIndex);
				var point = new PointF(posX, posY);

				graphics.DrawString(text, FretboardFont, Brushes.Black, point);
			}
		}

		void DrawNoteCircle(Graphics graphics, PointF point, bool isRoot)
		{
			var circleOffset = new OffsetF(-(NoteCircleRadius / 2), (CellSize.Height - NoteCircleRadius) / 2);
			var posX = point.X + circleOffset.X;
			var posY = point.Y + circleOffset.Y;

			using (var brush = new SolidBrush(isRoot ? NoteRootCircleColour : NoteCircleColour))
				graphics.FillEllipse(brush, posX, posY, NoteCircleRadius, NoteCircleRadius);
			using (var pen = new Pen(isRoot ? NoteRootCircleOutlineColour : NoteCircleOutlineColour, 2.0f))
				graphics.DrawEllipse(pen, posX, posY, NoteCircleRadius, NoteCircleRadius);
		}

		void DrawNoteLabel(Graphics graphics, PointF point, string text)
		{
			var textSize = graphics.MeasureString(text, NoteFont);
			var textOffset = new OffsetF(-(textSize.Width / 2), (CellSize.Height - textSize.Height) / 2);

			var posX = point.X + textOffset.X;
			var posY = point.Y + textOffset.Y;

			graphics.DrawString(text, NoteFont, Brushes.Black, posX, posY);
		}

	}
}
