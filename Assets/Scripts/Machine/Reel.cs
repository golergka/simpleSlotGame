using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Reel
{
	#region Construction

	public Reel(
			int						_CellCount,
			IEnumerable<CellType>	_CellTypes
		)
	{
		var cells = new List<Cell>(_CellCount);
		var types = _CellTypes.TakeRandom(_CellCount);
		foreach(var t in types)
		{
			cells.Add(new Cell(t));
		}
		Cells = cells.AsReadOnly();
	}

	#endregion

	#region Current state

	readonly public ReadOnlyCollection<Cell> Cells;

	#endregion
}
