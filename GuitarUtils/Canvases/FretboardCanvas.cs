using GuitarUtils.Drawing;
using GuitarUtils.Music;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace GuitarUtils.Canvases
{
	class FretboardCanvas
	{
		readonly SizeF _cellSize;
		readonly OffsetF _gridOffset;
		readonly IList<Note> _tuning;
		readonly int _fretCount;
		readonly Font _fretboardFont;
		readonly Font _scaleFont;
		readonly IDictionary<Note, IList<Point>> _noteLocations;

		public FretboardCanvas(SizeF canvasSize, int fretCount, IList<Note> tuning, string fontName)
		{
			_cellSize = GetCellSize(canvasSize, fretCount, tuning.Count);
			_gridOffset = new OffsetF(_cellSize.Width, _cellSize.Height);   // 1 row and col for labels
			_fretCount = fretCount;
			_tuning = tuning;
			_fretboardFont = GetFretboardFont(_cellSize, fontName);
			_scaleFont = GetScaleFont(_cellSize, fontName);
			_noteLocations = GetNoteLocations(fretCount, tuning);
		}

		public void Draw(Graphics graphics)
		{
			DrawGrid(graphics);
			DrawNut(graphics);
			DrawFretLabels(graphics);
			DrawStrings(graphics);
			DrawStringLabels(graphics);
		}

		public void DrawScale(Graphics graphics, Scale scale)
		{
			var radius = _cellSize.Height * 0.8f;
			foreach (var pitch in scale.Distinct())
			{
				var pitchLocations = _noteLocations.Where(kvp => kvp.Key.Pitch == pitch).SelectMany(kvp => kvp.Value).ToList();
				foreach (var pitchLocation in pitchLocations)
				{
					var posX = _gridOffset.X + (pitchLocation.X * _cellSize.Width);
					var posY = _gridOffset.Y + (pitchLocation.Y * _cellSize.Height);
					var point = new PointF(posX, posY);

					DrawScaleCircle(graphics, point, radius);
					DrawScaleLabel(graphics, point, PitchHelper.GetName(pitch));
				}
			}
		}

		void DrawScaleCircle(Graphics graphics, PointF point, float radius)
		{
			var offset = new OffsetF(-(radius / 2), (_cellSize.Height - radius) / 2);
			var posX = point.X + offset.X;
			var posY = point.Y + offset.Y;

			graphics.FillEllipse(Brushes.Red, posX, posY, radius, radius);
			using (var pen = new Pen(Color.DarkRed, 2.0f))
				graphics.DrawEllipse(pen, posX, posY, radius, radius);
		}

		void DrawScaleLabel(Graphics graphics, PointF point, string text)
		{
			var fontSize = graphics.MeasureString(text, _scaleFont);
			var offset = new OffsetF(-(fontSize.Width / 2), (_cellSize.Height - fontSize.Height) / 2);
			var posX = point.X + offset.X;
			var posY = point.Y + offset.Y;

			graphics.DrawString(text, _scaleFont, Brushes.Black, posX, posY);
		}

		static SizeF GetCellSize(SizeF canvasSize, int fretCount, int stringCount)
		{
			var cellWidth = (canvasSize.Width / (1 + fretCount));
			var cellHeight = (canvasSize.Height / (1 + stringCount));
			var cellSize = new SizeF(cellWidth, cellHeight);
			return cellSize;
		}

		static Font GetFretboardFont(SizeF cellSize, string fontName)
		{
			var fontSize = Math.Min(cellSize.Width, cellSize.Height) * 0.7f;
			var font = new Font(fontName, fontSize, GraphicsUnit.Pixel);
			return font;
		}

		static Font GetScaleFont(SizeF cellSize, string fontName)
		{
			var fontSize = Math.Min(cellSize.Width, cellSize.Height) * 0.5f;
			var font = new Font(fontName, fontSize, GraphicsUnit.Pixel);
			return font;
		}

		static IDictionary<Note, IList<Point>> GetNoteLocations(int fretCount, IList<Note> tuning)
		{
			var noteLocations = new Dictionary<Note, IList<Point>>();
			for (int stringIndex = 0; stringIndex < tuning.Count; stringIndex++)
			{
				var rootNote = tuning[stringIndex];
				for (int fretIter = 0; fretIter < fretCount; fretIter++)
				{
					var note = new Note(rootNote);
					note += fretIter;
					var location = new Point(fretIter, stringIndex);

					if (noteLocations.ContainsKey(note))
						noteLocations[note].Add(location);
					else
						noteLocations.Add(note, new List<Point> { location });
				}
			}
			return noteLocations;
		}

		void DrawGrid(Graphics graphics)
		{
			DrawGridColumns(graphics);
			DrawGridRows(graphics);
		}

		void DrawGridColumns(Graphics graphics)
		{
			using (var pen = new Pen(Color.Black, 2.0f))
			{
				for (int columnIndex = 0; columnIndex <= _fretCount; columnIndex++)
				{
					var posX = _gridOffset.X + (_cellSize.Width * columnIndex);
					var startPosY = _gridOffset.Y;
					var endPosY = _gridOffset.Y + (_cellSize.Height * _tuning.Count);
					var line = new LineF(posX, startPosY, posX, endPosY);


					graphics.DrawLine(pen, line.StartPoint, line.EndPoint);
				}
			}
		}

		void DrawGridRows(Graphics graphics)
		{
			for (int rowIndex = 0; rowIndex <= _tuning.Count; rowIndex++)
			{
				var posY = _gridOffset.Y + (_cellSize.Height * rowIndex);
				var startPosX = _gridOffset.X;
				var endPosX = _gridOffset.X + (_cellSize.Width * _fretCount);
				var line = new LineF(startPosX, posY, endPosX, posY);

				graphics.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
			}
		}

		void DrawNut(Graphics graphics)
		{
			var nutOffset = new OffsetF(5.0f, 0f);

			var posX = _gridOffset.X + nutOffset.X;
			var startPosY = _gridOffset.Y + nutOffset.Y;
			var endPosY = _gridOffset.Y + nutOffset.Y + (_cellSize.Height * _tuning.Count);
			var line = new LineF(posX, startPosY, posX, endPosY);

			graphics.DrawLine(Pens.Black, line.StartPoint, line.EndPoint);
		}

		void DrawFretLabels(Graphics graphics)
		{
			for (int fretIndex = 1; fretIndex <= _fretCount; fretIndex++)
			{
				var text = fretIndex.ToString();
				var textSize = graphics.MeasureString(text, _fretboardFont);

				var offset = new OffsetF(-(textSize.Width / 2), 0f);
				var posX = _gridOffset.X + offset.X + (_cellSize.Width * fretIndex);
				var posY = offset.Y;
				var point = new PointF(posX, posY);

				graphics.DrawString(text, _fretboardFont, Brushes.Black, point);
			}
		}

		void DrawStrings(Graphics graphics)
		{
			var offset = new OffsetF(0f, _cellSize.Height / 2);

			using (var stringPen = new Pen(Color.Gray, 2.0f))
			{
				stringPen.DashStyle = DashStyle.Dash;

				for (int rowIndex = 0; rowIndex < _tuning.Count; rowIndex++)
				{
					var posY = _gridOffset.Y + offset.Y + (_cellSize.Height * rowIndex);
					var startPosX = _gridOffset.X + offset.X;
					var endPosX = _gridOffset.X + offset.X + (_cellSize.Width * _fretCount);
					var line = new LineF(startPosX, posY, endPosX, posY);

					graphics.DrawLine(stringPen, line.StartPoint, line.EndPoint);
				}
			}
		}

		void DrawStringLabels(Graphics graphics)
		{
			for (int rowIndex = 0; rowIndex < _tuning.Count; rowIndex++)
			{
				var text = _tuning[rowIndex].ToString();
				var textSize = graphics.MeasureString(text, _fretboardFont);

				var offset = new OffsetF((_cellSize.Width - textSize.Width) / 2, (_cellSize.Height - textSize.Height) / 2);
				var posX = offset.X;
				var posY = _gridOffset.Y + offset.Y + (_cellSize.Height * rowIndex);
				var point = new PointF(posX, posY);

				graphics.DrawString(text, _fretboardFont, Brushes.Black, point);
			}
		}
	}
}
