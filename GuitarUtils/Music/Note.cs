using System;
using System.Collections.Generic;

namespace GuitarUtils.Music
{
	public class Note : IEquatable<Note>, IComparable<Note>
	{
		public Pitch Pitch { get; private set; }

		public int Octave { get; private set; }

		/* Constructors */

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

		public Note(Note rootNote, int intervalOffset)
			:this(rootNote)
		{
			for (int i = 0; i < Math.Abs(intervalOffset); i++)
			{
				if (intervalOffset > 0)
					Increment(this);
				else
					Decrement(this);
			}
		}

		/* Public Methods */

		public bool Equals(Note other)
		{
			if (other == null)
				return false;

			return Pitch == other.Pitch && Octave == other.Octave;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (obj is Note)
				return Equals(obj as Note);

			return false;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			return $"{Pitch.GetShortName()}{Octave.ToString()}";
		}

		public int CompareTo(Note other)
		{
			if (other  == null)
				throw new ArgumentNullException(nameof(other));

			var noteValue = (Octave * 12) + (int)Pitch;
			var otherNoteValue = (other.Octave * 12) + (int)other.Pitch;
			var compare = noteValue.CompareTo(otherNoteValue);
			return compare;
		}

		public static bool operator ==(Note note, Note other)
		{
			if ((object)note == null && (object)other == null)
				return true;
			if ((object)note == null || (object)other == null)
				return false;

			return note.Equals(other);
		}

		public static bool operator !=(Note note, Note other)
		{
			return !(note == other);
		}

		//public static Note operator ++(Note note)
		//{
		//	Increment(note);
		//	return note;
		//}

		//public static Note operator --(Note note)
		//{
		//	Decrement(note);
		//	return note;
		//}

		//public static Note operator +(Note note, int integer)
		//{
		//	for (int i = 0; i < Math.Abs(integer); i++)
		//	{
		//		if (integer > 0)
		//			Increment(note);
		//		else
		//			Decrement(note);
		//	}
		//	return note;
		//}

		//public static Note operator -(Note note, int integer)
		//{
		//	for (int i = 0; i < Math.Abs(integer); i++)
		//	{
		//		if (integer > 0)
		//			Decrement(note);
		//		else
		//			Increment(note);
		//	}
		//	return note;
		//}

		public static Note Parse(string text)
		{
			if (text.Length != 2 && text.Length != 3)
				throw new Exception("Note text must be 2 or 3 chars.");
			if (!char.IsLetter(text[0]))
				throw new Exception("Note text first char must be letter.");
			if (text.Length == 3 && !char.IsPunctuation(text[1]))
				throw new Exception("Note text second char must be punctuation(#).");
			if (!char.IsDigit(text[text.Length - 1]))
				throw new Exception("Note text last char must be digit.");

			var pitchString = text.Length == 2 ? text[0].ToString() : $"{text[0]}{text[1]}";
			var pitch = PitchExtensions.Parse(pitchString);

			var octaveString = text[text.Length - 1].ToString();
			var octave = int.Parse(octaveString);

			return new Note(pitch, octave);
		}

		/* Private Methods */

		static void Increment(Note note)
		{
			if (note.Pitch == PitchExtensions.MaxPitch)
			{
				note.Pitch = PitchExtensions.MinPitch;
				note.Octave++;
			}
			else
			{
				note.Pitch++;
			}
		}

		static void Decrement(Note note)
		{
			if (note.Pitch == PitchExtensions.MinPitch)
			{
				note.Pitch = PitchExtensions.MaxPitch;
				note.Octave--;
			}
			else
			{
				note.Pitch--;
			}
		}
	}

	public class NoteComparer : IComparer<Note>
	{
		public int Compare(Note x, Note y)
		{
			if (x == null)
				throw new ArgumentNullException(nameof(x));
			if (y == null)
				throw new ArgumentNullException(nameof(y));

			return x.CompareTo(y);
		}
	}
}