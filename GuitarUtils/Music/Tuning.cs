using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GuitarUtils.Music
{
	public class Tuning : IEnumerable<Note>, IReadOnlyCollection<Note>, IReadOnlyList<Note>
	{
		readonly List<Note> _notes;

		public string Name { get; private set; }

		public Tuning(string name, IEnumerable<string> strings)
		{
			Name = name;
			_notes = strings.Select(Note.Parse).ToList();
		}

		public int Count => _notes.Count;

		public Note this[int index] => _notes[index];

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
