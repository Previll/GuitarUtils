using System.Runtime.Serialization;

namespace GuitarUtils.Models
{
	[DataContract]
	class Tuning
	{
		[DataMember(Name = "name", Order = 0)]
		public string Name { get; private set; }

		[DataMember(Name = "strings", Order = 1)]
		public string[] Strings { get; private set; }

		public override string ToString()
		{
			return $"{Name} {nameof(Tuning)}";
		}
	}
}
