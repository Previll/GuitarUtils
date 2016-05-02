using System.Collections.Generic;
using System.Linq;

namespace GuitarUtils.Music
{
	public class Instrument
	{
		public IList<InstrumentString> Strings { get; private set; }

		public Tuning Tuning { get; private set; }

		public int FretCount { get; private set; }

		public int StringCount { get; private set; }

		public Instrument(Tuning tuning, int fretCount)
		{
			Tuning = tuning;
			FretCount = fretCount;
			StringCount = tuning.Count;
			Strings = GetInstrumentStrings(tuning, fretCount);
		}
		
		public IEnumerable<NoteLocation> GetNoteLocations(PitchedBase pitches, int fretStartLimit, int fretEndLimit)
		{
			var pitchLocationsByPitchQuery = from instrumentString in Strings
											 from note in instrumentString
											 where pitches.Contains(note.Pitch)
											 let fretIndex = instrumentString.IndexOf(note)
											 where fretIndex >= fretStartLimit && fretIndex <= fretEndLimit
											 select new NoteLocation(note, instrumentString.Index, fretIndex);

			return pitchLocationsByPitchQuery;
		}

		public IEnumerable<NoteLocation> GetScaleRunNoteLocations(PitchedBase pitches, int notesPerString, int fretStartLimit, int fretEndLimit)
		{
			var noteLocations = GetNoteLocations(pitches, fretStartLimit, fretEndLimit);
			var scaleRunPitchLocations = Enumerable.Range(0, StringCount).ToDictionary(stringIndex => stringIndex, stringIndex => new List<NoteLocation>());
			foreach (var noteLocation in noteLocations)
			{
				var currentStringNoteLocations = scaleRunPitchLocations[noteLocation.StringIndex];

				if (currentStringNoteLocations.Count == notesPerString)
					continue;

				var otherStringNoteLocations = scaleRunPitchLocations.SelectMany(kvp => kvp.Value);
				if (otherStringNoteLocations.Any(previousStringNoteLocation => previousStringNoteLocation.Note == noteLocation.Note))
					continue;

				currentStringNoteLocations.Add(noteLocation);
			}
			noteLocations = scaleRunPitchLocations.SelectMany(kvp => kvp.Value);
			return noteLocations;
		}

		static IList<InstrumentString> GetInstrumentStrings(Tuning tuning, int fretCount)
		{
			var instrumentStringQuery = from stringIndex in Enumerable.Range(0, tuning.Count)
										let rootNote = tuning[stringIndex]
										select new InstrumentString(rootNote, stringIndex, fretCount);
			return instrumentStringQuery.ToList();
		}
	}
}
