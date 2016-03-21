using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GuitarUtils.Models
{
	[CollectionDataContract]
	class Tunings : List<Tuning>
	{
	}
}
