using System.Drawing;

namespace GuitarUtils.Drawing
{
	static class PointFHelper
	{
		public static void Offset(ref PointF pointF, float dx, float dy)
		{
			pointF.X += dx;
			pointF.Y += dy;
		}

		public static void Offset(ref PointF pointF, OffsetF offset)
		{
			Offset(ref pointF, offset.X, offset.Y);
		}
	}
}
