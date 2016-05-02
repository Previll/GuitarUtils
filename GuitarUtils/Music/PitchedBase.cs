using System.Collections;
using System.Collections.Generic;

namespace GuitarUtils.Music
{
	public abstract class PitchedBase : IEnumerable<Pitch>, IReadOnlyList<Pitch>, IReadOnlyCollection<Pitch>
	{
		protected IList<Pitch> Pitches;

		public string Name { get; private set; }

		public Pitch RootPitch { get; private set; }

		public int Count => Pitches.Count;

		public Pitch this[int index] => Pitches[index];

		protected PitchedBase(Pitch root, string name)
		{
			Pitches = new List<Pitch>();
			RootPitch = root;
			Name = $"{name} in {root.GetLongName()}";
		}

		public IEnumerator<Pitch> GetEnumerator()
		{
			return Pitches.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
