using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// Represents a single spin result
public class Spin
{
	#region Construction

	public Spin(
			Machine				_Machine, 
			IEnumerable<Line>	_ActiveLines,
			Random				_Random
		)
	{
		// Generating reels
		{
			var reels = new List<Reel>(_Machine.ReelCount);
			for(int i = 0; i < _Machine.ReelCount; i++)
			{
				reels.Add(new Reel(
							i,
							_Machine.CellCount, 
							_Machine.CellTypes.AsReadOnly(),
							_Random
					));
			}
			Reels = reels.AsReadOnly();
		}

		// Matching combinations
		var combinationsWon = new List<Combination>();
		foreach(var line in _ActiveLines)
		{
			var cellsOnLine = CellsOnLine(line);
			foreach(var combinationType in _Machine.CombinationTypes)
			{
				var combination = combinationType.TryMatch(cellsOnLine);
				if (combination != null)
				{
					combinationsWon.Add(combination);
				}
			}
		}
		CombinationsWon = combinationsWon.AsReadOnly();
	}

	#endregion

	#region Public fields

	readonly public ReadOnlyCollection<Reel>		Reels;
	readonly public ReadOnlyCollection<Combination>	CombinationsWon;

	#endregion

	#region Helper methods

	IEnumerable<Cell> CellsOnLine(Line _Line)
	{
		if (_Line.Cells.Length != Reels.Count)
		{
			throw new ArgumentException("Expected line of length " + Reels.Count + " but got length " + _Line.Cells.Length);
		}
		var result = new List<Cell>();
		for(int i = 0; i < _Line.Cells.Length; i++)
		{
			var cellIndex = _Line.Cells[i];
			var reel = Reels[i];
			result.Add(reel.Cells[cellIndex]);
		}
		return result;
	}

	#endregion

}
