using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CombinationType : ScriptableObject
{
	#region Configuration

	public enum CombinationKind
	{
		Exact,
		Flash // like a Flash poker combination: all cells have to belong to one of the included types
	}

	public CombinationKind	Kind;
	public string			Name;
	public List<CellType>	CellTypes;

	#endregion

	#region Public methods

	// Returns Combination if this type matches the cells
	// Returns null if it doesn't
	public Combination TryMatch(IEnumerable<Cell> _Cells)
	{
		switch(Kind)
		{
			case(CombinationKind.Exact):
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

			case(CombinationKind.Flash):
				var cells = new List<Cell>(_Cells);
				foreach(var c in cells)
				{
					if (!CellTypes.Contains(c.Type))
					{
						return null;
					}
				}
				return new Combination(this, cells);
			default:
				throw new NotImplementedException();
		}
	}

	#endregion
}
