using System.Runtime.Serialization;

namespace GuitarUtils.Models
{
	[DataContract]
	class DataModel
	{
		[DataMember(Name = "scales", Order = 0)]
		public Scales Scales { get; private set; }

		[DataMember(Name = "chords", Order = 1)]
		public Chords Chords { get; private set; }

		[DataMember(Name = "tunings", Order = 1)]
		public Tunings Tunings { get; private set; }
	}
}