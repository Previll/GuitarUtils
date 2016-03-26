using System.Drawing;

namespace GuitarUtils.Drawing
{
	class LineF
	{
		public PointF StartPoint { get; private set; }
		public PointF EndPoint { get; private set; }

		public LineF(PointF startPoint, PointF endPoint)
		{
			StartPoint = startPoint;
			EndPoint = endPoint;
		}

		public LineF(float startPointX, float startPointY, float endPointX, float endPointY)
		{
			StartPoint = new PointF(startPointX, startPointY);
			EndPoint = new PointF(endPointX, endPointY);
		}

		public void Offset(float dx, float dy)
		{
			var startPoint = StartPoint;
			PointFHelper.Offset(ref startPoint, dx, dy);
			StartPoint = startPoint;

			var endPoint = EndPoint;
			PointFHelper.Offset(ref endPoint, dx, dy);
			EndPoint = endPoint;
		}
	}
}