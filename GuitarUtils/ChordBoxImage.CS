using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace GuitarUtils
{
	class ChordBoxImage : IDisposable
	{

		#region Constants

		const char NO_FINGER = '-';
		const char THUMB = 'T';
		const char INDEX_FINGER = '1';
		const char MIDDLE_FINGER = '2';
		const char RING_FINGER = '3';
		const char LITTLE_FINGER = '4';
		const int OPEN = 0;
		const int MUTED = -1;
		const int FRET_COUNT = 5;
		const string FONT_NAME = "Arial";

		#endregion

		static readonly Brush ForegroundBrush = Brushes.Black;
		static readonly Brush BackgroundBrush = Brushes.White;

		#region Fields
		private Bitmap _bitmap;
		private Graphics _graphics;

		private int _size;
		private int[] _chordPositions;
		private char[] _fingers;
		private string _name;   //chord name

		private float _fretWidth;
		private int _lineWidth;
		private float _boxWidth;
		private float _boxHeight;

		private int _imageWidth;
		private int _imageHeight;
		private float _xstart; //upper corner of the chordbox
		private float _ystart;
		private float _nutHeight;

		private int _dotWidth;
		private float _signWidth;
		private float _signRadius;

		//Different font sizes
		private float _fretFontSize;
		private float _fingerFontSize;
		private float _nameFontSize;
		private float _superScriptFontSize;
		private float _markerWidth;

		private int _baseFret;

		#endregion

		private struct Bar { public int Str, Pos, Length; public char Finger; }

		/* Constructor */

		public ChordBoxImage(string name, string chord, string fingers, string size)
		{
			_name = (name == null) ? "" : name.Replace(" ", "");
			_chordPositions = ParseChordPositions(chord);
			_baseFret = ParseBaseFret(chord);
			_fingers = ParseFingers(fingers);
			_size = ParseSize(size);
			InitializeSizes();
			CreateImage();
		}

		/* Public methods */

		public void Save(Stream output)
		{
			_bitmap.Save(output, ImageFormat.Png);
		}

		public byte[] GetBytes()
		{
			using (var ms = new MemoryStream())
			{
				Save(ms);
				ms.Seek(0, SeekOrigin.Begin);
				byte[] buffer = new byte[ms.Length];
				ms.Read(buffer, 0, buffer.Length);
				return buffer;
			}
		}

		public Bitmap GetBitmap()
		{
			return _bitmap;
		}

		public void Dispose()
		{
			_bitmap.Dispose();
		}

		/* Private methods */

		private void InitializeSizes()
		{
			_fretWidth = 4 * _size;
			_nutHeight = _fretWidth / 2f;
			_lineWidth = (int)Math.Ceiling(_size * 0.31);
			_dotWidth = (int)Math.Ceiling(0.9 * _fretWidth);
			_markerWidth = 0.7f * _fretWidth;
			_boxWidth = 5 * _fretWidth + 6 * _lineWidth;
			_boxHeight = FRET_COUNT * (_fretWidth + _lineWidth) + _lineWidth;

			//Find out font sizes
			FontFamily family = new FontFamily(FONT_NAME);
			float perc = family.GetCellAscent(FontStyle.Regular) / (float)family.GetLineSpacing(FontStyle.Regular);
			_fretFontSize = _fretWidth / perc;
			_fingerFontSize = _fretWidth * 0.8f;
			_nameFontSize = _fretWidth * 2f / perc;
			_superScriptFontSize = 0.7f * _nameFontSize;
			if (_size == 1)
			{
				_nameFontSize += 2;
				_fingerFontSize += 2;
				_fretFontSize += 2;
				_superScriptFontSize += 2;
			}

			_xstart = _fretWidth;
			_ystart = (float)Math.Round(0.2f * _superScriptFontSize + _nameFontSize + _nutHeight + 1.7f * _markerWidth);

			_imageWidth = (int)(_boxWidth + 5 * _fretWidth);
			_imageHeight = (int)(_boxHeight + _ystart + _fretWidth + _fretWidth);

			_signWidth = (int)(_fretWidth * 0.75);
			_signRadius = _signWidth / 2;
		}

		private int ParseSize(string size)
		{
			if (size == null)
			{
				return 1;
			}
			else {
				double dsize;
				if (double.TryParse(size, out dsize))
				{
					dsize = Math.Round(dsize, 0);
					return Convert.ToInt32(Math.Min(Math.Max(1, dsize), 10));
				}
				else {
					return 1;
				}
			}
		}

		private char[] ParseFingers(string fingers)
		{
			if (fingers == null)
			{
				return new char[] { NO_FINGER, NO_FINGER, NO_FINGER, NO_FINGER, NO_FINGER, NO_FINGER }; //Allowed to not specify fingers
			}
			else if (!Regex.IsMatch(fingers, @"[tT\-1234]{6}"))
			{
				throw new Exception("Invalid fingers, " + fingers);
			}
			else {
				return fingers.ToUpper().ToCharArray();
			}
		}

		private int[] ParseChordPositions(string chord)
		{
			if (chord == null || !Regex.IsMatch(chord, @"[\dxX]{6}|((1|2)?[\dxX]-){5}(1|2)?[\dxX]"))
			{
				throw new Exception("Invalid chord, " + chord);
			}

			string[] parts = GetChordParts(chord);

			int maxFret = 0;
			int minFret = int.MaxValue;
			var chordPositions = new int[6];

			for (int i = 0; i < 6; i++)
			{
				if (parts[i].ToUpper() == "X")
				{
					chordPositions[i] = MUTED;
				}
				else
				{
					chordPositions[i] = int.Parse(parts[i]);

					maxFret = Math.Max(maxFret, chordPositions[i]);
					if (chordPositions[i] != 0)
					{
						minFret = Math.Min(minFret, chordPositions[i]);
					}
				}
			}
			if (maxFret <= 5)
			{
				_baseFret = 1;
			}
			else
			{
				_baseFret = minFret;
			}
			return chordPositions;
		}

		private int ParseBaseFret(string chord)
		{
			if (chord == null || !Regex.IsMatch(chord, @"[\dxX]{6}|((1|2)?[\dxX]-){5}(1|2)?[\dxX]"))
			{
				throw new Exception("Invalid chord, " + chord);
			}

			string[] parts = GetChordParts(chord);

			int maxFret = 0;
			int minFret = int.MaxValue;
			var chordPositions = new int[6];

			for (int i = 0; i < 6; i++)
			{
				if (parts[i].ToUpper() == "X")
				{
					chordPositions[i] = MUTED;
				}
				else
				{
					chordPositions[i] = int.Parse(parts[i]);

					maxFret = Math.Max(maxFret, chordPositions[i]);
					if (chordPositions[i] != 0)
					{
						minFret = Math.Min(minFret, chordPositions[i]);
					}
				}
			}
			if (maxFret <= 5)
			{
				return 1;
			}
			else
			{
				return minFret;
			}
		}

		private static string[] GetChordParts(string chord)
		{
			string[] parts;
			if (chord.Length > 6)
			{
				parts = chord.Split('-');
			}
			else {
				parts = new string[6];
				for (int i = 0; i < 6; i++)
				{
					parts[i] = chord[i].ToString();
				}
			}

			return parts;
		}

		private void CreateImage()
		{
			_bitmap = new Bitmap(_imageWidth, _imageHeight);
			_graphics = Graphics.FromImage(_bitmap);
			_graphics.SmoothingMode = SmoothingMode.HighQuality;
			_graphics.FillRectangle(BackgroundBrush, 0, 0, _bitmap.Width, _bitmap.Height);
			DrawChordBox();
			DrawChordPositions();
			DrawChordName();
			DrawFingers();
			DrawBars();
		}

		private void DrawChordBox()
		{
			Pen pen = new Pen(ForegroundBrush, _lineWidth);
			float totalFretWidth = _fretWidth + _lineWidth;

			for (int i = 0; i <= FRET_COUNT; i++)
			{
				float y = _ystart + i * totalFretWidth;
				_graphics.DrawLine(pen, _xstart, y, _xstart + _boxWidth - _lineWidth, y);
			}

			for (int i = 0; i < 6; i++)
			{
				float x = _xstart + (i * totalFretWidth);
				_graphics.DrawLine(pen, x, _ystart, x, _ystart + _boxHeight - pen.Width);
			}

			if (_baseFret == 1)
			{
				//Need to draw the nut
				float nutHeight = _fretWidth / 2f;
				_graphics.FillRectangle(ForegroundBrush, _xstart - _lineWidth / 2f, _ystart - nutHeight, _boxWidth, nutHeight);
			}
		}

		private void DrawChordPositions()
		{
			float yoffset = _ystart - _fretWidth;
			float xoffset = _lineWidth / 2f;
			float totalFretWidth = _fretWidth + _lineWidth;
			float xfirstString = _xstart + 0.5f * _lineWidth;
			for (int i = 0; i < _chordPositions.Length; i++)
			{
				int absolutePos = _chordPositions[i];
				int relativePos = absolutePos - _baseFret + 1;

				float xpos = _xstart - (0.5f * _fretWidth) + (0.5f * _lineWidth) + (i * totalFretWidth);
				if (relativePos > 0)
				{
					float ypos = relativePos * totalFretWidth + yoffset;
					_graphics.FillEllipse(ForegroundBrush, xpos, ypos, _dotWidth, _dotWidth);
				}
				else if (absolutePos == OPEN)
				{
					Pen pen = new Pen(ForegroundBrush, _lineWidth);
					float ypos = _ystart - _fretWidth;
					float markerXpos = xpos + ((_dotWidth - _markerWidth) / 2f);
					if (_baseFret == 1)
					{
						ypos -= _nutHeight;
					}
					_graphics.DrawEllipse(pen, markerXpos, ypos, _markerWidth, _markerWidth);
				}
				else if (absolutePos == MUTED)
				{
					Pen pen = new Pen(ForegroundBrush, _lineWidth * 1.5f);
					float ypos = _ystart - _fretWidth;
					float markerXpos = xpos + ((_dotWidth - _markerWidth) / 2f);
					if (_baseFret == 1)
					{
						ypos -= _nutHeight;
					}
					_graphics.DrawLine(pen, markerXpos, ypos, markerXpos + _markerWidth, ypos + _markerWidth);
					_graphics.DrawLine(pen, markerXpos, ypos + _markerWidth, markerXpos + _markerWidth, ypos);
				}
			}
		}

		private void DrawChordName()
		{
			Font nameFont = new Font(FONT_NAME, _nameFontSize, GraphicsUnit.Pixel);
			Font superFont = new Font(FONT_NAME, _superScriptFontSize, GraphicsUnit.Pixel);
			string[] parts = _name.Split('_');
			float xTextStart = _xstart;

			//Set max parts to 4 for protection
			int maxParts = parts.Length;
			if (maxParts > 4)
			{
				maxParts = 4;
			}

			//count total width of the chord in pixels
			float chordNameSize = 0;
			for (int i = 0; i < maxParts; i++)
			{
				if (i % 2 == 0)
				{  //odd parts are normal text
					SizeF stringSize2 = _graphics.MeasureString(parts[i], nameFont);
					chordNameSize += 0.75f * stringSize2.Width;
				}
				else {    //even parts are superscipts
					SizeF stringSize2 = _graphics.MeasureString(parts[i], superFont);
					chordNameSize += 0.8f * stringSize2.Width;
				}
			}

			//set the x position for the chord name
			if (chordNameSize < _boxWidth)
			{
				xTextStart = _xstart + ((_boxWidth - chordNameSize) / 2f);
			}
			else if ((xTextStart + chordNameSize) > _imageWidth)
			{   // if it goes outside the boundaries
				float nx = (xTextStart + chordNameSize) / 2f;
				if (nx < _imageWidth / 2)
				{                         // if it can fit inside the image
					xTextStart = (_imageWidth / 2) - nx;
				}
				else {
					xTextStart = 2f;
				}
			}

			// Paint the chord
			for (int i = 0; i < maxParts; i++)
			{
				if (i % 2 == 0)
				{
					SizeF stringSize2 = _graphics.MeasureString(parts[i], nameFont);
					_graphics.DrawString(parts[i], nameFont, ForegroundBrush, xTextStart, 0.2f * _superScriptFontSize);
					xTextStart += 0.75f * stringSize2.Width;
				}
				else {
					SizeF stringSize2 = _graphics.MeasureString(parts[i], superFont);
					_graphics.DrawString(parts[i], superFont, ForegroundBrush, xTextStart, 0);
					xTextStart += 0.8f * stringSize2.Width;
				}
			}

			if (_baseFret > 1)
			{
				Font fretFont = new Font(FONT_NAME, _fretFontSize, GraphicsUnit.Pixel);
				float offset = (fretFont.Size - _fretWidth) / 2f;
				_graphics.DrawString(_baseFret + "fr", fretFont, ForegroundBrush, _xstart + _boxWidth + 0.3f * _fretWidth, _ystart - offset);
			}
		}

		private void DrawFingers()
		{
			float xpos = _xstart + (0.5f * _lineWidth);
			float ypos = _ystart + _boxHeight;
			Font font = new Font(FONT_NAME, _fingerFontSize);
			foreach (char finger in _fingers)
			{
				if (finger != NO_FINGER)
				{
					SizeF charSize = _graphics.MeasureString(finger.ToString(), font);
					_graphics.DrawString(finger.ToString(), font, ForegroundBrush, xpos - (0.5f * charSize.Width), ypos);
				}
				xpos += (_fretWidth + _lineWidth);
			}
		}

		private void DrawBars()
		{
			var bars = new Dictionary<char, Bar>();
			for (int i = 0; i < 5; i++)
			{
				if (_chordPositions[i] != MUTED && _chordPositions[i] != OPEN && _fingers[i] != NO_FINGER && !bars.ContainsKey(_fingers[i]))
				{
					Bar bar = new Bar { Str = i, Pos = _chordPositions[i], Length = 0, Finger = _fingers[i] };
					for (int j = i + 1; j < 6; j++)
					{
						if (_fingers[j] == bar.Finger && _chordPositions[j] == _chordPositions[i])
						{
							bar.Length = j - i;
						}
					}
					if (bar.Length > 0)
					{
						bars.Add(bar.Finger, bar);
					}
				}
			}

			float totalFretWidth = _fretWidth + _lineWidth;
			float arcWidth = _dotWidth / 7;
			foreach (Bar bar in bars.Values)
			{
				float yTempOffset = 0.0f;

				if (bar.Pos == 1)
				{  // the bar must go a little higher in order to be shown correctly
					yTempOffset = -0.3f * totalFretWidth;
				}

				float xstart = _xstart + bar.Str * totalFretWidth - (_dotWidth / 2);
				float y = _ystart + (bar.Pos - _baseFret) * totalFretWidth - (0.6f * totalFretWidth) + yTempOffset;
				Pen pen = new Pen(ForegroundBrush, arcWidth);
				Pen pen2 = new Pen(ForegroundBrush, 1.3f * arcWidth);
				//_graphics.DrawLine(pen, xstart, y, xend, y);

				float barWidth = bar.Length * totalFretWidth + _dotWidth;

				_graphics.DrawArc(pen, xstart, y, barWidth, totalFretWidth, -1, -178);
				_graphics.DrawArc(pen2, xstart, y - arcWidth, barWidth, totalFretWidth + arcWidth, -4, -172);
				_graphics.DrawArc(pen2, xstart, y - 1.5f * arcWidth, barWidth, totalFretWidth + 3 * arcWidth, -20, -150);
			}
		}
	}
}
