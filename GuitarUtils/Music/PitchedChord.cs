using System.Collections.Generic;
using System.Linq;

namespace GuitarUtils.Music
{
	public class PitchedChord : PitchedBase
	{
		public Pitch BasePitch { get; private set; }

		public PitchedChord(Pitch rootPitch, string name, IEnumerable<int> intervals)
			: base(rootPitch, name)
		{
			BasePitch = rootPitch;
			foreach (var interval in intervals.Select(interval => interval - 1))        // Uses eg maj: 1,5,8 to refer to 0,4,7
			{
				var pitch = rootPitch + interval;
				if ((int)pitch > (int)PitchExtensions.MaxPitch)
					pitch -= (int)PitchExtensions.MaxPitch;
				Pitches.Add(pitch);
			}
		}

		public PitchedChord(Pitch rootPitch, Pitch basePitch, string name, IEnumerable<int> intervals)
			: this(rootPitch, name, intervals)
		{
			BasePitch = basePitch;
			if (!Pitches.Contains(basePitch))
				Pitches.Add(basePitch);
		}
	}
}