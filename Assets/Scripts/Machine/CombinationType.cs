using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CombinationType
{
	public List<CellType> CellTypes;

	// Returns Combination if this type matches the cells
	// Returns null if it doesn't
	public Combination TryMatch(IEnumerable<Cell> _Cells)
	{
		var typesLeft = new List<CellType>(CellTypes);
		var combinationCells = new List<Cell>();
		foreach(var c in _Cells)
		{
			if (typesLeft.Contains(c.Type))
			{
				typesLeft.Remove(c.Type);
				combinationCells.Add(c);
			}
		}
		return (typesLeft.Count == 0 ?
			new Combination(this, combinationCells) :
			null);
	}
}
