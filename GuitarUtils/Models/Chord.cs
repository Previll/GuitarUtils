using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GuitarUtils.Models
{
	[DataContract]
	class Chord
	{
		[DataMember(Name = "name", Order = 0)]
		public string Name { get; private set; }

		[DataMember(Name = "intervals", Order = 1)]
		public IList<int> Intervals { get; private set; }

		public override string ToString()
		{
			return $"{Name} {nameof(Chord)}";
		}
	}
}