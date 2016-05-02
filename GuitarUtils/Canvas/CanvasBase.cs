using GuitarUtils.Drawing;
using GuitarUtils.Music;
using System;
using System.Drawing;

namespace GuitarUtils.Canvas
{
	abstract class CanvasBase
	{
		const string FontName = "Arial";

		protected readonly SizeF CellSize;
		protected readonly OffsetF GridOffset;
		protected readonly Font FretboardFont;
		protected readonly Font NoteFont;
		protected readonly float NoteCircleRadius;

		protected Color NoteCircleColour;
		protected Color NoteCircleOutlineColour;
		protected Color NoteRootCircleColour;
		protected Color NoteRootCircleOutlineColour;

		/* Constructors */

		protected CanvasBase(SizeF canvasSize, int xCellCount, int yCellCount)
		{
			CellSize = GetCellSize(canvasSize, xCellCount, yCellCount);
			GridOffset = new OffsetF(CellSize.Width, CellSize.Height);   // 1 row and col for labels
			FretboardFont = GetFretboardFont(CellSize, FontName);
			NoteFont = GetNoteFont(CellSize, FontName);
			NoteCircleRadius = Math.Min(CellSize.Width, CellSize.Height) * 0.8f;
		}

		/* Public Methods */

		public abstract void DrawFrame(Graphics graphics);
		
		/* Private Methods */

		static SizeF GetCellSize(SizeF canvasSize, int xCellCount, int yCellCount)
		{
			var cellWidth = (canvasSize.Width / (2 + xCellCount));     // 1 padding on left and right
			var cellHeight = (canvasSize.Height / (2 + yCellCount));   // 1 padding on top and bottom
			var cellSize = new SizeF(cellWidth, cellHeight);
			return cellSize;
		}
		
		static Font GetFretboardFont(SizeF cellSize, string fontName)
		{
			var fontSize = Math.Min(cellSize.Width, cellSize.Height) * 0.7f;
			var font = new Font(fontName, fontSize, GraphicsUnit.Pixel);
			return font;
		}

		static Font GetNoteFont(SizeF cellSize, string fontName)
		{
			var fontSize = Math.Min(cellSize.Width, cellSize.Height) * 0.5f;
			var font = new Font(fontName, fontSize, GraphicsUnit.Pixel);
			return font;
		}
	}
}
