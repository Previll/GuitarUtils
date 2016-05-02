using System;
using System.Linq;

namespace GuitarUtils.Music
{
	// https://en.wikipedia.org/wiki/Scientific_pitch_notation
	public enum Pitch
	{
		C = 1,
		Cs = 2,
		D = 3,
		Ds = 4,
		E = 5,
		F = 6,
		Fs = 7,
		G = 8,
		Gs = 9,
		A = 10,
		As = 11,
		B = 12
	}

	static class PitchExtensions
	{
		public static Pitch MinPitch { get; } = Enum.GetValues(typeof(Pitch)).Cast<Pitch>().Min();

		public static Pitch MaxPitch { get; } = Enum.GetValues(typeof(Pitch)).Cast<Pitch>().Max();

		public static string GetLongName(this Pitch pitch)
		{
			switch (pitch)
			{
				case Pitch.A:
					return "A";
				case Pitch.As:
					return "A♯/B♭";
				case Pitch.B:
					return "B";
				case Pitch.C:
					return "C";
				case Pitch.Cs:
					return "C♯/D♭";
				case Pitch.D:
					return "D";
				case Pitch.Ds:
					return "D♯/E♭";
				case Pitch.E:
					return "E";
				case Pitch.F:
					return "F";
				case Pitch.Fs:
					return "F♯/G♭";
				case Pitch.G:
					return "G";
				case Pitch.Gs:
					return "G♯";
				default:
					throw new Exception("Un-handled pitch, " + pitch);
			}
		}

		public static string GetShortName(this Pitch pitch)
		{
			switch (pitch)
			{
				case Pitch.A:
					return "A";
				case Pitch.As:
					return "A♯";
				case Pitch.B:
					return "B";
				case Pitch.C:
					return "C";
				case Pitch.Cs:
					return "C♯";
				case Pitch.D:
					return "D";
				case Pitch.Ds:
					return "D♯";
				case Pitch.E:
					return "E";
				case Pitch.F:
					return "F";
				case Pitch.Fs:
					return "F♯";
				case Pitch.G:
					return "G";
				case Pitch.Gs:
					return "G♯";
				default:
					throw new Exception("Un-handled pitch");
			}
		}

		public static Pitch Parse(string text)
		{
			switch (text)
			{
				case "A":
					return Pitch.A;
				case "A#":
					return Pitch.As;
				case "B":
					return Pitch.B;
				case "C":
					return Pitch.C;
				case "C#":
					return Pitch.Cs;
				case "D":
					return Pitch.D;
				case "D#":
					return Pitch.Ds;
				case "E" :
					return Pitch.E;
				case "F":
					return Pitch.F;
				case "F#":
					return Pitch.Fs;
				case "G":
					return Pitch.G;
				case "G#":
					return Pitch.Gs;
				default:
					throw new Exception("Un-handled pitch text, " + text);
			}
		}
	}
}