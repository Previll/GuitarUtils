using System;

namespace GuitarUtils.Music
{
	static class PitchHelper
	{
		public static string GetName(Pitch pitch)
		{
			switch (pitch)
			{
				case Pitch.A:
					return "A";
				case Pitch.As:
					return "A#";
				case Pitch.B:
					return "B";
				case Pitch.C:
					return "C";
				case Pitch.Cs:
					return "C#";
				case Pitch.D:
					return "D";
				case Pitch.Ds:
					return "D#";
				case Pitch.E:
					return "E";
				case Pitch.F:
					return "F";
				case Pitch.Fs:
					return "F#";
				case Pitch.G:
					return "G";
				case Pitch.Gs:
					return "G#";
				default:
					throw new NotImplementedException();
			}
		}
	}
}