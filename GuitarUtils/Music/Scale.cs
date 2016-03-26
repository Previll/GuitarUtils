using System.Collections.Generic;

namespace GuitarUtils.Music
{
	class Scale : List<Pitch>
	{
		public string Name { get; private set; }

		public Pitch Pitch { get; private set; }

		public Scale(string name, Pitch root, int[] intervals)
		{
			Name = name;
			Pitch = Pitch;

			Add(root);
			var intervalTotal = 0;
			foreach (var interval in intervals)
			{
				intervalTotal += interval;
				if (intervalTotal >= (int)Pitch.Gs)
					intervalTotal -= (int)Pitch.Gs;
				var pitch = root + intervalTotal;
				Add(pitch);
			}
		}
	}
}