using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Reel
{
	#region Construction

	public Reel(
			int								_ReelNumber,
			int								_CellCount,
			ReadOnlyCollection<CellType>	_CellTypes,
			Random							_Random
		)
	{
		ReelNumber = _ReelNumber;
		var cells = new List<Cell>(_CellCount);
		for (var i = 0; i < _CellCount; i++)
		{
			var k = _Random.Next(0, _CellTypes.Count);
			cells.Add(new Cell(_ReelNumber, i, _CellTypes[k]));
		}
		Cells = cells.AsReadOnly();
	}

	#endregion

	#region Current state

	readonly int	ReelNumber;
	readonly public ReadOnlyCollection<Cell> Cells;

	#endregion

	#region Default methods

	public override string ToString()
	{
		return ReelNumber.ToString();
	}

	#endregion
}
