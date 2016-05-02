using Xunit;

namespace GuitarUtils.Music.Tests
{
	public class ChordFinderTests
	{
		[Fact]
		public void FindChordFingeringsTest()
		{
			var tuning = new Tuning("Test", new string[] { "E2", "A2", "D3", "G3", "B3", "E4" });
			var pitchedChord = new PitchedChord(Pitch.C, "Test", new int[] { 1, 5, 8 });
			var instrument = new Instrument(tuning, 24);

			var chordFinderOptions = new ChordFinderOptions { Instrument = instrument, MinFret = 0, MaxFret = 5, AllowRootlessChords = false, AllowMutedStrings = true, AllowOpenStrings = true };
			var chordFinder = new ChordFinder();
			var chordFingerings = chordFinder.FindChordFingerings(pitchedChord, chordFinderOptions);
		}
	}
}