using System;
using System.Drawing;

namespace GuitarUtils.Drawing
{
	struct OffsetF
	{
		public float X { get; set; }
		public float Y { get; set; }

		public OffsetF(float x, float y)
		{
			X = x;
			Y = y;
		}
	}
}