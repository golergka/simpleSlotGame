using System;
using System.Collections.Generic;

public class CombinationType
{
	public Dictionary<CellType,int> CellTypes;
	public float Payout;

	// Returns Combination if this type matches the cells
	// Returns null if it doesn't
	public Combination TryMatch(IEnumerable<Cell> _Cells)
	{
		var typesLeft = new Dictionary<CellType,int>(CellTypes);
		var combinationCells = new List<Cell>();
		foreach(var c in _Cells)
		{
			if (typesLeft.ContainsKey(c.Type))
			{
				typesLeft[c.Type] --;
				if (typesLeft[c.Type] <= 0)
				{
					typesLeft.Remove(c.Type);
				}
				combinationCells.Add(c);
			}
		}
		return (typesLeft.Keys.Count == 0 ?
			new Combination(this, combinationCells) :
			null);
	}
}
