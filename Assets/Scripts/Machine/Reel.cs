using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Reel
{
	#region Construction

	public Reel(
			int								_CellCount,
			ReadOnlyCollection<CellType>	_CellTypes,
			Random							_Random
		)
	{
		var cells = new List<Cell>(_CellCount);
		var types = new List<CellType>(_CellCount);
		for (var i = 0; i < _CellCount; i++)
		{
			var k = _Random.Next(0, _CellTypes.Count);
			types.Add(_CellTypes[k]);
		}
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
