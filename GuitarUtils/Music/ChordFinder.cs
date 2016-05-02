using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarUtils.Music
{
	public class ChordFinderOptions
	{
		public Instrument Instrument { get; set; }
		public bool AllowRootlessChords { get; set; }
		public bool AllowMutedStrings { get; set; }
		public bool AllowOpenStrings { get; set; }
		public int MinFret { get; set; }
		public int MaxFret { get; set; }
	}

	public class ChordFinder
	{
		public IEnumerable<ChordFingering> FindChordFingerings(PitchedChord pitchedChord, ChordFinderOptions chordFinderOptions)
		{
			var results = new List<ChordFingering>();

			FindAllChordFingerings(results, null, pitchedChord, 0, chordFinderOptions);

			return results;
		}

		class NoteNode
		{
			public int StringIndex { get; private set; }
			public int FretIndex { get; private set; }
			public Note Note { get; private set; }
			public NoteNode Parent { get; private set; }

			public NoteNode(int stringIndex, int fretIndex, Note note, NoteNode parent)
			{
				StringIndex = stringIndex;
				FretIndex = fretIndex;
				Note = note;
				Parent = parent;
			}
		}

		static void FindAllChordFingerings(IList<ChordFingering> results, NoteNode noteNode, PitchedChord pitchedChord, int stringIndex, ChordFinderOptions chordFinderOptions)
		{
			if (stringIndex == chordFinderOptions.Instrument.StringCount) // Build a chord result
			{
				var noteLocations = new NoteLocation[chordFinderOptions.Instrument.StringCount];

				stringIndex--;

				var hasNotes = new bool[pitchedChord.Count];

				// Walk back up the tree to set the marks on the result and flag each target note
				while (noteNode != null)
				{
					noteLocations[stringIndex] = noteNode.Note == null  // Could be mute
						? new NoteLocation(noteNode.StringIndex)
						: new NoteLocation(noteNode.Note, noteNode.StringIndex, noteNode.FretIndex);

					if (noteNode.Note != null)
					{
						for (int i = 0; i < pitchedChord.Count; i++)
						{
							if (noteNode.Note.Pitch == pitchedChord[i])
							{
								hasNotes[i] = true;
							}
						}
					}

					noteNode = noteNode.Parent;
					stringIndex--;
				}

				// Add result if it had all the target notes
				bool valid = true;
				for (int i = 0; i < hasNotes.Length; i++)
				{
					// Validate:
						// 1. All notes when !AllowRootlessChords
					if (!chordFinderOptions.AllowRootlessChords ||
					   // 2. Non-root notes only when AllowRootlessChords
					   (chordFinderOptions.AllowRootlessChords && pitchedChord[i] != pitchedChord.RootPitch))
					{
						valid &= hasNotes[i];
					}
				}

				if (!valid)
					return;
				
				var baseNote = noteLocations.Where(noteLocation => noteLocation.Note != null).MinBy(noteLocation => noteLocation.Note, new NoteComparer()).Note;
				valid &= baseNote.Pitch == pitchedChord.BasePitch;

				if (!valid)
					return;
				
				results.Add(new ChordFingering(noteLocations));
			}
			else // Keep building the tree
			{
				// Look at the muted string
				if (chordFinderOptions.AllowMutedStrings)
				{
					//var note = chordFinderOptions.Instrument.Strings[stringIndex].RootNote;
					var muted = new NoteNode(stringIndex, -1, null, noteNode);
					FindAllChordFingerings(results, muted, pitchedChord, stringIndex + 1, chordFinderOptions);
				}

				var fretIndexes = Enumerable.Range(Math.Max(chordFinderOptions.MinFret, 1), Math.Min(chordFinderOptions.MaxFret, chordFinderOptions.Instrument.FretCount)).ToList();
				if (chordFinderOptions.AllowOpenStrings)
					fretIndexes.Add(0);   // Look at all the notes on the string
				
				foreach(var fretIndex in fretIndexes)
				{
					var note = chordFinderOptions.Instrument.Strings[stringIndex][fretIndex];

					// See if the note is a target note
					for (int i = 0; i < pitchedChord.Count; i++)
					{
						// If it's a target note add it and search on the next string
						if (note.Pitch == pitchedChord[i])
						{
							var child = new NoteNode(stringIndex, fretIndex, note, noteNode);
							FindAllChordFingerings(results, child, pitchedChord, stringIndex + 1, chordFinderOptions);
							break;
						}
					}
				}
			}
		}

		//public IEnumerable<ChordFingering> FindChordFingeringsOld(Instrument instrument, PitchedChord pitchedChord, int fretStartLimit, int fretEndLimit)
		//{
		//	var pitchLocations = instrument.GetNoteLocations(pitchedChord, fretStartLimit, fretEndLimit);
		//	var permutations = GetPermutations(pitchLocations);
		//	var chordFingerings = new List<ChordFingering>();

		//	foreach (var permutation in permutations)
		//	{
		//		var foundRoot = false;
		//		var fingeringLocations = new List<NoteLocation>();

		//		foreach (var pitchLocation in permutation)
		//		{
		//			foundRoot |= pitchLocation.Note.Pitch == pitchedChord.Root;

		//			if (foundRoot)
		//				fingeringLocations.Add(pitchLocation);
		//		}

		//		if (foundRoot && pitchedChord.All(pitch => fingeringLocations.Any(p => p.Note.Pitch == pitch)))
		//			chordFingerings.Add(new ChordFingering(fingeringLocations));
		//	}

		//	return chordFingerings.Distinct();
		//}

		//IEnumerable<ChordFingering> GetPermutations(IEnumerable<NoteLocation> pitchLocations)
		//{
		//	var stringCount = pitchLocations.GroupBy(pitchLocation => pitchLocation.StringIndex).Count();
		//	var permutations = new HashSet<ChordFingering>();

		//	foreach (var permutation in pitchLocations.Permutations())
		//	{
		//		var lookup = new Dictionary<int, NoteLocation>();
		//		foreach (var pitchLocation in permutation)
		//		{
		//			if (!lookup.ContainsKey(pitchLocation.StringIndex))
		//				lookup.Add(pitchLocation.StringIndex, pitchLocation);
		//			if (lookup.Count == stringCount)
		//				break;
		//		}
		//		var chordFingeringLocations = lookup.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value);
		//		var chordFingering = new ChordFingering(chordFingeringLocations);

		//		if (!permutations.Contains(chordFingering))
		//			permutations.Add(chordFingering);
		//	}
		//	return permutations;
		//}
	}
}
