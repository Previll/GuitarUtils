using System;

namespace GuitarUtils.Music
{
	public class NoteLocation : IEquatable<NoteLocation>
	{
		public Note Note { get; private set; }

		public int StringIndex { get; private set; }

		public int FretIndex { get; private set; }

		public bool IsMute { get; private set; }

		public NoteLocation(Note note, int stringIndex, int fretIndex)
		{
			Note = note;
			StringIndex = stringIndex;
			FretIndex = fretIndex;
			IsMute = false;
		}

		public NoteLocation(int stringIndex)
		{
			Note = null;
			StringIndex = stringIndex;
			FretIndex = 0;
			IsMute = true;
		}

		public bool Equals(NoteLocation other)
		{
			return StringIndex.Equals(other.StringIndex) && FretIndex.Equals(other.FretIndex);
		}

		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				int hashCode = 17;
				// Suitable nullity checks etc, of course :)
				hashCode = hashCode * 23 + StringIndex.GetHashCode();
				hashCode = hashCode * 23 + FretIndex.GetHashCode();
				return hashCode;
			}
		}

		public override string ToString()
		{
			return $"{StringIndex}:{FretIndex}";
		}
	}
}
