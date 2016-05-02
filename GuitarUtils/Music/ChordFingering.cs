using GuitarUtils.Canvas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GuitarUtils.Music
{
	public class ChordFingering : IEnumerable<NoteLocation>, IEquatable<ChordFingering>
	{
		readonly List<NoteLocation> _list;

		public ChordFingering()
		{
			_list = new List<NoteLocation>();
		}

		public ChordFingering(IEnumerable<NoteLocation> collection)
			: this()
		{
			_list.AddRange(collection);
		}

		public bool Equals(ChordFingering other)
		{
			return this.SequenceEqual(other);
		}

		public IEnumerator<NoteLocation> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				var hash = (int)2166136261;
				// Suitable nullity checks etc, of course :)
				foreach (var item in _list)
					hash = (hash * 16777619) ^ item.GetHashCode();
				return hash;
			}
		}
	}
}
