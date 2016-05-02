using System.Collections.Generic;
using System.Drawing;
using GuitarUtils.Music;
using GuitarUtils.Drawing;
using System.Drawing.Drawing2D;
using System;

namespace GuitarUtils.Canvas
{
	class ChordBoxCanvas : CanvasBase
	{
		readonly Instrument _instrument;
		readonly int _fretCount;

		readonly float NoteMuteRadius;
		readonly Color NoteMuteColour;
		readonly Color NoteMuteOutlineColour;

		/* Constructors */

		public ChordBoxCanvas(SizeF canvasSize, Instrument instrument, int fretCount)
			: base(canvasSize, instrument.StringCount, fretCount)
		{
			_instrument = instrument;
			_fretCount = fretCount;
			NoteCircleColour = Color.FromArgb(255, 128, 128, 255);
			NoteCircleOutlineColour = Color.FromArgb(255, 0, 0, 128);
			NoteRootCircleColour = Color.FromArgb(255, 0, 0, 255);
			NoteRootCircleOutlineColour = Color.FromArgb(255, 0, 0, 128);
			NoteMuteRadius = Math.Min(CellSize.Width, CellSize.Height) * 0.4f;
			NoteMuteColour = Color.FromArgb(255, 128, 128, 255);
			NoteMuteOutlineColour = Color.FromArgb(255, 0, 0, 128);
		}

		/* Public Methods */

		public override void DrawFrame(Graphics graphics)
		{
			DrawGrid(graphics);
			DrawNut(graphics);
			DrawFretLabels(graphics);
			//DrawStrings(graphics);
			//DrawStringLabels(graphics);
		}

		public void DrawChord(Graphics graphics, Pitch scaleRoot, IEnumerable<NoteLocation> pitchLocations)
		{
			foreach (var pitchLocation in pitchLocations)
			{
				var posX = GridOffset.X + (pitchLocation.StringIndex * CellSize.Width);
				var posY = GridOffset.Y + (pitchLocation.FretIndex * CellSize.Height) - (pitchLocation.FretIndex > 0 ? CellSize.Height / 2 : 0); // Remove last bit to have points on end of cell
				var point = new PointF(posX, posY);

				if (!pitchLocation.IsMute)
				{
					DrawNoteCircle(graphics, point, pitchLocation.Note.Pitch == scaleRoot);
					DrawNoteLabel(graphics, point, pitchLocation.Note.Pitch.GetShortName());
				}
				else
				{
					DrawNoteMute(graphics, point);
				}
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
			for (int columnIndex = 0; columnIndex <= _instrument.StringCount; columnIndex++)
			{
				var posX = GridOffset.X + (CellSize.Width * columnIndex);
				var startPosY = GridOffset.Y;
				var endPosY = startPosY + (CellSize.Height * _fretCount);
				var line = new LineF(posX, startPosY, posX, endPosY);

				graphics.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
			}
		}

		void DrawGridRows(Graphics graphics)
		{
			using (var pen = new Pen(Color.Black, 2.0f))
			{
				for (int rowIndex = 0; rowIndex <= _fretCount; rowIndex++)
				{
					var posY = GridOffset.Y + (CellSize.Height * rowIndex);
					var startPosX = GridOffset.X;
					var endPosX = startPosX + (CellSize.Width * _instrument.StringCount);
					var line = new LineF(startPosX, posY, endPosX, posY);

					graphics.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
				}
			}
		}

		void DrawNut(Graphics graphics)
		{
			var nutOffset = new OffsetF(0f, 5.0f);
			var posY = GridOffset.Y + nutOffset.Y;
			var startPosX = GridOffset.X + nutOffset.X;
			var endPosX = startPosX + (CellSize.Width * _instrument.StringCount);
			var line = new LineF(startPosX, posY, endPosX, posY);

			graphics.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
		}

		void DrawFretLabels(Graphics graphics)
		{
			for (int fretIndex = 1; fretIndex <= _fretCount; fretIndex++)
			{
				var text = fretIndex.ToString();
				var textSize = graphics.MeasureString(text, FretboardFont);
				var textOffset = new OffsetF((textSize.Width / 2), -(textSize.Height / 2));

				var posX = textOffset.X;
				var posY = GridOffset.Y + textOffset.Y + (CellSize.Height * fretIndex);
				var point = new PointF(posX, posY);

				graphics.DrawString(text, FretboardFont, Brushes.Black, point);
			}
		}

		void DrawStrings(Graphics graphics)
		{
			var stringOffset = new OffsetF(CellSize.Width / 2, 0f);

			using (var stringPen = new Pen(Color.Gray, 2.0f))
			{
				stringPen.DashStyle = DashStyle.Dash;

				for (int columnIndex = 0; columnIndex < _instrument.StringCount; columnIndex++)
				{
					var posX = GridOffset.X + stringOffset.X + (CellSize.Width * columnIndex);
					var startPosY = GridOffset.Y + stringOffset.Y;
					var endPosY = startPosY + (CellSize.Height * _fretCount);
					var line = new LineF(posX, startPosY, posX, endPosY);

					graphics.DrawLine(stringPen, line.StartPoint, line.EndPoint);
				}
			}
		}

		void DrawStringLabels(Graphics graphics)
		{
			for (int columnIndex = 0; columnIndex < _instrument.StringCount; columnIndex++)
			{
				var text = _instrument.Strings[columnIndex].RootNote.ToString();
				var textSize = graphics.MeasureString(text, FretboardFont);
				var textOffset = new OffsetF((CellSize.Width - textSize.Width) / 2, (CellSize.Height - textSize.Height) / 2);

				var posX = GridOffset.X + textOffset.X + (CellSize.Width * columnIndex);
				var posY = textOffset.Y;
				var point = new PointF(posX, posY);

				graphics.DrawString(text, FretboardFont, Brushes.Black, point);
			}
		}

		void DrawNoteCircle(Graphics graphics, PointF point, bool isRoot)
		{
			var circleOffset = new OffsetF((CellSize.Width - NoteCircleRadius) / 2, -(NoteCircleRadius / 2));
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
			var textOffset = new OffsetF((CellSize.Width - textSize.Width) / 2, -(textSize.Height / 2));

			var posX = point.X + textOffset.X;
			var posY = point.Y + textOffset.Y;

			graphics.DrawString(text, NoteFont, Brushes.Black, posX, posY);
		}

		void DrawNoteMute(Graphics graphics, PointF point)
		{
			var crossOffset = new OffsetF(CellSize.Width  / 2, 0f);
			var posX = point.X + crossOffset.X;
			var posY = point.Y + crossOffset.Y;

			using (var pen = new Pen(NoteMuteOutlineColour, 4.0f))
			{
				graphics.DrawLine(pen, posX + NoteMuteRadius + 1, posY + NoteMuteRadius + 1, posX - NoteMuteRadius - 1, posY - NoteMuteRadius - 1);
				graphics.DrawLine(pen, posX + NoteMuteRadius + 1, posY - NoteMuteRadius - 1, posX - NoteMuteRadius - 1, posY + NoteMuteRadius + 1);
			}
			using (var pen = new Pen(NoteMuteColour, 2.0f))
			{
				graphics.DrawLine(pen, posX + NoteMuteRadius, posY + NoteMuteRadius, posX - NoteMuteRadius, posY - NoteMuteRadius);
				graphics.DrawLine(pen, posX + NoteMuteRadius, posY - NoteMuteRadius, posX - NoteMuteRadius, posY + NoteMuteRadius);
			}
		}
	}
}
