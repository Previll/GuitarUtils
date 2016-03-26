using System;

namespace GuitarUtils.Music
{
	class Note : IEquatable<Note>
	{
		public Pitch Pitch { get; private set; }
		public int Octave { get; private set; }

		public Note(Pitch pitch, int octave)
		{
			Pitch = pitch;
			Octave = octave;
		}

		public Note(Note note)
		{
			Pitch = note.Pitch;
			Octave = note.Octave;
		}

		public bool Equals(Note other)
		{
			return Pitch == other.Pitch && Octave == other.Octave;
		}

		public override bool Equals(object obj)
		{
			if (obj is Note)
				return Equals((Note)obj);
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			return $"{PitchHelper.GetName(Pitch)}{Octave.ToString()}";
		}

		public static Note operator ++(Note note)
		{
			if (note.Pitch == Pitch.Gs)
			{
				note.Pitch = Pitch.A;
				note.Octave++;
			}
			else
			{
				note.Pitch++;
			}
			return note;
		}

		public static Note operator --(Note note)
		{
			if (note.Pitch == Pitch.A)
			{
				note.Pitch = Pitch.Gs;
				note.Octave--;
			}
			else
			{
				note.Pitch--;
			}
			return note;
		}

		public static Note operator +(Note note, int integer)
		{
			for (int i = 0; i < Math.Abs(integer); i++)
			{
				if (integer > 0)
					note++;
				else
					note--;
			}
			return note;
		}

		public static Note operator -(Note note, int integer)
		{
			for (int i = 0; i < Math.Abs(integer); i++)
			{
				if (integer > 0)
					note--;
				else
					note++;
			}
			return note;
		}
	}
}