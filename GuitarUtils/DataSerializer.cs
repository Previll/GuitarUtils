using GuitarUtils.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace GuitarUtils
{
	static class DataSerializer
	{
		public static Data ReadFromJson(string path)
		{
			var dataContractSerializer = new DataContractJsonSerializer(typeof(Data));
			using (var fileStream = File.OpenRead(path))
			{
				using (var streamReader = new StreamReader(fileStream))
				{
					var text = streamReader.ReadToEnd();
					var bytes = streamReader.CurrentEncoding.GetBytes(text);
					using (var jsonReader = JsonReaderWriterFactory.CreateJsonReader(bytes, new XmlDictionaryReaderQuotas()))
					{
						var data = dataContractSerializer.ReadObject(jsonReader) as Data;
						return data;
					}
				}
			}
		}

		public static void WriteToJson(Data data, string path, Encoding encoding)
		{
			var dataContractSerializer = new DataContractJsonSerializer(typeof(Data));
			using (var stream = new MemoryStream())
			{
				using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, encoding, false))
				{
					dataContractSerializer.WriteObject(writer, data);
					var contents = encoding.GetString(stream.ToArray());
					File.WriteAllText(path, contents, encoding);
				}
			}
		}
	}
}
