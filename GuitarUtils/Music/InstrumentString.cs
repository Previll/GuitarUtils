using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GuitarUtils.Music
{
	public class InstrumentString : IReadOnlyList<Note>, IEnumerable<Note>, IReadOnlyCollection<Note>, IEquatable<InstrumentString>, IComparable<InstrumentString>
	{
		readonly List<Note> _notes;

		public Note RootNote { get; private set; }

		public int Index { get; private set; }

		public bool IsReadOnly { get; } = true;

		public InstrumentString(Note rootNote, int index, int fretCount)
		{
			RootNote = rootNote;
			Index = index;
			_notes = Enumerable.Range(0, fretCount + 1).Select(fretIndex => new Note(rootNote, fretIndex)).ToList();
		}

		public int Count => _notes.Count;

		public Note this[int index] => _notes[index];

		public int IndexOf(Note note)
		{
			return _notes.IndexOf(note);
		}

		public bool Equals(InstrumentString other)
		{
			return Index.Equals(other.Index);
		}

		public int CompareTo(InstrumentString other)
		{
			return Index.CompareTo(other.Index);
		}

		public override bool Equals(object obj)
		{
			if (obj is InstrumentString)
				return Equals(obj as InstrumentString);
			throw new InvalidOperationException();
		}

		public override int GetHashCode()
		{
			return Index.GetHashCode();
		}

		public override string ToString()
		{
			return $"{Index} - {RootNote}";
		}

		public IEnumerator<Note> GetEnumerator()
		{
			return _notes.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
