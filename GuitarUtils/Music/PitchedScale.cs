using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarUtils.Music
{
	class PitchedScale : PitchedBase
	{
		public PitchedScale(Pitch root, string name, IEnumerable<int> intervals)
			: base(root, name)
		{
			Pitches.Add(root);
			var intervalTotal = 0;
			foreach (var interval in intervals)
			{
				intervalTotal += interval;
				var pitch = root + intervalTotal;
				if ((int)pitch > (int)PitchExtensions.MaxPitch)
					pitch -= (int)PitchExtensions.MaxPitch;
				Pitches.Add(pitch);
			}
			if (this.First() != this.Last())
				throw new Exception("Scale does not resolve.");
		}
	}
}